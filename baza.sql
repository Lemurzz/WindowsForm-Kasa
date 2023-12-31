USE [master]
GO
/****** Object:  Database [ProjekatPMK]    Script Date: 6/29/2023 5:37:25 PM ******/
CREATE DATABASE [ProjekatPMK]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'ProjekatPMK', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjekatPMK.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'ProjekatPMK_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\ProjekatPMK_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [ProjekatPMK] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [ProjekatPMK].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [ProjekatPMK] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [ProjekatPMK] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [ProjekatPMK] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [ProjekatPMK] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [ProjekatPMK] SET ARITHABORT OFF 
GO
ALTER DATABASE [ProjekatPMK] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [ProjekatPMK] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [ProjekatPMK] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [ProjekatPMK] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [ProjekatPMK] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [ProjekatPMK] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [ProjekatPMK] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [ProjekatPMK] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [ProjekatPMK] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [ProjekatPMK] SET  DISABLE_BROKER 
GO
ALTER DATABASE [ProjekatPMK] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [ProjekatPMK] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [ProjekatPMK] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [ProjekatPMK] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [ProjekatPMK] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [ProjekatPMK] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [ProjekatPMK] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [ProjekatPMK] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [ProjekatPMK] SET  MULTI_USER 
GO
ALTER DATABASE [ProjekatPMK] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [ProjekatPMK] SET DB_CHAINING OFF 
GO
ALTER DATABASE [ProjekatPMK] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [ProjekatPMK] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [ProjekatPMK] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [ProjekatPMK] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [ProjekatPMK] SET QUERY_STORE = ON
GO
ALTER DATABASE [ProjekatPMK] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [ProjekatPMK]
GO
/****** Object:  Table [dbo].[Artikal]    Script Date: 6/29/2023 5:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Artikal](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Price] [int] NOT NULL,
	[Kategorija_Id] [int] NOT NULL,
	[Jedinica_Mere_Id] [int] NOT NULL,
 CONSTRAINT [PK_Artikal] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Jedinica_Mere]    Script Date: 6/29/2023 5:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Jedinica_Mere](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Jedinica_Mere] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kategorija]    Script Date: 6/29/2023 5:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kategorija](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Kategorija] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Racun]    Script Date: 6/29/2023 5:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Racun](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Racun] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Stavke_Racuna]    Script Date: 6/29/2023 5:37:25 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Stavke_Racuna](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Quantity] [int] NOT NULL,
	[Racun_Id] [int] NOT NULL,
	[Artikal_Id] [int] NOT NULL,
 CONSTRAINT [PK_Stavke_Racuna] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Artikal] ON 

INSERT [dbo].[Artikal] ([Id], [Name], [Price], [Kategorija_Id], [Jedinica_Mere_Id]) VALUES (1, N'Whey Amino', 3600, 5, 1)
INSERT [dbo].[Artikal] ([Id], [Name], [Price], [Kategorija_Id], [Jedinica_Mere_Id]) VALUES (2, N'Sapun Dove', 90, 3, 6)
INSERT [dbo].[Artikal] ([Id], [Name], [Price], [Kategorija_Id], [Jedinica_Mere_Id]) VALUES (3, N'Kifla sa susamom', 33, 2, 6)
SET IDENTITY_INSERT [dbo].[Artikal] OFF
GO
SET IDENTITY_INSERT [dbo].[Jedinica_Mere] ON 

INSERT [dbo].[Jedinica_Mere] ([Id], [Name]) VALUES (1, N'kg')
INSERT [dbo].[Jedinica_Mere] ([Id], [Name]) VALUES (2, N'l')
INSERT [dbo].[Jedinica_Mere] ([Id], [Name]) VALUES (3, N'dl')
INSERT [dbo].[Jedinica_Mere] ([Id], [Name]) VALUES (4, N'm')
INSERT [dbo].[Jedinica_Mere] ([Id], [Name]) VALUES (5, N'cm')
INSERT [dbo].[Jedinica_Mere] ([Id], [Name]) VALUES (6, N'kom')
SET IDENTITY_INSERT [dbo].[Jedinica_Mere] OFF
GO
SET IDENTITY_INSERT [dbo].[Kategorija] ON 

INSERT [dbo].[Kategorija] ([Id], [Name]) VALUES (1, N'Hemija')
INSERT [dbo].[Kategorija] ([Id], [Name]) VALUES (2, N'Pekara')
INSERT [dbo].[Kategorija] ([Id], [Name]) VALUES (3, N'Kozmetika')
INSERT [dbo].[Kategorija] ([Id], [Name]) VALUES (5, N'Suplementi')
SET IDENTITY_INSERT [dbo].[Kategorija] OFF
GO
ALTER TABLE [dbo].[Artikal]  WITH CHECK ADD  CONSTRAINT [FK_Artikal_Jedinica_Mere] FOREIGN KEY([Jedinica_Mere_Id])
REFERENCES [dbo].[Jedinica_Mere] ([Id])
GO
ALTER TABLE [dbo].[Artikal] CHECK CONSTRAINT [FK_Artikal_Jedinica_Mere]
GO
ALTER TABLE [dbo].[Artikal]  WITH CHECK ADD  CONSTRAINT [FK_Artikal_Kategorija] FOREIGN KEY([Kategorija_Id])
REFERENCES [dbo].[Kategorija] ([Id])
GO
ALTER TABLE [dbo].[Artikal] CHECK CONSTRAINT [FK_Artikal_Kategorija]
GO
ALTER TABLE [dbo].[Stavke_Racuna]  WITH CHECK ADD  CONSTRAINT [FK_Stavke_Racuna_Artikal] FOREIGN KEY([Artikal_Id])
REFERENCES [dbo].[Artikal] ([Id])
GO
ALTER TABLE [dbo].[Stavke_Racuna] CHECK CONSTRAINT [FK_Stavke_Racuna_Artikal]
GO
ALTER TABLE [dbo].[Stavke_Racuna]  WITH CHECK ADD  CONSTRAINT [FK_Stavke_Racuna_Racun] FOREIGN KEY([Racun_Id])
REFERENCES [dbo].[Racun] ([Id])
GO
ALTER TABLE [dbo].[Stavke_Racuna] CHECK CONSTRAINT [FK_Stavke_Racuna_Racun]
GO
USE [master]
GO
ALTER DATABASE [ProjekatPMK] SET  READ_WRITE 
GO
