


INSERT INTO tbl_Kategoria (Kategoria)
VALUES 
('Bluzy'),
('Czapki'),
('Akcesoria');


INSERT INTO tbl_Produkty (KodProduktu, Nazwa, Cena, Stan, Idkategorii, Promocja)
VALUES 
('ABC123', 'Bluza', 1500.00, 10, 1, 'nie'),
('XYZ456', 'Czapka', 50.00, 50, 2, 'nie'),
('123BOOK', 'Plecak', 35.00, 30, 3, 'nie');

INSERT INTO tbl_Grafik (IdPracownika, Pon_od, Pon_do, Wt_od, Wt_do, Œr_od, Œr_do, Czw_od, Czw_do, Pt_od, Pt_do, [Status])
VALUES 
(1, '08:00', '16:00', '08:30', '17:00', '09:00', '18:00', '08:00', '16:00', '09:30', '17:30', 1),
(2, '09:00', '17:30', '09:30', '18:00', '08:00', '16:00', '08:30', '17:00', '09:00', '18:00', 1);

INSERT INTO tbl_PozycjaZakupyHurt ( DataZamówienia, SumaZakupu, [Status])
VALUES 
( '2024-01-25', 1050.00, 'niedostarczony'),
( '2024-01-24', 350.00, 'dostarczony');

INSERT INTO tbl_ZakupyHurtowe (IdPozycjiZamówienia, IdProduktu, Idkategorii, Iloœæ, CenaZasztukê)
VALUES 
(1, 1, 1, 1, 1050.00),
(2, 2, 2, 10, 350.00);



INSERT INTO tbl_PozycjaSprzeda¿y (IdKlienta, DataZamówienia, [Status], SumaSprzeda¿y)
VALUES 
(1, '2024-01-25',  'w trakcie realizacji', 500.00),
(1, '2024-01-24',  'odebrane', 35.00);

INSERT INTO tbl_Sprzeda¿Detal (IdPozycjiSD, IdProduktu, Idkategorii, CenaZasztukê, Iloœæ)
VALUES 
(1, 1, 1, 500.00, 10),
(2, 3, 3, 35.00, 1);



