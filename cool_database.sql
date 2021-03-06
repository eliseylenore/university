USE [cool_database]
GO
/****** Object:  Table [dbo].[classes]    Script Date: 2/28/2017 4:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[number] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[classes_departments]    Script Date: 2/28/2017 4:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes_departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[class_id] [int] NULL,
	[department_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[classes_students]    Script Date: 2/28/2017 4:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[classes_students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[class_id] [int] NULL,
	[student_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departments]    Script Date: 2/28/2017 4:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[departments_students]    Script Date: 2/28/2017 4:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[departments_students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[department_id] [int] NULL,
	[student_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[students]    Script Date: 2/28/2017 4:40:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[students](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[classes] ON 

INSERT [dbo].[classes] ([id], [name], [number]) VALUES (3, N'Hello', 9123)
SET IDENTITY_INSERT [dbo].[classes] OFF
SET IDENTITY_INSERT [dbo].[departments] ON 

INSERT [dbo].[departments] ([id], [name]) VALUES (1, N'What')
INSERT [dbo].[departments] ([id], [name]) VALUES (2, N'Math')
INSERT [dbo].[departments] ([id], [name]) VALUES (3, N'asdfasd')
INSERT [dbo].[departments] ([id], [name]) VALUES (4, N'asdfasd')
INSERT [dbo].[departments] ([id], [name]) VALUES (5, N'Holy Cow')
INSERT [dbo].[departments] ([id], [name]) VALUES (6, N'Holy Cow')
INSERT [dbo].[departments] ([id], [name]) VALUES (7, N'Holy Cow')
INSERT [dbo].[departments] ([id], [name]) VALUES (8, N'Holy Cow')
INSERT [dbo].[departments] ([id], [name]) VALUES (9, N'Holy Cow')
SET IDENTITY_INSERT [dbo].[departments] OFF
SET IDENTITY_INSERT [dbo].[students] ON 

INSERT [dbo].[students] ([id], [name]) VALUES (4, N'asdfasdf')
SET IDENTITY_INSERT [dbo].[students] OFF
