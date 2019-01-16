USE [Linerath-Blog]
GO

DROP TABLE IF EXISTS [dbo].[ArticlesComments]
GO

DROP TABLE IF EXISTS [dbo].[Comments]
GO

CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Sender] [nvarchar](max) NULL,
	[Article_Id] [int] NOT NULL,
	[CreationDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_dbo.Comments_dbo.Comments_Article_Id]
	FOREIGN KEY([Article_Id])
	REFERENCES [dbo].[Articles]([Id])
	ON DELETE CASCADE,
 )
GO
