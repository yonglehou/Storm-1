USE Storm
GO

CREATE SCHEMA Cars
GO

CREATE TABLE Cars.Brands
(
	Id				INT				NOT NULL	PRIMARY KEY IDENTITY
,	Name			NVARCHAR(255)	NOT NULL
,	Slogan			NVARCHAR(MAX)	NOT NULL
,	Country			NVARCHAR(255)	NOT NULL
,	Founded			DATETIME2		NOT NULL
)
GO

CREATE TABLE Cars.Models
(
	Id					INT				NOT NULL	PRIMARY KEY IDENTITY
,	BrandId				INT				NOT NULL
,	Name				NVARCHAR(255)	NOT NULL
,	HorsePower			INT				NOT NULL
,	Year				INT				NOT NULL

	CONSTRAINT FK_Models_Brands FOREIGN KEY (BrandId) REFERENCES Cars.Brands(Id)
)
GO

-- Demo
CREATE SCHEMA Demo
GO

CREATE PROCEDURE Demo.GetAllBrands
AS
BEGIN
	SELECT		b.Id
	,			b.Name
	,			b.Slogan
	,			b.Country
	,			b.Founded
	FROM		Cars.Brands b
END
GO

CREATE PROCEDURE Demo.GetModelsByMinimumYearAndMinimumHorsePower
(
	@MinimumYear		INT
,	@MinimumHorsePower	INT
)
AS
BEGIN
	SELECT		m.Id
	,			m.BrandId
	,			m.Name
	,			m.HorsePower
	,			m.Year
	FROM		Cars.Models m
	WHERE		m.Year >= @MinimumYear
			AND	m.HorsePower >= @MinimumHorsePower
END
GO

CREATE PROCEDURE Demo.AddBrand
(
	@Name			NVARCHAR(255)
,	@Slogan			NVARCHAR(MAX)
,	@Country		NVARCHAR(255)
,	@Founded		DATETIME2
)
AS
BEGIN
	INSERT INTO		Cars.Brands
	(Name, Slogan, Country, Founded)
	VALUES
	(@Name, @Slogan, @Country, @Founded)
END
GO

CREATE PROCEDURE Demo.AddModel
(
	@BrandId		INT
,	@Name			NVARCHAR(255)
,	@HorsePower		INT
,	@Year			INT
)
AS
BEGIN
	INSERT INTO	Cars.Models
	(BrandId, Name, HorsePower, Year)
	VALUES
	(@BrandId, @Name, @HorsePower, @Year)
END
GO

CREATE PROCEDURE Demo.GetAllBrandsAndModels
AS
BEGIN
	SELECT		b.Id
	,			b.Name
	,			b.Slogan
	,			b.Country
	,			b.Founded
	FROM		Cars.Brands b

	SELECT		m.Id
	,			m.BrandId
	,			m.Name
	,			m.HorsePower
	,			m.Year
	FROM		Cars.Models m
END
GO

CREATE TYPE Demo.udtModel AS TABLE
(
	BrandId		INT				NOT NULL
,	Name		NVARCHAR(255)	NOT NULL
,	HorsePower	INT				NOT NULL
,	Year		INT				NOT NULL
)
GO

CREATE PROCEDURE Demo.BulkAddModels
(
	@Models		Demo.udtModel READONLY
)
AS
BEGIN
	INSERT INTO	Cars.Models
	(BrandId, Name, HorsePower, Year)
	SELECT		m.BrandId
	,			m.Name
	,			m.HorsePower
	,			m.Year
	FROM		@Models m
END
GO

-- Integration tests
CREATE SCHEMA IntegrationTest
GO

CREATE PROCEDURE IntegrationTest.Query_NoParameters
AS
BEGIN
	SELECT		b.Id
	,			b.Name
	,			b.Slogan
	,			b.Country
	FROM		Cars.Brands b
END
GO

CREATE PROCEDURE IntegrationTest.NonQuery_NoParameters
AS
BEGIN
	UPDATE		Cars.Models
	SET			HorsePower = 1
	WHERE		1 = 2
END
GO

CREATE PROCEDURE IntegrationTest.Scalar_NoParameters
AS
BEGIN
	SELECT		COUNT(*)
	FROM		Cars.Brands
END
GO

CREATE PROCEDURE IntegrationTest.MultipleResultSets_NoParameters
AS
BEGIN
		SELECT		b.Id
		,			b.Name
		,			b.Slogan
		,			b.Country
		FROM		Cars.Brands b

		SELECT		m.BrandId
		,			m.Name
		,			m.HorsePower
		FROM		Cars.Models m
END
GO