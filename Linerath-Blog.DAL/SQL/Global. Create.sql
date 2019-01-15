USE [Linerath-Blog]
GO

DROP TABLE IF EXISTS [dbo].[ArticlesCategories]
GO

DROP TABLE IF EXISTS [dbo].[ArticlesComments]
GO

DROP TABLE IF EXISTS [dbo].[Comments]
GO

DROP TABLE IF EXISTS [dbo].[Articles]
GO

DROP TABLE IF EXISTS [dbo].[Categories]
GO


--Articles
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Articles] PRIMARY KEY CLUSTERED ([Id] ASC)
 )
GO

--Categories
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
 )
GO

CREATE TABLE [dbo].[ArticlesCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Article_Id] [int] NOT NULL,
	[Category_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.ArticlesCategories] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_dbo.ArticlesCategories_dbo.Articles_Article_Id]
	FOREIGN KEY([Article_Id])
	REFERENCES [dbo].[Articles]([Id])
	ON DELETE CASCADE,
 CONSTRAINT [FK_dbo.ArticlesCategories_dbo.Categories_Category_Id]
	FOREIGN KEY([Category_Id])
	REFERENCES [dbo].[Categories]([Id])
	ON DELETE CASCADE
 )
GO

--Comments
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[Sender] [nvarchar](max) NULL,
	[Article_Id] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Comments] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_dbo.Comments_dbo.Comments_Article_Id]
	FOREIGN KEY([Article_Id])
	REFERENCES [dbo].[Articles]([Id])
	ON DELETE CASCADE,
 )
GO
