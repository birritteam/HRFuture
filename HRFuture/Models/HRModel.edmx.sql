
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/30/2017 14:46:51
-- Generated from EDMX file: C:\Users\Birr IT\Documents\GitHub\HRFuture\HRFuture\Models\HRModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [HR-Future];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetRoles]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[FK_AspNetUserRoles_AspNetUsers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserRoles] DROP CONSTRAINT [FK_AspNetUserRoles_AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[FK_Best_Friends_Personal_Info]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Best_Friends] DROP CONSTRAINT [FK_Best_Friends_Personal_Info];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserClaims] DROP CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AspNetUserLogins] DROP CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId];
GO
IF OBJECT_ID(N'[dbo].[FK_Emergency_Address_Personal_Info]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Emergency_Address] DROP CONSTRAINT [FK_Emergency_Address_Personal_Info];
GO
IF OBJECT_ID(N'[dbo].[FK_Other_Course_Personal_Info]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Other_Course] DROP CONSTRAINT [FK_Other_Course_Personal_Info];
GO
IF OBJECT_ID(N'[dbo].[FK_Personal_Skills_Personal_Info]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Skills] DROP CONSTRAINT [FK_Personal_Skills_Personal_Info];
GO
IF OBJECT_ID(N'[dbo].[FK_Personal_Skills_Skills_Info]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Personal_Skills] DROP CONSTRAINT [FK_Personal_Skills_Skills_Info];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AspNetRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserClaims]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserClaims];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserLogins]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserLogins];
GO
IF OBJECT_ID(N'[dbo].[AspNetUserRoles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUserRoles];
GO
IF OBJECT_ID(N'[dbo].[AspNetUsers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AspNetUsers];
GO
IF OBJECT_ID(N'[dbo].[Best_Friends]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Best_Friends];
GO
IF OBJECT_ID(N'[dbo].[Emergency_Address]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Emergency_Address];
GO
IF OBJECT_ID(N'[dbo].[Other_Course]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Other_Course];
GO
IF OBJECT_ID(N'[dbo].[Personal_Info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Info];
GO
IF OBJECT_ID(N'[dbo].[Personal_Skills]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Personal_Skills];
GO
IF OBJECT_ID(N'[dbo].[Skills_Info]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Skills_Info];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AspNetRoles'
CREATE TABLE [dbo].[AspNetRoles] (
    [Id] nvarchar(128)  NOT NULL,
    [Name] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'AspNetUserClaims'
CREATE TABLE [dbo].[AspNetUserClaims] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] nvarchar(128)  NOT NULL,
    [ClaimType] nvarchar(max)  NULL,
    [ClaimValue] nvarchar(max)  NULL
);
GO

-- Creating table 'AspNetUserLogins'
CREATE TABLE [dbo].[AspNetUserLogins] (
    [LoginProvider] nvarchar(128)  NOT NULL,
    [ProviderKey] nvarchar(128)  NOT NULL,
    [UserId] nvarchar(128)  NOT NULL
);
GO

-- Creating table 'AspNetUsers'
CREATE TABLE [dbo].[AspNetUsers] (
    [Id] nvarchar(128)  NOT NULL,
    [Email] nvarchar(256)  NULL,
    [EmailConfirmed] bit  NOT NULL,
    [PasswordHash] nvarchar(max)  NULL,
    [SecurityStamp] nvarchar(max)  NULL,
    [PhoneNumber] nvarchar(max)  NULL,
    [PhoneNumberConfirmed] bit  NOT NULL,
    [TwoFactorEnabled] bit  NOT NULL,
    [LockoutEndDateUtc] datetime  NULL,
    [LockoutEnabled] bit  NOT NULL,
    [AccessFailedCount] int  NOT NULL,
    [UserName] nvarchar(256)  NOT NULL
);
GO

-- Creating table 'Best_Friends'
CREATE TABLE [dbo].[Best_Friends] (
    [personid] int  NOT NULL,
    [persontype] char(2)  NOT NULL,
    [name] nvarchar(100)  NOT NULL
);
GO

-- Creating table 'Emergency_Address'
CREATE TABLE [dbo].[Emergency_Address] (
    [personid] int  NOT NULL,
    [persontype] char(2)  NOT NULL,
    [name] nchar(10)  NOT NULL,
    [relationtype] nvarchar(50)  NULL,
    [phone] nvarchar(15)  NULL
);
GO

-- Creating table 'Other_Course'
CREATE TABLE [dbo].[Other_Course] (
    [personid] int  NOT NULL,
    [persontype] char(2)  NOT NULL,
    [name] nvarchar(100)  NOT NULL,
    [organizer] nvarchar(100)  NULL,
    [date] datetime  NULL
);
GO

-- Creating table 'Personal_Info'
CREATE TABLE [dbo].[Personal_Info] (
    [id] int  NOT NULL,
    [type] char(2)  NOT NULL,
    [fname] nvarchar(50)  NOT NULL,
    [lname] nvarchar(50)  NOT NULL,
    [fathername] nvarchar(50)  NOT NULL,
    [mothername] nvarchar(50)  NOT NULL,
    [ename] nvarchar(200)  NULL,
    [bdate] datetime  NULL,
    [bronum] int  NULL,
    [glass] bit  NULL,
    [smoke] bit  NULL,
    [health] bit  NULL,
    [smoketype] nvarchar(50)  NULL,
    [curraddres] nvarchar(50)  NULL,
    [lastaddress] nvarchar(50)  NULL,
    [mobile] nvarchar(15)  NULL,
    [phone] nvarchar(15)  NULL,
    [mail] nvarchar(50)  NULL,
    [facebook] nvarchar(300)  NULL,
    [education] nvarchar(50)  NULL,
    [netifuse] bit  NULL,
    [netusing] nvarchar(200)  NULL,
    [notes] varchar(max)  NULL,
    [knownfriend] nvarchar(100)  NULL,
    [knowninitiative] nvarchar(100)  NULL,
    [knowngheraspage] bit  NULL,
    [applydate] datetime  NULL,
    [sizejacket] nvarchar(50)  NULL,
    [sizeshirt] nvarchar(50)  NULL,
    [sizepants] int  NULL,
    [sizevest] nvarchar(50)  NULL,
    [sizesport] nvarchar(50)  NULL,
    [sizeshoes] int  NULL,
    [isactive] bit  NULL,
    [personalphoto] nvarchar(200)  NULL,
    [idphoto] nvarchar(200)  NULL,
    [schoolname] nvarchar(200)  NULL,
    [Time] nvarchar(max)  NULL,
    [updateddate] datetime  NULL,
    [educationbranch] nchar(30)  NULL
);
GO

-- Creating table 'Personal_Skills'
CREATE TABLE [dbo].[Personal_Skills] (
    [personid] int  NOT NULL,
    [persontype] char(2)  NOT NULL,
    [skillid] int  NOT NULL,
    [eval] nvarchar(100)  NULL
);
GO

-- Creating table 'Skills_Info'
CREATE TABLE [dbo].[Skills_Info] (
    [id] int  NOT NULL,
    [name] nvarchar(100)  NULL,
    [flag] char(4)  NULL
);
GO

-- Creating table 'AspNetUserRoles'
CREATE TABLE [dbo].[AspNetUserRoles] (
    [AspNetRoles_Id] nvarchar(128)  NOT NULL,
    [AspNetUsers_Id] nvarchar(128)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'AspNetRoles'
ALTER TABLE [dbo].[AspNetRoles]
ADD CONSTRAINT [PK_AspNetRoles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [PK_AspNetUserClaims]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [LoginProvider], [ProviderKey], [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [PK_AspNetUserLogins]
    PRIMARY KEY CLUSTERED ([LoginProvider], [ProviderKey], [UserId] ASC);
GO

-- Creating primary key on [Id] in table 'AspNetUsers'
ALTER TABLE [dbo].[AspNetUsers]
ADD CONSTRAINT [PK_AspNetUsers]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [personid], [persontype], [name] in table 'Best_Friends'
ALTER TABLE [dbo].[Best_Friends]
ADD CONSTRAINT [PK_Best_Friends]
    PRIMARY KEY CLUSTERED ([personid], [persontype], [name] ASC);
GO

-- Creating primary key on [personid], [persontype], [name] in table 'Emergency_Address'
ALTER TABLE [dbo].[Emergency_Address]
ADD CONSTRAINT [PK_Emergency_Address]
    PRIMARY KEY CLUSTERED ([personid], [persontype], [name] ASC);
GO

-- Creating primary key on [personid], [persontype], [name] in table 'Other_Course'
ALTER TABLE [dbo].[Other_Course]
ADD CONSTRAINT [PK_Other_Course]
    PRIMARY KEY CLUSTERED ([personid], [persontype], [name] ASC);
GO

-- Creating primary key on [id], [type] in table 'Personal_Info'
ALTER TABLE [dbo].[Personal_Info]
ADD CONSTRAINT [PK_Personal_Info]
    PRIMARY KEY CLUSTERED ([id], [type] ASC);
GO

-- Creating primary key on [personid], [persontype], [skillid] in table 'Personal_Skills'
ALTER TABLE [dbo].[Personal_Skills]
ADD CONSTRAINT [PK_Personal_Skills]
    PRIMARY KEY CLUSTERED ([personid], [persontype], [skillid] ASC);
GO

-- Creating primary key on [id] in table 'Skills_Info'
ALTER TABLE [dbo].[Skills_Info]
ADD CONSTRAINT [PK_Skills_Info]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [AspNetRoles_Id], [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [PK_AspNetUserRoles]
    PRIMARY KEY CLUSTERED ([AspNetRoles_Id], [AspNetUsers_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [UserId] in table 'AspNetUserClaims'
ALTER TABLE [dbo].[AspNetUserClaims]
ADD CONSTRAINT [FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserClaims_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserClaims]
    ([UserId]);
GO

-- Creating foreign key on [UserId] in table 'AspNetUserLogins'
ALTER TABLE [dbo].[AspNetUserLogins]
ADD CONSTRAINT [FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
    FOREIGN KEY ([UserId])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId'
CREATE INDEX [IX_FK_dbo_AspNetUserLogins_dbo_AspNetUsers_UserId]
ON [dbo].[AspNetUserLogins]
    ([UserId]);
GO

-- Creating foreign key on [personid], [persontype] in table 'Best_Friends'
ALTER TABLE [dbo].[Best_Friends]
ADD CONSTRAINT [FK_Best_Friends_Personal_Info]
    FOREIGN KEY ([personid], [persontype])
    REFERENCES [dbo].[Personal_Info]
        ([id], [type])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [personid], [persontype] in table 'Emergency_Address'
ALTER TABLE [dbo].[Emergency_Address]
ADD CONSTRAINT [FK_Emergency_Address_Personal_Info]
    FOREIGN KEY ([personid], [persontype])
    REFERENCES [dbo].[Personal_Info]
        ([id], [type])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [personid], [persontype] in table 'Other_Course'
ALTER TABLE [dbo].[Other_Course]
ADD CONSTRAINT [FK_Other_Course_Personal_Info]
    FOREIGN KEY ([personid], [persontype])
    REFERENCES [dbo].[Personal_Info]
        ([id], [type])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [personid], [persontype] in table 'Personal_Skills'
ALTER TABLE [dbo].[Personal_Skills]
ADD CONSTRAINT [FK_Personal_Skills_Personal_Info]
    FOREIGN KEY ([personid], [persontype])
    REFERENCES [dbo].[Personal_Info]
        ([id], [type])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [skillid] in table 'Personal_Skills'
ALTER TABLE [dbo].[Personal_Skills]
ADD CONSTRAINT [FK_Personal_Skills_Skills_Info]
    FOREIGN KEY ([skillid])
    REFERENCES [dbo].[Skills_Info]
        ([id])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Personal_Skills_Skills_Info'
CREATE INDEX [IX_FK_Personal_Skills_Skills_Info]
ON [dbo].[Personal_Skills]
    ([skillid]);
GO

-- Creating foreign key on [AspNetRoles_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetRoles]
    FOREIGN KEY ([AspNetRoles_Id])
    REFERENCES [dbo].[AspNetRoles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [AspNetUsers_Id] in table 'AspNetUserRoles'
ALTER TABLE [dbo].[AspNetUserRoles]
ADD CONSTRAINT [FK_AspNetUserRoles_AspNetUsers]
    FOREIGN KEY ([AspNetUsers_Id])
    REFERENCES [dbo].[AspNetUsers]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AspNetUserRoles_AspNetUsers'
CREATE INDEX [IX_FK_AspNetUserRoles_AspNetUsers]
ON [dbo].[AspNetUserRoles]
    ([AspNetUsers_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------