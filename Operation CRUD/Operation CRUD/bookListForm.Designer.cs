namespace Operation_CRUD
{
    partial class bookListForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            bookListBox = new ListBox();
            ajoutButton = new Button();
            modifButton = new Button();
            suppButton = new Button();
            SuspendLayout();
            // 
            // bookListBox
            // 
            bookListBox.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            bookListBox.ForeColor = SystemColors.Highlight;
            bookListBox.FormattingEnabled = true;
            bookListBox.ItemHeight = 28;
            bookListBox.Location = new Point(12, 8);
            bookListBox.Name = "bookListBox";
            bookListBox.Size = new Size(457, 424);
            bookListBox.TabIndex = 0;
            // 
            // ajoutButton
            // 
            ajoutButton.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ajoutButton.ForeColor = SystemColors.Desktop;
            ajoutButton.Location = new Point(535, 12);
            ajoutButton.Name = "ajoutButton";
            ajoutButton.Size = new Size(197, 52);
            ajoutButton.TabIndex = 1;
            ajoutButton.Text = "Ajouter";
            ajoutButton.UseVisualStyleBackColor = true;
            ajoutButton.Click += ajoutButton_Click;
            // 
            // modifButton
            // 
            modifButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            modifButton.ForeColor = SystemColors.Desktop;
            modifButton.Location = new Point(535, 83);
            modifButton.Name = "modifButton";
            modifButton.Size = new Size(197, 47);
            modifButton.TabIndex = 2;
            modifButton.Text = "Modifier";
            modifButton.UseVisualStyleBackColor = true;
            // 
            // suppButton
            // 
            suppButton.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            suppButton.ForeColor = SystemColors.Desktop;
            suppButton.Location = new Point(535, 151);
            suppButton.Name = "suppButton";
            suppButton.Size = new Size(205, 46);
            suppButton.TabIndex = 3;
            suppButton.Text = "Supprimer";
            suppButton.UseVisualStyleBackColor = true;
            // 
            // bookListForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(suppButton);
            Controls.Add(modifButton);
            Controls.Add(ajoutButton);
            Controls.Add(bookListBox);
            Name = "bookListForm";
            Text = "BookList";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox bookListBox;
        private Button ajoutButton;
        private Button modifButton;
        private Button suppButton;
    }
}
