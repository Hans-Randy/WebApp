
USE [WebAppDev]
GO

SET IDENTITY_INSERT [UserType] ON 
INSERT INTO [UserType] ([ID], [Name],[IsStaff]) VALUES (1, 'System', 1)
INSERT INTO [UserType] ([ID], [Name],[IsStaff]) VALUES (2, 'Customer', 0)
INSERT INTO [UserType] ([ID], [Name],[IsStaff]) VALUES (3, 'Employee', 1)
SET IDENTITY_INSERT [UserType] OFF
GO

SET IDENTITY_INSERT [User] ON 
INSERT INTO [User] ([ID], [UserTypeID],[Name], [Username], [Password], [Active], [LastLoginDate]) VALUES (1, 1, 'System', 'System', 'System.1234', 1, null)
INSERT INTO [User] ([ID], [UserTypeID],[Name], [Username], [Password], [Active], [LastLoginDate]) VALUES (2, 3, 'Bob', 'Employee', 'Employee.1234', 1, null)
INSERT INTO [User] ([ID], [UserTypeID],[Name], [Username], [Password], [Active], [LastLoginDate]) VALUES (3, 2, 'William', 'Customer', 'Customer.1234', 1, null)
SET IDENTITY_INSERT [User] OFF
GO


SET IDENTITY_INSERT [ProductType] ON 
INSERT INTO [ProductType] ([ID], [Name]) VALUES (1, 'Convenience Products')
INSERT INTO [ProductType] ([ID], [Name]) VALUES (2, 'Electronics')
INSERT INTO [ProductType] ([ID], [Name]) VALUES (3, 'Food and Beverages')
SET IDENTITY_INSERT [ProductType] OFF
GO

SET IDENTITY_INSERT [Product] ON 
INSERT INTO [Product] ([ID], [Name]) VALUES (1, 'Soap', 1)
INSERT INTO [Product] ([ID], [Name]) VALUES (2, 'Dell Laptop', 2)
INSERT INTO [Product] ([ID], [Name]) VALUES (3, 'Croissant', 3)
SET IDENTITY_INSERT [Product] OFF
GO

SET IDENTITY_INSERT [ActivityType] ON 
INSERT INTO [ActivityType] ([ID], [Name]) VALUES (1, 'Login')
INSERT INTO [ActivityType] ([ID], [Name]) VALUES (2, 'Logout')
SET IDENTITY_INSERT [ActivityType] OFF
GO


