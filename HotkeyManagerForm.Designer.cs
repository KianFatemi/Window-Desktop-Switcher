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
            dgvMappings = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnRemove = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvMappings).BeginInit();
            SuspendLayout();
            // 
            // dgvMappings
            // 
            dgvMappings.AllowUserToAddRows = false;
            dgvMappings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMappings.Dock = DockStyle.Fill;
            dgvMappings.Location = new Point(0, 0);
            dgvMappings.Name = "dgvMappings";
            dgvMappings.ReadOnly = true;
            dgvMappings.RowHeadersWidth = 62;
            dgvMappings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMappings.Size = new Size(800, 450);
            dgvMappings.TabIndex = 0;
            dgvMappings.CellContentClick += dataGridView1_CellContentClick;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(285, 394);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(135, 34);
            btnAdd.TabIndex = 1;
            btnAdd.Text = "Add Mapping\r\n";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += button1_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(458, 394);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(135, 34);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit Selected";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += button1_Click_1;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(632, 394);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(156, 34);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Remove Selected";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += button1_Click_2;
            // 
            // HotkeyManagerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemove);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(dgvMappings);
            Name = "HotkeyManagerForm";
            Text = "Hotkey Manager - Desktop Switcher";
            Load += HotkeyManagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvMappings).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvMappings;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnRemove;
    }
}