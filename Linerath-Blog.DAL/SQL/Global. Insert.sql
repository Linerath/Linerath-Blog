USE [Linerath-Blog]
GO

--Articles
INSERT INTO [dbo].[Articles]
           ([Title], [Body], [CreationDate])
     VALUES
           (N'Welcome', N'To my in-development blog. I''m so excited about that idea.', '20181231 06:00:00 PM')
          ,(N'Slipknot - Eyeless', N'Insane - Am I the only motherfucker with a brain?' + CHAR(13) + 'I''m hearing voices but all they do is complain' + CHAR(13) + 'How many times have you wanted to kill' + CHAR(13) + 'Everything and everyone - Say you''ll do it but never will' + CHAR(13) + 'You can''t see California without Marlon Brando''s eyes' + CHAR(13) + CHAR(13) + 'Can''t see California without Marlon Brando''s eyes' + CHAR(13) + 'You can''t see California without Marlon Brando''s eyes', '20181231 06:00:00 PM')
          ,(N'A', N'The show must go on.', '20190113 02:00:00 PM')
          ,(N'Haha', N'Money, money, money. Always sunny.', '20190113 03:00:00 PM')
		  ,(N'I''m A Marionette', N'"You''re so free," that''s what everybody''s telling me' + CHAR(13) + 'Yet I feel I''m like an outward-bound, pushed around, refugee' + CHAR(13) + 'Something''s wrong, got a feeling that I don''t belong' + CHAR(13) + 'As if I had come from outer space, out of place, like King Kong' + CHAR(13) + CHAR(13) + CHAR(13) + 'I''m a marionette, just a marionette, pull the string' + CHAR(13) + 'I''m a marionette, everybody''s pet, just as long as I sing' + CHAR(13) + 'I''m a marionette, see my pirouette, round and round' + CHAR(13) + 'I''m a marionette, I''m a marionette, just a silly old clown' + CHAR(13) + CHAR(13) + CHAR(13) + 'Like a doll, like a puppet with no will at all' + CHAR(13) + 'And somebody told me how to talk, how to walk, how to fall' + CHAR(13) + CHAR(13) + CHAR(13) + 'Can''t complain, I''ve got no-one but myself to blame' + CHAR(13) + 'Something''s happening I can''t control, lost my hold, is it safe?' + CHAR(13) + CHAR(13) + CHAR(13) + 'I''m a marionette, just a marionette, pull the string' + CHAR(13) + 'I''m a marionette, everybody''s pet, just as long as I sing' + CHAR(13) + 'I''m a marionette, see my pirouette, round and round' + CHAR(13) + 'I''m a marionette, I''m a marionette, just a silly old clown' + CHAR(13) + CHAR(13) + CHAR(13) + '"Look this way, just a little smile," is what they say' + CHAR(13) + '"You look better on the photograph if you laugh, that''s okay"' + CHAR(13) + CHAR(13) + CHAR(13) + 'I''m a marionette, just a marionette, pull the string' + CHAR(13) + 'I''m a marionette, everybody''s pet, just as long as I sing' + CHAR(13) + 'I''m a marionette, see my pirouette, round and round' + CHAR(13) + 'I''m a marionette, I''m a marionette, just a silly old clown' + CHAR(13) + CHAR(13) + CHAR(13) + '"You''re so free," that''s what everybody''s telling me' + CHAR(13) + 'Yet I feel I''m like an outward-bound, pushed around, refugee.', '20190115 08:41:00 AM')
GO

UPDATE [dbo].[Articles] SET Body=REPLACE(Body, '\\n', '\n')
GO

--Categories
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
          ,(3, 3)
          ,(4, 3)
		  ,(5, 3)

GO

--Comments
INSERT INTO [dbo].[Comments]
           ([Body], [Sender], [Article_Id])
     VALUES
           (N'In the rich man''s world', N'Abbba', 4)
          ,(N'Test message', N'Test sender', 4)
		  ,(N'Nice song man!', N'Никола Тесла', 5)
          ,(N'1337', N'228', 5)
GO
