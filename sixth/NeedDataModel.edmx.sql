
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/12/2021 13:36:31
-- Generated from EDMX file: D:\asp_web_api\six\sixth\sixth\NeedDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [needDb];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[need_login_table]', 'U') IS NOT NULL
    DROP TABLE [dbo].[need_login_table];
GO
IF OBJECT_ID(N'[dbo].[need_product_details]', 'U') IS NOT NULL
    DROP TABLE [dbo].[need_product_details];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'need_login_table'
CREATE TABLE [dbo].[need_login_table] (
    [mobile_number] varchar(10)  NOT NULL,
    [first_name] varchar(max)  NULL,
    [last_name] varchar(max)  NULL,
    [email] varchar(max)  NULL,
    [password] varchar(max)  NULL,
    [gender] varchar(max)  NULL,
    [profile_image] varchar(max)  NULL,
    [first_login] varchar(max)  NULL,
    [last_login] varchar(max)  NULL
);
GO

-- Creating table 'need_product_details'
CREATE TABLE [dbo].[need_product_details] (
    [product_id] varchar(50)  NOT NULL,
    [time_stamp] varchar(max)  NULL,
    [photo_one] varchar(max)  NULL,
    [photo_two] varchar(max)  NULL,
    [photo_three] varchar(max)  NULL,
    [lat] varchar(max)  NULL,
    [long] varchar(max)  NULL,
    [title] varchar(max)  NULL,
    [decription] varchar(max)  NULL,
    [category] varchar(max)  NULL,
    [sub_category] varchar(max)  NULL,
    [super_sub_catrgory] varchar(max)  NULL,
    [mobile_number] varchar(max)  NULL,
    [isactive] varchar(max)  NULL,
    [report_count] varchar(max)  NULL,
    [emailId] varchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [mobile_number] in table 'need_login_table'
ALTER TABLE [dbo].[need_login_table]
ADD CONSTRAINT [PK_need_login_table]
    PRIMARY KEY CLUSTERED ([mobile_number] ASC);
GO

-- Creating primary key on [product_id] in table 'need_product_details'
ALTER TABLE [dbo].[need_product_details]
ADD CONSTRAINT [PK_need_product_details]
    PRIMARY KEY CLUSTERED ([product_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------