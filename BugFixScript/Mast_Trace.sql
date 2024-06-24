IF EXISTS (
    SELECT kc.name
    FROM sys.key_constraints kc
    JOIN sys.tables t ON kc.parent_object_id = t.object_id
    WHERE t.name = 'MAST_TRACE'
    AND kc.name = 'PK_MAST_TRACE'
)
BEGIN
    ALTER TABLE [dbo].[MAST_TRACE] DROP CONSTRAINT [PK_MAST_TRACE] WITH ( ONLINE = OFF )
	--DROP INDEX PK_MAST_TRACE ON dbo.MAST_TRACE;
END
GO

IF NOT EXISTS (
    SELECT * 
    FROM sys.indexes 
    WHERE name = 'Unique_MAST_TRACE' 
    AND object_id = OBJECT_ID('MAST_TRACE')
)
BEGIN   
 CREATE UNIQUE NONCLUSTERED INDEX Unique_MAST_TRACE
    ON MAST_TRACE (line_id,proc_flow_id)
    WHERE cncl_flg =CAST(0 AS INT);
END
GO


