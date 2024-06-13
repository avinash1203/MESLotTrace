IF EXISTS (
    SELECT kc.name
    FROM sys.key_constraints kc
    JOIN sys.tables t ON kc.parent_object_id = t.object_id
    WHERE t.name = 'Mast_Reason'
    AND kc.name = 'PK_MAST_Reason'
)
BEGIN
    ALTER TABLE [dbo].Mast_Reason DROP CONSTRAINT [PK_MAST_Reason] WITH ( ONLINE = OFF )
	DROP INDEX UK_MAST_Reason_rsn_cd ON dbo.Mast_Reason;
END
GO

IF NOT EXISTS (
    SELECT * 
    FROM sys.indexes 
    WHERE name = 'IX_MAST_MAST_Reason_rsn' 
    AND object_id = OBJECT_ID('Mast_Reason')
)
BEGIN
    
 CREATE UNIQUE NONCLUSTERED INDEX IX_MAST_MAST_Reason_rsn
    ON Mast_Reason (RSN_DIV,RSN_GRP_CD,RSN_CD)
    WHERE cncl_flg =0;
END
GO