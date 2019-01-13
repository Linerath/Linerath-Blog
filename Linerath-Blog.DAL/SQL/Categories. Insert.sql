USE [Linerath-Blog]
GO

INSERT INTO [dbo].[Categories]
           ([Name])
     VALUES
           (N'Жизнь')
		  ,(N'Программирование')
		  ,(N'Музыка')
GO

INSERT INTO [dbo].[ArticlesCategories]
           ([Article_Id] ,[Category_Id])
     VALUES
           (1, 1)
          ,(1, 2)
          ,(2, 3)

GO
