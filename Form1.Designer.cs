namespace OutlookAddIn1
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
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFolder = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radIncident = new System.Windows.Forms.RadioButton();
            this.radCrime = new System.Windows.Forms.RadioButton();
            this.dtpIncident = new System.Windows.Forms.DateTimePicker();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCrime = new System.Windows.Forms.TextBox();
            this.txtIncident = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chkChangeRoot = new System.Windows.Forms.CheckBox();
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.btnUpdateRoot = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(368, 285);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 32);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFolder
            // 
            this.lblFolder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolder.Location = new System.Drawing.Point(32, 161);
            this.lblFolder.Name = "lblFolder";
            this.lblFolder.Size = new System.Drawing.Size(545, 63);
            this.lblFolder.TabIndex = 1;
            this.lblFolder.Text = "GC-20191117-0043";
            this.lblFolder.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(39, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(350, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Attachments will be saved to the following folder:";
            // 
            // radIncident
            // 
            this.radIncident.AutoSize = true;
            this.radIncident.CausesValidation = false;
            this.radIncident.Checked = true;
            this.radIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radIncident.Location = new System.Drawing.Point(7, 35);
            this.radIncident.Name = "radIncident";
            this.radIncident.Size = new System.Drawing.Size(84, 24);
            this.radIncident.TabIndex = 0;
            this.radIncident.Text = "Incident";
            this.radIncident.UseVisualStyleBackColor = true;
            this.radIncident.CheckedChanged += new System.EventHandler(this.refType);
            // 
            // radCrime
            // 
            this.radCrime.AutoSize = true;
            this.radCrime.CausesValidation = false;
            this.radCrime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radCrime.Location = new System.Drawing.Point(7, 67);
            this.radCrime.Name = "radCrime";
            this.radCrime.Size = new System.Drawing.Size(126, 24);
            this.radCrime.TabIndex = 10;
            this.radCrime.Text = "Crime number";
            this.radCrime.UseVisualStyleBackColor = true;
            this.radCrime.CheckedChanged += new System.EventHandler(this.refType);
            // 
            // dtpIncident
            // 
            this.dtpIncident.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpIncident.Location = new System.Drawing.Point(175, 33);
            this.dtpIncident.Name = "dtpIncident";
            this.dtpIncident.Size = new System.Drawing.Size(200, 26);
            this.dtpIncident.TabIndex = 1;
            this.dtpIncident.Value = new System.DateTime(2019, 11, 17, 0, 0, 0, 0);
            this.dtpIncident.EnabledChanged += new System.EventHandler(this.resetFields);
            this.dtpIncident.Validating += new System.ComponentModel.CancelEventHandler(this.validateIncidentNumber);
            // 
            // btnCancel
            // 
            this.btnCancel.CausesValidation = false;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(477, 285);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCrime);
            this.groupBox1.Controls.Add(this.txtIncident);
            this.groupBox1.Controls.Add(this.dtpIncident);
            this.groupBox1.Controls.Add(this.radCrime);
            this.groupBox1.Controls.Add(this.radIncident);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(36, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(536, 103);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incident or crime number";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label4.Location = new System.Drawing.Point(394, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Incident number";
            // 
            // txtCrime
            // 
            this.txtCrime.Location = new System.Drawing.Point(175, 67);
            this.txtCrime.MaxLength = 9;
            this.txtCrime.Name = "txtCrime";
            this.txtCrime.Size = new System.Drawing.Size(89, 26);
            this.txtCrime.TabIndex = 11;
            this.txtCrime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCrime.TextChanged += new System.EventHandler(this.inputTextChanged);
            this.txtCrime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCrime_KeyPress_1);
            this.txtCrime.Validating += new System.ComponentModel.CancelEventHandler(this.validateCrimeNumber);
            // 
            // txtIncident
            // 
            this.txtIncident.CausesValidation = false;
            this.txtIncident.Location = new System.Drawing.Point(391, 33);
            this.txtIncident.MaxLength = 4;
            this.txtIncident.Name = "txtIncident";
            this.txtIncident.Size = new System.Drawing.Size(89, 26);
            this.txtIncident.TabIndex = 2;
            this.txtIncident.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIncident.TextChanged += new System.EventHandler(this.inputTextChanged);
            this.txtIncident.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIncident_KeyPress);
            this.txtIncident.Validating += new System.ComponentModel.CancelEventHandler(this.validateIncidentNumber);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "within:";
            // 
            // chkChangeRoot
            // 
            this.chkChangeRoot.AutoSize = true;
            this.chkChangeRoot.CausesValidation = false;
            this.chkChangeRoot.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkChangeRoot.Location = new System.Drawing.Point(43, 271);
            this.chkChangeRoot.Name = "chkChangeRoot";
            this.chkChangeRoot.Size = new System.Drawing.Size(119, 17);
            this.chkChangeRoot.TabIndex = 17;
            this.chkChangeRoot.TabStop = false;
            this.chkChangeRoot.Text = "Change root folder?";
            this.chkChangeRoot.UseVisualStyleBackColor = true;
            this.chkChangeRoot.CheckedChanged += new System.EventHandler(this.chkChangeRoot_CheckedChanged);
            // 
            // txtRoot
            // 
            this.txtRoot.Enabled = false;
            this.txtRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoot.Location = new System.Drawing.Point(98, 236);
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.Size = new System.Drawing.Size(402, 26);
            this.txtRoot.TabIndex = 18;
            this.txtRoot.TabStop = false;
            this.txtRoot.Text = "default";
            this.txtRoot.TextChanged += new System.EventHandler(this.txtRoot_TextChanged);
            // 
            // btnUpdateRoot
            // 
            this.btnUpdateRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateRoot.Location = new System.Drawing.Point(506, 233);
            this.btnUpdateRoot.Name = "btnUpdateRoot";
            this.btnUpdateRoot.Size = new System.Drawing.Size(71, 32);
            this.btnUpdateRoot.TabIndex = 19;
            this.btnUpdateRoot.TabStop = false;
            this.btnUpdateRoot.Text = "Browse";
            this.btnUpdateRoot.UseVisualStyleBackColor = true;
            this.btnUpdateRoot.Visible = false;
            this.btnUpdateRoot.Click += new System.EventHandler(this.btnRoot_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(609, 330);
            this.Controls.Add(this.btnUpdateRoot);
            this.Controls.Add(this.txtRoot);
            this.Controls.Add(this.chkChangeRoot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblFolder);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radIncident;
        private System.Windows.Forms.RadioButton radCrime;
        private System.Windows.Forms.DateTimePicker dtpIncident;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox chkChangeRoot;
        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.Button btnUpdateRoot;
        private System.Windows.Forms.TextBox txtIncident;
        private System.Windows.Forms.TextBox txtCrime;
        private System.Windows.Forms.Label label4;
    }
}