
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 03/29/2012 09:18:27
-- Generated from EDMX file: C:\BTi\Projects\Babble\Bti.Babble.Model\Entity\Babble.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Babble];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PollEventPollResponse]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PollResponses] DROP CONSTRAINT [FK_PollEventPollResponse];
GO
IF OBJECT_ID(N'[dbo].[FK_PollEvent_inherits_BabbleEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BabbleEvents_PollEvent] DROP CONSTRAINT [FK_PollEvent_inherits_BabbleEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_CommentEvent_inherits_BabbleEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BabbleEvents_CommentEvent] DROP CONSTRAINT [FK_CommentEvent_inherits_BabbleEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_CouponEvent_inherits_BabbleEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BabbleEvents_CouponEvent] DROP CONSTRAINT [FK_CouponEvent_inherits_BabbleEvent];
GO
IF OBJECT_ID(N'[dbo].[FK_StoryEvent_inherits_BabbleEvent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[BabbleEvents_StoryEvent] DROP CONSTRAINT [FK_StoryEvent_inherits_BabbleEvent];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[BabbleEvents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BabbleEvents];
GO
IF OBJECT_ID(N'[dbo].[PollResponses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PollResponses];
GO
IF OBJECT_ID(N'[dbo].[BabbleEvents_PollEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BabbleEvents_PollEvent];
GO
IF OBJECT_ID(N'[dbo].[BabbleEvents_CommentEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BabbleEvents_CommentEvent];
GO
IF OBJECT_ID(N'[dbo].[BabbleEvents_CouponEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BabbleEvents_CouponEvent];
GO
IF OBJECT_ID(N'[dbo].[BabbleEvents_StoryEvent]', 'U') IS NOT NULL
    DROP TABLE [dbo].[BabbleEvents_StoryEvent];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'BabbleEvents'
CREATE TABLE [dbo].[BabbleEvents] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PubData] datetime  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [User] nvarchar(max)  NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Image] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PollResponses'
CREATE TABLE [dbo].[PollResponses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [Votes] int  NOT NULL,
    [PollEventId] int  NOT NULL
);
GO

-- Creating table 'BabbleEvents_PollEvent'
CREATE TABLE [dbo].[BabbleEvents_PollEvent] (
    [Question] nvarchar(max)  NOT NULL,
    [Votes] int  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'BabbleEvents_CommentEvent'
CREATE TABLE [dbo].[BabbleEvents_CommentEvent] (
    [Id] int  NOT NULL
);
GO

-- Creating table 'BabbleEvents_CouponEvent'
CREATE TABLE [dbo].[BabbleEvents_CouponEvent] (
    [Store] nvarchar(max)  NOT NULL,
    [Coupon] nvarchar(max)  NOT NULL,
    [Code] nvarchar(max)  NOT NULL,
    [Link] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- Creating table 'BabbleEvents_StoryEvent'
CREATE TABLE [dbo].[BabbleEvents_StoryEvent] (
    [Title] nvarchar(max)  NOT NULL,
    [Description] nvarchar(max)  NOT NULL,
    [Link] nvarchar(max)  NOT NULL,
    [StoryImage] nvarchar(max)  NOT NULL,
    [Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'BabbleEvents'
ALTER TABLE [dbo].[BabbleEvents]
ADD CONSTRAINT [PK_BabbleEvents]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PollResponses'
ALTER TABLE [dbo].[PollResponses]
ADD CONSTRAINT [PK_PollResponses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BabbleEvents_PollEvent'
ALTER TABLE [dbo].[BabbleEvents_PollEvent]
ADD CONSTRAINT [PK_BabbleEvents_PollEvent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BabbleEvents_CommentEvent'
ALTER TABLE [dbo].[BabbleEvents_CommentEvent]
ADD CONSTRAINT [PK_BabbleEvents_CommentEvent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BabbleEvents_CouponEvent'
ALTER TABLE [dbo].[BabbleEvents_CouponEvent]
ADD CONSTRAINT [PK_BabbleEvents_CouponEvent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BabbleEvents_StoryEvent'
ALTER TABLE [dbo].[BabbleEvents_StoryEvent]
ADD CONSTRAINT [PK_BabbleEvents_StoryEvent]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PollEventId] in table 'PollResponses'
ALTER TABLE [dbo].[PollResponses]
ADD CONSTRAINT [FK_PollEventPollResponse]
    FOREIGN KEY ([PollEventId])
    REFERENCES [dbo].[BabbleEvents_PollEvent]
        ([Id])
    ON DELETE CASCADE ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PollEventPollResponse'
CREATE INDEX [IX_FK_PollEventPollResponse]
ON [dbo].[PollResponses]
    ([PollEventId]);
GO

-- Creating foreign key on [Id] in table 'BabbleEvents_PollEvent'
ALTER TABLE [dbo].[BabbleEvents_PollEvent]
ADD CONSTRAINT [FK_PollEvent_inherits_BabbleEvent]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[BabbleEvents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'BabbleEvents_CommentEvent'
ALTER TABLE [dbo].[BabbleEvents_CommentEvent]
ADD CONSTRAINT [FK_CommentEvent_inherits_BabbleEvent]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[BabbleEvents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'BabbleEvents_CouponEvent'
ALTER TABLE [dbo].[BabbleEvents_CouponEvent]
ADD CONSTRAINT [FK_CouponEvent_inherits_BabbleEvent]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[BabbleEvents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Id] in table 'BabbleEvents_StoryEvent'
ALTER TABLE [dbo].[BabbleEvents_StoryEvent]
ADD CONSTRAINT [FK_StoryEvent_inherits_BabbleEvent]
    FOREIGN KEY ([Id])
    REFERENCES [dbo].[BabbleEvents]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------