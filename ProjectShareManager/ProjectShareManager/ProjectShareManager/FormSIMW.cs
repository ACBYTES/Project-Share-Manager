// MIT License

// Copyright (c) 2020 Alireza Shahbazi (ACBYTES) (alirezashahbazi641@yahoo.com)

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectShareManager
{
    public partial class FormSIMW : Form
    {
        public FormSIMW()
        {
            InitializeComponent();
            PUBLIC_ACCESSIBLE_ACCB = ACCB;
            CheckForIllegalCrossThreadCalls = false;
            processInfo.bgw = cbgw;
        }

        public ACBytesControlBox PUBLIC_ACCESSIBLE_ACCB;

        private FileSystemWatcher watcher;

        List<FileControl> fileControls = new List<FileControl>();
        Queue<Task> fcQ = new Queue<Task>();

        public Thread CancelableThread;

        private void btnApply_Click(object sender, EventArgs e)
        {
            txtPath.Enabled = false;
            btnApply.Enabled = false;
            txtVersion.Enabled = true;
            btnCC.Enabled = true;
            label1.Enabled = true;
            watcher = new FileSystemWatcher(txtPath.Text) { IncludeSubdirectories = true, EnableRaisingEvents = true };
            watcher.Created += Watcher_Created;
            watcher.Deleted += Watcher_Deleted;
            watcher.Renamed += Watcher_Renamed;
            watcher.Changed += Watcher_Changed;
        }

        private void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Task.Factory.StartNew(() => UpdateData(new FileControl(e.FullPath, FileControl.FileType.Changed)));
            //fileControls.Add(new FileControl(e.FullPath, FileControl.FileType.Changed));
        }

        private void Watcher_Renamed(object sender, RenamedEventArgs e)
        {
            Task.Factory.StartNew(() => UpdateData(new FileControl(e.FullPath, FileControl.FileType.Renamed)));
            //fileControls.Add(new FileControl(e.FullPath, FileControl.FileType.Renamed));
        }

        private void Watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            Task.Factory.StartNew(() => UpdateData(new FileControl(e.FullPath, FileControl.FileType.Deleted)));
            //fileControls.Add(new FileControl(e.FullPath, FileControl.FileType.Deleted));
        }

        private void Watcher_Created(object sender, FileSystemEventArgs e)
        {
            Task.Factory.StartNew(() => UpdateData(new FileControl(e.FullPath, FileControl.FileType.Created)));
            //fileControls.Add(new FileControl(e.FullPath, FileControl.FileType.Created));
        }

        public class FileControl
        {
            public FileType _type;
            public string _file;
            public FileControl(string File, FileType Type)
            {
                _type = Type;
                _file = File;
            }

            public FileControl() { }

            public enum FileType
            {
                Created, Deleted, Renamed, Changed
            };
        }

        private void guiBW_DoWork(object sender, DoWorkEventArgs e)
        {
            dgv.Rows.Clear();

            List<DataGridViewRow> d = new List<DataGridViewRow>();

            Parallel.ForEach(fileControls, (item) =>
            {
                DataGridViewRow row = dgv.RowTemplate.Clone() as DataGridViewRow;
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = item._file });
                row.Cells.Add(new DataGridViewTextBoxCell() { Value = item._type.ToString() });
                //dgv.Rows.Add(row);

                d.Add(row);
            });

            foreach (var item in d)
            {
                dgv.Rows.Add(item);
            }

            GC.Collect();
        }

        void UpdateData(FileControl FileControl)
        {
            fileControls.Add(FileControl);
        }

        private void dgv_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                fileControls = fileControls.GroupBy(p => p._file).Select(g => g.First()).Distinct().ToList();
                dgvCMS.Items[0].Text = $"Detected: {fileControls.Count}";
                dgvCMS.Items[1].Enabled = !guiBW.IsBusy;
                dgvCMS.Show(Cursor.Position);
            }
        }

        private void updateGVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            guiBW.RunWorkerAsync();
        }

        private void bgW_DoWork(object sender, DoWorkEventArgs e)
        {
            fileControls = fileControls.GroupBy(p => p._file).Select(g => g.First()).Distinct().ToList();
            CancelableThread = Thread.CurrentThread;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Select the directory that you want this version to get exported to.";
            Action inv = new Action(() => fbd.ShowDialog());
            this.Invoke(inv);

            List<FileControl> dirs = new List<FileControl>();
            List<FileControl> files = new List<FileControl>();

            Parallel.ForEach(fileControls, (item) =>
            {
                if (File.Exists(item._file))
                    files.Add(item);
                else
                    dirs.Add(item);
            });

            Action cpis = new Action(() => processInfo.ChangeLT('D', dirs.Count.ToString()));
            Invoke(cpis);
            cpis = new Action(() => processInfo.ChangeLT('F', files.Count.ToString()));
            Invoke(cpis);

            if (!string.IsNullOrEmpty(fbd.SelectedPath))
            {
                if (dirs.Count != 0 && files.Count != 0)
                {
                    //Copy files that are new and changed with ther folders sequentially containing them! Write Deleted Paths as well with extra info over renaming
                    Core.CopyToNewVersion(txtPath.Text, fbd.SelectedPath, txtVersion.Text, dirs, files);
                }
            }

            else
                MessageBox.Show("You should select a path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            GC.Collect();
        }
    }
}
