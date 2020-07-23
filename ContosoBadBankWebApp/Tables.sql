USE [depotdb]
GO

/****** Object: Table [dbo].[Orders] Script Date: 23.07.2020 13:57:10 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders] (
    [id]             INT          IDENTITY (1, 1) NOT NULL,
    [StockSymbol]    VARCHAR (10) NULL,
    [TradeDate]      DATETIME     NULL,
    [NrOfTradeItems] INT          NULL,
    [objectId]       VARCHAR (50) NULL,
    [Price]          DECIMAL (18) NULL,
    [OrderStatus]    NCHAR (20)   NULL,
    [Action]         VARCHAR (10) NULL
);

GO

CREATE TABLE [dbo].[DepotEntries] (
    [Id]          INT          IDENTITY (1, 1) NOT NULL,
    [objectId]    VARCHAR (50) NULL,
    [NrOfItems]   INT          NULL,
    [StockSymbol] VARCHAR (10) NULL
);
