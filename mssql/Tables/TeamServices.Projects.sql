/*** Справочник командных проектов ***/
USE Development
GO

DROP TABLE IF EXISTS TeamServices.Projects
GO

CREATE TABLE TeamServices.Projects
(
	 Id		     INTEGER IDENTITY(1,1) NOT NULL
	,Name		 NVARCHAR(32)		   NOT NULL
	,Description NVARCHAR(256)		       NULL
	,LogoPath    NVARCHAR(256)		       NULL
	,CONSTRAINT PkProjects PRIMARY KEY CLUSTERED
	(
		Id ASC
	)
)