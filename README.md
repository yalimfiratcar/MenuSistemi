# AcunMedya Akademi Back-End Temel E�itim Projesi - Men� Sistemi

AcunMedya Akademi'deki Back-End Temel E�itim kapsam�nda geli�tirdi�im Men� Sistemi Projesi.

Projeyi �al��t�rabilmek i�in, a�a��daki SQL scriptini veritaban�n�za eklemeniz gerekmektedir:

```sql
USE [MenuSistemiDB]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 18.03.2025 14:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
 CONSTRAINT [PK_TBLCategory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Menu]    Script Date: 18.03.2025 14:38:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Menu](
	[MenuId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NULL,
	[FoodName] [varchar](50) NULL,
	[FoodPrice] [int] NULL,
	[FoodImageUrl] [varchar](200) NULL,
	[FoodDescription] [varchar](100) NULL,
 CONSTRAINT [PK_TBLMenu] PRIMARY KEY CLUSTERED 
(
	[MenuId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (1, N'Ba�lang��')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (2, N'AnaYemek')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (3, N'Tatl�lar')
INSERT [dbo].[Category] ([Id], [CategoryName]) VALUES (4, N'��ecekler')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Menu] ON 

INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (2, 1, N'Fit Tabak', 460, N'https://pardonai-images.s3.eu-central-1.amazonaws.com/products/f37f44bb-4f5b-4e31-83df-e96e73965e35.webp', N'Sucuk+Yumurta+So�an')
INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (5, 3, N'Muhallebi', 20, N'https://i.nefisyemektarifleri.com/2021/10/15/en-kolay-muhallebi-1.jpg', N'Az �ekerli')
INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (6, 3, N'Bal', 30, N'https://bilimgenc.tubitak.gov.tr/sites/default/files/styles/bp-770px-custom_user_desktop_1x/public/Bal.jpg?itok=_7rHMQVl', N'Organik')
INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (7, 4, N'�ay', 5, N'https://www.popeyes.com.tr/cmsfiles/products/cay.png?v=305', N'Taze')
INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (8, 4, N'Kahve', 7, N'https://img-kahvedunyasi.mncdn.com/kahvedunyasi/product/500x500/37bfe_Orta_Kavrulmus_Turk_Kahvesi_250g.jpg', N'Gran�r')
INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (14, 1, N'Sucuklu Yumurta', 100, N'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ9nT4q8U7n_4R5nbZ4a33rwHmY9lydd7ixdw&s', N'Sucuk+Yumurta')
INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (15, 1, N'Kepekli Tost', 130, N'https://pardonai-images.s3.eu-central-1.amazonaws.com/products/04d26860-9d52-4c31-b9ca-df5c98f7fd28.webp', N'�ift Ka�arl�')
INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (16, 1, N'Tad�m Taba��', 380, N'https://pardonai-images.s3.eu-central-1.amazonaws.com/products/b4a0b32f-0375-4b05-983b-6a209a2e03cc.webp', N'MUAMMARA, G�R�T EZME, MAMZANA, TULUM PEYNIRLI PANCAR')
INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (17, 2, N'Tereya��nda Bonfile', 890, N'https://pardonai-images.s3.eu-central-1.amazonaws.com/products/d545ba8e-7fdd-41b7-a15a-b027d2d83305.webp', N'200gr dana bonfile, tereya�� soya sos ve ha�lanm�� sebze')
INSERT [dbo].[Menu] ([MenuId], [CategoryId], [FoodName], [FoodPrice], [FoodImageUrl], [FoodDescription]) VALUES (18, 2, N'Kar���k Izgara', 2450, N'https://pardonai-images.s3.eu-central-1.amazonaws.com/products/20cde0ec-399d-40b3-91f3-8c183a4c746c.webp', N'Kar���k �zgara')
SET IDENTITY_INSERT [dbo].[Menu] OFF
GO

```