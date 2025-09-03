namespace WindowDesktopSwitcher
{
    partial class HotkeyManagerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HotkeyManagerForm));
            dgvMappings = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnRemove = new Button();
            chkStartup = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)dgvMappings).BeginInit();
            SuspendLayout();
            // 
            // dgvMappings
            // 
            dgvMappings.AllowUserToAddRows = false;
            dgvMappings.BackgroundColor = SystemColors.HighlightText;
            dgvMappings.BorderStyle = BorderStyle.None;
            dgvMappings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMappings.Dock = DockStyle.Top;
            dgvMappings.Location = new Point(0, 0);
            dgvMappings.Name = "dgvMappings";
            dgvMappings.ReadOnly = true;
            dgvMappings.RowHeadersWidth = 62;
            dgvMappings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMappings.Size = new Size(800, 365);
            dgvMappings.TabIndex = 0;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Gainsboro;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(248, 382);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(153, 43);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Mapping\r\n";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.Gainsboro;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Location = new Point(426, 383);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(153, 43);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit Selected";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Gainsboro;
            btnRemove.FlatAppearance.BorderSize = 0;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Location = new Point(604, 382);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(184, 44);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Remove Selected";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // chkStartup
            // 
            chkStartup.AutoSize = true;
            chkStartup.FlatStyle = FlatStyle.Flat;
            chkStartup.Location = new Point(22, 390);
            chkStartup.Name = "chkStartup";
            chkStartup.Size = new Size(186, 29);
            chkStartup.TabIndex = 4;
            chkStartup.Text = "Start with Windows";
            chkStartup.UseVisualStyleBackColor = true;
            chkStartup.CheckedChanged += chkStartup_CheckedChanged;
            // 
            // HotkeyManagerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 450);
            Controls.Add(chkStartup);
            Controls.Add(btnRemove);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvMappings);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "HotkeyManagerForm";
            Text = "Hotkey Manager - Desktop Switcher";
            Load += HotkeyManagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMappings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvMappings;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnRemove;
        private CheckBox chkStartup;
    }
}