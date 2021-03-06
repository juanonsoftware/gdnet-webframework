CREATE TABLE [dbo].[UserCustomProperty](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[Name] nvarchar(256) NOT NULL,
	[Value] [ntext] NULL,
	CONSTRAINT [PK_UserCustomProperty] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)
)
GO

ALTER TABLE [dbo].[UserCustomProperty]  WITH CHECK ADD  CONSTRAINT [FK_UserCustomProperty_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO

