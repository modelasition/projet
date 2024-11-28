namespace Operation_CRUD
{
    public partial class bookListForm : Form
    {
        public bookListForm()
        {
            InitializeComponent();
        }

        private void ajoutButton_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refresh();
        }

        private void refresh()
        {
            bookListBox.Items.Clear();
            foreach (Book book in Database.GetBooks())
            {
                bookListBox.Items.Add(book);
            }
        }
    }
}
