create database RessourceHumaine;
\c ressourcehumaine;

CREATE SEQUENCE IDBesoin;
CREATE SEQUENCE IDQuestion;
CREATE SEQUENCE IDCandidat;
CREATE SEQUENCE Matricule;
CREATE SEQUENCE IDConge;

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

CREATE TABLE QCMReponse (
    ID_Besoin VARCHAR(10),
    ID_Candidat VARCHAR(10),
    ID_Question varchar(8),
    Reponse varchar(5)
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

CREATE TABLE CandidatNote (
    ID_Candidat VARCHAR(10),
    Note int
);

CREATE TABLE Candidat_Embauche(
    Matricule VARCHAR(50) PRIMARY KEY,
    ID_Candidat VARCHAR(255),
    date_naissance DATE,
    date_embauche DATE,
    numero_CIN VARCHAR(255),
    contact VARCHAR(40),
    direction VARCHAR(255),
    fonction VARCHAR(255)
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



CREATE VIEW Entretien AS
SELECT
    C.ID_Candidat,
    C.FirstName AS Prenom,
    C.LastName AS Nom,
    C.Genre AS Sexe,
    B.Titre AS PosteRecherche,
    CN.Note
FROM
    Candidat C
JOIN
    Besoin B ON C.ID_Besoin = B.ID_Besoin
LEFT JOIN
    CandidatNote CN ON C.ID_Candidat = CN.ID_Candidat;



INSERT INTO Besoin (ID_Besoin, Titre, Service, Description, Type, Region, HeureParJour, JourParSemaine)
VALUES ('BS' || nextval('IDBesoin'), 'Titre 1', 'Service 1', 'Description 1', 'Type 1', 'Region 1', 5, 7);


INSERT INTO Question VALUES ('Q1','Vous est efficace en travaillant seul ou en equipe ?','2');
INSERT INTO reponse VALUES ('Q1','seul','1');
INSERT INTO reponse VALUES ('Q1','En Equipe','2');
INSERT INTO reponse VALUES ('Q1','Ca depend','3');

INSERT INTO Question VALUES ('Q2','Parle moi de vous','1');
INSERT INTO reponse VALUES ('Q2','motiver','1');
INSERT INTO reponse VALUES ('Q2','Paresseux','2');

-- Question 1 : Parlez-moi de votre expérience professionnelle précédente.
INSERT INTO Question VALUES ('Q3', 'Parlez-moi de votre expérience professionnelle précédente.', '1');

INSERT INTO Reponse VALUES ('Q3', 'J ai travaillé pendant 5 ans en tant que développeur logiciel', '1');
INSERT INTO Reponse VALUES ('Q3', 'J ai de l expérience en gestion de projet', '2');
INSERT INTO Reponse VALUES ('Q3', 'Je n ai pas encore d expérience professionnelle', '3');

-- Question 2 : Pourquoi avez-vous choisi notre entreprise pour travailler ?
INSERT INTO Question VALUES ('Q4', 'Pourquoi avez-vous choisi notre entreprise pour travailler ?', '1');

INSERT INTO Reponse VALUES ('Q4', 'J admire la culture d entreprise de votre société', '1');
INSERT INTO Reponse VALUES ('Q4', 'Je suis intéressé par les opportunités de croissance ici', '2');
INSERT INTO Reponse VALUES ('Q4', 'Je cherchais simplement un emploi et j ai postulé', '3');

-- Question 3 : Pouvez-vous me donner un exemple de projet difficile que vous avez géré avec succès ?
INSERT INTO Question VALUES ('Q5', 'Pouvez-vous me donner un exemple de projet difficile que vous avez géré avec succès ?', '1');

INSERT INTO Reponse VALUES ('Q5', 'J ai géré un projet de migration de données complexe', '1');
INSERT INTO Reponse VALUES ('Q5', 'J ai dirigé une équipe pour résoudre un problème technique majeur', '2');
INSERT INTO Reponse VALUES ('Q5', 'Je n ai pas encore eu d expérience dans la gestion de projets', '3');

-- Question 4 : Comment gérez-vous les situations de conflit au sein de votre équipe ?
INSERT INTO Question VALUES ('Q6', 'Comment gérez-vous les situations de conflit au sein de votre équipe ?', '3');

INSERT INTO Reponse VALUES ('Q6', 'J encourage la communication ouverte et la médiation' , '1');
INSERT INTO Reponse VALUES ('Q6', 'Je prends des décisions autoritaires pour résoudre les conflits', '2');
INSERT INTO Reponse VALUES ('Q6', 'Je ne suis pas sûr de comment gérer les conflits', '3');

-- Question 5 : Où vous voyez-vous dans cinq ans sur le plan professionnel ?
INSERT INTO Question VALUES ('Q7', 'Où vous voyez-vous dans cinq ans sur le plan professionnel ?', '2');

INSERT INTO Reponse VALUES ('Q7', 'Je souhaite évoluer vers un poste de gestion' , '1');
INSERT INTO Reponse VALUES ('Q7', 'Je ne suis pas sûr, mais je veux apprendre et grandir', '2');
INSERT INTO Reponse VALUES ('Q7', 'Je n ai pas encore réfléchi à mes objectifs à long terme', '3');


-- JUDI : liste employer : 12 octobre 2023 , 14:28
-- view liste_candidat_ambauche
-- view liste_candidat_ambauche
create or replace view  liste_candidat_ambauche as (
    select candidat.*,
            candidat_embauche.matricule,
            candidat_embauche.date_naissance,
            candidat_embauche.date_embauche,
            candidat_embauche.numero_cin,
            candidat_embauche.contact,
            candidat_embauche.direction,
            candidat_embauche.fonction 
    from candidat_embauche 
    join candidat 
    on candidat.id_candidat = candidat_embauche.id_candidat
);




SELECT Matricule, EXTRACT(YEAR FROM age( CURRENT_DATE,date_embauche)) * 12 + EXTRACT(MONTH FROM age( CURRENT_DATE,date_embauche)) AS totalCongeObtenu
FROM Candidat_Embauche;


CREATE TABLE Candidat_Embauche(
    Matricule VARCHAR(50) PRIMARY KEY,
    ID_Candidat VARCHAR(255),
    date_naissance DATE,
    date_embauche DATE,
    numero_CIN VARCHAR(255),
    contact VARCHAR(40),
    direction VARCHAR(255),
    fonction VARCHAR(255)
);

CREATE TABLE TypeConge (
    ID_TypeConge VARCHAR(10) PRIMARY KEY,
    Titre VARCHAR(255)
);
-- Insertion des valeurs pour les types de congé
INSERT INTO TypeConge VALUES
    ('1','Affaire Familiale'),
    ('2','Vacances'),
    ('3','Congé pour motif personnel'),
    ('4','Congé pour voyage'),
    ('5','Maladie'),
    ('6','Congé de deuil'),
    ('7','Congé de maternité'),
    ('8','Congé de paternité');


CREATE TABLE DemandeConge(
    ID_Conge varchar(20),
    Matricule varchar(20),
    DateDepart date,
    DateRetour date,
    ID_TypeConge varchar(20),
    Motif text,
    Etat int
);


CREATE OR REPLACE VIEW PrevisionConge AS
SELECT
    d.Matricule,
    d.DateDepart,
    d.DateRetour,
    c.direction,
    tc.Titre,
    d.Motif,
    d.Etat
FROM DemandeConge d
INNER JOIN Candidat_Embauche c ON d.Matricule = c.Matricule
INNER JOIN TypeConge tc ON d.ID_TypeConge = tc.ID_TypeConge;


CREATE VIEW VueDemandeConge AS
SELECT
    d.Matricule,
    d.DateDepart,
    d.DateRetour,
    c.direction AS Direction,
    d.ID_TypeConge,
    d.Motif,
    d.Etat
FROM DemandeConge d
INNER JOIN Candidat_Embauche c ON d.Matricule = c.Matricule;

CREATE OR REPLACE VIEW congeAffichage AS
SELECT
    dc.ID_Conge,
    dc.Matricule,
    dc.DateDepart,
    dc.DateRetour,
    tc.Titre AS TypeConge,
    dc.Motif,
    dc.Etat
FROM DemandeConge dc
JOIN TypeConge tc ON dc.ID_TypeConge = tc.ID_TypeConge;



SELECT Matricule, SUM(DateRetour - DateDepart) AS TotalCongeDepense
FROM DemandeConge
GROUP BY Matricule;





-- lebron
CREATE TABLE emp_salaire_de_base (
    Matricule VARCHAR(255),
    salaire DOUBLE PRECISION,
    date_debut DATE
);

CREATE OR REPLACE VIEW employe AS 
    SELECT Candidat_Embauche.Matricule, Candidat_Embauche.ID_Candidat, Candidat_Embauche.date_naissance, Candidat_Embauche.numero_CIN, 
    Candidat_Embauche.contact, Candidat_Embauche.direction, Candidat_Embauche.fonction,
    Candidat.FirstName, Candidat.LastName, Candidat.Genre, Candidat.Email
    FROM Candidat_Embauche JOIN Candidat ON Candidat_Embauche.ID_Candidat = Candidat.ID_Candidat
    WHERE Candidat_Embauche.Matricule NOT IN (SELECT Matricule FROM emp_salaire_de_base)
;



delete from Besoin;
delete from Coefficient;
delete from QCMBesoin;
delete from QCMReponse;
delete from CandidatNote;



-- Information Employer
delete from Candidat;
delete from Candidat_Embauche;
delete from CandidatNote;
delete from DemandeConge;
delete from QCMReponse;

-- JUDI : fiche de paie : 20 octobre 2023 , 15:00
create table fiche_de_paie_details(
    matricule VARCHAR(50),
    date_debut date,
    date_fin date,
    nombre_de_jours int,
    salaire_de_base int,
    heure_sup_30 int,
    heure_sup_40 int,
    heure_sup_50 int,
    heure_sup_100 int,
    prime_de_rendement int,
    prime_d_anciennete int,
    majoration_heure_nuit int,
    prime_diverse int,
    rappels_periode_anterieure int,
    droit_conge int,
    droit_preavis int,
    indemnite_de_licenciement int,
    jours_absence int
);