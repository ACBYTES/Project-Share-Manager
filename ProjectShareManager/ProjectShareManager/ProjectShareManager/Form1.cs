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

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectShareManager
{
    public partial class Form1 : Form
    {
        public static int FormWidth { get; } = 636;
        public static string FormText { get; } = "Project Share Manager by ACBytes (Alireza Shahbazi)";

        private protected bool F = false;

        List<List<string>> result;
        public Thread CancelableThread;
        public Thread CancelableThread1;
        public Thread CancelableThread2;

        public ProcessInfo processInfoInst;

        public CustomLogForm clf;
        private bool clfState = false;
        public Form1()
        {
            InitializeComponent();
            processInfo.bgw = bgW;
            processInfo.bgw1 = bgW1;
            processInfo.bgw2 = bgW2;
            processInfoInst = processInfo;
            clf = new CustomLogForm();
            PUBLIC_ACCESSIBLE_ACCB = ACCB;
        }

        public List<string> PUBLIC_USER_CHOICE_FILE_SELECTED;
        public ACBytesControlBox PUBLIC_ACCESSIBLE_ACCB;

        private void btnLoadProjectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select the folder that contains the main project.";
            fbd.ShowNewFolderButton = false;
            fbd.ShowDialog();
            if (!string.IsNullOrEmpty(fbd.SelectedPath))
            {
                txtProjectPath.Text = (Directory.Exists(fbd.SelectedPath)) ? fbd.SelectedPath : string.Empty;
            }
            fbd.Dispose();
        }

        private void btnLoadRefPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Select the reference folder.";
            fbd.ShowNewFolderButton = true;
            fbd.ShowDialog();
            if (!string.IsNullOrEmpty(fbd.SelectedPath))
            {
                txtRefProject.Text = (Directory.Exists(fbd.SelectedPath)) ? fbd.SelectedPath : string.Empty;
                if (!Core.CheckReferencePath(txtRefProject.Text))
                {
                    DialogResult result = MessageBox.Show("The directory that you have selected is empty. The path will be counted as a new reference folder and all the files will be written to this directory without getting checked! Would you like to proceed?", "Directory is empty", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No)
                    {
                        btnLoadProjectPath.PerformClick();
                        GC.Collect();
                    }
                    F = true;
                }
            }
            fbd.Dispose();
        }

        private void rbImport_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            groupBox4.Enabled = true;
        }

        private void rbExport_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = true;
            groupBox2.Enabled = true;
            groupBox3.Enabled = true;
            groupBox4.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Core.customLog = clf.txtCustomLog.Text;
            try
            {
                if (F)
                {
                    processInfo.ProcessActiveState = ProcessInfo.ProcessState.IniExport;
                    processInfo.Visible = true;
                    bgW2.RunWorkerAsync($"{txtProjectPath.Text}|{txtRefProject.Text}");
                }
                else
                {
                    processInfo.ProcessActiveState = ProcessInfo.ProcessState.Export;
                    processInfo.Visible = true;
                    bgW.RunWorkerAsync();
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void bgW_DoWork(object sender, DoWorkEventArgs e)
        {
            CancelableThread = Thread.CurrentThread;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Select the directory that you want this version to get exported to.";
            Action inv = new Action(() => fbd.ShowDialog());
            this.Invoke(inv);

            result = Core.Export(txtProjectPath.Text, txtRefProject.Text, F);
            Action cpis = new Action(() => processInfo.ChangeLT('D', result[0].Count.ToString()));
            Invoke(cpis);
            cpis = new Action(() => processInfo.ChangeLT('F', result[1].Count.ToString()));
            Invoke(cpis);

            if (!string.IsNullOrEmpty(fbd.SelectedPath))
            {
                if (result[0].Count != 0 && result[1].Count != 0 && !F)
                {
                    //Copy files that are new and changed with ther folders sequentially containing them!
                    Core.CopyToNewVersion(txtProjectPath.Text, fbd.SelectedPath, txtVersion.Text);
                }
            }

            else
                MessageBox.Show("You should select a path.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            F = false;
            GC.Collect();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            processInfo.ProcessActiveState = ProcessInfo.ProcessState.Import;
            processInfo.Visible = true;
            bgW1.RunWorkerAsync();
        }

        private void bgW1_DoWork(object sender, DoWorkEventArgs e)
        {
            CancelableThread1 = Thread.CurrentThread;
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = true;
            fbd.Description = "Select a directory for importation.";
            Action inv = new Action(() => fbd.ShowDialog());
            this.Invoke(inv);

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "ACPSM File|*.ACPSM";
            ofd.Multiselect = false;
            inv = new Action(() => ofd.ShowDialog());
            Invoke(inv);

            if (!string.IsNullOrEmpty(fbd.SelectedPath) && !string.IsNullOrEmpty(ofd.FileName))
            {
                //Copy files that are new and changed with ther folders sequentially containing them!
                Core.Import(txtProjectPath.Text, fbd.SelectedPath, ofd.FileName, cbPAP.Checked);
            }

            else
                MessageBox.Show("You should select a path and an ACPSM file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            GC.Collect();
        }

        private void linklbl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:alirezashahbazi641@yahoo.com");
        }

        private void bgW2_DoWork(object sender, DoWorkEventArgs e)
        {
            CancelableThread2 = Thread.CurrentThread;
            try
            {
                Core.Export(e.Argument.ToString().Split('|')[0], e.Argument.ToString().Split('|')[1], true, this);
            }
            catch (Exception exc) { MessageBox.Show(exc.Message); }
            Action mba = new Action(() => MessageBox.Show("Files have been copied to the reference path.", "Success (P: 9612)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation));
            Invoke(mba);
            Action hpi = new Action(() => processInfo.Visible = false);
            this.Invoke(hpi);
        }

        private void bgW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Action mba = new Action(() => MessageBox.Show($"PD [ ERROR: ({((e.Error != null) ? e.Error.Message : "NULL")}) || RESULT: ({((e.Result != null) ? e.Result.ToString() : "NULL")}) || Cancelled: ({e.Cancelled.ToString()}) ]", "BGW STATUS", MessageBoxButtons.OK, MessageBoxIcon.Exclamation));
            Invoke(mba);
            F = false;
        }

        private void lblCustomLog_Click(object sender, EventArgs e)
        {
            if (!clfState == true)
                clf.Show();

            else
                clf.Hide();

            clfState = !clfState;
        }
    }
}
