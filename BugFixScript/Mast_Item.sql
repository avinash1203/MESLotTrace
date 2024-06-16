-- Drop columns from MAST_ITEM table if they exist
IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'applcbl_strt_date_utc' AND Object_ID = Object_ID(N'MAST_ITEM'))
BEGIN
    ALTER TABLE MAST_ITEM
    DROP COLUMN applcbl_strt_date_utc;
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'prod_srl_ctrl_div' AND Object_ID = Object_ID(N'MAST_ITEM'))
BEGIN
    ALTER TABLE MAST_ITEM
    DROP COLUMN prod_srl_ctrl_div;
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'prod_lot_ctrl_div' AND Object_ID = Object_ID(N'MAST_ITEM'))
BEGIN
    ALTER TABLE MAST_ITEM
    DROP COLUMN prod_lot_ctrl_div;
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'proc_expnd_trgt_flg' AND Object_ID = Object_ID(N'MAST_ITEM'))
BEGIN
    ALTER TABLE MAST_ITEM
    DROP COLUMN proc_expnd_trgt_flg;
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'draw_num' AND Object_ID = Object_ID(N'MAST_ITEM'))
BEGIN
    ALTER TABLE MAST_ITEM
    DROP COLUMN draw_num;
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'spec' AND Object_ID = Object_ID(N'MAST_ITEM'))
BEGIN
    ALTER TABLE MAST_ITEM
    DROP COLUMN spec;
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'devide_qty' AND Object_ID = Object_ID(N'MAST_ITEM'))
BEGIN
    ALTER TABLE MAST_ITEM
    DROP COLUMN devide_qty;
END

IF EXISTS (SELECT 1 FROM sys.columns WHERE Name = N'lot_num_rule' AND Object_ID = Object_ID(N'MAST_ITEM'))
BEGIN
    ALTER TABLE MAST_ITEM
    DROP COLUMN lot_num_rule;
END
