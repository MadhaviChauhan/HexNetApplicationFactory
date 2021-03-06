USE [TestDB1]
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 10/1/2014 12:53:53 PM ******/
DROP PROCEDURE [dbo].[UpdateOrder]
GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 10/1/2014 12:53:53 PM ******/
DROP PROCEDURE [dbo].[UpdateCustomer]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderHeader]    Script Date: 10/1/2014 12:53:53 PM ******/
DROP PROCEDURE [dbo].[InsertOrderHeader]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderDetail]    Script Date: 10/1/2014 12:53:53 PM ******/
DROP PROCEDURE [dbo].[InsertOrderDetail]
GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 10/1/2014 12:53:53 PM ******/
DROP PROCEDURE [dbo].[InsertOrder]
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 10/1/2014 12:53:53 PM ******/
DROP PROCEDURE [dbo].[InsertCustomer]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerByID]    Script Date: 10/1/2014 12:53:53 PM ******/
DROP PROCEDURE [dbo].[GetCustomerByID]
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerBy]    Script Date: 10/1/2014 12:53:53 PM ******/
DROP PROCEDURE [dbo].[GetCustomerBy]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomer]    Script Date: 10/1/2014 12:53:53 PM ******/
DROP PROCEDURE [dbo].[GetAllCustomer]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomer]    Script Date: 10/1/2014 12:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCustomer]
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

END
GO
/****** Object:  StoredProcedure [dbo].[GetCustomerBy]    Script Date: 10/1/2014 12:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

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
	SELECT * from Customer c where (c.ID = @ID OR @ID IS NULL) AND (C.Name Like '%'+@Name+'%' OR @Name IS NULL)
							AND (C.Phone=@Phone OR @Phone IS NULL) AND (C.Address Like '%'+@Address+'%' OR @Address IS NULL)
END

GO
/****** Object:  StoredProcedure [dbo].[GetCustomerByID]    Script Date: 10/1/2014 12:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCustomerByID] 
	-- Add the parameters for the stored procedure here
	@id  int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * from Customer where ID=@id;
END
GO
/****** Object:  StoredProcedure [dbo].[InsertCustomer]    Script Date: 10/1/2014 12:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertCustomer]

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

GO
/****** Object:  StoredProcedure [dbo].[InsertOrder]    Script Date: 10/1/2014 12:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertOrder]
@CustomerID int,  @OrderDate date	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	insert into dbo.[Order] values(@CustomerID, @OrderDate)
	
END
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderDetail]    Script Date: 10/1/2014 12:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertOrderDetail]

@ID int Output , @OrderId int, @ProductId int ,@Quantity int ,@UnitPrice float ,@Discount float
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	insert into dbo.[OrderDetail] values(@OrderId, @ProductId,@Quantity,@UnitPrice,@Discount)
	set @ID =@@IDENTITY
END
GO
/****** Object:  StoredProcedure [dbo].[InsertOrderHeader]    Script Date: 10/1/2014 12:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertOrderHeader]
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

GO
/****** Object:  StoredProcedure [dbo].[UpdateCustomer]    Script Date: 10/1/2014 12:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateCustomer]
@ID int,@Name varchar(50),@Address varchar(max),@Phone varchar(10)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	Update Customer set [Name]=@Name,Phone=@Phone,Address=@Address
	Where ID=@ID
	
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateOrder]    Script Date: 10/1/2014 12:53:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateOrder]
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

GO
