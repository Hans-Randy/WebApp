
USE [WebAppDev]
GO



Create view [OrderDetail]
as

select 
	[Order].ID
	, [Order].OrderNo
	, [User].ID as UserID
	, [User].Name as UserName
	, [Order].DateCreated
	, (select sum(Amount) from LineItem with (nolock) where LineItem.OrderID = [Order].ID) as TotalAmount
from
	[Order] with (nolock)
inner join
	[User] with (nolock) on [Order].UserID = [User].ID
inner join
	[UserType] with (nolock) on [User].UserTypeID = [UserType].ID and [UserType].IsStaff = 0

GO

create view [LineOrderDetail]
as

select 
	[Order].ID
	, [Order].OrderNo
	, [Order].DateCreated
	, [LineItem].Description
	, [LineItem].Quantity
	, [LineItem].Amount
	, [User].ID as UserID
	, [User].Name as UserName
from
	[Order] with (nolock)
inner join
	[User] with (nolock) on [Order].UserID = [User].ID
inner join
	[UserType] with (nolock) on [User].UserTypeID = [UserType].ID and [UserType].IsStaff = 0
inner join
	[LineItem] with (nolock) on [Order].ID = [LineItem].OrderID

GO



