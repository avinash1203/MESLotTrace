<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DEPartAdj.aspx.vb" Inherits="MESLotTrace.DEPartAdj" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); width: 543px; height: 500px; border: 1px solid black; background-color: azure;">
            <asp:Image ID="Image1" runat="server" Height="20px" ImageUrl="~/Images/icon_del_canc_reject.png" style="z-index: 99; left: 493px; top: 18px; position: absolute" Width="20px" />
            <asp:Label ID="Label1" runat="server" Text="Parts Adjustment" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 14px; position: absolute; width: 523px; text-align: center" Font-Size="X-Large"></asp:Label>
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 34px; top: 70px; position: absolute" Text="Line"></asp:Label>
            <asp:Label ID="Label3" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute" Text="Process"></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute" Text="Step"></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 1; left: 34px; top: 190px; position: absolute" Text="Equip"></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 34px; top: 230px; position: absolute" Text="Parts"></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 270px; position: absolute" Text="Vendor Lot"></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 34px; top: 310px; position: absolute" Text="Current Balance"></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 36px; top: 370px; position: absolute" Text="Adjusted Qty"></asp:Label>
            <asp:Label ID="Label10" runat="server" Style="z-index: 1; left: 36px; top: 406px; position: absolute" Text="Reason Code"></asp:Label>
            <asp:TextBox ID="txtLineCd" runat="server" Style="z-index: 1; left: 218px; top: 69px; height:25px; width : 160px; position: absolute" ReadOnly="True" BackColor="#CCCCCC"></asp:TextBox>
            <asp:TextBox ID="txtProcessCd" runat="server" Style="z-index: 1; left: 218px; top: 109px; position: absolute; width: 160px" height="25px" ReadOnly="True" BackColor="#CCCCCC"></asp:TextBox>
            <asp:TextBox ID="txtStep" runat="server" Style="z-index: 1; left: 218px; top: 149px; position: absolute; width: 160px; bottom: 320px;" height="25px" ReadOnly="True" BackColor="#CCCCCC"></asp:TextBox>
            <asp:TextBox ID="txtEquip" runat="server" Style="z-index: 1; left: 218px; top: 190px; position: absolute; width: 160px" height="25px" ReadOnly="True" BackColor="#CCCCCC"></asp:TextBox>
            <asp:TextBox ID="txtPartNo" runat="server" Style="z-index: 1; left: 218px; top: 229px; position: absolute" ReadOnly="True" height="25px" width="160px" BackColor="#CCCCCC"></asp:TextBox>
            <asp:TextBox ID="txtVendorLot" runat="server" Style="z-index: 1; left: 218px; top: 269px; position: absolute" ReadOnly="True" height="25px" width="160px" BackColor="#CCCCCC"></asp:TextBox>
            <asp:TextBox ID="txtCurrBal" runat="server" Style="z-index: 1; left: 218px; top: 309px; position: absolute" ReadOnly="True" height="25px" width="160px" BackColor="#CCCCCC"></asp:TextBox>

            <asp:TextBox ID="txtAdjQty" runat="server" Style="z-index: 1; left: 218px; top: 369px; position: absolute"></asp:TextBox>

            <asp:Button ID="btnUpdate" runat="server" Style="z-index: 1; left: 44px; top: 454px; width: 99px; height: 30px; position: absolute" Text="Update" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 408px; top: 454px; position: absolute" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
            <asp:DropDownList ID="ddReasonCd" runat="server" style="z-index: 1; left: 218px; top: 405px; position: absolute; width: 211px">
            </asp:DropDownList>
            <asp:Panel ID="Panel1" runat="server" BorderColor="#0066FF" BorderStyle="Solid" style="z-index: 1; left: 26px; top: 357px; position: absolute; height: 82px; width: 479px">
            </asp:Panel>
        </div>
    </form>
</body>
</html>
