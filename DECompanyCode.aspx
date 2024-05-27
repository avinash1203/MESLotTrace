<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="DECompanyCode.aspx.vb" Inherits="MESLotTrace.DECompanyCode" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 257px; border: 1px solid black; background-color: azure;">
            <asp:Image ID="Image1" runat="server" Height="20px" ImageUrl="~/Images/icon_del_canc_reject.png" style="z-index: 1; left: 550px; top: 17px; position: absolute" Width="20px" />
            <asp:Label ID="Label1" runat="server" Text="COMPANY Code Data Entry" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 14px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 35px; top: 70px; position: absolute; width: auto;" Text="Company code"></asp:Label>
            <asp:Label ID="Label3" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute; width:auto;" Text="Company Name"></asp:Label>
           

            <asp:TextBox ID="txtCompcd" runat="server" Style="z-index: 1; left: 218px; top: 69px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtCompnM" runat="server" Style="z-index: 1; left: 218px; top: 109px; position: absolute; width: 318px"></asp:TextBox>
         

            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 38px; top: 200px; width: 99px; height: 30px; position: absolute" Text="Save" CssClass="button1" />
            <asp:Button ID="btnDelete" runat="server" Style="z-index: 1; left: 250px; top: 200px; position: absolute" Text="Delete" Height="30px" Width="99px" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 450px; top: 200px; position: absolute" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
        </div>
    </form>
</body>
</html>
