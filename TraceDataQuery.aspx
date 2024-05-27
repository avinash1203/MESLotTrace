<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TraceDataQuery.aspx.vb" Inherits="MESLotTrace.TraceDataQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TraceDataQuery</title>
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
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="Detail Traceability Query" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
       <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/BackBlue01v1.png" Style="z-index: 1; left: 95%; top: 8px; position: absolute; width: 50px; height: 38px" Width="25px" />
            </div>
        <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 550px; border: 1px black solid;">
            <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 509px; border: 1px black solid; top: 6px; left: 4px;">
                <div id="formdetail" runat="server" style="z-index: 1; position: absolute; width: 98%; top: 3px; left: 13px; height: 490px; border: 1px red solid;">
                    <asp:Label ID="Label5" runat="server" Style="position: absolute; z-index: 1; left: 38px; top: 20px" Text="Time Stamp" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label7" runat="server" Style="position: absolute; z-index: 1; left: 598px; top: 20px" Text="To" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label9" runat="server" Style="position: absolute; z-index: 1; left: 38px; top: 71px" Text="Mfg. Lot No." Font-Size="X-Large"></asp:Label>

                    <asp:Label ID="Label10" runat="server" Style="position: absolute; z-index: 1; left: 38px; top: 121px" Text="Serial No." Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label1" runat="server" Style="position: absolute; z-index: 1; left: 652px; top: 121px;" Text="Line" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Style="position: absolute; z-index: 1; left: 38px; top: 171px" Text="Process" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Style="position: absolute; z-index: 1; left: 581px; top: 171px" Text="Step Code" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Style="position: absolute; z-index: 1; left: 38px; top: 221px" Text="Part Code" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Style="position: absolute; z-index: 1; left: 596px; top: 221px" Text="Equip ID" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Style="position: absolute; z-index: 1; left: 38px; top: 271px" Text="Trace Code" Font-Size="X-Large"></asp:Label>
  <asp:Label ID="Label11" runat="server" Style="position: absolute; z-index: 1; left: 38px; top: 321px" Text="Trace Data Item" Font-Size="X-Large"></asp:Label>
                      <asp:Label ID="Label14" runat="server" Style="position: absolute; z-index: 1; left: 420px; top: 321px" Text="1" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label15" runat="server" Style="position: absolute; z-index: 1; left: 623px; top: 321px" Text="2" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label16" runat="server" Style="position: absolute; z-index: 1; left: 823px; top: 321px" Text="3" Font-Size="X-Large"></asp:Label>
<asp:Label ID="Label12" runat="server" Style="position: absolute; z-index: 1; left: 253px; top: 354px" Text="Key" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label13" runat="server" Style="position: absolute; z-index: 1; left: 251px; top: 396px" Text="Value" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label17" runat="server" Style="position: absolute; z-index: 1; left: 38px; top: 441px" Text="Max Display Item" Font-Size="X-Large" width="219"></asp:Label>

                    <asp:TextBox ID="txtStartDt" runat="server" placeholder = "Start Date Time" Style="z-index: 1; left: 255px; top: 20px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtEndDt" runat="server" placeholder ="End Date Time" Style="z-index: 1; left: 718px; top: 20px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtMfgLot" runat="server" placeholder="Manufacturing Lot" Style="z-index: 1; left: 255px; top: 70px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtSNo" runat="server" placeholder="Serial Number" Style="z-index: 1; left: 255px; top: 120px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="ttLineID" runat="server" placeholder ="Line ID" Style="z-index: 1; left: 718px; top: 120px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtProcess" runat="server" placeholder ="Process ID" Style="z-index: 1; left: 255px; top: 170px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtStepCode" runat="server" placeholder="Step code" Style="z-index: 1; left: 721px; top: 170px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtPartCode" runat="server" placeholder="Part number" Style="z-index: 1; left: 257px; top: 220px; position: absolute; width: 254px; height: 30px; right: 689px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtEquipID" runat="server" placeholder ="Equipment ID" Style="z-index: 1; left: 721px; top: 220px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtTraceCd" runat="server" Placeholder="Trace Code" Style="z-index: 1; left: 257px; top: 270px; position: absolute; width: 718px; height: 30px;" BorderStyle="Solid"></asp:TextBox>

                    <asp:TextBox ID="txtKey1" runat="server" Style="z-index: 1; left: 359px; top: 353px; position: absolute; width: 135px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                        <asp:TextBox ID="txtKey2" runat="server" Style="z-index: 1; left: 559px; top: 353px; position: absolute; width: 135px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                                            <asp:TextBox ID="txtKey3" runat="server" Style="z-index: 1; left: 759px; top: 353px; position: absolute; width: 135px; height: 30px;" BorderStyle="Solid"></asp:TextBox>

                    
                                   <asp:TextBox ID="txtVal1" runat="server" Style="z-index: 1; left: 359px; top: 395px; position: absolute; width: 135px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                        <asp:TextBox ID="txtVal2" runat="server" Style="z-index: 1; left: 559px; top: 395px; position: absolute; width: 135px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                                            <asp:TextBox ID="txtVal3" runat="server" Style="z-index: 1; left: 759px; top: 395px; position: absolute; width: 135px; height: 30px;" BorderStyle="Solid"></asp:TextBox>

                    <asp:TextBox ID="txtMaxLine" runat="server" Style="z-index: 1; left: 359px; top: 440px; position: absolute; width: 135px; height: 30px;" BorderStyle="Solid"></asp:TextBox>

                    <asp:Button ID="Button1" runat="server" CssClass="button1" style="z-index: 1; left: 988px; top: 437px; position: absolute" Text="Query" />

                </div>

            </div>
        </div>
        <div id="formfoot" style="z-index: 1; position: absolute; top: 663px; left: 1px; width: 99%; height: 57px; border: 1px black; background-color: aqua">
            <asp:Label ID="LoginUser" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

    </form>
</body>
</html>
