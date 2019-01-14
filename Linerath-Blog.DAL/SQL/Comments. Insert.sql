USE [Linerath-Blog]
GO

INSERT INTO [dbo].[Comments]
           ([Body], [Sender], [Article_Id])
     VALUES
           (N'In the rich man''s world', N'Abbba', 4)
          ,(N'Test message', N'Test sender', 4)
GO
