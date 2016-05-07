namespace Login
{
    partial class SearchUser
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearchField = new System.Windows.Forms.TextBox();
            this.checkBoxUsers = new System.Windows.Forms.CheckBox();
            this.checkBoxSecretary = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Insert Keyword";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(275, 19);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 1;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            // 
            // textBoxSearchField
            // 
            this.textBoxSearchField.Location = new System.Drawing.Point(119, 21);
            this.textBoxSearchField.Name = "textBoxSearchField";
            this.textBoxSearchField.Size = new System.Drawing.Size(138, 20);
            this.textBoxSearchField.TabIndex = 2;
            // 
            // checkBoxUsers
            // 
            this.checkBoxUsers.AutoSize = true;
            this.checkBoxUsers.Location = new System.Drawing.Point(398, 24);
            this.checkBoxUsers.Name = "checkBoxUsers";
            this.checkBoxUsers.Size = new System.Drawing.Size(53, 17);
            this.checkBoxUsers.TabIndex = 3;
            this.checkBoxUsers.Text = "Users";
            this.checkBoxUsers.UseVisualStyleBackColor = true;
            // 
            // checkBoxSecretary
            // 
            this.checkBoxSecretary.AutoSize = true;
            this.checkBoxSecretary.Location = new System.Drawing.Point(479, 23);
            this.checkBoxSecretary.Name = "checkBoxSecretary";
            this.checkBoxSecretary.Size = new System.Drawing.Size(71, 17);
            this.checkBoxSecretary.TabIndex = 4;
            this.checkBoxSecretary.Text = "Secretary";
            this.checkBoxSecretary.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(17, 73);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(533, 349);
            this.dataGridView1.TabIndex = 5;
            // 
            // SearchUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 471);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBoxSecretary);
            this.Controls.Add(this.checkBoxUsers);
            this.Controls.Add(this.textBoxSearchField);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.label1);
            this.Name = "SearchUser";
            this.Text = "SearchUser";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearchField;
        private System.Windows.Forms.CheckBox checkBoxUsers;
        private System.Windows.Forms.CheckBox checkBoxSecretary;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}