/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : SQL Server
 Source Server Version : 10501600
 Source Host           : localhost:1433
 Source Catalog        : BookOnline
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 10501600
 File Encoding         : 65001

 Date: 24/04/2018 10:33:14
*/


-- ----------------------------
-- Table structure for __MigrationHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__MigrationHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__MigrationHistory]
GO

CREATE TABLE [dbo].[__MigrationHistory] (
  [MigrationId] nvarchar(150) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NOT NULL,
  [ContextKey] nvarchar(300) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NOT NULL,
  [Model] varbinary(max) NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NOT NULL
)
GO

ALTER TABLE [dbo].[__MigrationHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for BookDetailInfoes
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BookDetailInfoes]') AND type IN ('U'))
	DROP TABLE [dbo].[BookDetailInfoes]
GO

CREATE TABLE [dbo].[BookDetailInfoes] (
  [BookId] int IDENTITY(1,1) NOT NULL,
  [PlaceOfPublication] nvarchar(max) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NULL,
  [CopyrightDescription] nvarchar(max) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NULL,
  [ISBN] int NULL,
  [Price] decimal(18,2) NULL,
  [Folio] int NULL,
  [Sheet] int NULL,
  [Impression] int NULL,
  [Revision] int NULL,
  [PrintingCompany] int NULL
)
GO

ALTER TABLE [dbo].[BookDetailInfoes] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for BookInfoes
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BookInfoes]') AND type IN ('U'))
	DROP TABLE [dbo].[BookInfoes]
GO

CREATE TABLE [dbo].[BookInfoes] (
  [BookId] int IDENTITY(1,1) NOT NULL,
  [BookName] nvarchar(max) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NULL,
  [AuthorName] nvarchar(max) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NULL,
  [BookTypeId] nvarchar(max) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NULL
)
GO

ALTER TABLE [dbo].[BookInfoes] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for BorrowInfoes
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[BorrowInfoes]') AND type IN ('U'))
	DROP TABLE [dbo].[BorrowInfoes]
GO

CREATE TABLE [dbo].[BorrowInfoes] (
  [BorrowId] int IDENTITY(1,1) NOT NULL,
  [UserId] int NULL,
  [BookId] int NULL,
  [BorrowTime] datetime NULL,
  [ReturnTime] datetime NULL,
  [State] int NULL
)
GO

ALTER TABLE [dbo].[BorrowInfoes] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Table structure for Users
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type IN ('U'))
	DROP TABLE [dbo].[Users]
GO

CREATE TABLE [dbo].[Users] (
  [UserId] int NOT NULL,
  [UserAccount] nvarchar(128) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NOT NULL,
  [PassWord] nvarchar(max) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NULL,
  [UserName] nvarchar(max) COLLATE Chinese_Traditional_Bopomofo_100_CI_AS_KS NULL,
  [UserSex] int NULL,
  [StartTime] datetime NULL,
  [EndTime] datetime NULL
)
GO

ALTER TABLE [dbo].[Users] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table __MigrationHistory
-- ----------------------------
ALTER TABLE [dbo].[__MigrationHistory] ADD CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED ([MigrationId], [ContextKey])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BookDetailInfoes
-- ----------------------------
ALTER TABLE [dbo].[BookDetailInfoes] ADD CONSTRAINT [PK_dbo.BookDetailInfoes] PRIMARY KEY CLUSTERED ([BookId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BookInfoes
-- ----------------------------
ALTER TABLE [dbo].[BookInfoes] ADD CONSTRAINT [PK_dbo.BookInfoes] PRIMARY KEY CLUSTERED ([BookId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table BorrowInfoes
-- ----------------------------
ALTER TABLE [dbo].[BorrowInfoes] ADD CONSTRAINT [PK_dbo.BorrowInfoes] PRIMARY KEY CLUSTERED ([BorrowId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table Users
-- ----------------------------
ALTER TABLE [dbo].[Users] ADD CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([UserId], [UserAccount])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO

