IF N'$(SeedSampleOrders)' = N'true'
BEGIN
    INSERT INTO [dbo].[Orders] ([Id], [Customer], [Status], [Total])
    SELECT sample.[Id], sample.[Customer], sample.[Status], sample.[Total]
    FROM (VALUES
        (N'#1048', N'Northstar Studio', N'Completed', 324.00),
        (N'#1047', N'Oak & Finch', N'Processing', 185.50),
        (N'#1046', N'Harbor Supply', N'Completed', 620.00),
        (N'#1045', N'Juniper Labs', N'Pending', 92.40),
        (N'#1044', N'Summit Works', N'Completed', 248.00)
    ) AS sample ([Id], [Customer], [Status], [Total])
    WHERE NOT EXISTS
    (
        SELECT 1
        FROM [dbo].[Orders] AS existing WITH (UPDLOCK, HOLDLOCK)
        WHERE existing.[Id] = sample.[Id]
    );
END;
