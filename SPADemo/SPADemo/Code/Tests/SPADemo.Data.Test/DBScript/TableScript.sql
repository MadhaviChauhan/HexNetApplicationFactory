
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_OrderDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT [CK_OrderDetail]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.OrderDetail_dbo.Order_OrderID]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail] DROP CONSTRAINT [FK_dbo.OrderDetail_dbo.Order_OrderID]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
DROP TABLE [dbo].[Product]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDetail]') AND type in (N'U'))
DROP TABLE [dbo].[OrderDetail]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
DROP TABLE [dbo].[Order]
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
DROP TABLE [dbo].[Customer]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomer]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllCustomer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetAllCustomer]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerBy]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerBy]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCustomerBy]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerByID]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerByID]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[GetCustomerByID]
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertCustomer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertCustomer]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertOrder]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderDetail]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertOrderDetail]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertOrderDetail]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderHeader]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertOrderHeader]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[InsertOrderHeader]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateCustomer]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateCustomer]
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 10/1/2014 12:52:48 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[UpdateOrder]
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateOrder]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateOrder]
@ID int, @CustomerID int, @OrderDate date
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	Update dbo.[Order] set CustomerID=@CustomerID,  OrderDate=@OrderDate
	Where ID=@ID
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateCustomer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[UpdateCustomer]
@ID int,@Name varchar(50),@Address varchar(max),@Phone varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	Update Customer set [Name]=@Name,Phone=@Phone,Address=@Address
	Where ID=@ID
	
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderHeader]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertOrderHeader]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertOrderHeader]
@ID int Output , @CustomerID int,  @OrderDate date	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	insert into dbo.[Order] values(@CustomerID, @OrderDate)
	set @ID =@@IDENTITY
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderDetail]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertOrderDetail]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertOrderDetail]

@ID int Output , @OrderId int, @ProductId int ,@Quantity int ,@UnitPrice float ,@Discount float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	insert into dbo.[OrderDetail] values(@OrderId, @ProductId,@Quantity,@UnitPrice,@Discount)
	set @ID =@@IDENTITY
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertOrder]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertOrder]
@CustomerID int,  @OrderDate date	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	insert into dbo.[Order] values(@CustomerID, @OrderDate)
	
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertCustomer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[InsertCustomer]

@ID int Output ,@Name varchar(50),@Phone varchar(10),@Address varchar(max)

	

AS

BEGIN

	-- SET NOCOUNT ON added to prevent extra result sets from

	-- interfering with SELECT statements.

	SET NOCOUNT ON;



    -- Insert statements for procedure here



	--insert into Customer values(@ID,@Name,@Address,@Phone)

	insert into Customer values(@Name,@Address,@Phone)
	set @ID =@@IDENTITY

	

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerByID]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerByID]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetCustomerByID] 
	-- Add the parameters for the stored procedure here
	@id  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Customer where ID=@id;
END' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerBy]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetCustomerBy]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[GetCustomerBy] 
	@id  int=null,
	@Name nvarchar(max)=null,
	@Phone nvarchar(max)=null,
	@Address nvarchar(max)=null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Customer c where (c.ID = @ID OR @ID IS NULL) AND (C.Name Like ''%''+@Name+''%'' OR @Name IS NULL)
							AND (C.Phone=@Phone OR @Phone IS NULL) AND (C.Address Like ''%''+@Address+''%'' OR @Address IS NULL)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomer]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GetAllCustomer]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[GetAllCustomer]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT [ID]
      ,[Name]
      ,[Address]
      ,[Phone]
  FROM [dbo].[Customer]

END' 
END
GO
/****** Object:  Table [dbo].[Customer]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[Address] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Order]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Order](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[CustomerID] [int] NOT NULL,
	[OrderDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderDetail]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OrderID] [int] NOT NULL,
	[ProductID] [int] NOT NULL,
	[Quantity] [int] NOT NULL,
	[UnitPrice] [float] NOT NULL,
	[Discount] [float] NOT NULL,
 CONSTRAINT [PK_dbo.OrderDetail] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Product]    Script Date: 10/1/2014 12:52:48 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NULL,
	[IsInStock] [bit] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Product] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.OrderDetail_dbo.Order_OrderID]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_dbo.OrderDetail_dbo.Order_OrderID] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_dbo.OrderDetail_dbo.Order_OrderID]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_dbo.OrderDetail_dbo.Order_OrderID]
GO
IF NOT EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_OrderDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [CK_OrderDetail] CHECK  (([Quantity]>(0)))
GO
IF  EXISTS (SELECT * FROM sys.check_constraints WHERE object_id = OBJECT_ID(N'[dbo].[CK_OrderDetail]') AND parent_object_id = OBJECT_ID(N'[dbo].[OrderDetail]'))
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [CK_OrderDetail]
GO
