CREATE PROCEDURE [dbo].[spOrders_Insert]
	@OrderName NVARCHAR(50),
	@OrderDate DATETIME2(7),
	@FoodId INT,
	@Quantity INT,
	@Total MONEY,
	@Id INT OUTPUT
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO dbo.[Order](OrderName, OrderDate, FoodId, Quantity, Total)
		VALUES(@OrderName, @OrderDate, @FoodId, @Quantity, @Total);

		set @Id = SCOPE_IDENTITY();
END
