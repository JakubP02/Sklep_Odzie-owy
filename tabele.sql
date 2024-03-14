CREATE DATABASE Sklep_Odzie¿owy;

CREATE TABLE tbl_U¿ytkownicy (
CONSTRAINT CHK_rola CHECK (rola IN ('Admin', 'Pracownik', 'Klient ')),
IdU¿ytkownika int IDENTITY(1,1) PRIMARY KEY,
[adresEmail] varchar(200), 
Has³o varchar (20),
rola VARCHAR(9) NOT NULL
);


CREATE TABLE tbl_Administratorzy (
IdAdministratora int IDENTITY(1,1) PRIMARY KEY,
IdU¿ytkownika int FOREIGN KEY (IdU¿ytkownika) REFERENCES tbl_U¿ytkownicy(IdU¿ytkownika),
Imiê varchar(50) NOT NULL,
Nazwisko varchar(50) NOT NULL,
AdresEmail varchar(100) NOT NULL,
NrTEl nchar(11) NOT NULL );








CREATE TABLE tbl_Kategoria (
IdKategorii int IDENTITY(1,1) PRIMARY KEY,
Kategoria varchar(50) NOT NULL
);


CREATE TABLE tbl_Produkty (
CONSTRAINT CHK_promocja CHECK (promocja IN ('tak', 'nie')),
IdProduktu int IDENTITY(1,1) PRIMARY KEY,
KodProduktu varchar(10),
Nazwa varchar(50) NOT NULL,
Cena decimal(10,2) NOT NULL,
Stan int NOT NULL,
Idkategorii int FOREIGN KEY (IdKategorii) REFERENCES tbl_Kategoria(IdKategorii),
Promocja VARCHAR(3) NOT NULL DEFAULT 'nie'
);



CREATE TABLE tbl_Pracownicy (
IdPracownika int IDENTITY(1,1) PRIMARY KEY,
IdU¿ytkownika int FOREIGN KEY (IdU¿ytkownika) REFERENCES tbl_U¿ytkownicy(IdU¿ytkownika),
Imiê varchar(50) NOT NULL,
Nazwisko varchar(50) NOT NULL,
AdresEmail varchar(100) NOT NULL,
NrTEl nchar(11) NOT NULL ,
StawkaGodzinowa int NOT NULL
);


CREATE TABLE tbl_Grafik(
IdGrafiku int IDENTITY(1,1) PRIMARY KEY,
IdPracownika int FOREIGN KEY (IdPracownika) REFERENCES tbl_Pracownicy(IdPracownika),
Pon_od time DEFAULT NULL, 
Pon_do time DEFAULT NULL, 
Wt_od time DEFAULT NULL, 
Wt_do time DEFAULT NULL, 
Œr_od time DEFAULT NULL, 
Œr_do time DEFAULT NULL, 
Czw_od time DEFAULT NULL,
Czw_do time DEFAULT NULL, 
Pt_od time DEFAULT NULL, 
Pt_do time DEFAULT NULL, 
[Status] tinyint DEFAULT 0 );


CREATE TABLE tbl_PozycjaZakupyHurt (
CONSTRAINT CHK_Status CHECK ( [Status] IN  ('dostarczony','niedostarczony')), 
IdPozycjiZH int IDENTITY(1,1) PRIMARY KEY,
DataZamówienia Date NOT NULL DEFAULT GETDATE(),
SumaZakupu decimal(10, 2)  NULL,
[Status] varchar(14) NOT NULL DEFAULT 'niedostarczony',
IdPracownika int FOREIGN KEY (IdPracownika) REFERENCES tbl_Pracownicy(IdPracownika)
);

CREATE TABLE tbl_ZakupyHurtowe (
IdZamówienia int IDENTITY(1,1) PRIMARY KEY,
IdPozycjiZamówienia int FOREIGN KEY REFERENCES tbl_PozycjaZakupyHurt(IdPozycjiZH),
IdProduktu int FOREIGN KEY (IdProduktu) REFERENCES tbl_Produkty(IdProduktu),
Idkategorii int FOREIGN KEY (IdKategorii) REFERENCES tbl_Kategoria(IdKategorii),
Iloœæ int NOT NULL,
CenaZasztukê decimal(10,2),
);



