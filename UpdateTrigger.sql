CREATE TRIGGER UpdateKwotaCalkowita ON dbo.Zakupy
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    UPDATE P
    SET KwotaCalkowita = I.TotalCenaZakupu
    FROM dbo.Paragony P
    INNER JOIN (
        SELECT Z.IDDokumentu, SUM(Z.CenaZakupu) AS TotalCenaZakupu
        FROM dbo.Zakupy Z
        GROUP BY Z.IDDokumentu
    ) I ON P.IDDokumentu = I.IDDokumentu;
END
GO
