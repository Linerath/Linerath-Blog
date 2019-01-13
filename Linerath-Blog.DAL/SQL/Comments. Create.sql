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
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED ([Id] ASC)
 )
GO

CREATE TABLE [dbo].[ArticlesComments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Article_Id] [int] NOT NULL,
	[Comment_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ArticlesComments] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_dbo.ArticlesComments_dbo.Articles_Article_Id]
	FOREIGN KEY([Article_Id])
	REFERENCES [dbo].[Articles]([Id])
	ON DELETE CASCADE,
 CONSTRAINT [FK_dbo.ArticlesComments_dbo.Comments_Comment_Id]
	FOREIGN KEY([Comment_Id])
	REFERENCES [dbo].[Comments]([Id])
	ON DELETE CASCADE
 )
GO