CREATE TABLE tbl_Klienci (
IdKlienta int IDENTITY(1,1) PRIMARY KEY,
IdU¿ytkownika int FOREIGN KEY (IdU¿ytkownika) REFERENCES tbl_U¿ytkownicy(IdU¿ytkownika),
Imiê varchar(50) NOT NULL,
Nazwisko varchar(50) NOT NULL,
AdresEmail varchar(100) NOT NULL,
NrTEl nchar(11) NOT NULL 
);

CREATE TABLE tbl_PozycjaSprzeda¿y (
CONSTRAINT CHK_StatusSprzedaz CHECK( [Status] IN ('w dostarczeniu','odebrane','w trakcie realizacji')),   
  IdPozycjiSD int IDENTITY(1, 1) PRIMARY KEY,
  IdKlienta int FOREIGN KEY (IdKlienta) REFERENCES tbl_Klienci(IdKlienta),
  DataZamówienia Date NOT NULL DEFAULT GETDATE(),
  IdPracownika int FOREIGN KEY (IdPracownika) REFERENCES tbl_Pracownicy(IdPracownika),
  [Status] varchar(25) NOT NULL DEFAULT 'w trakcie realizacji',
  SumaSprzeda¿y decimal(10, 2)
);


CREATE TABLE tbl_Sprzeda¿Detal(
IdSprzeda¿y int IDENTITY(1,1) PRIMARY KEY,
IdPozycjiSD int FOREIGN KEY (IdPozycjiSD) REFERENCES tbl_PozycjaSprzeda¿y(IdPozycjiSD),
IdProduktu int FOREIGN KEY (IdProduktu) REFERENCES tbl_Produkty(IdProduktu),
Idkategorii int FOREIGN KEY (IdKategorii) REFERENCES tbl_Kategoria(IdKategorii),
CenaZasztukê decimal(10,2) ,
Iloœæ int NOT NULL
);

	CREATE TABLE tbl_cenyHurtoweProduktów (
    Id int IDENTITY(1,1) PRIMARY KEY,
    IdProduktu int,
    CenaHurtowa decimal(10,2),
    FOREIGN KEY (IdProduktu) REFERENCES tbl_Produkty(IdProduktu)
);






ALTER TABLE tbl_U¿ytkownicy
ADD [Status] int DEFAULT 0;

ALTER TABLE tbl_U¿ytkownicy
ADD [CzyUsuniêty] int DEFAULT 0;

ALTER TABLE tbl_Produkty
ADD [CzyUsuniêty] int DEFAULT 0;




INSERT INTO tbl_U¿ytkownicy (adresEmail, Has³o, rola, [Status])
VALUES 
('admin@admin.com', 'Admin123', 'Admin', 0),
('pracownik@pracownik.com', 'Pracownik123', 'Pracownik', 0),
('klient@klient.com', 'Klient123', 'Klient', 0);

INSERT INTO tbl_Administratorzy (IdU¿ytkownika, Imiê, Nazwisko, AdresEmail, NrTEl)
VALUES 
(1, 'Admin', 'Admin', 'admin@admin.com', '123-123-323');

INSERT INTO tbl_Pracownicy (IdU¿ytkownika, Imiê, Nazwisko, AdresEmail, NrTEl, StawkaGodzinowa)
VALUES 
(2, 'Pracownik', 'pracownik', 'pracownik@pracownik.com', '872-982-987', 22);

INSERT INTO tbl_Klienci (IdU¿ytkownika, Imiê, Nazwisko, AdresEmail, NrTEl)
VALUES 
(3, 'Klient', 'Klient', 'klient@klient.com', '234-213-212');

CREATE TRIGGER trg_PrzeliczanieCenyHurt
ON tbl_Produkty
AFTER INSERT
AS
BEGIN
    INSERT INTO tbl_cenyHurtoweProduktów (IdProduktu, CenaHurtowa)
    SELECT IdProduktu, Cena * 0.7
    FROM inserted;
END

