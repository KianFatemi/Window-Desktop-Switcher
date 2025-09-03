namespace WindowDesktopSwitcher
{
    partial class EditMappingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditMappingForm));
            txtHotkey = new TextBox();
            btnRecord = new Button();
            label1 = new Label();
            label2 = new Label();
            numDesktop = new NumericUpDown();
            label3 = new Label();
            txtAppPath = new TextBox();
            button2 = new Button();
            btnCancel = new Button();
            btnSave = new Button();
            ((System.ComponentModel.ISupportInitialize)numDesktop).BeginInit();
            SuspendLayout();
            // 
            // txtHotkey
            // 
            txtHotkey.Location = new Point(217, 80);
            txtHotkey.Name = "txtHotkey";
            txtHotkey.ReadOnly = true;
            txtHotkey.Size = new Size(266, 31);
            txtHotkey.TabIndex = 0;
            txtHotkey.Text = "Hotkey";
            txtHotkey.KeyDown += txtHotkey_KeyDown;
            // 
            // btnRecord
            // 
            btnRecord.BackColor = Color.Gainsboro;
            btnRecord.FlatAppearance.BorderSize = 0;
            btnRecord.FlatStyle = FlatStyle.Flat;
            btnRecord.Location = new Point(499, 78);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new Size(141, 34);
            btnRecord.TabIndex = 1;
            btnRecord.Text = "Record Hotkey";
            btnRecord.UseVisualStyleBackColor = false;
            btnRecord.Click += btnRecord_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(24, 77);
            label1.Name = "label1";
            label1.Size = new Size(73, 25);
            label1.TabIndex = 2;
            label1.Text = "Hotkey:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 198);
            label2.Name = "label2";
            label2.Size = new Size(153, 25);
            label2.TabIndex = 3;
            label2.Text = "Desktop Number:";
            // 
            // numDesktop
            // 
            numDesktop.BorderStyle = BorderStyle.None;
            numDesktop.Location = new Point(217, 198);
            numDesktop.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numDesktop.Name = "numDesktop";
            numDesktop.Size = new Size(50, 27);
            numDesktop.TabIndex = 4;
            numDesktop.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(24, 299);
            label3.Name = "label3";
            label3.Size = new Size(106, 25);
            label3.TabIndex = 5;
            label3.Text = "Application:";
            // 
            // txtAppPath
            // 
            txtAppPath.Location = new Point(217, 299);
            txtAppPath.Name = "txtAppPath";
            txtAppPath.Size = new Size(266, 31);
            txtAppPath.TabIndex = 6;
            // 
            // button2
            // 
            button2.BackColor = Color.Gainsboro;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(499, 297);
            button2.Name = "button2";
            button2.Size = new Size(89, 34);
            button2.TabIndex = 7;
            button2.Text = "Browse...";
            button2.UseVisualStyleBackColor = false;
            button2.Click += btnBrowse_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Gainsboro;
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Location = new Point(699, 404);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(89, 34);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.Gainsboro;
            btnSave.DialogResult = DialogResult.OK;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Location = new Point(589, 404);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(89, 34);
            btnSave.TabIndex = 9;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // EditMappingForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(button2);
            Controls.Add(txtAppPath);
            Controls.Add(label3);
            Controls.Add(numDesktop);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnRecord);
            Controls.Add(txtHotkey);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "EditMappingForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Add/Edit Mapping";
            ((System.ComponentModel.ISupportInitialize)numDesktop).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtHotkey;
        private Button btnRecord;
        private Label label1;
        private Label label2;
        private NumericUpDown numDesktop;
        private Label label3;
        private TextBox txtAppPath;
        private Button button2;
        private Button btnCancel;
        private Button btnSave;
    }
}