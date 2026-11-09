CREATE PROCEDURE [dbo].[GetOrders]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [Id], [Customer], [Status], [Total]
    FROM [dbo].[Orders]
    ORDER BY [Id] DESC;
END;
