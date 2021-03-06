USE [master]
GO
/****** Object:  Database [ProcessMonitor]    Script Date: 11/04/2017 4:11:13 PM ******/
CREATE DATABASE [ProcessMonitor]
GO
USE [ProcessMonitor]
GO
/****** Object:  Table [dbo].[CUM]    Script Date: 11/04/2017 4:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CUM](
	[MSCum] [nchar](10) NOT NULL,
	[MSTram] [nchar](10) NULL,
	[TenCum] [nvarchar](150) NULL,
 CONSTRAINT [PK_CUM] PRIMARY KEY CLUSTERED 
(
	[MSCum] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HISTORY]    Script Date: 11/04/2017 4:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HISTORY](
	[MaTB] [nchar](10) NULL,
	[ThoiGian] [nchar](10) NULL,
	[MoTa] [nchar](10) NULL,
	[MaTrangThai] [datetime] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LOAITHIETBI]    Script Date: 11/04/2017 4:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAITHIETBI](
	[MaLoaiTB] [nchar](10) NOT NULL,
	[TenLoaiTB] [nvarchar](150) NULL,
	[GhiChu] [nvarchar](150) NULL,
 CONSTRAINT [PK_LOAITHIETBI] PRIMARY KEY CLUSTERED 
(
	[MaLoaiTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MAYTINH]    Script Date: 11/04/2017 4:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MAYTINH](
	[MaMT] [nchar](10) NOT NULL,
	[IP] [varchar](20) NULL,
	[MSCum] [nchar](10) NULL,
	[MAC] [varchar](50) NULL,
	[ProductID] [nvarchar](150) NULL,
 CONSTRAINT [PK_MAYTINH] PRIMARY KEY CLUSTERED 
(
	[MaMT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[THIETBI]    Script Date: 11/04/2017 4:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[THIETBI](
	[MaTB] [nchar](10) NOT NULL,
	[TenTB] [nvarchar](150) NULL,
	[MaLoaiTB] [nchar](10) NULL,
	[MaMT] [nchar](10) NULL,
	[IP] [varchar](20) NULL,
	[NgayLapDat] [datetime] NULL,
	[ViTri] [nvarchar](250) NULL,
 CONSTRAINT [PK_THIETBI] PRIMARY KEY CLUSTERED 
(
	[MaTB] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[TRAM]    Script Date: 11/04/2017 4:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRAM](
	[MSTram] [nchar](10) NOT NULL,
	[TenTram] [nvarchar](150) NULL,
 CONSTRAINT [PK_TRAM] PRIMARY KEY CLUSTERED 
(
	[MSTram] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TRANGTHAI]    Script Date: 11/04/2017 4:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TRANGTHAI](
	[MaTrangThai] [nchar](10) NOT NULL,
	[NoiDung] [nvarchar](150) NULL,
	[TieuChuanMin] [float] NULL,
	[TieuChuanMax] [float] NULL,
 CONSTRAINT [PK_TRANGTHAI] PRIMARY KEY CLUSTERED 
(
	[MaTrangThai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TRANGTHAITB]    Script Date: 11/04/2017 4:11:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TRANGTHAITB](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MaTB] [nchar](10) NULL,
	[ThoiGian] [datetime] NULL,
	[MoTa] [nvarchar](100) NULL,
	[TrangThai] [float] NULL,
	[MaTrangThai] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM001   ', N'TRAM001   ', N'Cum 1')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM002   ', N'TRAM001   ', N'Cum 2')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM003   ', N'TRAM001   ', N'Cum 3')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM004   ', N'TRAM001   ', N'Cum 4')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM005   ', N'TRAM002   ', N'Cum 1')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM006   ', N'TRAM002   ', N'Cum 2')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM007   ', N'TRAM002   ', N'Cum 3')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM008   ', N'TRAM002   ', N'Cum 4')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM009   ', N'TRAM003   ', N'Cum 1')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM010   ', N'TRAM003   ', N'Cum 2')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM011   ', N'TRAM003   ', N'Cum 3')
INSERT [dbo].[CUM] ([MSCum], [MSTram], [TenCum]) VALUES (N'TRAM012   ', N'TRAM003   ', N'Cum 4')
INSERT [dbo].[LOAITHIETBI] ([MaLoaiTB], [TenLoaiTB], [GhiChu]) VALUES (N'LTB001    ', N'Loại 1', NULL)
INSERT [dbo].[LOAITHIETBI] ([MaLoaiTB], [TenLoaiTB], [GhiChu]) VALUES (N'LTB002    ', N'Loai 2', NULL)
INSERT [dbo].[LOAITHIETBI] ([MaLoaiTB], [TenLoaiTB], [GhiChu]) VALUES (N'LTB003    ', N'Loai 3', NULL)
INSERT [dbo].[LOAITHIETBI] ([MaLoaiTB], [TenLoaiTB], [GhiChu]) VALUES (N'LTB004    ', N'Loai 4', NULL)
INSERT [dbo].[LOAITHIETBI] ([MaLoaiTB], [TenLoaiTB], [GhiChu]) VALUES (N'LTB005    ', N'Loại 5', NULL)
INSERT [dbo].[LOAITHIETBI] ([MaLoaiTB], [TenLoaiTB], [GhiChu]) VALUES (N'LTB006    ', N'Loại 6', NULL)
INSERT [dbo].[MAYTINH] ([MaMT], [IP], [MSCum], [MAC], [ProductID]) VALUES (N'MT001     ', N'192.168.1.2', N'CUM001    ', NULL, N'MFSFJF01')
INSERT [dbo].[MAYTINH] ([MaMT], [IP], [MSCum], [MAC], [ProductID]) VALUES (N'MT002     ', N'192.168.1.3', N'CUM001    ', NULL, N'MFSFSF02')
INSERT [dbo].[MAYTINH] ([MaMT], [IP], [MSCum], [MAC], [ProductID]) VALUES (N'MT003     ', N'192.168.1.4', N'CUM001    ', NULL, N'FSFSFSMFJF03')
INSERT [dbo].[MAYTINH] ([MaMT], [IP], [MSCum], [MAC], [ProductID]) VALUES (N'MT004     ', N'192.168.1.5', N'CUM002    ', N'', N'FSFSVV03')
INSERT [dbo].[MAYTINH] ([MaMT], [IP], [MSCum], [MAC], [ProductID]) VALUES (N'MT005     ', N'192.268.1.6', N'CUM002    ', NULL, N'FSSGGG05')
INSERT [dbo].[MAYTINH] ([MaMT], [IP], [MSCum], [MAC], [ProductID]) VALUES (N'MT006     ', N'192.168.1.7', N'CUM003    ', N'', N'FSFSVV03')
INSERT [dbo].[MAYTINH] ([MaMT], [IP], [MSCum], [MAC], [ProductID]) VALUES (N'MT007     ', N'192.268.1.8', N'CUM003    ', NULL, N'FSSGGG05')
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0001    ', N'Thiết bị 1', N'LTB001    ', N'MT001     ', N'122.121.12.1', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0002    ', N'Thiết bị 2', N'LTB001    ', N'MT001     ', N'122.121.12.2', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0003    ', N'Thiết bị 3', N'LTB002    ', N'MT001     ', N'122.121.12.3', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0004    ', N'Thiết bị 4', N'LTB003    ', N'MT001     ', N'122.121.12.4', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0005    ', N'Thiết bị 5', N'LTB004    ', N'MT001     ', N'122.121.12.5', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0006    ', N'Thiết bị 6', N'LTB005    ', N'MT001     ', N'122.121.12.6', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0007    ', N'Thiết bị 7', N'LTB006    ', N'MT001     ', N'122.121.12.7', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0008    ', N'Thiết bị 8', N'LTB005    ', N'MT001     ', N'122.121.12.8', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0009    ', N'Thiết bị 9', N'LTB004    ', N'MT002     ', N'122.121.12.9', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0010    ', N'Thiết bị 10', N'LTB003    ', N'MT002     ', N'122.121.12.12', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0011    ', N'Thiết bị 11', N'LTB002    ', N'MT003     ', N'122.121.12.22', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0012    ', N'Thiết bị 12', N'LTB002    ', N'MT002     ', N'122.121.12.42', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0013    ', N'Thiết bị 13', N'LTB001    ', N'MT002     ', N'122.121.12.32', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0014    ', N'Thiết bị 14', N'LTB002    ', N'MT002     ', N'122.121.12.23', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0015    ', N'Thiết bị 15', N'LTB003    ', N'MT003     ', N'122.121.12.32', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0016    ', N'Thiết bị 16', N'LTB005    ', N'MT003     ', N'122.121.12.52', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0017    ', N'Thiết bị 17', N'LTB001    ', N'MT002     ', N'122.121.12.72', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0018    ', N'Thiết bị 18', N'LTB001    ', N'MT003     ', N'122.121.12.82', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0019    ', N'Thiết bị 19', N'LTB002    ', N'MT003     ', N'122.121.12.82', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0020    ', N'Thiết bị 20', N'LTB001    ', N'MT002     ', N'122.121.12.92', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0021    ', N'Thiết bị 21', N'LTB002    ', N'MT003     ', N'122.121.12.42', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0022    ', N'Thiết bị 22', N'LTB004    ', N'MT002     ', N'122.121.12.23', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0023    ', N'Thiết bị 23', N'LTB005    ', N'MT003     ', N'122.121.12.22', NULL, NULL)
INSERT [dbo].[THIETBI] ([MaTB], [TenTB], [MaLoaiTB], [MaMT], [IP], [NgayLapDat], [ViTri]) VALUES (N'TB0024    ', N'Thiết bị 24', N'LTB006    ', N'MT001     ', N'122.121.12.22', NULL, NULL)
INSERT [dbo].[TRAM] ([MSTram], [TenTram]) VALUES (N'TRAM001   ', N'Trạm 1')
INSERT [dbo].[TRAM] ([MSTram], [TenTram]) VALUES (N'TRAM002   ', N'Tram 2')
INSERT [dbo].[TRAM] ([MSTram], [TenTram]) VALUES (N'TRAM003   ', N'Trạm 3')
INSERT [dbo].[TRANGTHAI] ([MaTrangThai], [NoiDung], [TieuChuanMin], [TieuChuanMax]) VALUES (N'TT001     ', N'Kết nối', 1, NULL)
INSERT [dbo].[TRANGTHAI] ([MaTrangThai], [NoiDung], [TieuChuanMin], [TieuChuanMax]) VALUES (N'TT002     ', N'Reader active ', 1, NULL)
INSERT [dbo].[TRANGTHAI] ([MaTrangThai], [NoiDung], [TieuChuanMin], [TieuChuanMax]) VALUES (N'TT003     ', N'Công suất phát', 10, 2000)
INSERT [dbo].[TRANGTHAI] ([MaTrangThai], [NoiDung], [TieuChuanMin], [TieuChuanMax]) VALUES (N'TT004     ', N'Nhiệt độ', NULL, 50)
INSERT [dbo].[TRANGTHAI] ([MaTrangThai], [NoiDung], [TieuChuanMin], [TieuChuanMax]) VALUES (N'TT005     ', N'Suy hao Angten', NULL, 1.5)
INSERT [dbo].[TRANGTHAI] ([MaTrangThai], [NoiDung], [TieuChuanMin], [TieuChuanMax]) VALUES (N'TT006     ', N'Không đọc thẻ etag', 1, NULL)
INSERT [dbo].[TRANGTHAI] ([MaTrangThai], [NoiDung], [TieuChuanMin], [TieuChuanMax]) VALUES (N'TT007     ', N'Angten bức xạ yếu  ', 120, NULL)
INSERT [dbo].[TRANGTHAI] ([MaTrangThai], [NoiDung], [TieuChuanMin], [TieuChuanMax]) VALUES (N'TT008     ', N'Hardware alarm', 1, NULL)
INSERT [dbo].[TRANGTHAI] ([MaTrangThai], [NoiDung], [TieuChuanMin], [TieuChuanMax]) VALUES (N'TT009     ', N'Hình ảnh', 1, NULL)
SET IDENTITY_INSERT [dbo].[TRANGTHAITB] ON 

INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (1, N'TB0001    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (2, N'TB0001    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, NULL, NULL)
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (3, N'TB0001    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT002')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (4, N'TB0001    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 112, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (5, N'TB0001    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 45, N'TT004')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (6, N'TB0001    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1.2, N'TT005')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (7, N'TB0001    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT006')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (8, N'TB0001    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 110, N'TT007')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (9, N'TB0002    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (10, N'TB0002    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 10, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (11, N'TB0002    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (12, N'TB0003    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (13, N'TB0003    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (14, N'TB0003    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (15, N'TB0003    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 40, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (16, N'TB0004    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (17, N'TB0004    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (18, N'TB0004    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 41, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (19, N'TB0004    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (20, N'TB0005    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (21, N'TB0005    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (22, N'TB0005    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (23, N'TB0006    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 40, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (24, N'TB0006    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (25, N'TB0006    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (26, N'TB0006    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 41, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (27, N'TB0006    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (28, N'TB0007    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT002')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (29, N'TB0007    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 112, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (30, N'TB0007    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 45, N'TT004')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (31, N'TB0007    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1.2, N'TT005')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (32, N'TB0007    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT006')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (33, N'TB0007    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 110, N'TT007')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (34, N'TB0008    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (35, N'TB0008    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 10, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (36, N'TB0008    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (37, N'TB0009    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (38, N'TB0009    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (39, N'TB0009    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (40, N'TB0009    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 40, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (41, N'TB0010    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (42, N'TB0010    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (43, N'TB0010    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 41, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (44, N'TB0010    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (45, N'TB0011    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT002')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (46, N'TB0011    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 112, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (47, N'TB0011    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 45, N'TT004')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (48, N'TB0011    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1.2, N'TT005')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (49, N'TB0011    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT006')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (50, N'TB0011    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 110, N'TT007')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (51, N'TB0012    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (52, N'TB0012    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 10, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (53, N'TB0012    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (54, N'TB0012    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (55, N'TB0012    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (56, N'TB0012    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (57, N'TB0012    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 40, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (58, N'TB0013    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (59, N'TB0013    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (60, N'TB0013    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 41, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (61, N'TB0013    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (62, N'TB0014    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT002')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (63, N'TB0014    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 112, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (64, N'TB0014    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 45, N'TT004')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (65, N'TB0014    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1.2, N'TT005')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (66, N'TB0014    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT006')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (67, N'TB0014    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 110, N'TT007')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (68, N'TB0015    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (69, N'TB0015    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 10, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (70, N'TB0015    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (71, N'TB0015    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (72, N'TB0015    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (73, N'TB0015    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (74, N'TB0015    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 40, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (75, N'TB0016    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (76, N'TB0016    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (77, N'TB0016    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 41, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (78, N'TB0016    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (79, N'TB0017    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT002')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (80, N'TB0017    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 112, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (81, N'TB0017    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 45, N'TT004')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (82, N'TB0017    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1.2, N'TT005')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (83, N'TB0017    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT006')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (84, N'TB0017    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 110, N'TT007')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (85, N'TB0018    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (86, N'TB0018    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 10, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (87, N'TB0018    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (88, N'TB0018    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (89, N'TB0018    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (90, N'TB0019    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (91, N'TB0019    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 40, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (92, N'TB0019    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (93, N'TB0020    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (94, N'TB0020    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 41, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (95, N'TB0020    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (96, N'TB0021    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT002')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (97, N'TB0021    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 112, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (98, N'TB0021    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 45, N'TT004')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (99, N'TB0021    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1.2, N'TT005')
GO
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (100, N'TB0021    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT006')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (101, N'TB0021    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 110, N'TT007')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (102, N'TB0022    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (103, N'TB0022    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 10, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (104, N'TB0022    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (105, N'TB0022    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (106, N'TB0022    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (107, N'TB0022    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (108, N'TB0022    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 40, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (109, N'TB0022    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT001')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (110, N'TB0023    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT008')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (111, N'TB0023    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 41, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (112, N'TB0023    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT009')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (113, N'TB0024    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT002')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (114, N'TB0024    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 112, N'TT003')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (115, N'TB0024    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 45, N'TT004')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (116, N'TB0024    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1.2, N'TT005')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (117, N'TB0024    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 1, N'TT006')
INSERT [dbo].[TRANGTHAITB] ([ID], [MaTB], [ThoiGian], [MoTa], [TrangThai], [MaTrangThai]) VALUES (118, N'TB0024    ', CAST(N'2017-04-12 00:00:00.000' AS DateTime), NULL, 110, N'TT007')
SET IDENTITY_INSERT [dbo].[TRANGTHAITB] OFF
ALTER TABLE [dbo].[CUM]  WITH CHECK ADD  CONSTRAINT [FK_CUM_TRAM] FOREIGN KEY([MSTram])
REFERENCES [dbo].[TRAM] ([MSTram])
GO
ALTER TABLE [dbo].[CUM] CHECK CONSTRAINT [FK_CUM_TRAM]
GO
ALTER TABLE [dbo].[THIETBI]  WITH CHECK ADD  CONSTRAINT [FK_THIETBI_LOAITHIETBI] FOREIGN KEY([MaLoaiTB])
REFERENCES [dbo].[LOAITHIETBI] ([MaLoaiTB])
GO
ALTER TABLE [dbo].[THIETBI] CHECK CONSTRAINT [FK_THIETBI_LOAITHIETBI]
GO
ALTER TABLE [dbo].[THIETBI]  WITH CHECK ADD  CONSTRAINT [FK_THIETBI_MAYTINH] FOREIGN KEY([MaMT])
REFERENCES [dbo].[MAYTINH] ([MaMT])
GO
ALTER TABLE [dbo].[THIETBI] CHECK CONSTRAINT [FK_THIETBI_MAYTINH]
GO
ALTER TABLE [dbo].[TRANGTHAITB]  WITH CHECK ADD  CONSTRAINT [FK_TRANGTHAITB_THIETBI1] FOREIGN KEY([MaTB])
REFERENCES [dbo].[THIETBI] ([MaTB])
GO
ALTER TABLE [dbo].[TRANGTHAITB] CHECK CONSTRAINT [FK_TRANGTHAITB_THIETBI1]
GO
USE [master]
GO
ALTER DATABASE [ProcessMonitor] SET  READ_WRITE 
GO
