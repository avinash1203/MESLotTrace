<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PartsAdj.aspx.vb" Inherits="MESLotTrace.PartsAdj" %>

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
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="PARTS ADJUSTMENT" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/BackBlue01v1.png" Style="z-index: 1; left: 95%; top: 8px; position: absolute; width: 50px; height: 38px" Width="25px" />
        </div>
        <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 1000px; border: 1px black solid;">
            <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 900px; border: 1px black solid; top: 20px; left: 4px;">
                <div id="formdetail" runat="server" style="z-index: 1; position: absolute; width: 98%; top: 3px; left: 13px; height: 850px; border: 1px red solid;">
                    <asp:Label ID="Label1" runat="server" Style="position: absolute; z-index: 1; left: 14px; top: 7px; right: 1355px;" Text="Line" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label2" runat="server" Style="position: absolute; z-index: 1; left: 14px; top: 46px" Text="Process" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label3" runat="server" Style="position: absolute; z-index: 1; left: 14px; top: 85px" Text="Step Code" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label4" runat="server" Style="position: absolute; z-index: 1; left: 14px; top: 124px" Text="Equip ID" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label6" runat="server" Style="position: absolute; z-index: 1; left: 645px; top: 10px" Text="Model" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label8" runat="server" Style="position: absolute; z-index: 1; left: 645px; top: 49px" Text="Part Code" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label9" runat="server" Style="position: absolute; z-index: 1; left: 645px; top: 88px" Text="Vendor Lot" Font-Size="X-Large"></asp:Label>
                    <asp:Label ID="Label10" runat="server" Style="position: absolute; z-index: 1; left: 645px; top: 124px" Text="Zero Qty Flag" Font-Size="X-Large"></asp:Label>
                    <asp:TextBox ID="ttLineID" runat="server" Style="z-index: 1; left: 170px; top: 6px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtProcess" runat="server" Style="z-index: 1; left: 170px; top: 45px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtStepCode" runat="server" Style="z-index: 1; left: 170px; top: 84px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtEquipID" runat="server" Style="z-index: 1; left: 170px; top: 123px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtModel" runat="server" Style="z-index: 1; left: 861px; top: 6px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtPartCode" runat="server" Style="z-index: 1; left: 861px; top: 45px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>
                    <asp:TextBox ID="txtVendorLot" runat="server" Style="z-index: 1; left: 861px; top: 84px; position: absolute; width: 254px; height: 30px;" BorderStyle="Solid"></asp:TextBox>

                    <asp:Button ID="btnFilter" OnClick="btnFilter_Click" runat="server" CssClass="button1" Font-Bold="True" Font-Size="X-Large" Style="z-index: 1; left: 1211px; top: 20px; position: absolute; width: 144px; height: 94px" Text="Filter" />
                    <asp:RadioButton ID="RBYes" GroupName="isZero" runat="server" Style="z-index: 1; left: 861px; top: 130px; position: absolute" Text="YES" />
                    <asp:RadioButton ID="RBNo" GroupName="isZero" runat="server" Style="z-index: 1; left: 957px; top: 130px; position: absolute" Text="NO" />
                    <asp:GridView PageSize="22" Font-Size="Medium" AllowPaging="True" OnRowCommand="gvContent_RowCommand"
                        OnPageIndexChanging="gvContent_PageIndexChanging" ID="GVContent" runat="server" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="3"
                        EmptyDataText="No Data Selected" GridLines="Vertical" Style="z-index: 1; left: 14px; top: 189px; position: absolute; height: 222px; width: 1343px" ShowHeaderWhenEmpty="True">
                        <AlternatingRowStyle BackColor="#DCDCDC" />
                        <Columns>
                            <asp:BoundField DataField="tag_seq" Visible="false" />
                            <asp:BoundField DataField="line_id" HeaderText="Line" />
                            <asp:BoundField DataField="proc_flow_id" HeaderText="Process" />
                            <asp:BoundField DataField="step_cd" HeaderText="Step" />
                            <asp:BoundField DataField="equip_id" HeaderText="Equip" />
                            <asp:BoundField DataField="item_cd" HeaderText="Parts" />
                            <asp:BoundField DataField="vendor_cd" HeaderText="Vendor Lot" />
                            <asp:BoundField DataField="input_date" HeaderText="Input Time" />
                            <asp:BoundField DataField="input_qty" HeaderText="Tag Qty" />
                            <asp:BoundField DataField="current_qty" HeaderText="Bal. Qty" />
                            <%-- <asp:BoundField DataField="current_qty" HeaderText="Adjusted Qty" />--%>
                            <%-- <asp:CommandField HeaderText="Adjust" SelectText="Adjust" ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>--%>
                            <asp:TemplateField HeaderText="Actions">
                                <ItemStyle Width="100px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="adjustedLinkView" runat="server" CommandName="Adjust" CommandArgument='<%#  Eval("tag_seq") & "_" & Eval("current_qty") %>' Text="Adjust" />
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

            </div>
        </div>

        <div id="DataEntryScr" visible="false" runat="server"
            style="z-index: 9999; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); width: 499px; height: 300px; border: 1px solid black; background-color: azure;">

            <asp:Label ID="Label12" runat="server" Text="Adjust quantity" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 24px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:HiddenField ID="hfTagSeq" Value="" runat="server" />
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 70px; position: absolute" Text="Current qty "></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute" Text="Adjust qty "></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute" Text="Reason ID "></asp:Label>

            <asp:TextBox ID="txtCqty" Enabled="false" ClientIDMode="Static" type="text" runat="server" Style="z-index: 1; left: 267px; top: 70px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>
            <asp:TextBox ID="txtAty" ClientIDMode="Static" type="text" runat="server" Style="z-index: 1; left: 267px; top: 110px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>
            <asp:DropDownList ID="ddlReason" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 150px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px" DataSourceID="ddlReasonSda" DataTextField="RSN_CD" DataValueField="RSN_CD">
            </asp:DropDownList>

            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 39px; top: 229px; width: 99px; height: 30px; position: absolute; font-size: medium; font-weight: 600;" Text="Save" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 280px; top: 230px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
            <asp:SqlDataSource ID="ddlReasonSda" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [RSN_DIV],[RSN_CD] FROM [dbo].[MAST_REASON]"></asp:SqlDataSource>

        </div>

        <div id="formfoot" style="z-index: 1; position: absolute; top: 1100px; left: 1px; width: 100%; height: 50px; border: 1px black; background-color: aqua">
            <asp:Label ID="User" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

    </form>
</body>
</html>
