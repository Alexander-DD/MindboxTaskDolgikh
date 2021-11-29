USE [MarketBase]
GO
/****** Object:  Table [dbo].[category]    Script Date: 28.11.2021 22:53:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product]    Script Date: 28.11.2021 22:53:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[product_category]    Script Date: 28.11.2021 22:53:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product_category](
	[productId] [int] NULL,
	[categoryId] [int] NULL
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[category] ON 
GO
INSERT [dbo].[category] ([id], [name]) VALUES (1, N'Молочные изделия')
GO
INSERT [dbo].[category] ([id], [name]) VALUES (2, N'Выпечка')
GO
INSERT [dbo].[category] ([id], [name]) VALUES (3, N'Мясные изделия')
GO
INSERT [dbo].[category] ([id], [name]) VALUES (4, N'Овощи')
GO
INSERT [dbo].[category] ([id], [name]) VALUES (5, N'Косметика')
GO
INSERT [dbo].[category] ([id], [name]) VALUES (6, N'Бижутерия')
GO
INSERT [dbo].[category] ([id], [name]) VALUES (7, N'Инопланетные товары')
GO
SET IDENTITY_INSERT [dbo].[category] OFF
GO
SET IDENTITY_INSERT [dbo].[product] ON 
GO
INSERT [dbo].[product] ([id], [name]) VALUES (1, N'Куриный суп ')
GO
INSERT [dbo].[product] ([id], [name]) VALUES (2, N'Пирог с капустой')
GO
INSERT [dbo].[product] ([id], [name]) VALUES (3, N'Сыр')
GO
INSERT [dbo].[product] ([id], [name]) VALUES (4, N'Апельсины')
GO
INSERT [dbo].[product] ([id], [name]) VALUES (5, N'Колбаса')
GO
INSERT [dbo].[product] ([id], [name]) VALUES (6, N'Картофель с говядиной')
GO
INSERT [dbo].[product] ([id], [name]) VALUES (7, N'Огурцы')
GO
INSERT [dbo].[product] ([id], [name]) VALUES (8, N'Куртка')
GO
SET IDENTITY_INSERT [dbo].[product] OFF
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (1, 3)
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (1, 4)
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (2, 2)
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (2, 4)
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (3, 1)
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (4, NULL)
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (5, 3)
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (6, 3)
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (6, 4)
GO
INSERT [dbo].[product_category] ([productId], [categoryId]) VALUES (7, 4)
GO