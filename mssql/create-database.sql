USE master
GO
-- Create the new database if it does not exist already
IF NOT EXISTS (
    SELECT [name]
        FROM sys.databases
        WHERE [name] = N'webapidemodb'
)
CREATE DATABASE webapidemodb
GO

USE webapidemodb
GO

CREATE TABLE [dbo].[Professors](
	[ProfessorId] [int] NOT NULL,
	[Name] [varchar](100) NULL,
	[Teaches] [varchar](100) NULL)

GO

USE webapidemodb
GO

INSERT INTO [dbo].[Professors] ([ProfessorId], [Name], [Teaches])  
VALUES (101, 'Shiva Sai', 'C Sharp; EF Core')
GO
INSERT INTO [dbo].[Professors] ([ProfessorId], [Name], [Teaches])  
VALUES (106, 'Mathew Philips', 'Java; Python')
GO
INSERT INTO [dbo].[Professors] ([ProfessorId], [Name], [Teaches])  
VALUES (111, 'Mohd Azim', 'F Sharp; ML; AI')
GO