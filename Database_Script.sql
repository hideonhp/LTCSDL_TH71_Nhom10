USE [master]
GO
/****** Object:  Database [SteveJobs]    Script Date: 6/22/2020 7:41:26 AM ******/
CREATE DATABASE [SteveJobs]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SteveJobs', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SteveJobs.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SteveJobs_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL13.MSSQLSERVER\MSSQL\DATA\SteveJobs_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [SteveJobs] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SteveJobs].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SteveJobs] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SteveJobs] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SteveJobs] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SteveJobs] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SteveJobs] SET ARITHABORT OFF 
GO
ALTER DATABASE [SteveJobs] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SteveJobs] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SteveJobs] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SteveJobs] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SteveJobs] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SteveJobs] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SteveJobs] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SteveJobs] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SteveJobs] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SteveJobs] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SteveJobs] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SteveJobs] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SteveJobs] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SteveJobs] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SteveJobs] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SteveJobs] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SteveJobs] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SteveJobs] SET RECOVERY FULL 
GO
ALTER DATABASE [SteveJobs] SET  MULTI_USER 
GO
ALTER DATABASE [SteveJobs] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SteveJobs] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SteveJobs] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SteveJobs] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SteveJobs] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SteveJobs', N'ON'
GO
ALTER DATABASE [SteveJobs] SET QUERY_STORE = OFF
GO
USE [SteveJobs]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [SteveJobs]
GO
/****** Object:  User [1751010157]    Script Date: 6/22/2020 7:41:26 AM ******/
CREATE USER [1751010157] FOR LOGIN [1751010157] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[ChiTietDonHang]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietDonHang](
	[IdSanPham] [int] NOT NULL,
	[IdDonHang] [int] NOT NULL,
	[SoLuong] [varchar](50) NULL,
 CONSTRAINT [PK_ChiTietDonHang] PRIMARY KEY CLUSTERED 
(
	[IdSanPham] ASC,
	[IdDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[IdDonHang] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[NgayDat] [datetime] NOT NULL,
	[TongTien] [nvarchar](50) NULL,
	[TinhTrangDonHang] [nvarchar](50) NULL,
 CONSTRAINT [PK_DonHang] PRIMARY KEY CLUSTERED 
(
	[IdDonHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[IdGioHang] [int] IDENTITY(1,1) NOT NULL,
	[IdSanPham] [int] NULL,
	[IdUsers] [int] NULL,
	[TrangThai] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KieuNguoiDung]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KieuNguoiDung](
	[IdTypeUser] [int] NOT NULL,
	[TypeUser] [varchar](50) NULL,
 CONSTRAINT [PK_KieuNguoiDung] PRIMARY KEY CLUSTERED 
(
	[IdTypeUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[IdLoai] [int] IDENTITY(1,1) NOT NULL,
	[TenLoai] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[IdLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[IdUser] [int] IDENTITY(1,1) NOT NULL,
	[IdTypeUser] [int] NOT NULL,
	[TenDangNhap] [varchar](50) NOT NULL,
	[MatKhau] [varchar](50) NOT NULL,
	[HoVaTen] [nvarchar](50) NULL,
	[SoDienThoai] [varchar](50) NULL,
	[DiaChi] [nvarchar](50) NULL,
 CONSTRAINT [PK_NguoiDung] PRIMARY KEY CLUSTERED 
(
	[IdUser] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[IdSanPham] [int] IDENTITY(1,1) NOT NULL,
	[IdLoai] [int] NOT NULL,
	[Ten] [nvarchar](50) NOT NULL,
	[MoTa] [nvarchar](max) NULL,
	[Gia] [nvarchar](50) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[IdSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_DonHang] FOREIGN KEY([IdDonHang])
REFERENCES [dbo].[DonHang] ([IdDonHang])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_DonHang]
GO
ALTER TABLE [dbo].[ChiTietDonHang]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietDonHang_SanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPham] ([IdSanPham])
GO
ALTER TABLE [dbo].[ChiTietDonHang] CHECK CONSTRAINT [FK_ChiTietDonHang_SanPham]
GO
ALTER TABLE [dbo].[NguoiDung]  WITH CHECK ADD  CONSTRAINT [FK_NguoiDung_KieuNguoiDung] FOREIGN KEY([IdTypeUser])
REFERENCES [dbo].[KieuNguoiDung] ([IdTypeUser])
GO
ALTER TABLE [dbo].[NguoiDung] CHECK CONSTRAINT [FK_NguoiDung_KieuNguoiDung]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_LoaiSanPham] FOREIGN KEY([IdLoai])
REFERENCES [dbo].[LoaiSanPham] ([IdLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_LoaiSanPham]
GO
/****** Object:  StoredProcedure [dbo].[DonHang_Delete]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[DonHang_Delete]
@IdDonHang int
as
Delete from DonHang
		where IdDonHang =@IdDonHang
GO
/****** Object:  StoredProcedure [dbo].[DonHang_Select]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[DonHang_Select]
@IdDonHang int
AS
SELECT *
FROM DonHang
WHERE
IdDonHang = @IdDonHang 
GO
/****** Object:  StoredProcedure [dbo].[GioHang_Delete]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GioHang_Delete]
@IdGioHang int
as
Delete from GioHang
		where IdGioHang =@IdGioHang
GO
/****** Object:  StoredProcedure [dbo].[GioHang_Insert]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GioHang_Insert]
@IdSanPham int,
@IdUsers int

AS
INSERT INTO GioHang(IdSanPham,IdUsers)
VALUES (@IdSanPham,@IdUsers)
GO
/****** Object:  StoredProcedure [dbo].[GioHang_Select]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[GioHang_Select]
@IdUser int
AS
SELECT *
FROM GioHang
WHERE
IdUsers = @IdUser 
GO
/****** Object:  StoredProcedure [dbo].[NguoiDung_DangNhap_Admin_Select]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NguoiDung_DangNhap_Admin_Select]
@TenDangNhap varchar(50),
@MatKhau varchar(50)
AS
SELECT HoVaTen,IdUser,IdTypeUser
FROM NguoiDung
WHERE
TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau AND IdTypeUser = 1
GO
/****** Object:  StoredProcedure [dbo].[NguoiDung_DangNhap_Select]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NguoiDung_DangNhap_Select]
@TenDangNhap varchar(50),
@MatKhau varchar(50)
AS
SELECT HoVaTen,IdUser,IdTypeUser
FROM NguoiDung
WHERE
TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau 
GO
/****** Object:  StoredProcedure [dbo].[NguoiDung_Delete]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[NguoiDung_Delete]
@IdUser int
as
Delete from NguoiDung
		where IdUser =@IdUser
GO
/****** Object:  StoredProcedure [dbo].[NguoiDung_Insert]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[NguoiDung_Insert]
@HoVaTen nvarchar(50),
@TenDangNhap varchar(50),
@DiaChi nvarchar(50),
@SoDienThoai varchar(50),
@IdTypeUser int,
@MatKhau varchar(50)
AS
INSERT INTO NguoiDung (IdTypeUser,TenDangNhap,MatKhau,HoVaTen,SoDienThoai,DiaChi)
VALUES (@IdTypeUser,@TenDangNhap,@MatKhau,@HoVaTen,@SoDienThoai,@DiaChi)
GO
/****** Object:  StoredProcedure [dbo].[NguoiDung_Update]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[NguoiDung_Update]
@IdUser int,
@HoVaTen nvarchar(50),
@TenDangNhap varchar(50),
@DiaChi nvarchar(50),
@SoDienThoai varchar(50),
@IdTypeUser int,
@MatKhau varchar(50)
AS
update NguoiDung
set		IdTypeUser = @IdTypeUser,
		TenDangNhap = @TenDangNhap,
		MatKhau = @MatKhau,
		HoVaTen = @HoVaTen,
		SoDienThoai = @SoDienThoai,
		DiaChi = @DiaChi
where IdUser = @IdUser
GO
/****** Object:  StoredProcedure [dbo].[SanPham_Select_by_Id]    Script Date: 6/22/2020 7:41:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SanPham_Select_by_Id] @id int
as
select * from SanPham
where IdLoai =3
GO
USE [master]
GO
ALTER DATABASE [SteveJobs] SET  READ_WRITE 
GO
