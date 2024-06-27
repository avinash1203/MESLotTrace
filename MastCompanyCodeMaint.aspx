<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MastCompanyCodeMaint.aspx.vb" Inherits="MESLotTrace.MastCompanyCodeMaint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Company Code Maintenance</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" type="image/x-icon" href="~/images/favicon.ico">
    <link href="Scripts/dndod-popup.min.css" rel="stylesheet" />
    <script src="Scripts/dndod-popup.min.js"></script>
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" style="z-index: 1; font: calibri; width: auto; height: auto;">
        <div id="mainform" runat="server" style="z-index: 1; font: calibri; width: auto; height: auto;">
            <div id="formheader" runat="server"
                style="z-index: 1; position: absolute; top: 1px; left: 1px; border: 1px black solid; width: 100%; height: 80px; background-color: aquamarine;">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/FormHeader01.png"
                    Style="z-index: 1; border-image-repeat: stretch; padding: 5px 5px 2px 2px; width: 100%; height: 100%;" />
            </div>
            <div id="formtitle" runat="server" style="z-index: 1; position: absolute; top: 86px; left: 1px; width: 100%; height: 50px; text-align: center; border: 1px solid black; background-color: azure;">
                <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="COMPANY CODE MAINTENANCE" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            </div>
            <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 550px; border: 1px black solid;">
                <asp:Label ID="Label1" runat="server" Text="Defined Data" Style="z-index: 1; position: absolute; top: 5px; left: 1px;" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue"></asp:Label>
                <asp:Button ID="btnNew" runat="server" Style="z-index: 1; position: absolute; top: 2px; left: 200px; font-size: large;" Text="Create New" CssClass="button1" />
                <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 491px; border: 1px black solid; top: 55px; left: 4px;">
                    <asp:HiddenField ID="hfNewFlg" runat="server" />
                    <asp:GridView ID="gvContent" runat="server"
                        Font-Size="Large"  AllowPaging="true" PageSize="20"  OnPageIndexChanging="gvContent_PageIndexChanging" 
                        ShowFooter="True"
                        EmptyDataText="No Data Defined" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="MastCompanyCodeSDA" Width="100%">
                        <Columns>
                            <asp:CommandField ShowSelectButton="True">
                            <ItemStyle Width="20%" />
                            </asp:CommandField>
                            <asp:BoundField DataField="CMP_Cd" HeaderText="Company code" ReadOnly="True" SortExpression="CompCd">
                            <ItemStyle Width="30%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CMP_Nm" HeaderText="Company Name" ReadOnly="True" SortExpression="CompNm">
                            <ItemStyle Width="60%" />
                            </asp:BoundField>
                        </Columns>
                        <EmptyDataRowStyle BorderStyle="Solid" BorderWidth="1px" Height="20px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="#24292" ForeColor="White" BorderWidth="1px" Font-Size="Smaller"
                            Height="5px" BorderColor="Black" BorderStyle="Solid" />
                        <HeaderStyle BackColor="#0000FF" Font-Bold="True" ForeColor="White" Height="20px" />
                        <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                        <RowStyle ForeColor="Black" Height="20px" BorderColor="Black"
                            BorderStyle="Solid" BorderWidth="1px" />
                        <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                    </asp:GridView>
                </div>
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/BackBlue01v1.png" Style="z-index: 1; left: 97%; top: 13px; position: absolute; width: 50px; height: 38px" Width="25px" />
            </div>
            <div id="formfoot" style="z-index: 1; position: absolute; top: 698px; left: 1px; width: 100%; height: 48px; border: 1px black; background-color: aqua">
                <asp:Label ID="LoginUser" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            </div>

            <div id="DataEntryScr" runat="server"
                style="z-index: 9999; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 257px; border: 1px solid black; background-color: azure;">
                <asp:Label ID="Label3" runat="server" Text="COMPANY Code Data Entry" Font-Bold="True"
                    Style="z-index: 1; left: 10px; top: 14px; position: absolute; width: 582px; text-align: center"></asp:Label>
                <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 35px; top: 70px; position: absolute; width: auto;" Text="Company code"></asp:Label>
                <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute; width: auto;" Text="Company Name"></asp:Label>


                <asp:TextBox ID="txtCompCd" runat="server" Style="z-index: 1; left: 218px; top: 69px; position: absolute"></asp:TextBox>
                <asp:TextBox ID="txtCompNm" runat="server" Style="z-index: 1; left: 218px; top: 109px; position: absolute; width: 318px"></asp:TextBox>


                <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 38px; top: 200px; width: 99px; height: 30px; position: absolute" Text="Save" CssClass="button1" />
                <asp:Button ID="btnDelete" runat="server" Style="z-index: 1; left: 250px; top: 200px; position: absolute" Text="Delete" Height="30px" Width="99px" CssClass="button1" />
                <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 450px; top: 200px; position: absolute" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />

            </div>

        <div id="ConfirmDelete" runat="server"
            style="z-index: 9999; position: absolute; top: 50%; left: 886px; transform: translate(-50%,-50%); width: 599px; height: 353px; border: 1px solid black; background-color: #FFCC00;">
            <asp:Label ID="Label2" runat="server" Text="Delete confirmation" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 14px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:Label ID="Label12" runat="server" Style="z-index: 1; left: 154px; top: 122px; position: absolute" Text="Please confirm Deletion" Font-Size="X-Large"></asp:Label>
            <asp:Button ID="btnConfirmDelete" runat="server" Style="z-index: 1; left: 77px; top: 248px; width: 201px; height: 60px; position: absolute; font-size: medium; font-weight: 600;" Text="Confirm" CssClass="button1" />
            <asp:Button ID="btnCanceldelete" runat="server" Style="z-index: 1; left: 356px; top: 256px; width: 201px; height: 60px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" CssClass="button1" />
            <asp:ImageButton ID="ImageButton2" runat="server" Height="30px" ImageUrl="~/Images/icon_del_canc_reject.png" Style="z-index: 1; left: 559px; top: 29px; position: absolute" Width="30px" />
        </div>
        </div>
        <asp:SqlDataSource ID="MastCompanyCodeSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [CMP_Cd], [CMP_Nm] FROM [MAST_COMPANYCODE]"></asp:SqlDataSource>
    </form>
</body>
</html>
