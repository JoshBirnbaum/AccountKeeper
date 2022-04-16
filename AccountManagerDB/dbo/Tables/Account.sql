CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Email] NVARCHAR(50) NULL, 
    [UserName] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(50) NULL, 
    [AccountName] NVARCHAR(50) NOT NULL
)
