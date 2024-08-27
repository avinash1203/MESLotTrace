<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LotMainSel.aspx.vb" Inherits="MESLotTrace.LotMainSel" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manufacturing Lot Number Selection</title>
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
                Style="z-index: 1; border-image-repeat: stretch; padding: 5px 5px 2px 2px; width: 100%; height: 100%;" />
        </div>
        <div id="formtitle" runat="server" style="z-index: 1; position: absolute; top: 86px; left: 1px; width: 100%; height: 50px; text-align: center; border: 1px solid black; background-color: azure;">
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="Manufacturing Lot Number Selection" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/BackBlue01v1.png" Style="z-index: 1; left: 95%; top: 8px; position: absolute; width: 50px; height: 38px" Width="25px" />
        </div>
        <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 550px; border: 1px black solid;">
            <div id="formcontent" runat="server" style="width: 99%; height: 543px; border: 1px black solid; z-index: 1; left: 6px; top: -1px; position: absolute;">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" style="z-index: 1; left: 17px; top: 10px; position: absolute" Text="Manufacturing Lot Selection Criteria"></asp:Label>
                <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 17px; top: 55px; position: absolute" Text="Line ID"></asp:Label>
                <asp:Label ID="Label3" runat="server" style="z-index: 1; left: 270px; top: 55px; position: absolute" Text="Process Flow ID"></asp:Label>
                <asp:Label ID="Label4" runat="server" style="z-index: 1; left: 642px; top: 55px; position: absolute" Text="Item Code"></asp:Label>
                <asp:Label ID="Label5" runat="server" style="z-index: 1; left: 1032px; top: 55px; position: absolute" Text="Plan Start Date"></asp:Label>
            
                
                <asp:GridView ID="gvContent" runat="server"  AllowPaging="True" PageSize="12" OnPageIndexChanging="gvContent_OnPageIndexChanging"   
                    Font-Size="Medium"
                    ShowFooter="True" OnRowCommand="gvContent_RowCommand"  
                    EmptyDataText="No Data Defined" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="MastSetupSDA" 
                    Width="95%" style="z-index: 1; left: 13px; top: 133px; position: absolute; ">
                    <Columns>
                       <%-- <asp:TemplateField HeaderText="Select">
                            <ItemStyle Width="20%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="detailsLnkView" runat="server" CommandName="Select" CommandArgument='<%# Eval("proc_flow_id") %>' Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>--%>

                        <asp:CommandField ShowSelectButton="True" />

                        <asp:BoundField DataField="plan_manu_line_id" HeaderText="Line ID" SortExpression="plan_manu_line_id" />
                        <asp:BoundField DataField="proc_flow_id" HeaderText="Proc. FlowID" SortExpression="proc_flow_id" />

                        <asp:BoundField DataField="manu_lot_no" HeaderText="Manu. Lot No." SortExpression="manu_lot_no">
                        </asp:BoundField>
                        <asp:BoundField DataField="prod_order_no" HeaderText="Prod. Order No." SortExpression="prod_order_no">
                        </asp:BoundField>
                        <asp:BoundField DataField="item_cd" HeaderText="Item Code" SortExpression="item_cd">
                        </asp:BoundField>
                        <asp:BoundField DataField="LOTSTATUS" HeaderText="Lot Status">
                        </asp:BoundField>
                        <asp:BoundField DataField="plod_strt_actl_dt_utc" HeaderText="Plan Start Date" SortExpression="plod_strt_actl_dt_utc" />
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



                <asp:DropDownList ID="ddlLineID" runat="server" style="z-index: 1; left: 103px; top: 54px; position: absolute; width: 117px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SDALineID" runat="server" ConnectionString="<%$ ConnectionStrings:MyDatabase %>" SelectCommand="SELECT LINE_ID, LINE_NM FROM MAST_LINE ORDER BY LINE_ID"></asp:SqlDataSource>
                <asp:DropDownList ID="ddlProcFlowID" runat="server" style="z-index: 1; left: 426px; top: 54px; position: absolute; width: 198px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SDAProcFlowID" runat="server" ConnectionString="<%$ ConnectionStrings:MyDatabase %>" SelectCommand="select proc_flow_id,proc_flow_nm from mast_proc"></asp:SqlDataSource>
                <asp:DropDownList ID="ddlItemCd" runat="server" style="z-index: 1; left: 750px; top: 54px; position: absolute; width: 231px">
                </asp:DropDownList>
                <asp:SqlDataSource ID="SDAitem" runat="server" ConnectionString="<%$ ConnectionStrings:MyDatabase %>" SelectCommand="select item_cd,item_nm from mast_item order by item_cd"></asp:SqlDataSource>



                <asp:SqlDataSource ID="MastSetupSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT A.manu_lot_no,A.manu_ord_no,A.prod_order_no,A.item_cd,A.plan_manu_line_id,A.proc_flow_id,
CASE 
WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 0 THEN 'NOT STARTED'
WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 1 THEN 'FIRST START'
WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 2 THEN 'SUSPEND'
WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 3 THEN 'PROGRESS'
WHEN CONVERT(INTEGER,B.LTST_OPR_ACT_DIV) = 6 THEN 'CLOSED'
END AS LOTSTATUS, plod_strt_actl_dt_utc
 FROM MAST_MFGLOT a
 left join mast_mfglot2 b ON A.manu_lot_no = B.manu_lot_no "></asp:SqlDataSource>

                <asp:Calendar ID="Calendar1" runat="server" BackColor="#CCFFFF" style="z-index: 1; left: 1058px; top: 99px; position: absolute; height: 213px; width: 309px"></asp:Calendar>
                <asp:ImageButton ID="ImageButton4" runat="server" Height="30px" ImageUrl="~/Images/calendar01.JPG" style="z-index: 1; left: 1163px; top: 51px; position: absolute" Width="30px" />
                <asp:TextBox ID="txtStartDt" runat="server" style="z-index: 1; left: 1201px; top: 54px; position: absolute"></asp:TextBox>

                <asp:Button ID="btnfilter" runat="server" style="z-index: 1; left: 14px; top: 94px; position: absolute; width: 136px" Text="Filter" />

            </div>
        </div>
        <div id="formfoot" style="z-index: 1; position: absolute; top: 698px; left: 1px; width: 100%; height: 50px; border: 1px black; background-color: aqua">
            <asp:Label ID="User" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

       
    </form>

</body>

<script>

</script>
</html>


