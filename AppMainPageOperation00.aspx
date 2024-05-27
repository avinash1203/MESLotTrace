<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AppMainPageOperation00.aspx.vb" Inherits="MESLotTrace.AppMainPageOperation00" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
    <link href="dndod-popup.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="dndod-popup.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=yes">
</head>
<body>
    <form id="form1" runat="server" style="font-family: Calibri;">


        <div id="topLogo" class="toplogo">
            <table id="mainlogo" class="mainlogo">
                <tr>
                    <td class="auto-style1">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/MinebeaMit.JPG" />
                    </td>
                    <td class="auto-style2">
                        <asp:Image ID="Image2" runat="server"
                            ImageUrl="~/Images/SystemLogo2.png" Width="70%" ImageAlign="AbsMiddle" />
                    </td>
                </tr>
            </table>
            <asp:ImageButton ID="ImageButton12" runat="server" 
                Style="z-index: 1; left: 92%; top: 66px; position: absolute; width: 50px; height: 50px;"
                ImageUrl="~/Images/BackBlue01v1.png" />
        </div>
        <asp:Label ID="Label6" runat="server" Style="z-index: 1; position: absolute; top: 87px; height: 20px; left: 24px; width: 151px;"
            Text="Logged On As : " Font-Size="Small" Font-Names="Arial Rounded MT Bold" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtLogonID" runat="server"
            Style="z-index: 1; top: 84px; height: 20px; width: 142px; border-radius: 5px; padding-left: 5px; position: absolute; left: 186px; right: 1184px;" Font-Size="Medium" ReadOnly="True"></asp:TextBox>
        <asp:TextBox ID="txtLogonName" runat="server"
            Style="z-index: 1; position: absolute; border-radius: 5px; height: 20px; top: 84px; left: 353px; width: 308px;" Font-Size="Medium" ReadOnly="True"></asp:TextBox>

        <%--    <asp:LinkButton ID="lkLogout" runat="server" Style="z-index: 99; position: absolute; width: 6%; left: 92%; top: 86px;"
            Font-Bold="True" Font-Names="Calibri" Font-Size="Large">Logout</asp:LinkButton>--%>



        <div id="mainpage" runat="server" style="z-index: 1; width: 99%; height: auto;">

            <div id="mainmenu" runat="server" style="z-index: 1; position: absolute; left: 10px; top: 121px; height: 570px; width: 25%; left: 23px; background-color: aqua; border: solid 1px blue">
                <asp:ImageButton ID="ImageButton1" runat="server" Style="z-index: 1; left: 36px; top: 15px; width: 80%; position: absolute" ImageUrl="~/Images/button_administration.png" />
                <asp:ImageButton ID="ImageButton2" runat="server" Style="z-index: 1; left: 36px; top: 110px; width: 80%; position: absolute" ImageUrl="~/Images/button_master-maintenance.png" />
                <asp:ImageButton ID="ImageButton3" runat="server" Style="z-index: 1; left: 35px; top: 205px; width: 80%; position: absolute" ImageUrl="~/Images/button_operations_selected.png" ImageAlign="Middle" BackColor="#CCFFCC" Enabled="False" />
                <asp:ImageButton ID="ImageButton4" runat="server" Style="z-index: 1; left: 35px; top: 300px; width: 80%; position: absolute" ImageUrl="~/Images/button_reporting.png" ImageAlign="Middle" />
                <asp:ImageButton ID="ImageButton5" runat="server" Style="z-index: 1; left: 35px; top: 395px; width: 80%; position: absolute" ImageUrl="~/Images/button_import-from-sap.png" ImageAlign="Middle" />
                <asp:ImageButton ID="ImageButton6" runat="server" Style="z-index: 1; left: 35px; top: 490px; width: 80%; position: absolute" ImageUrl="~/Images/button_export-to-sap.png" ImageAlign="Middle" />
            </div>
            <div id="centerscr" runat="server" style="z-index: 1; position: absolute; left: 30%; top: 121px; border: solid 1px black; width: 65%; height: 570px; background-color: #CCFFFF;">
                <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial Rounded MT Bold" Style="z-index: 1; left: 4px; top: 7px; position: absolute; text-align: center; width: 938px; height: 34px" Text="Operations" Font-Size="Larger"></asp:Label>
                <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/button_lot-management.png" Style="z-index: 1; left: 298px; top: 60px; position: absolute" />
                <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Images/button_rework.png" Style="z-index: 1; left: 298px; top: 153px; position: absolute" />
                <asp:ImageButton ID="ImageButton9" runat="server" ImageUrl="~/Images/button_scrap-item.png" Style="z-index: 1; left: 298px; top: 252px; position: absolute" />
                <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="~/Images/button_print-tag.png" Style="z-index: 1; left: 298px; top: 351px; position: absolute" />
                <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="~/Images/button_plc-trace-data-amendment.png" Style="z-index: 1; left: 298px; top: 451px; position: absolute" />
                <asp:Button ID="btnLotMgt" runat="server" style="z-index: 1; left: 49px; top: 59px; position: absolute; width: 231px; height: 75px; border-radius:10px;" Text="Lot Management" />
            </div>

        </div>

        <asp:HiddenField ID="hflogonid" runat="server" />

    </form>

</body>
</html>
