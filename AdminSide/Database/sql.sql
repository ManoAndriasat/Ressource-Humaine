create database RessourceHumaine;
\c ressourcehumaine;

CREATE SEQUENCE IDBesoin;
CREATE SEQUENCE IDQuestion;

CREATE TABLE Question(
    ID_Question varchar(8) PRIMARY KEY,
    question varchar(255),
    bonneReponse varchar(5)
);

CREATE TABLE Reponse(
    ID_Question varchar(8),
    reponse varchar(255),
    Indice varchar(2)
);

CREATE TABLE Besoin (
    ID_Besoin varchar(8) PRIMARY KEY,
    Titre varchar(255),
    Service varchar(255),
    Description text,
    Type varchar(255),
    Region varchar(255),
    HeureParJour int,
    JourParSemaine int
);

CREATE TABLE Coefficient(
    ID_Besoin varchar(8),
    Titre varchar(255),
    ValueTitre varchar(255),
    Indice int,
    Coefficient int
);

CREATE TABLE QCMBesoin(
    ID_Besoin varchar(8),
    ID_Question varchar(8)
);



INSERT INTO Besoin (ID_Besoin, Titre, Service, Description, Type, Region, HeureParJour, JourParSemaine)
VALUES ('BS' || nextval('IDBesoin'), 'Titre 1', 'Service 1', 'Description 1', 'Type 1', 'Region 1', 5, 7);