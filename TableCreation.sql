BEGIN TRANSACTION;

-- Create Klienci table
CREATE TABLE Klienci(
    IDKlienta int not null primary key identity(1,1),
    ImieNazwisko varchar(64),
    NazwaFirmy varchar(128),
    Email varchar(128) NOT NULL CHECK(DATALENGTH(Email) > 0)
);

-- Add CONSTRAINT to Klienci table
ALTER TABLE Klienci ADD CONSTRAINT Fizyczna_lub_Firma CHECK
(
      (ImieNazwisko = '' AND NazwaFirmy IS NOT NULL)
      OR (NazwaFirmy = '' AND ImieNazwisko IS NOT NULL)
);

-- Create Produkty table
CREATE TABLE Produkty(
    IDProduktu integer primary key not null identity(1,1),
    Nazwa varchar(64) NOT NULL,
    CenaAktualna decimal(5,2) NOT NULL,
    Dostepnosc integer
);

-- Create Paragony table
CREATE TABLE Paragony(
    IDDokumentu varchar(128) PRIMARY KEY NOT NULL,
    DataZakupu DateTime NOT NULL,
    IDKlienta integer FOREIGN KEY REFERENCES Klienci(IDKlienta),
    KwotaCalkowita decimal(7,2)
);

-- Create Zakupy table
CREATE TABLE Zakupy(
    IDZakupu int primary key not null identity(1,1),
    IDDokumentu varchar(128) FOREIGN KEY REFERENCES Paragony(IDDokumentu),
    IDProduktu integer FOREIGN KEY REFERENCES Produkty(IDProduktu),
    Ilosc integer NOT NULL,
    CenaZakupu decimal(5,2) NOT NULL default 0
);

COMMIT;
