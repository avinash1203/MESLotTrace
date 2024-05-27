<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserMaint.aspx.vb" Inherits="MESLotTrace.UserMaint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 15%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 399px; border: 1px solid black; background-color: azure;">
            <asp:Label ID="Label3" runat="server" Text="USER Administration" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 7px; position: absolute; vertical-align:middle; width: 582px; text-align: center; height: 33px;" Font-Size="24px" BackColor="#6699FF"></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 35px; top: 70px; position: absolute; width: auto;"
                Text="Employee No."></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute; width: auto;"
                Text="Employee Name"></asp:Label>
            <asp:Label ID="Label1" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute; width: auto;"
                Text="Password"></asp:Label>
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 34px; top: 187px; position: absolute; width: auto;"
                Text="User role"></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 34px; top: 228px; position: absolute; width: auto;"
                Text="User Status"></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 34px; top: 268px; position: absolute; width: auto;"
                Text="Assigned Printer"></asp:Label>


            <asp:TextBox ID="txtEmpno" runat="server" Style="z-index: 1; left: 218px; top: 69px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtEmpNm" runat="server" Style="z-index: 1; left: 218px; top: 109px; position: absolute; width: 318px"></asp:TextBox>
            <asp:TextBox ID="txtPwd" runat="server" Style="z-index: 1; left: 218px; top: 149px; position: absolute"></asp:TextBox>


            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 33px; top: 344px; width: 99px; height: 30px; position: absolute" Text="Save" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 460px; top: 344px; position: absolute" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />

            <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; left: 218px; top: 186px; position: absolute; width: 164px">
                <asp:ListItem Value="99">Admin</asp:ListItem>
                <asp:ListItem Value="1">Engineer</asp:ListItem>
                <asp:ListItem Value="2">Operation</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList2" runat="server" style="z-index: 1; left: 218px; top: 227px; position: absolute; width: 150px">
                <asp:ListItem Value="9">Active</asp:ListItem>
                <asp:ListItem Value="-1">Disabled</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtAssignedIP" runat="server" style="z-index: 1; left: 218px; top: 267px; position: absolute; width: 240px"></asp:TextBox>

        </div>

    </form>
</body>
</html>
