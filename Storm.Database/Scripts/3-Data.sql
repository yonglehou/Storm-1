INSERT INTO Cars.Brands
(Name, Slogan, Country, Founded)
VALUES
('Audi', 'Never follow', 'Germany', '1932-06-29'),
('BMW', 'The ultimate driving machine', 'Germany', '1916-03-07'),
('Honda', 'The power of dreams', 'Japan', '1946-10-01'),
('Volkswagen', 'Das auto', 'Germany', '1946-05-28'),
('Volvo', 'Made by Sweden', 'Sweden', '1927-04-14')
GO

INSERT INTO Cars.Models
(BrandId, Name, HorsePower, Year)
VALUES
(1, 'A3', 80, 1996),
(1, 'A4', 120, 1996),
(1, 'R8', 240, 2006),

(2, '1 Series', 140, 2011),
(2, 'M4', 260, 2013),
(2, 'i8', 120, 2014),

(3, 'Civic', 70, 1972),
(3, 'Jazz', 85, 1982),
(3, 'NSX', 140, 1990),

(4, 'Scirocco', 120, 1974),
(4, 'Polo', 70, 1975),
(4, 'Passat', 120, 1973),

(5, 'V40', 120, 2012),
(5, 'S60', 160, 2010),
(5, 'XC70', 180, 2007)
GO