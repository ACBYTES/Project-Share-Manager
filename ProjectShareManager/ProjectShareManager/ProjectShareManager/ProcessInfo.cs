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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace ProjectShareManager
{
    public partial class ProcessInfo : UserControl
    {
        public ProcessInfo()
        {
            InitializeComponent();
            D = lblD;
            F = lblF;
            this.ProcessActiveState = ProcessState.Export;
            aliveInstance = this;
        }

        public static Label D;
        public static Label F;
        public static ProcessInfo aliveInstance;
        public BackgroundWorker bgw;
        public BackgroundWorker bgw1;
        public BackgroundWorker bgw2;

        public const string DV = "Directories Remaining: ";
        public const string FV = "Files Remaining: ";
        public const string IniExpBF = "Base Files (X)";
        public const string IniExpBF1 = "Other Directories and Files (X)";
        public const string Check = "✔️";

        public enum ProcessState
        {
            Import, Export, IniExport
        }

        private ProcessState state = ProcessState.Export;
        public ProcessState ProcessActiveState { get { return state; } set { ChangeFormState(value); state = value; } }

        public void ChangeLT(char Target, string Value)
        {
            if (Target == 'D')
                D.Text = DV + Value;
            else if (Target == 'F')
                F.Text = FV + Value;
            else if (Target == 'T')
                label1.Text = Value;
        }

        public void AddLT(char Target, string Value)
        {
            if (Target == 'D')
                D.Text += Value;
            else if (Target == 'F')
                F.Text += Value;
            else if (Target == 'T')
                label1.Text += Value;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            BackgroundWorker currentBGW = (ProcessActiveState == ProcessState.Export) ? bgw : (ProcessActiveState == ProcessState.Import) ? bgw1 : bgw2;
            Thread currentThread;
            try
            {
                currentThread = (ProcessActiveState == ProcessState.Export) ? (ParentForm as Form1).CancelableThread : (ProcessActiveState == ProcessState.Import) ?
                   (ParentForm as Form1).CancelableThread1 : (ParentForm as Form1).CancelableThread2;
            }
            catch
            {
                currentThread = (ParentForm as FormSIMW).CancelableThread;
            }
            Action d = new Action(() => currentBGW.CancelAsync());
            ParentForm.Invoke(d);
            d = new Action(() => currentThread.Abort());
            ParentForm.Invoke(d);
            Visible = false;
            MessageBox.Show("Thread was canceled!", "Thread Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ChangeFormState(ProcessState State)
        {
            if (State == ProcessState.Import)
            {
                lblD.Visible = false;
                lblF.Visible = false;
                label1.Text = "Importing";
            }

            else if (State == ProcessState.Export)
            {
                lblD.Visible = true;
                lblF.Visible = true;
                label1.Text = "Process:";
            }

            else if (State == ProcessState.IniExport)
            {
                lblD.Visible = true;
                lblF.Visible = true;
                lblD.Text = IniExpBF;
                lblF.Text = IniExpBF1;
                label1.Text = "P: 9612 <-..EXPORTATION AS NEW DIR..->";
            }
        }
    }
}
