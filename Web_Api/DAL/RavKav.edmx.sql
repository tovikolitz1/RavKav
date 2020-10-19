
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/26/2020 22:47:54
-- Generated from EDMX file: D:\technut\פרויקט גמר\MyKav\Web_Api\DAL\RavKav.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RavKav];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Area]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Area];
GO
IF OBJECT_ID(N'[dbo].[AreaToContract]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AreaToContract];
GO
IF OBJECT_ID(N'[dbo].[Contract]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contract];
GO
IF OBJECT_ID(N'[dbo].[Profile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Profile];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[ModelStoreContainer].[Transit]', 'U') IS NOT NULL
    DROP TABLE [ModelStoreContainer].[Transit];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'CardTbls'
CREATE TABLE [dbo].[CardTbls] (
    [id] int  NOT NULL,
    [describe] nchar(30)  NULL,
    [freeMonthly] float  NULL,
    [freeWeekly] float  NULL,
    [freeDaily] float  NULL,
    [single] float  NOT NULL,
    [test] varchar(50)  NULL
);
GO

-- Creating table 'ProfilsTbls'
CREATE TABLE [dbo].[ProfilsTbls] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nchar(20)  NULL,
    [discountPercentage] nchar(15)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'TransitTbls'
CREATE TABLE [dbo].[TransitTbls] (
    [id] int IDENTITY(1,1) NOT NULL,
    [number] int  NOT NULL,
    [cardId] int  NOT NULL
);
GO

-- Creating table 'TravelsTbls'
CREATE TABLE [dbo].[TravelsTbls] (
    [id] int IDENTITY(1,1) NOT NULL,
    [dateAndTime] datetime  NOT NULL,
    [userId] int  NOT NULL,
    [TransitId] int  NOT NULL,
    [Property1] nvarchar(max)  NOT NULL,
    [Property2] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserTbls'
CREATE TABLE [dbo].[UserTbls] (
    [id] int IDENTITY(1,1) NOT NULL,
    [isManager] bit  NOT NULL,
    [ravkav] varchar(50)  NOT NULL,
    [password] varchar(50)  NOT NULL,
    [firstName] varchar(50)  NOT NULL,
    [lastName] varchar(50)  NOT NULL,
    [profileId] int  NOT NULL
);
GO

-- Creating table 'Areas'
CREATE TABLE [dbo].[Areas] (
    [id] int  NOT NULL,
    [name] varchar(50)  NOT NULL
);
GO

-- Creating table 'AreaToContracts'
CREATE TABLE [dbo].[AreaToContracts] (
    [id] int  NOT NULL,
    [contractID] int  NOT NULL,
    [areaID] int  NOT NULL
);
GO

-- Creating table 'Contracts'
CREATE TABLE [dbo].[Contracts] (
    [id] int  NOT NULL,
    [freeDay] float  NOT NULL,
    [freeMounth] float  NOT NULL
);
GO

-- Creating table 'Profiles'
CREATE TABLE [dbo].[Profiles] (
    [id] int  NOT NULL,
    [discount] int  NOT NULL,
    [describe] varchar(50)  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [id] int  NOT NULL,
    [fName] varchar(50)  NOT NULL,
    [lName] varchar(50)  NOT NULL,
    [email] varchar(50)  NOT NULL,
    [isManager] bit  NOT NULL,
    [pass] varchar(15)  NOT NULL,
    [ravkavNum] varchar(50)  NOT NULL,
    [profileId] int  NULL
);
GO

-- Creating table 'Transits'
CREATE TABLE [dbo].[Transits] (
    [id] int  NOT NULL,
    [bas] varchar(3)  NOT NULL,
    [price] float  NOT NULL,
    [areaID] int  NOT NULL,
    [InternalOrIntermediate] bit  NOT NULL,
    [transitTrip] bit  NOT NULL,
    [userID] int  NOT NULL,
    [date] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'CardTbls'
ALTER TABLE [dbo].[CardTbls]
ADD CONSTRAINT [PK_CardTbls]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ProfilsTbls'
ALTER TABLE [dbo].[ProfilsTbls]
ADD CONSTRAINT [PK_ProfilsTbls]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [id] in table 'TransitTbls'
ALTER TABLE [dbo].[TransitTbls]
ADD CONSTRAINT [PK_TransitTbls]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'TravelsTbls'
ALTER TABLE [dbo].[TravelsTbls]
ADD CONSTRAINT [PK_TravelsTbls]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'UserTbls'
ALTER TABLE [dbo].[UserTbls]
ADD CONSTRAINT [PK_UserTbls]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Areas'
ALTER TABLE [dbo].[Areas]
ADD CONSTRAINT [PK_Areas]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'AreaToContracts'
ALTER TABLE [dbo].[AreaToContracts]
ADD CONSTRAINT [PK_AreaToContracts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Contracts'
ALTER TABLE [dbo].[Contracts]
ADD CONSTRAINT [PK_Contracts]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Profiles'
ALTER TABLE [dbo].[Profiles]
ADD CONSTRAINT [PK_Profiles]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [bas], [price], [areaID], [InternalOrIntermediate], [transitTrip], [userID], [date] in table 'Transits'
ALTER TABLE [dbo].[Transits]
ADD CONSTRAINT [PK_Transits]
    PRIMARY KEY CLUSTERED ([id], [bas], [price], [areaID], [InternalOrIntermediate], [transitTrip], [userID], [date] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [cardId] in table 'TransitTbls'
ALTER TABLE [dbo].[TransitTbls]
ADD CONSTRAINT [FK_TransitTbl_CardTbl]
    FOREIGN KEY ([cardId])
    REFERENCES [dbo].[CardTbls]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TransitTbl_CardTbl'
CREATE INDEX [IX_FK_TransitTbl_CardTbl]
ON [dbo].[TransitTbls]
    ([cardId]);
GO

-- Creating foreign key on [profileId] in table 'UserTbls'
ALTER TABLE [dbo].[UserTbls]
ADD CONSTRAINT [FK_UserTbl_ProfilsTbl]
    FOREIGN KEY ([profileId])
    REFERENCES [dbo].[ProfilsTbls]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserTbl_ProfilsTbl'
CREATE INDEX [IX_FK_UserTbl_ProfilsTbl]
ON [dbo].[UserTbls]
    ([profileId]);
GO

-- Creating foreign key on [TransitId] in table 'TravelsTbls'
ALTER TABLE [dbo].[TravelsTbls]
ADD CONSTRAINT [FK_TravelsTbl_TransitTbl]
    FOREIGN KEY ([TransitId])
    REFERENCES [dbo].[TransitTbls]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelsTbl_TransitTbl'
CREATE INDEX [IX_FK_TravelsTbl_TransitTbl]
ON [dbo].[TravelsTbls]
    ([TransitId]);
GO

-- Creating foreign key on [userId] in table 'TravelsTbls'
ALTER TABLE [dbo].[TravelsTbls]
ADD CONSTRAINT [FK_TravelsTbl_UserTbl]
    FOREIGN KEY ([userId])
    REFERENCES [dbo].[UserTbls]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TravelsTbl_UserTbl'
CREATE INDEX [IX_FK_TravelsTbl_UserTbl]
ON [dbo].[TravelsTbls]
    ([userId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------