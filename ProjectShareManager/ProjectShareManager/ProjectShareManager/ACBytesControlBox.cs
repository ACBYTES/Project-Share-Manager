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

namespace ProjectShareManager
{
    public partial class ACBytesControlBox : UserControl
    {
        private const char CloseButtonText = 'X';
        private const char MaximizeButtonText = '⬜';
        private const char MinimizeButtonText = '➖';
        public ACBytesControlBox()
        {
            InitializeComponent();
            Width = Form1.FormWidth;
            lblFormText.Text = Form1.FormText;
            Location = new Point(0, 0);
            Dock = DockStyle.Top;
        }

        private protected Point mouseDownPos;

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }

        private void btnMRForm_Click(object sender, EventArgs e)
        {
            FormWindowState state = (ParentForm.WindowState == FormWindowState.Maximized) ? FormWindowState.Normal : FormWindowState.Maximized;
            ParentForm.WindowState = state;
        }

        private void btnMinimizeForm_Click(object sender, EventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Minimized;
        }

        private void ACBytesControlBox_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDownPos = e.Location;
            MouseMove += ACBytesControlBox_MouseMove;
        }

        private void ACBytesControlBox_MouseUp(object sender, MouseEventArgs e)
        {
            MouseMove -= ACBytesControlBox_MouseMove;
        }

        private void ACBytesControlBox_MouseMove(object sender, MouseEventArgs e)
        {
            ParentForm.WindowState = FormWindowState.Normal;
            ParentForm.DesktopLocation = new Point((ParentForm.DesktopLocation.X + (e.Location.X - mouseDownPos.X)), (ParentForm.DesktopLocation.Y + (e.Location.Y - mouseDownPos.Y)));
        }

        public void AddTextToACCB(string Text)
        {
            lblFormText.Text += Text;
        }
    }
}
