<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ScrapMaint.aspx.vb" Inherits="MESLotTrace.ScrapMaint" %>

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
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="SCRAP MAINTENANCE" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/BackBlue01v1.png" Style="z-index: 1; left: 95%; top: 8px; position: absolute; width: 50px; height: 38px" Width="25px" />
            </div>
        <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 550px; border: 1px black solid;">
            <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 493px; border: 1px black solid; top: 20px; left: 4px;">
                <div id="formdetail" runat="server" style="z-index: 1; position: absolute; width: 98%; top: 3px; left: 13px; height: 475px; border: 1px red solid;">
     <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 11px; top: 17px; position: absolute" Text="Note : System will allow individual or Mass upload" Font-Italic="True"></asp:Label>

                    <asp:Label ID="Label1" runat="server" Style="position: absolute; z-index: 1; left: 20%; top: 94px" Text="Serial Number" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox ID="txtSNo" runat="server" Style="z-index: 1; left: 40%; top: 96px; position: absolute; width: 420px; height: 30px;" BorderStyle="Solid" Font-Size="Large"></asp:TextBox>
  <asp:Label ID="Label2" runat="server" Font-Italic="True" Font-Size="Small" ForeColor="#FF0066" style="z-index: 1; left: 40%; top: 139px; position: absolute" Text="Scan In or Key In"></asp:Label>
                    <asp:Button ID="btnProcess" runat="server" CssClass="button1" Font-Bold="True" Font-Size="X-Large" Style="z-index: 1; left: 18%; top: 401px; position: absolute; width: 230px; height: 50px" Text="Process Scrap" />
                    <asp:Button ID="btnExit" runat="server" CssClass="button1" Font-Bold="True" Font-Size="X-Large" Style="z-index: 1; left: 60%; top: 401px; position: absolute; width: 230px; height: 50px" Text="EXIT" />
                                        <asp:Label ID="Label3" runat="server" Style="position: absolute; z-index: 1; left: 20%; top: 193px" Text="Upload File" Font-Size="X-Large"></asp:Label>

                  

                    <asp:FileUpload ID="FileUpload1" runat="server" style="z-index: 1; left: 40%; top: 194px; position: absolute; width: 494px" Font-Size="Large" BorderStyle="Solid" />
               <asp:Label ID="Label5" runat="server" Font-Italic="True" Font-Size="Small" ForeColor="#FF0066" style="z-index: 1; left:40%; top: 235px; position: absolute" Text="File in CSV format"></asp:Label>

                  <asp:Label ID="Label6" runat="server" Style="position: absolute; z-index: 1; left: 20%; top: 293px" Text="Select Reason Code" Font-Size="X-Large"></asp:Label>

                    <asp:DropDownList ID="ddReasonCode" runat="server" style="z-index: 1; left: 40%; top: 294px; position: absolute; width: 424px; " Font-Size="Large">
                    </asp:DropDownList>

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
