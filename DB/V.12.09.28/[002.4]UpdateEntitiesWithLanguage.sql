-- [ContentItem]
ALTER TABLE [ContentItem] ADD [LanguageId] [uniqueidentifier] NULL;
GO

ALTER TABLE [dbo].[ContentItem]  ADD  CONSTRAINT [FK_ContentItem_DataLine] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[DataLine] ([Id])
GO


UPDATE [ContentItem] SET [LanguageId] = (
	SELECT [Id] from [DataLine] where [Code] = 'vi' AND [CatalogId] = (
		SELECT [Id] from [Catalog] where [Code] = 'c.languages'
	)
)
GO

ALTER TABLE [ContentItem] ALTER COLUMN [LanguageId] [uniqueidentifier] NOT NULL
GO


-- [User]
ALTER TABLE [User] ADD [LanguageId] [uniqueidentifier] NULL;
GO

ALTER TABLE [dbo].[User]  ADD  CONSTRAINT [FK_User_DataLine] FOREIGN KEY([LanguageId])
REFERENCES [dbo].[DataLine] ([Id])
GO


UPDATE [User] SET [LanguageId] = (
	SELECT [Id] from [DataLine] where [Code] = 'vi' AND [CatalogId] = (
		SELECT [Id] from [Catalog] where [Code] = 'c.languages'
	)
)
GO
