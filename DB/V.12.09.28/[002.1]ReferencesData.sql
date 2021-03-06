CREATE TABLE [dbo].[Catalog](
	[Id] [uniqueidentifier] NOT NULL,
	[Code] [varchar](512) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Description] [ntext] NULL,
	[IsCustomizable] [bit] NOT NULL,
	CONSTRAINT [PK_Catalog] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

ALTER TABLE [dbo].[Catalog]  ADD  CONSTRAINT [FK_Catalog_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO

ALTER TABLE [dbo].[Catalog]  ADD  CONSTRAINT [UK_Catalog_Code] UNIQUE([Code])
GO

CREATE TABLE [dbo].[DataLine](
	[Id] [uniqueidentifier] NOT NULL,
	[CatalogId] [uniqueidentifier] NULL,
	[ParentId] [uniqueidentifier] NULL,
	[Code] [varchar](512) NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Description] [ntext] NULL,
	[Position] [int] NOT NULL,
	CONSTRAINT [PK_DataLine] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

ALTER TABLE [dbo].[DataLine]  ADD  CONSTRAINT [FK_DataLine_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO

ALTER TABLE [dbo].[DataLine]  ADD  CONSTRAINT [FK_DataLine_Catalog] FOREIGN KEY([CatalogId])
REFERENCES [dbo].[Catalog] ([Id])
GO

ALTER TABLE [dbo].[DataLine]  ADD  CONSTRAINT [FK_DataLine_DataLine] FOREIGN KEY([ParentId])
REFERENCES [dbo].[DataLine] ([Id])
GO

ALTER TABLE [dbo].[DataLine]  ADD  CONSTRAINT [UK_DataLine_Code_Catalog] UNIQUE([Code], [CatalogId])
GO
