<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AppMainPage00.aspx.vb" Inherits="MESLotTrace.AppMainPage00" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Page</title>
    <link href="dndod-popup.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="dndod-popup.min.js"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <style>
        body {
            margin: 0;
            font-family: Calibri;
        }

        div.toplogo {
            position: fixed;
            top: 1%;
            left: 1%
        }

        table.mainlogo {
            position: fixed;
            top: 1%;
            left: 1%;
            width: 100%;
        }

        .sidebar {
            margin: 0;
            padding: 0;
            width: 300px;
            top: 160px;
            background-color: #7DF9FF;
            position: fixed;
            height: 70%;
            overflow: auto;
            left: 10px;
        }

            .sidebar a {
                display: block;
                color: black;
                padding: 16px;
                text-decoration: none;
            }

                .sidebar a.active {
                    background-color: #FFCC00;
                    color: black;
                    font-size: larger;
                }

                .sidebar a:hover:not(.active) {
                    /*    background-color: #555;*/
                    text-decoration: red underline;
                    font-size: larger;
                    color: darkblue;
                }

        div.content {
            position: fixed;
            margin-left: 200px;
            padding: 0px 0px 0px 0px;
            height: 50%;
            top: 170px;
            width: 90%;
            left: 174px;
        }

        @media screen and (max-width: 700px) {
            .sidebar {
                width: 100%;
                height: 90%;
                position: relative;
                top: 100px;
            }

                .sidebar a {
                    float: left;
                }

            div.content {
                margin-left: 0;
            }
        }

        @media screen and (max-width: 400px) {
            .sidebar {
                width: 1%;
                height: auto;
                position: relative;
            }

                .sidebar a {
                    text-align: center;
                    float: LEFT;
                }
        }
    </style>

</head>
<body>
    <form id="form1" runat="server" style="font-family: Calibri;">
        <div id="topLogo" class="toplogo">
            <table id="mainlogo" class="mainlogo">
                <tr>
                    <td style="width: 15%;">
                        <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/MinebeaMit.JPG" />
                    </td>
                    <td style="width: 40%;">
                        <asp:Image ID="Image2" runat="server"
                            ImageUrl="~/Images/SystemLogo2.png" Width="70%" />
                    </td>
                </tr>
            </table>
            </div>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; position: fixed; top: 99px; height: 35px; left: 10px; width: 151px;"
                Text="Logged On As : "></asp:Label>
            <asp:TextBox ID="txtLogonID" runat="server"
                Style="z-index: 1; left: 223px; top: 96px; height: 35px; width: 89px; border-radius: 5px; padding-left: 5px; position: absolute;"></asp:TextBox>
            <asp:TextBox ID="txtLogonName" runat="server"
                Style="z-index: 1; position: absolute; border-radius: 5px; height: 35px; top: 97px; left: 369px; width: 308px;"></asp:TextBox>

            <asp:LinkButton ID="lkLogout" runat="server" Style="z-index: 99; position: absolute; width: 6%; left: 92%; top: 68px;"
                Font-Bold="True" Font-Names="Calibri" Font-Size="Large">Logout</asp:LinkButton>




        <div id="sidebar" runat="server" class="sidebar">
            <asp:LinkButton ID="LK1" runat="server">Administration</asp:LinkButton>
            <asp:LinkButton ID="LK2" runat="server">Master Maintenance</asp:LinkButton>
            <asp:LinkButton ID="LK3" runat="server">Operations</asp:LinkButton>
            <asp:LinkButton ID="LK4" runat="server">Reporting</asp:LinkButton>
            <asp:LinkButton ID="LK5" runat="server">Import from SAP</asp:LinkButton>
            <asp:LinkButton ID="LK6" runat="server">Export to SAP</asp:LinkButton>
        </div>

        <%--    <div id="FormFeature" style="z-index: 1; position: absolute; border: 1px solid black; top: 159px; left: 314px; width: 80%; height: 800px;">
                <iframe id="doc1" src="SystemLogo.aspx" runat="server"
                    style="z-index: 1; border: 1px solid black; width: 100%; height: 100%;"></iframe>
            </div>--%>
        <iframe id="doc1" src="SystemLogo.aspx" runat="server" style="resize: horizontal; border: thin groove #0000FF; z-index: -1; left: 426px; top: 200px; position: absolute; height: 68%; width: 74%;"></iframe>

        <asp:HiddenField ID="hflogonid" runat="server" />

    </form>

</body>
</html>
