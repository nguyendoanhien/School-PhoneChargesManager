USE [Sim]
GO
/****** Object:  Table [dbo].[Hd]    Script Date: 16/04/2019 12:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hd](
	[MaHd] [int] IDENTITY(1,1) NOT NULL,
	[MaKh] [int] NULL,
	[TongTien] [varchar](255) NULL,
 CONSTRAINT [PK_Hd] PRIMARY KEY CLUSTERED 
(
	[MaHd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HdDk]    Script Date: 16/04/2019 12:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HdDk](
	[MaHdDk] [int] IDENTITY(1,1) NOT NULL,
	[MaKh] [int] NULL,
	[ChiPhiDk] [varchar](255) NULL,
 CONSTRAINT [PK_HdDk] PRIMARY KEY CLUSTERED 
(
	[MaHdDk] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Kg]    Script Date: 16/04/2019 12:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kg](
	[MaKg] [int] NOT NULL,
	[GioBd] [time](7) NULL,
	[GioKt] [time](7) NULL,
	[GiaCuoc] [nvarchar](255) NULL,
 CONSTRAINT [PK_Kg] PRIMARY KEY CLUSTERED 
(
	[MaKg] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Kh]    Script Date: 16/04/2019 12:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kh](
	[MaKh] [int] IDENTITY(1,1) NOT NULL,
	[TenKh] [nvarchar](255) NULL,
	[NgheNghiep] [nvarchar](255) NULL,
	[ChucVu] [nvarchar](255) NULL,
	[DiaChi] [nvarchar](255) NULL,
 CONSTRAINT [PK_Kh] PRIMARY KEY CLUSTERED 
(
	[MaKh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sd]    Script Date: 16/04/2019 12:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sd](
	[MaSd] [int] IDENTITY(1,1) NOT NULL,
	[MaHd] [int] NULL,
	[MaSim] [int] NULL,
	[TgBd] [datetime] NULL,
	[TgKt] [datetime] NULL,
	[TongTien] [varchar](255) NULL,
 CONSTRAINT [PK_Sd] PRIMARY KEY CLUSTERED 
(
	[MaSd] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Sim]    Script Date: 16/04/2019 12:49:40 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sim](
	[MaSim] [int] IDENTITY(1,1) NOT NULL,
	[SoSim] [varchar](255) NULL,
	[MaHdDk] [int] NULL,
 CONSTRAINT [PK_Sim] PRIMARY KEY CLUSTERED 
(
	[MaSim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Hd] ON 

INSERT [dbo].[Hd] ([MaHd], [MaKh], [TongTien]) VALUES (1, 1, N'5589600')
SET IDENTITY_INSERT [dbo].[Hd] OFF
SET IDENTITY_INSERT [dbo].[HdDk] ON 

INSERT [dbo].[HdDk] ([MaHdDk], [MaKh], [ChiPhiDk]) VALUES (1, 1, N'50000')
INSERT [dbo].[HdDk] ([MaHdDk], [MaKh], [ChiPhiDk]) VALUES (2, 1, N'50000')
INSERT [dbo].[HdDk] ([MaHdDk], [MaKh], [ChiPhiDk]) VALUES (3, 1, N'50000')
INSERT [dbo].[HdDk] ([MaHdDk], [MaKh], [ChiPhiDk]) VALUES (4, 1, N'50000')
INSERT [dbo].[HdDk] ([MaHdDk], [MaKh], [ChiPhiDk]) VALUES (5, 2, N'50000')
SET IDENTITY_INSERT [dbo].[HdDk] OFF
INSERT [dbo].[Kg] ([MaKg], [GioBd], [GioKt], [GiaCuoc]) VALUES (1, CAST(0x0700D85EAC3A0000 AS Time), CAST(0x070058A5C8C00000 AS Time), N'200')
INSERT [dbo].[Kg] ([MaKg], [GioBd], [GioKt], [GiaCuoc]) VALUES (2, CAST(0x070058A5C8C00000 AS Time), CAST(0x0700D85EAC3A0000 AS Time), N'150')
SET IDENTITY_INSERT [dbo].[Kh] ON 

INSERT [dbo].[Kh] ([MaKh], [TenKh], [NgheNghiep], [ChucVu], [DiaChi]) VALUES (1, N'Heo', N'Bán thịt heo', N'Giám đốc', N'Chuồng heo')
INSERT [dbo].[Kh] ([MaKh], [TenKh], [NgheNghiep], [ChucVu], [DiaChi]) VALUES (2, N'Gà', N'Bán thịt gà', N'Đầu bếp', N'Chuồng gà')
INSERT [dbo].[Kh] ([MaKh], [TenKh], [NgheNghiep], [ChucVu], [DiaChi]) VALUES (3, N'Vịt', N'Bán thịt vịt', N'Chăn nuôi', N'Chuồng vịt')
SET IDENTITY_INSERT [dbo].[Kh] OFF
SET IDENTITY_INSERT [dbo].[Sim] ON 

INSERT [dbo].[Sim] ([MaSim], [SoSim], [MaHdDk]) VALUES (1, N'0001', 2)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [MaHdDk]) VALUES (2, N'0002', 3)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [MaHdDk]) VALUES (3, N'0003', 4)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [MaHdDk]) VALUES (4, N'0004', 4)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [MaHdDk]) VALUES (5, N'0005', 4)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [MaHdDk]) VALUES (6, N'0006', 5)
INSERT [dbo].[Sim] ([MaSim], [SoSim], [MaHdDk]) VALUES (7, N'0007', 5)
SET IDENTITY_INSERT [dbo].[Sim] OFF
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Sim]    Script Date: 16/04/2019 12:49:40 AM ******/
ALTER TABLE [dbo].[Sim] ADD  CONSTRAINT [IX_Sim] UNIQUE NONCLUSTERED 
(
	[SoSim] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Hd]  WITH CHECK ADD  CONSTRAINT [FK_Hd_Kh] FOREIGN KEY([MaKh])
REFERENCES [dbo].[Kh] ([MaKh])
GO
ALTER TABLE [dbo].[Hd] CHECK CONSTRAINT [FK_Hd_Kh]
GO
ALTER TABLE [dbo].[HdDk]  WITH CHECK ADD  CONSTRAINT [FK_HdDk_Kh] FOREIGN KEY([MaKh])
REFERENCES [dbo].[Kh] ([MaKh])
GO
ALTER TABLE [dbo].[HdDk] CHECK CONSTRAINT [FK_HdDk_Kh]
GO
ALTER TABLE [dbo].[Sd]  WITH CHECK ADD  CONSTRAINT [FK_Sd_Hd] FOREIGN KEY([MaHd])
REFERENCES [dbo].[Hd] ([MaHd])
GO
ALTER TABLE [dbo].[Sd] CHECK CONSTRAINT [FK_Sd_Hd]
GO
ALTER TABLE [dbo].[Sd]  WITH CHECK ADD  CONSTRAINT [FK_Sd_Sim] FOREIGN KEY([MaSim])
REFERENCES [dbo].[Sim] ([MaSim])
GO
ALTER TABLE [dbo].[Sd] CHECK CONSTRAINT [FK_Sd_Sim]
GO
ALTER TABLE [dbo].[Sim]  WITH CHECK ADD  CONSTRAINT [FK_Sim_HdDk] FOREIGN KEY([MaHdDk])
REFERENCES [dbo].[HdDk] ([MaHdDk])
GO
ALTER TABLE [dbo].[Sim] CHECK CONSTRAINT [FK_Sim_HdDk]
GO
