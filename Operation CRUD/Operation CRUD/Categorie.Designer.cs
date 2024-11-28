namespace Operation_CRUD
{
    partial class Categorie
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
            label1 = new Label();
            txtBoxCategorie = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Desktop;
            label1.Location = new Point(233, 76);
            label1.Name = "label1";
            label1.Size = new Size(237, 31);
            label1.TabIndex = 0;
            label1.Text = "Ajout de la categorie";
            // 
            // txtBoxCategorie
            // 
            txtBoxCategorie.Location = new Point(248, 137);
            txtBoxCategorie.Name = "txtBoxCategorie";
            txtBoxCategorie.Size = new Size(203, 27);
            txtBoxCategorie.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Desktop;
            button1.Location = new Point(194, 189);
            button1.Name = "button1";
            button1.Size = new Size(329, 56);
            button1.TabIndex = 2;
            button1.Text = "Ajouter Categorie";
            button1.UseVisualStyleBackColor = true;
            // 
            // Categorie
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(txtBoxCategorie);
            Controls.Add(label1);
            Name = "Categorie";
            Text = "Categorie";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtBoxCategorie;
        private Button button1;
    }
}