
BEGIN TRANSACTION;
	   INSERT INTO Klienci (ImieNazwisko, Email)
VALUES ('John Doe', 'john@abc.com'),
       ('Jane Smith', 'jane@xyz.com'),
       ('Mike Johnson', 'mike@qwerty.com'),
       ('Emily Davis','emily@asdf.com');

	   	   INSERT INTO Klienci (NazwaFirmy, Email)
VALUES ( 'ABC Company', 'abs@abc.com'),
       ('XYZ Corporation', 'xyz@xyz.com'),
       ( 'QWERTY Ltd.', 'qwerty@qwerty.com'),
       ( 'ASDF Enterprises', 'asdf@asdf.com');

	   INSERT INTO Produkty (Nazwa, CenaAktualna, Dostepnosc)
VALUES ('Apple', 1.99, 50),
       ('Orange', 0.99, 75),
       ('Banana', 2.49, 30),
       ('Grapes', 3.99, 20),
	   ('Pears', 5.99, 23),
	   ('Bread', 3.49, 95),
	   ('Cookies', 9.99,184),
	   ('Cola', 6.99, 29),
	   ('Chips', 7.49, 64),
	   ('Pizza', 4.49, 45),
	   ('Fries', 3.99, 40),
	   ('Eggs', 7.99, 90)


INSERT INTO Paragony (IDDokumentu, DataZakupu, IDKlienta, KwotaCalkowita)
VALUES ('fw/abc123', '2022-07-15T03:34:12', 1, 50.99),
       ('fw/xyz456', '2022-09-02T11:45:15', 2, 30.49),
       ('fw/qwerty', '2022-11-18T13:54:12', 3, 75.25),
       ('fw/asdf123', '2022-06-30T20:55:19', 1, 40.00),
       ('fw/zxcv456', '2022-08-22T16:54:23', 4, 60.75),
       ('fw/ghjkl12', '2022-10-05T23:43:16', 2, 22.99),
       ('fw/poiuy98', '2022-12-11T06:56:12', 3, 85.50),
       ('fw/mnbv321', '2022-06-17T16:54:55', 1, 33.75),
       ('fw/09876tr', '2022-08-29T18:00:23', 2, 45.50),
       ('fw/qazxsw2', '2022-10-09T12:43:12', 3, 77.25),
	   ('fw/abd543', '2023-05-15T12:45:34', 6, 50.99),
       ('fw/xyg546', '2023-04-02T09:34:58', 7, 69.49),
       ('fw/qwe123', '2023-03-18T14:54:56', 8, 95.25),
	   ('fw/asl432', '2023-05-10T16:48:40', 6, 23.12),
       ('fw/edcvfr4', '2022-12-25T22:40:00', 4, 86.99),
	   ('pw/123546', '2023-02-02T20:43:34', 7, 23.49),
       ('pw/542123', '2023-03-20T14:43:55', 8, 59.25),
	   ('pw/124432', '2023-04-09T07:07:07', 6, 120.12),
       ('pw/295454', '2022-11-30T06:06:06', 4, 100.99);

INSERT INTO Zakupy (IDDokumentu, IDProduktu, Ilosc, CenaZakupu)
VALUES ('fw/abd543', 1, 2, 10.99),
       ('fw/xyg546', 2, 3, 5.99),
       ('fw/qwe123', 3, 1, 14.99),
	   ('fw/asl432', 3, 10, 12),
	   ('fw/abc123', 10, 1, 50.99),
       ('fw/xyz456', 7, 2, 30.49),
       ('fw/qwerty', 4, 3, 75.25),
       ('fw/asdf123', 5, 1, 40.00),
       ('fw/zxcv456', 8, 4, 60.75),
       ('fw/ghjkl12', 1, 2, 22.99),
       ('fw/poiuy98', 1, 3, 85.50),
       ('fw/mnbv321', 9, 1, 33.75),
       ('fw/09876tr', 11, 2, 45.50),
       ('fw/qazxsw2', 12, 3, 77.25),
	   ('fw/abd543', 4, 6, 50.99),
       ('fw/xyg546', 5, 7, 69.49),
       ('fw/qwe123', 6, 8, 95.25),
	   ('fw/asl432', 7, 6, 23.12),
       ('fw/edcvfr4', 2, 4, 86.99),
	   ('pw/123546', 1, 7, 23.49),
       ('pw/542123', 3, 8, 59.25),
	   ('pw/124432', 6, 6, 120.12),
       ('pw/295454', 10, 4, 100.99),
	   ('fw/abc123', 1, 2, 10.99),
       ('fw/abc123', 2, 3, 5.99),
       ('fw/abc123', 3, 1, 14.99),
       ('fw/xyz456', 2, 2, 8.99),
       ('fw/xyz456', 4, 1, 21.49),
       ('fw/qwerty', 1, 4, 7.99),
       ('fw/qwerty', 3, 2, 9.75),
       ('fw/asdf123', 1, 3, 12.99),
       ('fw/asdf123', 4, 2, 17.50),
       ('fw/zxcv456', 2, 1, 6.49),
       ('fw/zxcv456', 3, 3, 11.99);

COMMIT;
