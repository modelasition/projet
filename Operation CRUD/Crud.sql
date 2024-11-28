create database bd_livres;
use bd_livres; 

CREATE TABLE Auteurs (
    id_auteur INT AUTO_INCREMENT PRIMARY KEY,
    prenom VARCHAR(100),
    nom VARCHAR(100)
);


CREATE TABLE Categories (
    id_categorie INT AUTO_INCREMENT PRIMARY KEY,
    categorie VARCHAR(100)
);

CREATE TABLE Livres (
    isbn VARCHAR(20) PRIMARY KEY,
    titre VARCHAR(255),
    description TEXT,
    id_categorie INT,
    FOREIGN KEY (id_categorie) REFERENCES Categories(id_categorie)
);

select Livres.isbn, livres.titre, livres.description, categories.categorie from Livres inner join categories on livres.id_categorie = categories.id_categorie;
select Livres.isbn, livres.titre, livres.description, auteurs.prenom, auteurs.nom
from Livres 
inner join Livre_Auteur on Livre_Auteur.isbn = Livres.isbn
inner join Auteurs on Livre_Auteur.id_auteur = auteurs.id_auteur;

CREATE TABLE Livre_Auteur (
    isbn VARCHAR(20),
    id_auteur INT,
    PRIMARY KEY (isbn, id_auteur),
    FOREIGN KEY (isbn) REFERENCES Livres(isbn),
    FOREIGN KEY (id_auteur) REFERENCES Auteurs(id_auteur)
);
INSERT INTO Categories (categorie) VALUES ('Roman polar');
INSERT INTO Categories (categorie) VALUES ('Biographie');
INSERT INTO Categories (categorie) VALUES ('Recueil de voyage');

INSERT INTO Auteurs (prenom, nom) VALUES ('Jean', 'Dupont');
INSERT INTO Auteurs (prenom, nom) VALUES ('Marie', 'Lemoine');

INSERT INTO Livres (isbn, titre, description, id_categorie) 
VALUES ('978-3-16-148410-0', 'Le Mystère Noir', 'Un polar mystérieux à Paris.', 1);

INSERT INTO Livres (isbn, titre, description, id_categorie) 
VALUES ('978-0-06-112241-5', 'Histoire de vie', 'Biographie inspirante d\'une vie', 2);

INSERT INTO Livre_Auteur (isbn, id_auteur) 
VALUES ('978-3-16-148410-0', 1);

INSERT INTO Livre_Auteur (isbn, id_auteur) 
VALUES ('978-0-06-112241-5', 2);

create user 'AppLivre'@'localhost' identified by 'monsupermdp';
grant select, insert, update, delete on bd_livres.* to 'AppLivre'@'localhost';

