CREATE TABLE [dbo].[LoggingTable]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Logged] DATETIME2 NOT NULL, 
    [Application] NVARCHAR(50) NOT NULL, 
    [Level] NVARCHAR(50) NOT NULL, 
    [Message] NVARCHAR(MAX) NOT NULL, 
    [Logger] NVARCHAR(250) NULL, 
    [ActionMethod] NVARCHAR(250) NULL, 
    [Exception] NVARCHAR(MAX) NULL, 
    [StackTrace] NVARCHAR(MAX) NULL
)

GO

CREATE INDEX [IX_LoggingTable_Column] ON [dbo].[LoggingTable] ([Logged], [Level])
