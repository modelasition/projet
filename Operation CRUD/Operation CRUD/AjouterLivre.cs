using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Operation_CRUD
{
    public partial class AjouterLivre : Form
    {
        public AjouterLivre()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtBoxIsbn.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxTitre.Text) ||
                    string.IsNullOrWhiteSpace(txtBoxDescription.Text) ||
                    cmboBoxCategorie.SelectedItem == null)
                {
                    MessageBox.Show("Tous les champs doivent être remplis.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string isbn = txtBoxIsbn.Text.Trim();
                string titre = txtBoxTitre.Text.Trim();
                string description = txtBoxDescription.Text.Trim();
                int idCategorie = ((Category)cmboBoxCategorie.SelectedItem).Id_Category;

                Book newBook = new Book(isbn, titre, description, new Category(idCategorie, cmboBoxCategorie.SelectedItem.ToString()));

                Database.AddBook(newBook);

                MessageBox.Show("Livre ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtBoxIsbn.Clear();
                txtBoxTitre.Clear();
                txtBoxDescription.Clear();
                cmboBoxCategorie.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Une erreur est survenue : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AjouterLivre_Load(object sender, EventArgs e)
        {
            try
            {
                List<Category> categories = Database.GetCategories(); 
                cmboBoxCategorie.DataSource = categories;
                cmboBoxCategorie.DisplayMember = "CategoryName"; 
                cmboBoxCategorie.ValueMember = "Id_Category";    
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des catégories : {ex.Message}", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

