USE [Northwind]
GO
/****** Object:  StoredProcedure [dbo].[GetAllCustomerCount]    Script Date: 07/21/2013 09:13:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllCustomerCount]

AS
BEGIN
	
	SET NOCOUNT ON;

    SELECT COUNT(*) FROM Customers
END
