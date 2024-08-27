<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ReasonCodeDE.aspx.vb" Inherits="MESLotTrace.ReasonCodeDE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 500px; border: 1px solid black; background-color: azure;">
            <asp:Image ID="Image1" runat="server" Height="20px" ImageUrl="~/Images/icon_del_canc_reject.png" style="z-index: 1; left: 550px; top: 17px; position: absolute" Width="20px" />
            <asp:Label ID="Label1" runat="server" Text="REASON Data Entry" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 14px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 34px; top: 70px; position: absolute" Text="Reason code "></asp:Label>
            <asp:Label ID="Label3" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute" Text="Reason Description "></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute" Text="Reason Div Code "></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 1; left: 34px; top: 190px; position: absolute" Text="Reason Group Code "></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 34px; top: 230px; position: absolute" Text="SAP Cost Center "></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 270px; position: absolute" Text="SAP Transfer Code "></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 34px; top: 310px; position: absolute" Text="SAP Movement Code"></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 36px; top: 350px; position: absolute" Text="Remarks"></asp:Label>

            <asp:TextBox ID="txtRSNcd" runat="server" Style="z-index: 1; left: 218px; top: 69px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtRSNNM" runat="server" Style="z-index: 1; left: 218px; top: 109px; position: absolute; width: 245px"></asp:TextBox>
            <asp:TextBox ID="txtRSNDiv" runat="server" Style="z-index: 1; left: 218px; top: 149px; position: absolute; width: 168px" height="25px"></asp:TextBox>
            <asp:TextBox ID="txtRSNGrpCd" runat="server" Style="z-index: 1; left: 218px; top: 190px; position: absolute; width: 168px" height="25px"></asp:TextBox>
            <asp:TextBox ID="txtSAPCostCntr" runat="server" Style="z-index: 1; left: 218px; top: 229px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtSAPTrnCd" runat="server" Style="z-index: 1; left: 218px; top: 269px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtSAPMovCd" runat="server" Style="z-index: 1; left: 218px; top: 309px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtRem" runat="server" Style="z-index: 1; left: 218px; top: 349px; position: absolute"></asp:TextBox>

            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 50px; top: 427px; width: 99px; height: 30px; position: absolute" Text="Save" CssClass="button1" />
            <asp:Button ID="btnDelete" runat="server" Style="z-index: 1; left: 250px; top: 427px; position: absolute" Text="Delete" Height="30px" Width="99px" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 450px; top: 427px; position: absolute" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
        </div>
    </form>
</body>
</html>
