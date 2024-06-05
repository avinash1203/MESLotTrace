﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AppMainPageAdmin.aspx.vb" Inherits="MESLotTrace.AppMainPageAdmin" %>

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
        </div>
        <asp:Label ID="Label6" runat="server" Style="z-index: 1; position: absolute; top: 87px; height: 20px; left: 24px; width: 151px; right: 1140px;"
            Text="Logged On As : " Font-Size="Small" Font-Names="Arial Rounded MT Bold" Font-Bold="True"></asp:Label>
        <asp:TextBox ID="txtLogonID" runat="server"
            Style="z-index: 1; top: 84px; height: 20px; width: 142px; border-radius: 5px; padding-left: 5px; position: absolute; right: 973px;" Font-Size="X-Small"></asp:TextBox>
        <asp:TextBox ID="txtLogonName" runat="server"
            Style="z-index: 1; position: absolute; border-radius: 5px; height: 20px; top: 84px; left: 353px; width: 308px;" Font-Size="Medium"></asp:TextBox>

        <asp:LinkButton ID="lkLogout" runat="server" Style="z-index: 99; position: absolute; width: 6%; left: 92%; top: 86px;"
            Font-Bold="True" Font-Names="Calibri" Font-Size="Large">Logout</asp:LinkButton>



        <div id="mainpage" runat="server" style="z-index: 1; width: 99%; height: auto;">
        
                        <div id="mainmenu" runat="server" style="z-index: 1; position: absolute; left: 10px; top: 121px; height: 570px; width: 25%; left: 23px; background-color: aqua; border: solid 1px blue">
                            <asp:ImageButton ID="ImageButton1" runat="server" Style="z-index: 1; left: 36px; top: 15px; width: 80%; position: absolute" ImageUrl="~/Images/button_administration.png"  />
                            <asp:ImageButton ID="ImageButton2" runat="server" Style="z-index: 1; left: 36px; top:110px; width: 80%; position: absolute" ImageUrl="~/Images/button_master-maintenance.png" />
                            <asp:ImageButton ID="ImageButton3" runat="server" Style="z-index: 1; left: 35px; top: 205px; width: 80%; position: absolute" ImageUrl="~/Images/button_operations.png" ImageAlign="Middle" />
                            <asp:ImageButton ID="ImageButton4" runat="server" Style="z-index: 1; left: 35px; top: 300px; width: 80%; position: absolute" ImageUrl="~/Images/button_reporting.png" ImageAlign="Middle" />
                            <asp:ImageButton ID="ImageButton5" runat="server" Style="z-index: 1; left: 35px; top: 395px; width: 80%; position: absolute" ImageUrl="~/Images/button_import-from-sap.png" ImageAlign="Middle" />
                            <asp:ImageButton ID="ImageButton6" runat="server" Style="z-index: 1; left: 35px; top: 490px; width: 80%; position: absolute" ImageUrl="~/Images/button_export-to-sap.png" ImageAlign="Middle" />
                     </div>
                        <div id="centerscr" runat="server" style="z-index:1; position:absolute; left: 30%;top:121px;border: solid 1px black;width:65%;height:570px; background-color: #CCFFFF;">
                            <asp:Label ID="Label7" runat="server" Font-Bold="True" Font-Names="Arial Rounded MT Bold" style="z-index: 1; left: 4px; top: 7px; position: absolute; text-align:center; width: 822px; height: 34px" Text="Administration" Font-Size="Larger"></asp:Label>
                            <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="~/Images/button_user-management.png" style="z-index: 1; left: 239px; top: 102px; position: absolute" />
                            <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="~/Images/button_access-control.png" style="z-index: 1; left: 241px; top: 220px; position: absolute" />
                        </div>
     
        </div>

        <asp:HiddenField ID="hflogonid" runat="server" />

    </form>

</body>
</html>