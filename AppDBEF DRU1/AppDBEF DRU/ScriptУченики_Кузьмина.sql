USE [lesuser28]
GO
/****** Object:  Table [dbo].[Предметы]    Script Date: 02.10.2023 11:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Предметы](
	[ID_Предмета] [int] IDENTITY(1,1) NOT NULL,
	[Название] [nvarchar](50) NOT NULL,
	[Часы] [int] NOT NULL,
 CONSTRAINT [PK_Предметы] PRIMARY KEY CLUSTERED 
(
	[ID_Предмета] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ученики_Кузьмина]    Script Date: 02.10.2023 11:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ученики_Кузьмина](
	[ID_ученика] [int] IDENTITY(1,1) NOT NULL,
	[Фамилия] [nvarchar](50) NULL,
	[ID_предмета] [int] NULL,
	[ID_школы] [int] NULL,
	[Баллы] [float] NULL,
 CONSTRAINT [PK_Ученики_Кузьмина] PRIMARY KEY CLUSTERED 
(
	[ID_ученика] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Школы]    Script Date: 02.10.2023 11:32:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Школы](
	[ID_Школы] [int] IDENTITY(1,1) NOT NULL,
	[Название] [nvarchar](50) NULL,
 CONSTRAINT [PK_Школы] PRIMARY KEY CLUSTERED 
(
	[ID_Школы] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Предметы] ON 

INSERT [dbo].[Предметы] ([ID_Предмета], [Название], [Часы]) VALUES (1, N'Математика', 100)
INSERT [dbo].[Предметы] ([ID_Предмета], [Название], [Часы]) VALUES (2, N'Физика', 58)
INSERT [dbo].[Предметы] ([ID_Предмета], [Название], [Часы]) VALUES (3, N'Русский язык', 150)
INSERT [dbo].[Предметы] ([ID_Предмета], [Название], [Часы]) VALUES (4, N'Химия', 48)
SET IDENTITY_INSERT [dbo].[Предметы] OFF
GO
SET IDENTITY_INSERT [dbo].[Ученики_Кузьмина] ON 

INSERT [dbo].[Ученики_Кузьмина] ([ID_ученика], [Фамилия], [ID_предмета], [ID_школы], [Баллы]) VALUES (1, N'Кузьмина', 1, 4, 99.5)
INSERT [dbo].[Ученики_Кузьмина] ([ID_ученика], [Фамилия], [ID_предмета], [ID_школы], [Баллы]) VALUES (2, N'Чуприна', 2, 4, 100)
INSERT [dbo].[Ученики_Кузьмина] ([ID_ученика], [Фамилия], [ID_предмета], [ID_школы], [Баллы]) VALUES (3, N'Жаворонков', 3, 4, 25.6)
INSERT [dbo].[Ученики_Кузьмина] ([ID_ученика], [Фамилия], [ID_предмета], [ID_школы], [Баллы]) VALUES (4, N'Паршиков', 2, 2, 45.6)
INSERT [dbo].[Ученики_Кузьмина] ([ID_ученика], [Фамилия], [ID_предмета], [ID_школы], [Баллы]) VALUES (5, N'Гаврилов', 3, 2, 59.5)
INSERT [dbo].[Ученики_Кузьмина] ([ID_ученика], [Фамилия], [ID_предмета], [ID_школы], [Баллы]) VALUES (7, N'Кайнов', 4, 3, 45)
INSERT [dbo].[Ученики_Кузьмина] ([ID_ученика], [Фамилия], [ID_предмета], [ID_школы], [Баллы]) VALUES (8, N'Зорин', 4, 1, 82.3)
INSERT [dbo].[Ученики_Кузьмина] ([ID_ученика], [Фамилия], [ID_предмета], [ID_школы], [Баллы]) VALUES (9, N'Яковлев', 3, 1, 45)
INSERT [dbo].[Ученики_Кузьмина] ([ID_ученика], [Фамилия], [ID_предмета], [ID_школы], [Баллы]) VALUES (10, N'Глуховцева', 1, 3, 78)
SET IDENTITY_INSERT [dbo].[Ученики_Кузьмина] OFF
GO
SET IDENTITY_INSERT [dbo].[Школы] ON 

INSERT [dbo].[Школы] ([ID_Школы], [Название]) VALUES (1, N'Лицей')
INSERT [dbo].[Школы] ([ID_Школы], [Название]) VALUES (2, N'Гимназия')
INSERT [dbo].[Школы] ([ID_Школы], [Название]) VALUES (3, N'Школа')
INSERT [dbo].[Школы] ([ID_Школы], [Название]) VALUES (4, N'Колледж')
SET IDENTITY_INSERT [dbo].[Школы] OFF
GO
ALTER TABLE [dbo].[Ученики_Кузьмина]  WITH CHECK ADD  CONSTRAINT [FK_Ученики_Кузьмина_Предметы] FOREIGN KEY([ID_предмета])
REFERENCES [dbo].[Предметы] ([ID_Предмета])
GO
ALTER TABLE [dbo].[Ученики_Кузьмина] CHECK CONSTRAINT [FK_Ученики_Кузьмина_Предметы]
GO
ALTER TABLE [dbo].[Ученики_Кузьмина]  WITH CHECK ADD  CONSTRAINT [FK_Ученики_Кузьмина_Школы] FOREIGN KEY([ID_школы])
REFERENCES [dbo].[Школы] ([ID_Школы])
GO
ALTER TABLE [dbo].[Ученики_Кузьмина] CHECK CONSTRAINT [FK_Ученики_Кузьмина_Школы]
GO
