<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Scrap.aspx.vb" Inherits="MESLotTrace.Scrap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Parts Adjustment</title>
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
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="SCRAP AND REWORK" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/BackBlue01v1.png" Style="z-index: 1; left: 95%; top: 8px; position: absolute; width: 50px; height: 38px" Width="25px" />
        </div>
        <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 1000px; border: 1px black solid;">
            <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 900px; border: 1px black solid; top: 20px; left: 4px;">
                <div id="formdetail" runat="server" style="z-index: 1; position: absolute; width: 98%; top: 3px; left: 13px; height: 850px; border: 1px red solid;">
                    <asp:Label ID="Label1" runat="server" Style="position: absolute; z-index: 1; left: 14px; top: 7px; right: 1355px;" Text="Line" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Style="position: absolute; z-index: 1; left: 14px; top: 46px" Text="Process" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Style="position: absolute; z-index: 1; left: 14px; top: 85px" Text="Step Code" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Style="position: absolute; z-index: 1; left: 722px; top: 4px" Text="Item Cd" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Style="position: absolute; z-index: 1; left: 580px; top: 82px" Text="Completed/Reject" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox ID="ttLineID" runat="server" Style="z-index: 1; left: 170px; top: 6px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtProcess" runat="server" Style="z-index: 1; left: 170px; top: 45px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtStepCode" runat="server" Style="z-index: 1; left: 170px; top: 84px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtModel" runat="server" Style="z-index: 1; left: 861px; top: 6px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>

                    <asp:Button ID="btnFilter" OnClick="btnFilter_Click" runat="server" CssClass="button1" Font-Bold="True" Font-Size="X-Large" Style="z-index: 1; left: 1211px; top: 20px; position: absolute; width: 144px; height: 94px" Text="Filter" />
                    <asp:RadioButton ID="RBYes" GroupName="isZero" runat="server" Style="z-index: 1; left: 861px; top: 88px; position: absolute" Text="YES" />
                    <asp:RadioButton ID="RBNo" GroupName="isZero" runat="server" Style="z-index: 1; left: 957px; top: 88px; position: absolute" Text="NO" />

                </div>

            </div>
        </div>

        <div id="DEScrap" visible="false" runat="server"
            style="z-index: 9999; position: absolute; top: 55%; left: 40%; transform: translate(-50%,-50%); width: 499px; height: 300px; border: 1px solid black; background-color: azure;">

            <asp:Label ID="LblHdr" runat="server" Text="Scrap Serial" Font-Bold="True"
                Style="z-index: 1; left: 12px; top: 8px; position: absolute; width: 484px; text-align: center; height: 39px;"></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 72px; position: absolute" Text="Serial No.  "></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 34px; top: 112px; position: absolute" Text="Item Code"></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute" Text="Manu. Lot No."></asp:Label>
                        <asp:Label ID="Label13" runat="server" Style="z-index: 1; left: 34px; top: 195px; position: absolute" Text="Reason"></asp:Label>

            <asp:TextBox ID="txtSNo" Enabled="false" ClientIDMode="Static" type="text" runat="server" Style="z-index: 1; left: 267px; top: 70px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>
            <asp:TextBox ID="txtItemCd" ClientIDMode="Static" type="text" runat="server" Style="z-index: 1; left: 267px; top: 110px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>
            <asp:TextBox ID="txtMLot" ClientIDMode="Static" type="text" runat="server" Style="z-index: 1; left: 267px; top: 148px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>
 
            <asp:DropDownList ID="ddlReason" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 194px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px" DataTextField="RSN_CD" DataValueField="RSN_CD">
            </asp:DropDownList>

            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 43px; top: 254px; width: 99px; height: 30px; position: absolute; font-size: medium; font-weight: 600;" Text="Save" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 338px; top: 249px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
            <asp:SqlDataSource ID="ddlReasonSdaScrap" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [RSN_DIV],[RSN_CD] FROM [dbo].[MAST_REASON] WHERE RSN_DIV=101"></asp:SqlDataSource>
                        <asp:SqlDataSource ID="ddlReasonSdaReject" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [RSN_DIV],[RSN_CD] FROM [dbo].[MAST_REASON] WHERE RSN_DIV=100"></asp:SqlDataSource>

                    <asp:GridView PageSize="22" Font-Size="Medium" AllowPaging="True" OnRowCommand="gvContent_RowCommand"
                        OnPageIndexChanging="gvContent_PageIndexChanging" ID="GVContent" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                        EmptyDataText="No Data Selected" GridLines="Vertical" Style="z-index: 1; left: -603px; top: 343px; position: absolute; height: 222px; width: 1343px" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <%-- <asp:BoundField DataField="current_qty" HeaderText="Adjusted Qty" />--%>
                            <%-- <asp:CommandField HeaderText="Adjust" SelectText="Adjust" ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>--%>
                            <asp:BoundField DataField="Item_Cd" HeaderText="Item Code" />
                            <asp:BoundField DataField="line_id" HeaderText="Line" />
                            <asp:BoundField DataField="proc_flow_id" HeaderText="Process" />
                            <asp:BoundField DataField="step_cd" HeaderText="Step" />
                            <asp:TemplateField HeaderText="Scrap">
                                <ItemStyle Width="100px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="ScrapLinkView" runat="server" CommandName="Scrap" CommandArgument='<%#  Eval("l_serial") %>' Text="Scrap" />
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Reject">
                                <ItemStyle Width="100px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="RejectLinkView" runat="server" CommandName="Reject" CommandArgument='<%#  Eval("l_serial") %>' Text="Reject" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" Height="50px" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                        <SortedDescendingHeaderStyle BackColor="#000065" />
                    </asp:GridView>

        </div>

        <div id="formfoot" style="z-index: 1; position: absolute; top: 1100px; left: 1px; width: 100%; height: 50px; border: 1px black; background-color: aqua">
            <asp:Label ID="User" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

    </form>
</body>
</html>
