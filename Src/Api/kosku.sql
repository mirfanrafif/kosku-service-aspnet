USE [master]
GO
/****** Object:  Database [kosku]    Script Date: 6/15/2021 1:27:18 PM ******/
CREATE DATABASE [kosku]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'kosku', FILENAME = N'D:\Apps\MSSQLServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\kosku.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'kosku_log', FILENAME = N'D:\Apps\MSSQLServer\MSSQL15.MSSQLSERVER\MSSQL\DATA\kosku_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

USE [kosku]
GO
/****** Object:  User [mirfanrafif]    Script Date: 6/15/2021 1:27:21 PM ******/
CREATE USER [mirfanrafif] FOR LOGIN [mirfanrafif] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[anakkos]    Script Date: 6/15/2021 1:27:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[anakkos]
(
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nama] [varchar](50) NOT NULL,
	[asal] [varchar](50) NOT NULL,
	[nohp] [varchar](50) NOT NULL
) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [kosku] SET  READ_WRITE 
GO
