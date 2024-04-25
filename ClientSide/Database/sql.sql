create database RessourceHumaine;
\c ressourcehumaine;

CREATE SEQUENCE IDBesoin;
CREATE SEQUENCE IDQuestion;
CREATE SEQUENCE IDCandidat;

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


CREATE TABLE Candidat (
    ID_Besoin VARCHAR(10),
    ID_Candidat VARCHAR(10),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    Genre VARCHAR(10),
    Email VARCHAR(100),
    Situation VARCHAR(20),
    Experience VARCHAR(20),
    Proximite VARCHAR(10),
    DiplomeNiveau VARCHAR(20),
    DiplomeFiliere VARCHAR(50)
);

CREATE OR REPLACE VIEW AllQcm AS
SELECT
    QB.ID_Besoin,
    Q.ID_Question,
    Q.question,
    R.reponse,
    R.Indice
FROM
    QCMBesoin QB
JOIN
    Question Q ON QB.ID_Question = Q.ID_Question
JOIN
    Reponse R ON Q.ID_Question = R.ID_Question;



INSERT INTO Besoin (ID_Besoin, Titre, Service, Description, Type, Region, HeureParJour, JourParSemaine)
VALUES ('BS' || nextval('IDBesoin'), 'Titre 1', 'Service 1', 'Description 1', 'Type 1', 'Region 1', 5, 7);

delete from Besoin;
delete from Coefficient;
delete from Candidat;
delete from QCMBesoin;


