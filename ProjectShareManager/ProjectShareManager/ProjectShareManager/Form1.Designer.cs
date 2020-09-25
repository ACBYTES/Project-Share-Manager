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
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtProjectPath = new System.Windows.Forms.TextBox();
            this.btnLoadProjectPath = new System.Windows.Forms.Button();
            this.txtRefProject = new System.Windows.Forms.TextBox();
            this.rbExport = new System.Windows.Forms.RadioButton();
            this.rbImport = new System.Windows.Forms.RadioButton();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnLoadRefPath = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbPAP = new System.Windows.Forms.CheckBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.bgW = new System.ComponentModel.BackgroundWorker();
            this.bgW1 = new System.ComponentModel.BackgroundWorker();
            this.linklbl = new System.Windows.Forms.LinkLabel();
            this.bgW2 = new System.ComponentModel.BackgroundWorker();
            this.processInfo = new ProjectShareManager.ProcessInfo();
            this.ACCB = new ProjectShareManager.ACBytesControlBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblCustomLog = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbSettings.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectPath.Location = new System.Drawing.Point(34, 25);
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Size = new System.Drawing.Size(460, 26);
            this.txtProjectPath.TabIndex = 2;
            // 
            // btnLoadProjectPath
            // 
            this.btnLoadProjectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadProjectPath.BackColor = System.Drawing.Color.Silver;
            this.btnLoadProjectPath.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnLoadProjectPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnLoadProjectPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnLoadProjectPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadProjectPath.ForeColor = System.Drawing.Color.Black;
            this.btnLoadProjectPath.Location = new System.Drawing.Point(151, 57);
            this.btnLoadProjectPath.Name = "btnLoadProjectPath";
            this.btnLoadProjectPath.Size = new System.Drawing.Size(241, 29);
            this.btnLoadProjectPath.TabIndex = 3;
            this.btnLoadProjectPath.Text = "Browse...";
            this.btnLoadProjectPath.UseVisualStyleBackColor = false;
            this.btnLoadProjectPath.Click += new System.EventHandler(this.btnLoadProjectPath_Click);
            // 
            // txtRefProject
            // 
            this.txtRefProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRefProject.Location = new System.Drawing.Point(85, 25);
            this.txtRefProject.Name = "txtRefProject";
            this.txtRefProject.Size = new System.Drawing.Size(460, 26);
            this.txtRefProject.TabIndex = 2;
            // 
            // rbExport
            // 
            this.rbExport.AutoSize = true;
            this.rbExport.ForeColor = System.Drawing.Color.LightGray;
            this.rbExport.Location = new System.Drawing.Point(16, 53);
            this.rbExport.Name = "rbExport";
            this.rbExport.Size = new System.Drawing.Size(66, 22);
            this.rbExport.TabIndex = 4;
            this.rbExport.TabStop = true;
            this.rbExport.Text = "Export";
            this.rbExport.UseVisualStyleBackColor = true;
            this.rbExport.CheckedChanged += new System.EventHandler(this.rbExport_CheckedChanged);
            // 
            // rbImport
            // 
            this.rbImport.AutoSize = true;
            this.rbImport.ForeColor = System.Drawing.Color.LightGray;
            this.rbImport.Location = new System.Drawing.Point(16, 25);
            this.rbImport.Name = "rbImport";
            this.rbImport.Size = new System.Drawing.Size(68, 22);
            this.rbImport.TabIndex = 5;
            this.rbImport.TabStop = true;
            this.rbImport.Text = "Import";
            this.rbImport.UseVisualStyleBackColor = true;
            this.rbImport.CheckedChanged += new System.EventHandler(this.rbImport_CheckedChanged);
            // 
            // gbSettings
            // 
            this.gbSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.gbSettings.Controls.Add(this.rbImport);
            this.gbSettings.Controls.Add(this.rbExport);
            this.gbSettings.ForeColor = System.Drawing.Color.LightGray;
            this.gbSettings.Location = new System.Drawing.Point(16, 52);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Size = new System.Drawing.Size(97, 96);
            this.gbSettings.TabIndex = 6;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.Controls.Add(this.txtProjectPath);
            this.groupBox1.Controls.Add(this.btnLoadProjectPath);
            this.groupBox1.Enabled = false;
            this.groupBox1.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox1.Location = new System.Drawing.Point(119, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(527, 96);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Project Path:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox2.Controls.Add(this.txtRefProject);
            this.groupBox2.Controls.Add(this.btnLoadRefPath);
            this.groupBox2.Enabled = false;
            this.groupBox2.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox2.Location = new System.Drawing.Point(16, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(630, 96);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reference Path:";
            // 
            // btnLoadRefPath
            // 
            this.btnLoadRefPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadRefPath.BackColor = System.Drawing.Color.Silver;
            this.btnLoadRefPath.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnLoadRefPath.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnLoadRefPath.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnLoadRefPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadRefPath.ForeColor = System.Drawing.Color.Black;
            this.btnLoadRefPath.Location = new System.Drawing.Point(200, 57);
            this.btnLoadRefPath.Name = "btnLoadRefPath";
            this.btnLoadRefPath.Size = new System.Drawing.Size(241, 29);
            this.btnLoadRefPath.TabIndex = 3;
            this.btnLoadRefPath.Text = "Browse...";
            this.btnLoadRefPath.UseVisualStyleBackColor = false;
            this.btnLoadRefPath.Click += new System.EventHandler(this.btnLoadRefPath_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.txtVersion);
            this.groupBox3.Controls.Add(this.btnExport);
            this.groupBox3.Enabled = false;
            this.groupBox3.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox3.Location = new System.Drawing.Point(16, 256);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 96);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Export Settings:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Version:";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(75, 25);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(220, 26);
            this.txtVersion.TabIndex = 2;
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.Silver;
            this.btnExport.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(14, 57);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(280, 29);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Check and Export";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox4.Controls.Add(this.cbPAP);
            this.groupBox4.Controls.Add(this.btnImport);
            this.groupBox4.Enabled = false;
            this.groupBox4.ForeColor = System.Drawing.Color.LightGray;
            this.groupBox4.Location = new System.Drawing.Point(334, 256);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(312, 96);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Import Settings:";
            // 
            // cbPAP
            // 
            this.cbPAP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPAP.AutoSize = true;
            this.cbPAP.Location = new System.Drawing.Point(245, 45);
            this.cbPAP.Name = "cbPAP";
            this.cbPAP.Size = new System.Drawing.Size(51, 22);
            this.cbPAP.TabIndex = 4;
            this.cbPAP.Text = "PAP";
            this.cbPAP.UseVisualStyleBackColor = true;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.Silver;
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gainsboro;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.Location = new System.Drawing.Point(14, 40);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(213, 29);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // bgW
            // 
            this.bgW.WorkerSupportsCancellation = true;
            this.bgW.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgW_DoWork);
            this.bgW.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgW_RunWorkerCompleted);
            // 
            // bgW1
            // 
            this.bgW1.WorkerSupportsCancellation = true;
            this.bgW1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgW1_DoWork);
            this.bgW1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgW_RunWorkerCompleted);
            // 
            // linklbl
            // 
            this.linklbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linklbl.AutoSize = true;
            this.linklbl.Location = new System.Drawing.Point(4, 356);
            this.linklbl.Name = "linklbl";
            this.linklbl.Size = new System.Drawing.Size(123, 18);
            this.linklbl.TabIndex = 8;
            this.linklbl.TabStop = true;
            this.linklbl.Text = "Contact Developer";
            this.linklbl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklbl_LinkClicked);
            // 
            // bgW2
            // 
            this.bgW2.WorkerSupportsCancellation = true;
            this.bgW2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgW2_DoWork);
            this.bgW2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgW_RunWorkerCompleted);
            // 
            // processInfo
            // 
            this.processInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.processInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.processInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.processInfo.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.processInfo.ForeColor = System.Drawing.Color.LightGray;
            this.processInfo.Location = new System.Drawing.Point(212, 118);
            this.processInfo.Margin = new System.Windows.Forms.Padding(4);
            this.processInfo.Name = "processInfo";
            this.processInfo.ProcessActiveState = ProjectShareManager.ProcessInfo.ProcessState.Export;
            this.processInfo.Size = new System.Drawing.Size(268, 172);
            this.processInfo.TabIndex = 7;
            this.processInfo.Visible = false;
            // 
            // ACCB
            // 
            this.ACCB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.ACCB.Dock = System.Windows.Forms.DockStyle.Top;
            this.ACCB.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ACCB.Location = new System.Drawing.Point(0, 0);
            this.ACCB.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.ACCB.Name = "ACCB";
            this.ACCB.Size = new System.Drawing.Size(666, 43);
            this.ACCB.TabIndex = 0;
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCustomLog});
            this.statusStrip.Location = new System.Drawing.Point(0, 355);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip.Size = new System.Drawing.Size(666, 22);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblCustomLog
            // 
            this.lblCustomLog.AutoSize = false;
            this.lblCustomLog.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomLog.ForeColor = System.Drawing.Color.White;
            this.lblCustomLog.Name = "lblCustomLog";
            this.lblCustomLog.Size = new System.Drawing.Size(651, 17);
            this.lblCustomLog.Spring = true;
            this.lblCustomLog.Text = "Add Custom Log";
            this.lblCustomLog.Click += new System.EventHandler(this.lblCustomLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(18)))), ((int)(((byte)(18)))));
            this.ClientSize = new System.Drawing.Size(666, 377);
            this.ControlBox = false;
            this.Controls.Add(this.linklbl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.processInfo);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbSettings);
            this.Controls.Add(this.ACCB);
            this.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Main";
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ACBytesControlBox ACCB;
        private System.Windows.Forms.TextBox txtProjectPath;
        private System.Windows.Forms.Button btnLoadProjectPath;
        private System.Windows.Forms.TextBox txtRefProject;
        private System.Windows.Forms.RadioButton rbExport;
        private System.Windows.Forms.RadioButton rbImport;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoadRefPath;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnImport;
        private System.ComponentModel.BackgroundWorker bgW;
        private System.Windows.Forms.CheckBox cbPAP;
        private ProcessInfo processInfo;
        private System.ComponentModel.BackgroundWorker bgW1;
        private System.Windows.Forms.LinkLabel linklbl;
        private System.ComponentModel.BackgroundWorker bgW2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblCustomLog;
    }
}

