CREATE PROCEDURE [dbo].[spOrders_Delete]
	@Id INT
AS
BEGIN
	
	SET NOCOUNT ON
	
	DELETE
	FROM dbo.[Order]
	WHERE Id = @Id;

END
