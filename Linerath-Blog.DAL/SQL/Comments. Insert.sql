USE [Linerath-Blog]
GO

INSERT INTO [dbo].[Comments]
           ([Body], [Sender], [Article_Id], [CreationDate])
     VALUES
           (N'In the rich man''s world', N'Abbba', 4, '20181231 06:00:00 PM')
          ,(N'Test message', N'Test sender', 4, '20181231 06:00:00 PM')
		  ,(N'Nice song man!', N'Никола Тесла', 5, '20181231 06:00:00 PM')
          ,(N'1337', N'228', 5, '20181231 06:00:00 PM')
GO
