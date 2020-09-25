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

namespace ProjectShareManager
{
    partial class ACBytesControlBox
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblFormText = new System.Windows.Forms.Label();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.btnMRForm = new System.Windows.Forms.Button();
            this.btnMinimizeForm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblFormText
            // 
            this.lblFormText.AutoSize = true;
            this.lblFormText.ForeColor = System.Drawing.Color.LightGray;
            this.lblFormText.Location = new System.Drawing.Point(16, 10);
            this.lblFormText.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFormText.Name = "lblFormText";
            this.lblFormText.Size = new System.Drawing.Size(46, 18);
            this.lblFormText.TabIndex = 0;
            this.lblFormText.Text = "label1";
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseForm.FlatAppearance.BorderSize = 0;
            this.btnCloseForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseForm.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCloseForm.ForeColor = System.Drawing.Color.LightGray;
            this.btnCloseForm.Location = new System.Drawing.Point(802, 8);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(34, 23);
            this.btnCloseForm.TabIndex = 1;
            this.btnCloseForm.Text = "X";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnCloseForm_Click);
            // 
            // btnMRForm
            // 
            this.btnMRForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMRForm.FlatAppearance.BorderSize = 0;
            this.btnMRForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMRForm.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMRForm.ForeColor = System.Drawing.Color.LightGray;
            this.btnMRForm.Location = new System.Drawing.Point(762, 9);
            this.btnMRForm.Name = "btnMRForm";
            this.btnMRForm.Size = new System.Drawing.Size(34, 23);
            this.btnMRForm.TabIndex = 1;
            this.btnMRForm.Text = "⬜";
            this.btnMRForm.UseVisualStyleBackColor = true;
            this.btnMRForm.Click += new System.EventHandler(this.btnMRForm_Click);
            // 
            // btnMinimizeForm
            // 
            this.btnMinimizeForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizeForm.FlatAppearance.BorderSize = 0;
            this.btnMinimizeForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeForm.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnMinimizeForm.ForeColor = System.Drawing.Color.LightGray;
            this.btnMinimizeForm.Location = new System.Drawing.Point(722, 10);
            this.btnMinimizeForm.Name = "btnMinimizeForm";
            this.btnMinimizeForm.Size = new System.Drawing.Size(34, 23);
            this.btnMinimizeForm.TabIndex = 1;
            this.btnMinimizeForm.Text = "➖";
            this.btnMinimizeForm.UseVisualStyleBackColor = true;
            this.btnMinimizeForm.Click += new System.EventHandler(this.btnMinimizeForm_Click);
            // 
            // ACBytesControlBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.Controls.Add(this.btnMinimizeForm);
            this.Controls.Add(this.btnMRForm);
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.lblFormText);
            this.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ACBytesControlBox";
            this.Size = new System.Drawing.Size(845, 40);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ACBytesControlBox_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ACBytesControlBox_MouseUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFormText;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.Button btnMRForm;
        private System.Windows.Forms.Button btnMinimizeForm;
    }
}
