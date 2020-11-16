CREATE PROCEDURE [dbo].[spOrders_UpdateName]
	@Id INT,
	@OrderName NVARCHAR(50)
AS
BEGIN
	
	SET NOCOUNT ON;

	UPDATE dbo.[Order]
	SET OrderName = @OrderName
	WHERE Id = @Id;

END