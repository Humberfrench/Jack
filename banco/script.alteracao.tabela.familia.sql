/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Familia
	DROP CONSTRAINT FK_Familia_StatusFamilia
GO
ALTER TABLE dbo.StatusFamilia SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Familia
	DROP CONSTRAINT FK_Familia_Nivel
GO
ALTER TABLE dbo.Nivel SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_Familia
	(
	Codigo int NOT NULL IDENTITY (1, 1),
	Nome varchar(75) NOT NULL,
	Sacolinha bit NOT NULL,
	Consistente bit NOT NULL,
	PermiteExcedenteRepresentantes bit NOT NULL,
	PermiteExcedenteCriancas bit NOT NULL,
	Nivel tinyint NOT NULL,
	Status int NOT NULL,
	EnderecoFamilia varchar(100) NULL,
	Contato varchar(50) NULL,
	Fake bit NOT NULL,
	PresencaJustificada bit NOT NULL,
	BlackListPasso1 bit NOT NULL,
	BlackListPasso2 bit NOT NULL,
	DataAtualizacao smalldatetime NULL,
	DataCriacao smalldatetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_Familia SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_Familia ON
GO
IF EXISTS(SELECT * FROM dbo.Familia)
	 EXEC('INSERT INTO dbo.Tmp_Familia (Codigo, Nome, Sacolinha, Consistente, PermiteExcedenteRepresentantes, PermiteExcedenteCriancas, Nivel, Status, Contato, Fake, PresencaJustificada, BlackListPasso1, BlackListPasso2, DataAtualizacao, DataCriacao)
		SELECT Codigo, Nome, Sacolinha, Consistente, PermiteExcedenteRepresentantes, PermiteExcedenteCriancas, Nivel, Status, Contato, Fake, PresencaJustificada, BlackListPasso1, BlackListPasso2, DataAtualizacao, DataCriacao FROM dbo.Familia WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_Familia OFF
GO
ALTER TABLE dbo.Crianca
	DROP CONSTRAINT FK_Crianca_Familia
GO
ALTER TABLE dbo.Presenca
	DROP CONSTRAINT FK_Presenca_Familia
GO
ALTER TABLE dbo.Tratamento
	DROP CONSTRAINT FK_Tratamento_Familia
GO
DROP TABLE dbo.Familia
GO
EXECUTE sp_rename N'dbo.Tmp_Familia', N'Familia', 'OBJECT' 
GO
ALTER TABLE dbo.Familia ADD CONSTRAINT
	PK_Familia PRIMARY KEY CLUSTERED 
	(
	Codigo
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.Familia ADD CONSTRAINT
	FK_Familia_Nivel FOREIGN KEY
	(
	Nivel
	) REFERENCES dbo.Nivel
	(
	Codigo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Familia ADD CONSTRAINT
	FK_Familia_StatusFamilia FOREIGN KEY
	(
	Status
	) REFERENCES dbo.StatusFamilia
	(
	Codigo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Tratamento ADD CONSTRAINT
	FK_Tratamento_Familia FOREIGN KEY
	(
	FamiliaId
	) REFERENCES dbo.Familia
	(
	Codigo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Tratamento SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Presenca ADD CONSTRAINT
	FK_Presenca_Familia FOREIGN KEY
	(
	Familia
	) REFERENCES dbo.Familia
	(
	Codigo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Presenca SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
BEGIN TRANSACTION
GO
ALTER TABLE dbo.Crianca ADD CONSTRAINT
	FK_Crianca_Familia FOREIGN KEY
	(
	Familia
	) REFERENCES dbo.Familia
	(
	Codigo
	) ON UPDATE  NO ACTION 
	 ON DELETE  NO ACTION 
	
GO
ALTER TABLE dbo.Crianca SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
