CREATE DATABASE [WebAppDev]
GO

USE [WebAppDev]
GO

CREATE TABLE [UserType](
	ID int IDENTITY(1,1) NOT NULL,
	Name varchar(50) NOT NULL,
	IsStaff bit NOT NULL,
	CONSTRAINT [PK_UserType] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO


CREATE TABLE [User](
	ID INT IDENTITY(1,1) NOT NULL,
	UserTypeID int NOT NULL,
	[Name] varchar(25) NOT NULL,
	Username varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	Active bit NOT NULL,
	LastLoginDate datetime NULL,
	CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO

ALTER TABLE [User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserType] FOREIGN KEY([UserTypeID])
REFERENCES [UserType] ([ID])
GO

CREATE TABLE [ProductType](
	ID int IDENTITY(1,1) NOT NULL,
	Name varchar(max) NOT NULL,
	CONSTRAINT [PK_ProductType] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO

CREATE TABLE [Product](
	ID int IDENTITY(1,1) NOT NULL,
	Name varchar(250) NOT NULL,
	ProductTypeID int NOT NULL,
	Price money NOT NULL,
	CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED ([ID] ASC)
)
GO

ALTER TABLE [Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_ProductType] FOREIGN KEY([ProductTypeID])
REFERENCES [ProductType] ([ID])
GO

CREATE TABLE [ActivityType](
	ID int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	Name varchar(50) NOT NULL,
	CONSTRAINT [PK_ActivityType] PRIMARY KEY CLUSTERED ([ID] ASC)
)

GO


CREATE TABLE [UserActivity](
	ID int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	UserID int NOT NULL,
	SessionID varchar(50) NOT NULL,
	ActivityTypeID int NOT NULL,
	DateCreated datetime NOT NULL,
	CONSTRAINT [PK_UserActivity] PRIMARY KEY CLUSTERED ([ID] ASC)
)

GO

ALTER TABLE [UserActivity]  WITH CHECK ADD  CONSTRAINT [FK_UserActivity_ActivityType] FOREIGN KEY([ActivityTypeID])
REFERENCES [ActivityType] ([ID])
GO

ALTER TABLE [UserActivity]  WITH CHECK ADD  CONSTRAINT [FK_UserActivity_User] FOREIGN KEY([UserID])
REFERENCES [User] ([ID])
GO


CREATE TABLE [Order](
	ID int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	OrderNo varchar(100) NOT NULL,
	UserID int NOT NULL,
	DateCreated datetime NOT NULL,
	CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED ([ID] ASC)
)

GO

ALTER TABLE [Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY(UserID)
REFERENCES [User] ([ID])
GO

CREATE TABLE [LineItem](
	ID int IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	OrderID int NOT NULL,
	ProductID int NOT NULL,
	[Description] varchar(150) NOT NULL,
	Quantity int not null,
	Amount money not null,
	CONSTRAINT [PK_LineItem] PRIMARY KEY CLUSTERED ([ID] ASC)
)

GO

ALTER TABLE [LineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Order] FOREIGN KEY(OrderID)
REFERENCES [Order] ([ID])
GO

ALTER TABLE [LineItem]  WITH CHECK ADD  CONSTRAINT [FK_LineItem_Product] FOREIGN KEY(ProductID)
REFERENCES [Product] ([ID])
GO

