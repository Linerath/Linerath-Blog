USE [Linerath-Blog]
GO

ALTER TABLE [dbo].[ArticlesCategories]
   DROP CONSTRAINT IF EXISTS [FK_dbo.ArticlesCategories_dbo.Categories_Category_Id]
GO

DROP TABLE IF EXISTS [dbo].[Categories]
GO

CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_dbo.Categories] PRIMARY KEY CLUSTERED ([Id] ASC)
 )
GO
