USE [Linerath-Blog]
GO

ALTER TABLE [dbo].[ArticlesCategories]
   DROP CONSTRAINT IF EXISTS [FK_dbo.ArticlesCategories_dbo.Articles_Article_Id]
GO

DROP TABLE IF EXISTS [dbo].[Articles]
GO

CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](max) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
    CONSTRAINT [PK_dbo.Articles] PRIMARY KEY CLUSTERED ([Id] ASC)
 )
GO
