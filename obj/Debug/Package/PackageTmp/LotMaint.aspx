﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LotMaint.aspx.vb" Inherits="MESLotTrace.LotMaint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Lot Maintenance</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" type="image/x-icon" href="~/images/favicon.ico">
    <link href="Scripts/dndod-popup.min.css" rel="stylesheet" />
    <script src="Scripts/dndod-popup.min.js"></script>
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="z-index: 1; font: calibri; width: auto; height: auto;">
        <div id="formheader" runat="server"
            style="z-index: 1; position: absolute; top: 1px; left: 1px; border: 1px black solid; width: 100%; height: 80px; background-color: aquamarine;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/FormHeader01.png"
                Style="z-index: 1; border-image-repeat: stretch; padding: 2px 2px 2px 2px; width: 100%; height: 100%;" />
        </div>
        <div id="formtitle" runat="server" style="z-index: 1; position: absolute; top: 86px; left: 1px; width: 100%; height: 50px; text-align: center; border: 1px solid black; background-color: azure;">
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="LOT MAINTENANCE" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
        <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 550px; border: 1px black solid;">
            <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 493px; border: 1px black solid; top: 20px; left: 4px;">
                <div id="formdetail" runat="server" style="z-index: 1; position: absolute; width: 98%; top: 3px; left: 13px; height: 475px; border: 1px red solid;">
                    <asp:Label ID="Label1" runat="server" Style="position: absolute; z-index: 1; left: 165px; top: 10px" Text="Manufactuing Lot No." Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Style="position: absolute; z-index: 1; left: 165px; top: 50px" Text="Model No." Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Style="position: absolute; z-index: 1; left: 165px; top: 88px" Text="Production Scheduled Quantity" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Style="position: absolute; z-index: 1; left: 165px; top: 128px" Text="Pass Quantity" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label5" runat="server" Style="position: absolute; z-index: 1; left: 165px; top: 168px" Text="NG Quantity" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Style="position: absolute; z-index: 1; left: 830px; top: 10px" Text="Process" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Style="position: absolute; z-index: 1; left: 830px; top: 49px" Text="Work Status" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label9" runat="server" Style="position: absolute; z-index: 1; left: 830px; top: 88px" Text="Parts Consump ?" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Style="position: absolute; z-index: 1; left: 831px; top: 128px" Text="Abnormal Pass (Skip)" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label11" runat="server" Style="position: absolute; z-index: 1; left: 830px; top: 168px" Text="Abrnormal Pass (NG)" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label7" runat="server" Style="position: absolute; z-index: 1; left: 168px; top: 210px" Text="Comment" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label12" runat="server" Style="position: absolute; z-index: 1; left: 166px; top: 300px" Text="Production Date" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label14" runat="server" Style="position: absolute; z-index: 1; left: 164px; top: 340px" Text="MAMM Lot" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label13" runat="server" Style="position: absolute; z-index: 1; left: 833px; top: 300px; right: 391px;" Text="Shift" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox ID="txtMfgLotNo" runat="server" Style="z-index: 1; left: 505px; top: 6px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtModelNo" runat="server" Style="z-index: 1; left: 505px; top: 45px; position: absolute; width: 254px; height: 30px; right: 599px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtProdSchQty" runat="server" Style="z-index: 1; left: 505px; top: 84px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtPassQty" runat="server" Style="z-index: 1; left: 505px; top: 124px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="NGQty" runat="server" Style="z-index: 1; left: 505px; top: 164px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtProcess" runat="server" Style="z-index: 1; left: 1061px; top: 6px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtWorkSt" runat="server" Style="z-index: 1; left: 1061px; top: 45px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtPartCon" runat="server" Style="z-index: 1; left: 1061px; top: 84px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtAbPassSkip" runat="server" Style="z-index: 1; left: 1061px; top: 124px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtAbPassNG" runat="server" Style="z-index: 1; left: 1061px; top: 164px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>



                    <asp:TextBox ID="txtRem" runat="server" Style="z-index: 1; left: 505px; top: 204px; position: absolute; width: 814px; height: 82px;" BorderStyle="Solid" TextMode="MultiLine"></asp:TextBox>
                    <asp:TextBox ID="TextBox1" runat="server" Style="z-index: 1; left: 505px; top: 296px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="TextBox8" runat="server" Style="z-index: 1; left: 1061px; top: 296px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>



                    <asp:TextBox ID="txtMAMMLot" runat="server" Style="z-index: 1; left: 505px; top: 336px; position: absolute; width: 254px; height: 30px; right: 552px;" BorderStyle="Solid"></asp:TextBox>

                    <asp:Button ID="btnStartLot" runat="server" CssClass="button1" Font-Bold="True" Font-Size="X-Large" Style="z-index: 1; left: 250px; top: 401px; position: absolute; width: 230px; height: 50px" Text="START LOT" />
                    <asp:Button ID="btnSuspendLot" runat="server" CssClass="button1" Font-Bold="True" Font-Size="X-Large" Style="z-index: 1; left: 550px; top: 403px; position: absolute; width: 230px; height: 50px" Text="SUSPEND LOT" />
                    <asp:Button ID="btnCloseLot" runat="server" CssClass="button1" Font-Bold="True" Font-Size="X-Large" Style="z-index: 1; left: 850px; top: 401px; position: absolute; width: 230px; height: 50px" Text="CLOSE LOT" />
                    <asp:Button ID="btnExit" runat="server" CssClass="button1" Font-Bold="True" Font-Size="X-Large" Style="z-index: 1; left: 1150px; top: 401px; position: absolute; width: 230px; height: 50px" Text="EXIT" />

                    <asp:Button ID="Button1" runat="server" BackColor="#CCCCCC" Font-Size="X-Large" Style="z-index: 1; left: 776px; top: 336px; position: absolute; width: 160px" Text="Generate Lot" />

                </div>

            </div>
        </div>
        <div id="formfoot" style="z-index: 1; position: absolute; top: 663px; left: 1px; width: 99%; height: 50px; border: 1px black; background-color: aqua">
            <asp:Label ID="LoginUser" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

    </form>
</body>
</html>
