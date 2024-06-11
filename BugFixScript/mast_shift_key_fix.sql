IF EXISTS (
    SELECT kc.name
    FROM sys.key_constraints kc
    JOIN sys.tables t ON kc.parent_object_id = t.object_id
    WHERE t.name = 'MAST_SHIFT'
    AND kc.name = 'PK_MAST_SHIFT'
)
BEGIN
    ALTER TABLE [dbo].[MAST_SHIFT] DROP CONSTRAINT [PK_MAST_SHIFT] WITH ( ONLINE = OFF )
	DROP INDEX UK_MAST_SHIFT_shift_ptrn_id ON dbo.MAST_SHIFT;
END
GO

IF NOT EXISTS (
    SELECT * 
    FROM sys.indexes 
    WHERE name = 'unique_shift_ptrn_wrk_shift_seq' 
    AND object_id = OBJECT_ID('MAST_SHIFT')
)
BEGIN
    ALTER TABLE MAST_SHIFT
    ADD CONSTRAINT unique_shift_ptrn_wrk_shift_seq UNIQUE (shift_ptrn_id, wrk_shift_seq);
END
GO

IF EXISTS (
    SELECT kc.name
    FROM sys.key_constraints kc
    JOIN sys.tables t ON kc.parent_object_id = t.object_id
    WHERE t.name = 'MAST_SHIFT2'
    AND kc.name = 'PK_MAST_SHIFT2'
)
BEGIN
   ALTER TABLE [dbo].[MAST_SHIFT2] DROP CONSTRAINT [PK_MAST_SHIFT2] WITH ( ONLINE = OFF )
   ALTER TABLE [dbo].[MAST_SHIFT2] DROP CONSTRAINT [unique_shift_ptrn_wrk_shift_seq2]
END
GO

IF NOT EXISTS (
    SELECT * 
    FROM sys.indexes 
    WHERE name = 'unique_shift_ptrn_wrk_shift_seq' 
    AND object_id = OBJECT_ID('MAST_SHIFT2')
)
BEGIN
    ALTER TABLE MAST_SHIFT2
    ADD CONSTRAINT unique_shift_ptrn_wrk_shift_seq2 UNIQUE (shift_ptrn_id, wrk_shift_seq);
END
GO

