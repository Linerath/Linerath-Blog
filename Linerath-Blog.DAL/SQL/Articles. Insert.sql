USE [Linerath-Blog]
GO

INSERT INTO [dbo].[Articles]
           ([Title], [Body], [CreationDate])
     VALUES
           (N'Welcome', N'To my in-development blog. I''m so excited about that idea.', '20181231 06:00:00 PM')
          ,(N'Slipknot - Eyeless', N'Insane - Am I the only motherfucker with a brain?' + CHAR(13) + 'I''m hearing voices but all they do is complain' + CHAR(13) + 'How many times have you wanted to kill' + CHAR(13) + 'Everything and everyone - Say you''ll do it but never will' + CHAR(13) + 'You can''t see California without Marlon Brando''s eyes' + CHAR(13) + CHAR(13) + 'Can''t see California without Marlon Brando''s eyes' + CHAR(13) + 'You can''t see California without Marlon Brando''s eyes', '20181231 06:00:00 PM')
GO
