using MySql.Data.MySqlClient;

namespace Operation_CRUD
{
    public static class Database
    {
        public static List<Category> GetCategories()
        {
            List<Category> categories = new();

            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new("SELECT id_categorie, categorie FROM Categories", sqlConnection))
                {
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        categories.Add(new Category((int)reader["id_categorie"], (string)reader["categorie"]));
                    }
                }

                sqlConnection.Close();
            }

            return categories;
        }


        private static string connectionString = "Server=localhost;Database=bd_livres;Uid=AppLivre;Pwd=monsupermdp";
        internal static List<Book> GetBooks()
        {
            List<Book> books = new();
            string currentIsbn = "";

            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new(@"select Livres.isbn, livres.titre, livres.description, categories.categorie from Livres inner join categories on livres.id_categorie = categories.id_categorie;
                                                select Livres.isbn, livres.titre, livres.description, auteurs.prenom, auteurs.nom
                                                from Livres 
                                                inner join Livre_Auteur on Livre_Auteur.isbn = Livres.isbn
                                                inner join Auteurs on Livre_Auteur.id_auteur = auteurs.id_auteur;
                                                ", sqlConnection))

                {
                    using MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (currentIsbn != reader["isbn"].ToString())
                        {
                            books.Add(
                                new Book(
                                    reader["isbn"].ToString(),
                                    (string)reader["titre"],
                                    reader["description"].ToString(),
                                    new Category
                                        (
                                             (int)reader["id_categorie"],
                                             (string)reader["categorie"]
                                        )
                                    //Email = (string)reader["courriel"]
                                    )
                            );
                            currentIsbn = reader["isbn"].ToString();
                        }

                        //if (reader["id_categorie"].GetType() != typeof(DBNull))
                        //{
                        //    books[^1].Categories.Add(new()
                        //    {
                        //        Id_Category = (int)reader["id_categorie"],
                        //        CategoryName = (string)reader["categorie"]               
                        //    });
                        //}

                        if (reader["id_auteur"].GetType() != typeof(DBNull))
                        {
                            books[^1].Authors.Add(new()
                            {
                                Id_Author = (int)reader["id_auteur"],
                                LastName = (string)reader["nom"],
                                FirstName = (string)reader["prenom"]
                            });
                        }
                    }
                }

                sqlConnection.Close();
            }

            return books;
        }

        internal static void AddBook(Book book)
        {
            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new("INSERT INTO Livres (isbn, titre, description, id_categorie) values (@isbn, @titre, @description, @id_categorie)", sqlConnection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@isbn", book.ISBN));
                    cmd.Parameters.Add(new MySqlParameter("@titre", book.Titre));
                    cmd.Parameters.Add(new MySqlParameter("@description", book.Description));
                    cmd.Parameters.Add(new MySqlParameter("@id_categorie", book.Category.Id_Category));
                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        internal static void RemoveBook(Book livre)
        {
            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new(@"DELETE FROM Livres WHERE isbn = @isbn;"
                        , sqlConnection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@isbn", livre.ISBN));
                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        internal static void ModifyBook(Book livre)
        {
            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new(@"UPDATE Livres
SET titre = @titre,
    description = @description,
    id_categorie = @id_categorie
WHERE isbn = @isbn;", sqlConnection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@isbn", livre.ISBN));
                    cmd.Parameters.Add(new MySqlParameter("@titre", livre.Titre));
                    cmd.Parameters.Add(new MySqlParameter("@description", livre.Description));
                    cmd.Parameters.Add(new MySqlParameter("@id_categorie", livre.Category.Id_Category));
                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        internal static void AddCategorie(Category category)
        {
            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new("INSERT INTO Categories (categorie) VALUES (@categorie);", sqlConnection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@categorie", category.CategoryName));

                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        internal static void RemoveCategorie(Category category)
        {
            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new(@"DELETE FROM Categories 
WHERE id_categorie = @id_categorie;"
                        , sqlConnection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id_categorie", category.Id_Category));
                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        internal static void ModifyCategorie(Category category)
        {
            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new(@"UPDATE Categories
SET categorie = @categorie
WHERE id_categorie = @id_categorie;", sqlConnection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id_categorie", category.Id_Category));
                    cmd.Parameters.Add(new MySqlParameter("@categorie", category.CategoryName));

                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        internal static void AddAutor(Author author)
        {
            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new("INSERT INTO Auteurs (prenom, nom) VALUES (@prenom, @nom);", sqlConnection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@prenom", author.FirstName));
                    cmd.Parameters.Add(new MySqlParameter("@nom", author.LastName));
                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        internal static void RemoveAuthor(Author author)
        {
            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new(@"DELETE FROM Auteurs 
WHERE id_auteur = @id_auteur;"
                        , sqlConnection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id_auteur", author.Id_Author));
                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }

        internal static void ModifyAuthor(Author author)
        {
            using (MySqlConnection sqlConnection = new(connectionString))
            {
                sqlConnection.Open();

                using (MySqlCommand cmd = new(@"UPDATE Auteurs
SET prenom = @prenom,
    nom = @nom
WHERE id_auteur = @id_auteur;", sqlConnection))
                {
                    cmd.Parameters.Add(new MySqlParameter("@id_auteur", author.Id_Author));
                    cmd.Parameters.Add(new MySqlParameter("@prenom", author.FirstName));
                    cmd.Parameters.Add(new MySqlParameter("@nom", author.LastName));
                    cmd.ExecuteNonQuery();
                }

                sqlConnection.Close();
            }
        }



    }
}
