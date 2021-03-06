USE [WebFramework]
GO
/****** Object:  ForeignKey [FK_Application_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:20 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Application_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[Application]'))
ALTER TABLE [dbo].[Application] DROP CONSTRAINT [FK_Application_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_ApplicationAlias_Application]    Script Date: 09/21/2012 23:10:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationAlias_Application]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationAlias]'))
ALTER TABLE [dbo].[ApplicationAlias] DROP CONSTRAINT [FK_ApplicationAlias_Application]
GO
/****** Object:  ForeignKey [FK_ApplicationAlias_EntityHistory]    Script Date: 09/21/2012 23:10:22 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationAlias_EntityHistory]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationAlias]'))
ALTER TABLE [dbo].[ApplicationAlias] DROP CONSTRAINT [FK_ApplicationAlias_EntityHistory]
GO
/****** Object:  ForeignKey [FK_ContentItem_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:23 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContentItem_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContentItem]'))
ALTER TABLE [dbo].[ContentItem] DROP CONSTRAINT [FK_ContentItem_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_ContentPart_ContentItem]    Script Date: 09/21/2012 23:10:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContentPart_ContentItem]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContentPart]'))
ALTER TABLE [dbo].[ContentPart] DROP CONSTRAINT [FK_ContentPart_ContentItem]
GO
/****** Object:  ForeignKey [FK_ContentPart_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:24 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContentPart_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContentPart]'))
ALTER TABLE [dbo].[ContentPart] DROP CONSTRAINT [FK_ContentPart_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_Employee_User]    Script Date: 09/21/2012 23:10:25 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Employee_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Employee]'))
ALTER TABLE [dbo].[Employee] DROP CONSTRAINT [FK_Employee_User]
GO
/****** Object:  ForeignKey [FK_EntityHistoryComplex_EntityLog_FirstLog]    Script Date: 09/21/2012 23:10:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntityHistoryComplex_EntityLog_FirstLog]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntityHistoryComplex]'))
ALTER TABLE [dbo].[EntityHistoryComplex] DROP CONSTRAINT [FK_EntityHistoryComplex_EntityLog_FirstLog]
GO
/****** Object:  ForeignKey [FK_EntityHistoryComplex_EntityLog_LastLog]    Script Date: 09/21/2012 23:10:29 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntityHistoryComplex_EntityLog_LastLog]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntityHistoryComplex]'))
ALTER TABLE [dbo].[EntityHistoryComplex] DROP CONSTRAINT [FK_EntityHistoryComplex_EntityLog_LastLog]
GO
/****** Object:  ForeignKey [FK_EntityLog_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:31 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntityLog_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntityLog]'))
ALTER TABLE [dbo].[EntityLog] DROP CONSTRAINT [FK_EntityLog_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_Translation_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:32 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Translation_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[Translation]'))
ALTER TABLE [dbo].[Translation] DROP CONSTRAINT [FK_Translation_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_User_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:34 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_UserConnections_User_ConnectionId]    Script Date: 09/21/2012 23:10:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserConnections_User_ConnectionId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserConnections]'))
ALTER TABLE [dbo].[UserConnections] DROP CONSTRAINT [FK_UserConnections_User_ConnectionId]
GO
/****** Object:  ForeignKey [FK_UserConnections_User_UserId]    Script Date: 09/21/2012 23:10:35 ******/
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserConnections_User_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserConnections]'))
ALTER TABLE [dbo].[UserConnections] DROP CONSTRAINT [FK_UserConnections_User_UserId]
GO
/****** Object:  Table [dbo].[ContentPart]    Script Date: 09/21/2012 23:10:24 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentPart]') AND type in (N'U'))
DROP TABLE [dbo].[ContentPart]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 09/21/2012 23:10:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
DROP TABLE [dbo].[Employee]
GO
/****** Object:  Table [dbo].[UserConnections]    Script Date: 09/21/2012 23:10:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserConnections]') AND type in (N'U'))
DROP TABLE [dbo].[UserConnections]
GO
/****** Object:  Table [dbo].[ApplicationAlias]    Script Date: 09/21/2012 23:10:21 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationAlias]') AND type in (N'U'))
DROP TABLE [dbo].[ApplicationAlias]
GO
/****** Object:  Table [dbo].[ContentItem]    Script Date: 09/21/2012 23:10:23 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentItem]') AND type in (N'U'))
DROP TABLE [dbo].[ContentItem]
GO
/****** Object:  Table [dbo].[User]    Script Date: 09/21/2012 23:10:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[EntityLog]    Script Date: 09/21/2012 23:10:31 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntityLog]') AND type in (N'U'))
DROP TABLE [dbo].[EntityLog]
GO
/****** Object:  Table [dbo].[EntityHistory]    Script Date: 09/21/2012 23:10:27 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntityHistory]') AND type in (N'U'))
DROP TABLE [dbo].[EntityHistory]
GO
/****** Object:  Table [dbo].[Application]    Script Date: 09/21/2012 23:10:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Application]') AND type in (N'U'))
DROP TABLE [dbo].[Application]
GO
/****** Object:  Table [dbo].[EntityHistoryComplex]    Script Date: 09/21/2012 23:10:29 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntityHistoryComplex]') AND type in (N'U'))
DROP TABLE [dbo].[EntityHistoryComplex]
GO
/****** Object:  Table [dbo].[Translation]    Script Date: 09/21/2012 23:10:32 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Translation]') AND type in (N'U'))
DROP TABLE [dbo].[Translation]
GO
/****** Object:  Table [dbo].[EntityHistory]    Script Date: 09/21/2012 23:10:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntityHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EntityHistory](
	[Id] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [varchar](512) NOT NULL,
	[LastModifiedAt] [datetime] NULL,
	[LastModifiedBy] [varchar](512) NULL,
 CONSTRAINT [PK_EntityHistory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ApplicationAlias]    Script Date: 09/21/2012 23:10:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ApplicationAlias]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ApplicationAlias](
	[Id] [uniqueidentifier] NOT NULL,
	[ApplicationId] [uniqueidentifier] NOT NULL,
	[Url] [varchar](512) NOT NULL,
 CONSTRAINT [PK_ApplicationAlias] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_ApplicationAlias_ApplicationId_Url] UNIQUE NONCLUSTERED 
(
	[ApplicationId] ASC,
	[Url] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntityHistoryComplex]    Script Date: 09/21/2012 23:10:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntityHistoryComplex]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EntityHistoryComplex](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstLogId] [uniqueidentifier] NULL,
	[LastLogId] [uniqueidentifier] NULL,
	[IsActive] [bit] NOT NULL,
	[Views] [bigint] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [varchar](512) NOT NULL,
	[LastModifiedAt] [datetime] NULL,
	[LastModifiedBy] [varchar](512) NULL,
 CONSTRAINT [PK_EntityHistoryComplex] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentPart]    Script Date: 09/21/2012 23:10:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentPart]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ContentPart](
	[Id] [uniqueidentifier] NOT NULL,
	[ContentItemId] [uniqueidentifier] NULL,
	[Name] [ntext] NOT NULL,
	[Details] [ntext] NOT NULL,
	[Position] [int] NULL,
 CONSTRAINT [PK_ContentPart] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 09/21/2012 23:10:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Employee](
	[Id] [uniqueidentifier] NOT NULL,
	[UserId] [uniqueidentifier] NOT NULL,
	[StartDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UserConnections]    Script Date: 09/21/2012 23:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserConnections]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserConnections](
	[UserId] [uniqueidentifier] NULL,
	[ConnectionId] [uniqueidentifier] NULL,
	[ConnectionDate] [datetime] NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Application]    Script Date: 09/21/2012 23:10:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Application]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Application](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](512) NOT NULL,
	[Description] [ntext] NULL,
	[MainUrl] [varchar](512) NOT NULL,
 CONSTRAINT [PK_Application] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_Application_MainUrl] UNIQUE NONCLUSTERED 
(
	[MainUrl] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Translation]    Script Date: 09/21/2012 23:10:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Translation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Translation](
	[Id] [uniqueidentifier] NOT NULL,
	[Keyword] [varchar](512) NOT NULL,
	[Language] [char](2) NOT NULL,
	[Value] [ntext] NOT NULL,
 CONSTRAINT [PK_Translation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EntityLog]    Script Date: 09/21/2012 23:10:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EntityLog]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EntityLog](
	[Id] [uniqueidentifier] NOT NULL,
	[EntityHistoryId] [uniqueidentifier] NOT NULL,
	[CreatedAt] [datetime] NOT NULL,
	[CreatedBy] [varchar](512) NOT NULL,
	[LogMessage] [ntext] NOT NULL,
	[LogContentText] [ntext] NULL,
 CONSTRAINT [PK_EntityLog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContentItem]    Script Date: 09/21/2012 23:10:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ContentItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ContentItem](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [ntext] NOT NULL,
	[Description] [ntext] NULL,
	[Keywords] [ntext] NULL,
 CONSTRAINT [PK_ContentItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[User]    Script Date: 09/21/2012 23:10:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[Id] [uniqueidentifier] NOT NULL,
	[Email] [varchar](512) NOT NULL,
	[Password] [varchar](512) NOT NULL,
	[DisplayName] [nvarchar](512) NULL,
	[TotalPoints] [bigint] NULL,
	[IsGuest] [bit] NOT NULL,
	[IsRoot] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [IX_User_Email] UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_Application_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:20 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Application_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[Application]'))
ALTER TABLE [dbo].[Application]  WITH CHECK ADD  CONSTRAINT [FK_Application_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[Application] CHECK CONSTRAINT [FK_Application_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_ApplicationAlias_Application]    Script Date: 09/21/2012 23:10:22 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationAlias_Application]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationAlias]'))
ALTER TABLE [dbo].[ApplicationAlias]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationAlias_Application] FOREIGN KEY([ApplicationId])
REFERENCES [dbo].[Application] ([Id])
GO
ALTER TABLE [dbo].[ApplicationAlias] CHECK CONSTRAINT [FK_ApplicationAlias_Application]
GO
/****** Object:  ForeignKey [FK_ApplicationAlias_EntityHistory]    Script Date: 09/21/2012 23:10:22 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ApplicationAlias_EntityHistory]') AND parent_object_id = OBJECT_ID(N'[dbo].[ApplicationAlias]'))
ALTER TABLE [dbo].[ApplicationAlias]  WITH CHECK ADD  CONSTRAINT [FK_ApplicationAlias_EntityHistory] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistory] ([Id])
GO
ALTER TABLE [dbo].[ApplicationAlias] CHECK CONSTRAINT [FK_ApplicationAlias_EntityHistory]
GO
/****** Object:  ForeignKey [FK_ContentItem_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:23 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContentItem_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContentItem]'))
ALTER TABLE [dbo].[ContentItem]  WITH CHECK ADD  CONSTRAINT [FK_ContentItem_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[ContentItem] CHECK CONSTRAINT [FK_ContentItem_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_ContentPart_ContentItem]    Script Date: 09/21/2012 23:10:24 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContentPart_ContentItem]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContentPart]'))
ALTER TABLE [dbo].[ContentPart]  WITH CHECK ADD  CONSTRAINT [FK_ContentPart_ContentItem] FOREIGN KEY([ContentItemId])
REFERENCES [dbo].[ContentItem] ([Id])
GO
ALTER TABLE [dbo].[ContentPart] CHECK CONSTRAINT [FK_ContentPart_ContentItem]
GO
/****** Object:  ForeignKey [FK_ContentPart_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:24 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ContentPart_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[ContentPart]'))
ALTER TABLE [dbo].[ContentPart]  WITH CHECK ADD  CONSTRAINT [FK_ContentPart_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[ContentPart] CHECK CONSTRAINT [FK_ContentPart_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_Employee_User]    Script Date: 09/21/2012 23:10:25 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Employee_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[Employee]'))
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_User]
GO
/****** Object:  ForeignKey [FK_EntityHistoryComplex_EntityLog_FirstLog]    Script Date: 09/21/2012 23:10:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntityHistoryComplex_EntityLog_FirstLog]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntityHistoryComplex]'))
ALTER TABLE [dbo].[EntityHistoryComplex]  WITH CHECK ADD  CONSTRAINT [FK_EntityHistoryComplex_EntityLog_FirstLog] FOREIGN KEY([FirstLogId])
REFERENCES [dbo].[EntityLog] ([Id])
GO
ALTER TABLE [dbo].[EntityHistoryComplex] CHECK CONSTRAINT [FK_EntityHistoryComplex_EntityLog_FirstLog]
GO
/****** Object:  ForeignKey [FK_EntityHistoryComplex_EntityLog_LastLog]    Script Date: 09/21/2012 23:10:29 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntityHistoryComplex_EntityLog_LastLog]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntityHistoryComplex]'))
ALTER TABLE [dbo].[EntityHistoryComplex]  WITH CHECK ADD  CONSTRAINT [FK_EntityHistoryComplex_EntityLog_LastLog] FOREIGN KEY([LastLogId])
REFERENCES [dbo].[EntityLog] ([Id])
GO
ALTER TABLE [dbo].[EntityHistoryComplex] CHECK CONSTRAINT [FK_EntityHistoryComplex_EntityLog_LastLog]
GO
/****** Object:  ForeignKey [FK_EntityLog_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:31 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_EntityLog_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[EntityLog]'))
ALTER TABLE [dbo].[EntityLog]  WITH CHECK ADD  CONSTRAINT [FK_EntityLog_EntityHistoryComplex] FOREIGN KEY([EntityHistoryId])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[EntityLog] CHECK CONSTRAINT [FK_EntityLog_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_Translation_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:32 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Translation_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[Translation]'))
ALTER TABLE [dbo].[Translation]  WITH CHECK ADD  CONSTRAINT [FK_Translation_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[Translation] CHECK CONSTRAINT [FK_Translation_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_User_EntityHistoryComplex]    Script Date: 09/21/2012 23:10:34 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_EntityHistoryComplex]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_EntityHistoryComplex] FOREIGN KEY([Id])
REFERENCES [dbo].[EntityHistoryComplex] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_EntityHistoryComplex]
GO
/****** Object:  ForeignKey [FK_UserConnections_User_ConnectionId]    Script Date: 09/21/2012 23:10:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserConnections_User_ConnectionId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserConnections]'))
ALTER TABLE [dbo].[UserConnections]  WITH CHECK ADD  CONSTRAINT [FK_UserConnections_User_ConnectionId] FOREIGN KEY([ConnectionId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserConnections] CHECK CONSTRAINT [FK_UserConnections_User_ConnectionId]
GO
/****** Object:  ForeignKey [FK_UserConnections_User_UserId]    Script Date: 09/21/2012 23:10:35 ******/
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserConnections_User_UserId]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserConnections]'))
ALTER TABLE [dbo].[UserConnections]  WITH CHECK ADD  CONSTRAINT [FK_UserConnections_User_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserConnections] CHECK CONSTRAINT [FK_UserConnections_User_UserId]
GO
