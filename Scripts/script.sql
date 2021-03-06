USE [master]
GO
/****** Object:  Database [SPEEDYSOL]    Script Date: 4/10/2018 11:02:13 PM ******/
CREATE DATABASE [SPEEDYSOL]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SPEEDYSOL', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.INSTANCE1\MSSQL\DATA\SPEEDYSOL.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SPEEDYSOL_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.INSTANCE1\MSSQL\DATA\SPEEDYSOL_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SPEEDYSOL] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SPEEDYSOL].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SPEEDYSOL] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET ARITHABORT OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SPEEDYSOL] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SPEEDYSOL] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SPEEDYSOL] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SPEEDYSOL] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SPEEDYSOL] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET RECOVERY FULL 
GO
ALTER DATABASE [SPEEDYSOL] SET  MULTI_USER 
GO
ALTER DATABASE [SPEEDYSOL] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SPEEDYSOL] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SPEEDYSOL] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SPEEDYSOL] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'SPEEDYSOL', N'ON'
GO
USE [SPEEDYSOL]
GO
/****** Object:  StoredProcedure [dbo].[uspGetUser]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[uspGetUser] @loginid nvarchar(255)
AS
select * from ssusers where loginid = @loginid

GO
/****** Object:  Table [dbo].[AccountCategory]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountCategory](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[GroupID] [int] NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AccountCategory] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AccountGroup]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[AccountGroup](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AccountGroup] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DailySales]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DailySales](
	[DSRNumber] [bigint] NOT NULL,
	[SalesManID] [bigint] NOT NULL,
	[CreatedOn] [date] NOT NULL,
 CONSTRAINT [PK_DailySales] PRIMARY KEY CLUSTERED 
(
	[DSRNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GodownItems]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GodownItems](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[godownID] [bigint] NOT NULL,
	[itemID] [bigint] NOT NULL,
	[CTN] [bigint] NOT NULL,
	[Pcs] [int] NULL,
 CONSTRAINT [PK_GodownItems] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Godowns]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Godowns](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NULL,
	[Name] [varchar](255) NOT NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK__Godowns__3B08E2BCA02ADE74] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemBrand]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemBrand](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_ItemBrand] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemGroup]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemGroup](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_ItemGroup] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ItemManufacturer]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ItemManufacturer](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [varchar](150) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_ItemManufacturer] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Items]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Items](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[PurchasePrice] [int] NOT NULL,
	[SalePrice] [int] NOT NULL,
	[RetailPrice] [int] NOT NULL,
	[ManufacturerID] [int] NOT NULL,
	[GroupID] [int] NOT NULL,
	[BrandID] [int] NOT NULL,
	[Remarks] [varchar](255) NULL,
	[PackUnit] [int] NOT NULL,
	[CTNSize] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[UnitWeight] [int] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__Items__3B08E2BCD1CC4911] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[OrderBooker]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OrderBooker](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Address] [varchar](255) NOT NULL,
	[Type] [varchar](255) NULL,
	[ContactNum] [nvarchar](255) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__OrderBoo__3B08E2BC08B017B1] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseDamageChallan]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDamageChallan](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[VendorID] [bigint] NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_PurchaseDamageChallan] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseDamageChallanItems]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDamageChallanItems](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[PDamCID] [bigint] NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[CTN] [int] NOT NULL,
	[PC] [int] NULL,
 CONSTRAINT [PK_PurchaseDamageChallanItems] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseOrder]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PurchaseOrder](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[POrderID] [nvarchar](max) NULL,
	[GodownID] [bigint] NULL,
	[ClientID] [bigint] NULL,
	[InvType] [varchar](255) NULL,
	[Remarks] [varchar](255) NULL,
	[TotalQtyPack] [int] NULL,
	[TotalQtyLoose] [int] NULL,
	[TotalQty] [int] NULL,
	[TotalQtyBonus] [int] NULL,
	[TotalDiscountPercentage] [int] NULL,
	[TotalFlatDiscount] [bigint] NULL,
	[TotalGST] [bigint] NULL,
	[TotalExclTax] [bigint] NULL,
	[TotalInclTax] [bigint] NULL,
	[GrandTotal] [bigint] NULL,
	[isPosted] [bit] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__Purchase__3B08E2BCB762E233] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PurchaseOrderDetail]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseOrderDetail](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[POrderID] [bigint] NULL,
	[ItemID] [bigint] NULL,
	[FlatDiscount] [bigint] NULL,
	[GSTPercentage] [int] NULL,
	[GSTValue] [bigint] NULL,
	[MarginPercentage] [int] NULL,
	[MarkupPercentage] [int] NULL,
	[NetRate] [int] NULL,
	[Qty] [int] NOT NULL,
	[Bonus] [int] NULL,
	[TotalDisc] [bigint] NULL,
	[DiscAfterTax] [bigint] NULL,
	[TP] [bigint] NULL,
	[GrossAmount] [bigint] NULL,
	[DiscPercentage] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseRecievingChallan]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseRecievingChallan](
	[sysSerial] [int] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[VendorID] [bigint] NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_PurchaseRecievingChallan] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseRecievingChallanItems]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseRecievingChallanItems](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[PRCID] [int] NOT NULL,
	[Ctn] [bigint] NOT NULL,
	[Pcs] [bigint] NOT NULL,
 CONSTRAINT [PK_PurchaseRecievingChallanItems] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseReturnChallan]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseReturnChallan](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[VendorID] [bigint] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_PurchaseReturnChallan] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PurchaseReturnChallanItems]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseReturnChallanItems](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[PRCID] [int] NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[CTN] [int] NOT NULL,
	[PC] [int] NULL,
 CONSTRAINT [PK_PurchaseReturnChallanItems] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SaleOrder]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SaleOrder](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[SalesManID] [bigint] NULL,
	[BookerID] [bigint] NULL,
	[ClientID] [bigint] NULL,
	[SaleAddress] [varchar](255) NULL,
	[Remarks] [varchar](255) NULL,
	[VehicleNo] [varchar](255) NULL,
	[TotalQtyPack] [int] NULL,
	[TotalQtyLoose] [int] NULL,
	[TotalQty] [int] NULL,
	[TotalQtyBonus] [int] NULL,
	[TotalDiscountPercentage] [int] NULL,
	[TotalFlatDiscount] [bigint] NULL,
	[TotalDiscount] [bigint] NULL,
	[TotalGST] [bigint] NULL,
	[TotalAdditionalGST] [bigint] NULL,
	[TotalGrossSalePercentage] [int] NULL,
	[TotalExclTax] [bigint] NULL,
	[TotalInclTax] [bigint] NULL,
	[GrandTotal] [bigint] NULL,
	[SaleReturn] [bigint] NULL,
	[NetValue] [int] NULL,
	[CashBack] [bigint] NULL,
	[isPosted] [bit] NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__SaleOrde__3B08E2BCDEC97112] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SaleOrderDetail]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SaleOrderDetail](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[SOrderID] [bigint] NULL,
	[ItemID] [bigint] NULL,
	[DiscountPercentage] [int] NULL,
	[Total] [bigint] NULL,
	[ExtraDiscount] [int] NULL,
	[SaleTO] [int] NULL,
	[Qty] [int] NOT NULL,
	[Bonus] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesDamageChallan]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDamageChallan](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[DSRNumber] [bigint] NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_SalesDamageChallan] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesDamageChallanItems]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDamageChallanItems](
	[sysSerial] [int] NOT NULL,
	[DamCID] [bigint] NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[CTN] [int] NOT NULL,
	[PC] [int] NULL,
 CONSTRAINT [PK_SalesDamageChallanItems] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesDeliveryChallan]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDeliveryChallan](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[DSRNumber] [bigint] NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_SalesDC] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesDeliveryChallanItems]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesDeliveryChallanItems](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[DCID] [int] NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[CTN] [int] NOT NULL,
	[PC] [int] NULL,
 CONSTRAINT [PK_SalesDCItems] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Salesman]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Salesman](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[Type] [varchar](255) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__Salesman__3B08E2BC907E76FA] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SalesReturnChallan]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesReturnChallan](
	[sysSerial] [int] IDENTITY(1,1) NOT NULL,
	[DSRNumber] [bigint] NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_SalesRC] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SalesReturnChallanItems]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SalesReturnChallanItems](
	[sysSerial] [bigint] NOT NULL,
	[RCID] [int] NOT NULL,
	[ItemID] [bigint] NOT NULL,
	[CTN] [int] NOT NULL,
	[PC] [int] NOT NULL,
 CONSTRAINT [PK_SalesRCItems] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SSAccounts]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SSAccounts](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[AccNo] [varchar](max) NOT NULL,
	[CategoryID] [int] NULL,
	[Name] [varchar](255) NOT NULL,
	[BalanceLimit] [bigint] NOT NULL,
	[DiscountInPercentage] [int] NULL,
	[Remarks] [varchar](255) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK__SSAccoun__3B08E2BCC4D91D45] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SSClients]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SSClients](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[ContactPerson] [varchar](255) NULL,
	[Address] [varchar](255) NULL,
	[ContactNumber] [nvarchar](255) NOT NULL,
	[Email] [varchar](255) NULL,
	[Fax] [nvarchar](255) NULL,
	[NIC] [varchar](255) NULL,
	[City] [varchar](255) NULL,
	[NTN] [nvarchar](255) NULL,
	[SalesTaxNo] [varchar](255) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__SSClient__3B08E2BCD8AD408D] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SSUsers]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SSUsers](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[RoleID] [bigint] NULL,
	[Name] [varchar](255) NOT NULL,
	[ContactNum] [nvarchar](255) NULL,
	[LoginID] [nvarchar](255) NULL,
	[Password] [nvarchar](max) NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__SSUsers__3B08E2BC45F4CAD1] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SSUsersRoles]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SSUsersRoles](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](255) NOT NULL,
	[CreatedOn] [date] NULL,
	[UpdatedOn] [date] NULL,
	[Code] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK__SSUsersR__3B08E2BC56BD199E] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vendor]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vendor](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[Code] [nvarchar](max) NOT NULL,
	[Name] [varchar](max) NOT NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_Vendor] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Vouchers]    Script Date: 4/10/2018 11:02:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Vouchers](
	[sysSerial] [bigint] IDENTITY(1,1) NOT NULL,
	[VoucherCode] [nvarchar](max) NOT NULL,
	[AccountID] [bigint] NOT NULL,
	[Amount] [bigint] NOT NULL,
	[Remarks] [varchar](max) NULL,
	[CreatedOn] [date] NOT NULL,
	[UpdatedOn] [date] NULL,
 CONSTRAINT [PK_Vouchers] PRIMARY KEY CLUSTERED 
(
	[sysSerial] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[SSAccounts] ADD  CONSTRAINT [DF__SSAccount__AccNo__15502E78]  DEFAULT (newid()) FOR [AccNo]
GO
ALTER TABLE [dbo].[AccountCategory]  WITH CHECK ADD  CONSTRAINT [FK_AccountCategory_AccountGroup] FOREIGN KEY([GroupID])
REFERENCES [dbo].[AccountGroup] ([sysSerial])
GO
ALTER TABLE [dbo].[AccountCategory] CHECK CONSTRAINT [FK_AccountCategory_AccountGroup]
GO
ALTER TABLE [dbo].[DailySales]  WITH CHECK ADD  CONSTRAINT [FK_DailySales_DailySales] FOREIGN KEY([SalesManID])
REFERENCES [dbo].[Salesman] ([sysSerial])
GO
ALTER TABLE [dbo].[DailySales] CHECK CONSTRAINT [FK_DailySales_DailySales]
GO
ALTER TABLE [dbo].[GodownItems]  WITH CHECK ADD  CONSTRAINT [FK_GodownItems_Godowns] FOREIGN KEY([godownID])
REFERENCES [dbo].[Godowns] ([sysSerial])
GO
ALTER TABLE [dbo].[GodownItems] CHECK CONSTRAINT [FK_GodownItems_Godowns]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_ItemBrand] FOREIGN KEY([BrandID])
REFERENCES [dbo].[ItemBrand] ([sysSerial])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_ItemBrand]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_ItemGroup] FOREIGN KEY([GroupID])
REFERENCES [dbo].[ItemGroup] ([sysSerial])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_ItemGroup]
GO
ALTER TABLE [dbo].[Items]  WITH CHECK ADD  CONSTRAINT [FK_Items_ItemManufacturer] FOREIGN KEY([ManufacturerID])
REFERENCES [dbo].[ItemManufacturer] ([sysSerial])
GO
ALTER TABLE [dbo].[Items] CHECK CONSTRAINT [FK_Items_ItemManufacturer]
GO
ALTER TABLE [dbo].[PurchaseDamageChallan]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDamageChallan_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseDamageChallan] CHECK CONSTRAINT [FK_PurchaseDamageChallan_Vendor]
GO
ALTER TABLE [dbo].[PurchaseDamageChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDamageChallanItems_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseDamageChallanItems] CHECK CONSTRAINT [FK_PurchaseDamageChallanItems_Items]
GO
ALTER TABLE [dbo].[PurchaseDamageChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDamageChallanItems_PurchaseDamageChallan] FOREIGN KEY([PDamCID])
REFERENCES [dbo].[PurchaseDamageChallan] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseDamageChallanItems] CHECK CONSTRAINT [FK_PurchaseDamageChallanItems_PurchaseDamageChallan]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_Godown] FOREIGN KEY([GodownID])
REFERENCES [dbo].[Godowns] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_Godown]
GO
ALTER TABLE [dbo].[PurchaseOrder]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrder_SSClients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[SSClients] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseOrder] CHECK CONSTRAINT [FK_PurchaseOrder_SSClients]
GO
ALTER TABLE [dbo].[PurchaseOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderDetail_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([sysSerial])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PurchaseOrderDetail] CHECK CONSTRAINT [FK_PurchaseOrderDetail_Items]
GO
ALTER TABLE [dbo].[PurchaseOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseOrderDetail_POrder] FOREIGN KEY([POrderID])
REFERENCES [dbo].[PurchaseOrder] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseOrderDetail] CHECK CONSTRAINT [FK_PurchaseOrderDetail_POrder]
GO
ALTER TABLE [dbo].[PurchaseRecievingChallan]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseRecievingChallan_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseRecievingChallan] CHECK CONSTRAINT [FK_PurchaseRecievingChallan_Vendor]
GO
ALTER TABLE [dbo].[PurchaseRecievingChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseRecievingChallanItems_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseRecievingChallanItems] CHECK CONSTRAINT [FK_PurchaseRecievingChallanItems_Items]
GO
ALTER TABLE [dbo].[PurchaseRecievingChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseRecievingChallanItems_PurchaseRecievingChallan] FOREIGN KEY([PRCID])
REFERENCES [dbo].[PurchaseRecievingChallan] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseRecievingChallanItems] CHECK CONSTRAINT [FK_PurchaseRecievingChallanItems_PurchaseRecievingChallan]
GO
ALTER TABLE [dbo].[PurchaseReturnChallan]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturnChallan_Vendor] FOREIGN KEY([VendorID])
REFERENCES [dbo].[Vendor] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseReturnChallan] CHECK CONSTRAINT [FK_PurchaseReturnChallan_Vendor]
GO
ALTER TABLE [dbo].[PurchaseReturnChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturnChallanItems_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseReturnChallanItems] CHECK CONSTRAINT [FK_PurchaseReturnChallanItems_Items]
GO
ALTER TABLE [dbo].[PurchaseReturnChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseReturnChallanItems_PurchaseReturnChallan] FOREIGN KEY([PRCID])
REFERENCES [dbo].[PurchaseReturnChallan] ([sysSerial])
GO
ALTER TABLE [dbo].[PurchaseReturnChallanItems] CHECK CONSTRAINT [FK_PurchaseReturnChallanItems_PurchaseReturnChallan]
GO
ALTER TABLE [dbo].[SaleOrder]  WITH CHECK ADD  CONSTRAINT [FK_SaleOrder_Booker] FOREIGN KEY([BookerID])
REFERENCES [dbo].[OrderBooker] ([sysSerial])
GO
ALTER TABLE [dbo].[SaleOrder] CHECK CONSTRAINT [FK_SaleOrder_Booker]
GO
ALTER TABLE [dbo].[SaleOrder]  WITH CHECK ADD  CONSTRAINT [FK_SaleOrder_SalesMan] FOREIGN KEY([SalesManID])
REFERENCES [dbo].[Salesman] ([sysSerial])
GO
ALTER TABLE [dbo].[SaleOrder] CHECK CONSTRAINT [FK_SaleOrder_SalesMan]
GO
ALTER TABLE [dbo].[SaleOrder]  WITH CHECK ADD  CONSTRAINT [FK_SaleOrder_SSClients] FOREIGN KEY([ClientID])
REFERENCES [dbo].[SSClients] ([sysSerial])
GO
ALTER TABLE [dbo].[SaleOrder] CHECK CONSTRAINT [FK_SaleOrder_SSClients]
GO
ALTER TABLE [dbo].[SaleOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_SaleOrderDetail_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([sysSerial])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SaleOrderDetail] CHECK CONSTRAINT [FK_SaleOrderDetail_Items]
GO
ALTER TABLE [dbo].[SaleOrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_SaleOrderDetail_SOrder] FOREIGN KEY([SOrderID])
REFERENCES [dbo].[SaleOrder] ([sysSerial])
GO
ALTER TABLE [dbo].[SaleOrderDetail] CHECK CONSTRAINT [FK_SaleOrderDetail_SOrder]
GO
ALTER TABLE [dbo].[SalesDamageChallan]  WITH CHECK ADD  CONSTRAINT [FK_SalesDamageChallan_DailySales] FOREIGN KEY([DSRNumber])
REFERENCES [dbo].[DailySales] ([DSRNumber])
GO
ALTER TABLE [dbo].[SalesDamageChallan] CHECK CONSTRAINT [FK_SalesDamageChallan_DailySales]
GO
ALTER TABLE [dbo].[SalesDamageChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_SalesDamageChallanItems_SalesDamageChallan] FOREIGN KEY([DamCID])
REFERENCES [dbo].[SalesDamageChallan] ([sysSerial])
GO
ALTER TABLE [dbo].[SalesDamageChallanItems] CHECK CONSTRAINT [FK_SalesDamageChallanItems_SalesDamageChallan]
GO
ALTER TABLE [dbo].[SalesDeliveryChallan]  WITH CHECK ADD  CONSTRAINT [FK_SalesDC_DailySales] FOREIGN KEY([DSRNumber])
REFERENCES [dbo].[DailySales] ([DSRNumber])
GO
ALTER TABLE [dbo].[SalesDeliveryChallan] CHECK CONSTRAINT [FK_SalesDC_DailySales]
GO
ALTER TABLE [dbo].[SalesDeliveryChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_SalesDCItems_SalesDC] FOREIGN KEY([DCID])
REFERENCES [dbo].[SalesDeliveryChallan] ([sysSerial])
GO
ALTER TABLE [dbo].[SalesDeliveryChallanItems] CHECK CONSTRAINT [FK_SalesDCItems_SalesDC]
GO
ALTER TABLE [dbo].[SalesDeliveryChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_SalesDCItems_SalesDCItems] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([sysSerial])
GO
ALTER TABLE [dbo].[SalesDeliveryChallanItems] CHECK CONSTRAINT [FK_SalesDCItems_SalesDCItems]
GO
ALTER TABLE [dbo].[SalesReturnChallan]  WITH CHECK ADD  CONSTRAINT [FK_SalesRC_DailySales] FOREIGN KEY([DSRNumber])
REFERENCES [dbo].[DailySales] ([DSRNumber])
GO
ALTER TABLE [dbo].[SalesReturnChallan] CHECK CONSTRAINT [FK_SalesRC_DailySales]
GO
ALTER TABLE [dbo].[SalesReturnChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_SalesRCItems_Items] FOREIGN KEY([ItemID])
REFERENCES [dbo].[Items] ([sysSerial])
GO
ALTER TABLE [dbo].[SalesReturnChallanItems] CHECK CONSTRAINT [FK_SalesRCItems_Items]
GO
ALTER TABLE [dbo].[SalesReturnChallanItems]  WITH CHECK ADD  CONSTRAINT [FK_SalesRCItems_SalesRC] FOREIGN KEY([RCID])
REFERENCES [dbo].[SalesReturnChallan] ([sysSerial])
GO
ALTER TABLE [dbo].[SalesReturnChallanItems] CHECK CONSTRAINT [FK_SalesRCItems_SalesRC]
GO
ALTER TABLE [dbo].[SSAccounts]  WITH CHECK ADD  CONSTRAINT [FK_SSAccounts_AccountCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[AccountCategory] ([sysSerial])
GO
ALTER TABLE [dbo].[SSAccounts] CHECK CONSTRAINT [FK_SSAccounts_AccountCategory]
GO
ALTER TABLE [dbo].[SSUsers]  WITH CHECK ADD  CONSTRAINT [FK_SSUsers_SSUserRoles] FOREIGN KEY([RoleID])
REFERENCES [dbo].[SSUsersRoles] ([sysSerial])
GO
ALTER TABLE [dbo].[SSUsers] CHECK CONSTRAINT [FK_SSUsers_SSUserRoles]
GO
ALTER TABLE [dbo].[Vouchers]  WITH CHECK ADD  CONSTRAINT [FK_Vouchers_SSAccounts] FOREIGN KEY([AccountID])
REFERENCES [dbo].[SSAccounts] ([sysSerial])
GO
ALTER TABLE [dbo].[Vouchers] CHECK CONSTRAINT [FK_Vouchers_SSAccounts]
GO
USE [master]
GO
ALTER DATABASE [SPEEDYSOL] SET  READ_WRITE 
GO
