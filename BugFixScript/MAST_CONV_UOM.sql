CREATE TABLE MAST_CONV_UOM (
    conv_unit_bf_cd NVARCHAR(10) NULL,
    conv_unit_aft_cd NVARCHAR(10) NULL,
    conv_nmrt INT NULL,
    conv_dnmn INT NULL,
    cncl_flg INT NULL,
    reg_utc DATETIME NULL,
    regr_id NVARCHAR(30) NULL,
    upd_utc DATETIME NULL,
    updr_id NVARCHAR(30) NULL,
    admin_mnt_notes NVARCHAR(300) NULL
);