<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MastLineMaint.aspx.vb" Inherits="MESLotTrace.MastLineMaint" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Line Maintenance</title>
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
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="LINE MASTER MAINTENANCE" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
        <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 550px; border: 1px black solid;">
            <asp:Label ID="Label1" runat="server" Text="Defined Data" Style="z-index: 1; position: absolute; top: 5px; left: 1px;" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue"></asp:Label>
            <asp:Button ID="btnNew" runat="server" Style="z-index: 1; position: absolute; top: 2px; left: 200px; font-size: large;" Text="Create New" CssClass="button1" />
            <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 491px; border: 1px black solid; top: 55px; left: 4px;">
                <asp:GridView ID="gvContent" runat="server"
                    Font-Size="Medium"
                    ShowFooter="True" OnRowCommand="gvContent_RowCommand"
                    EmptyDataText="No Data Defined" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="MastLineSDA" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:LinkButton ID="detailsLnkView" runat="server" CommandName="Select" CommandArgument='<%# Eval("line_id") %>' Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="line_id" HeaderText="Line Id" SortExpression="line_id">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="line_nm" HeaderText="Line Description" SortExpression="line_nm">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="shift_ptrn_id" HeaderText="Shift Id" SortExpression="shift_ptrn_id">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="cost_center" HeaderText="Cost Center" SortExpression="cost_center">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="str_location" HeaderText="Storage Location" SortExpression="str_location">
                            <ItemStyle Width="200px" />
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



                <asp:SqlDataSource ID="MastLineSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [cmp_cd]
                       ,[plnt_cd],[line_id],[line_nm],[lproc_id],[line_nm_local],[shift_ptrn_id],[cost_center] ,[str_location],[REGR_ID],[REGR_DATE],[UPD_ID] ,[UPD_DATE]
                       ,[CNCL_FLG] FROM [MAST_LINE] WHERE CNCL_FLG = 0 ORDER BY [line_id]"></asp:SqlDataSource>

            </div>
        </div>
        <div id="formfoot" style="z-index: 1; position: absolute; top: 698px; left: 1px; width: 100%; height: 50px; border: 1px black; background-color: aqua">
            <asp:Label ID="User" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 60%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 600px; border: 1px solid black; background-color: azure;">
            <asp:HiddenField ID="hfPopUpType" Value="" runat="server" />

            <asp:Label ID="Label3" runat="server" Text="Line Data Entry" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 14px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 34px; top: 70px; position: absolute" Text="Company Code "></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute" Text="Plant Code "></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute" Text="Line ID  "></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 1; left: 34px; top: 190px; position: absolute" Text="Line Description "></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 34px; top: 241px; position: absolute" Text="Lproc id "></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 34px; top: 284px; position: absolute" Text="Line nm local "></asp:Label>
            <asp:Label ID="Label10" runat="server" Style="z-index: 1; left: 34px; top: 344px; position: absolute" Text="Notes "></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 1; left: 34px; top: 389px; position: absolute" Text="Shift ID "></asp:Label>
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 34px; top: 447px; position: absolute" Text="Cost center "></asp:Label>
            <asp:Label ID="Label12" runat="server" Style="z-index: 1; left: 34px; top: 503px; position: absolute" Text="Storage Location "></asp:Label>

            <asp:DropDownList ID="ddlCC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 66px; width: 168px; height: 25px; position: absolute" DataSourceID="ddlCCSDA" DataTextField="cmp_nm" DataValueField="cmp_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>


            <asp:DropDownList ID="ddlPC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 109px; width: 168px; height: 25px; position: absolute;" DataSourceID="ddlPCSDA" DataTextField="pltn_nm" DataValueField="pltn_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>

            <asp:TextBox ID="txtLID" runat="server" Style="z-index: 1; left: 267px; top: 149px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>
            <asp:TextBox ID="txtLD" runat="server" Style="z-index: 1; left: 267px; top: 190px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>

            <asp:TextBox ID="txtLprocId" runat="server" Style="z-index: 1; left: 267px; top: 241px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtLNL" runat="server" Style="z-index: 1; left: 267px; top: 289px; width: 168px; height: 25px; position: absolute"></asp:TextBox>

            <asp:TextBox ID="txtNotes" runat="server" Style="z-index: 1; left: 267px; top: 342px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:DropDownList ID="ddlShift" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 390px; width: 168px; height: 25px; position: absolute;" DataSourceID="ddlShiftSDA" DataTextField="shift_ptrn_id" DataValueField="shift_ptrn_id">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>
            <asp:TextBox ID="txtCostCenter" runat="server" Style="z-index: 1; left: 267px; top: 437px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtSL" runat="server" Style="z-index: 1; left: 267px; top: 500px; width: 168px; height: 25px; position: absolute"></asp:TextBox>



            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 39px; top: 550px; width: 99px; height: 30px; position: absolute; font-size: medium; font-weight: 600; right: 461px;" Text="Save" CssClass="button1" />
            <asp:Button ID="btnDelete" runat="server" Style="z-index: 1; left: 239px; top: 550px; position: absolute; font-size: medium; font-weight: 600;" Text="Delete" Height="30px" Width="99px" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 448px; top: 550px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
            <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/Images/icon_del_canc_reject.png" Style="z-index: 1; left: 559px; top: 29px; position: absolute" Width="30px" />


        </div>
        <asp:SqlDataSource ID="ddlCCSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [cmp_nm], [cmp_cd],[REGR_ID] FROM [MAST_COMPANYCODE] WHERE CNCL_FLG = 0 ORDER BY [cmp_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlPCSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [pltn_nm],[pltn_cd], [REGR_ID] FROM [MAST_PLANTCODE] WHERE CNCL_FLG = 0 ORDER BY [pltn_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlShiftSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [shift_ptrn_id] FROM MAST_SHIFT WHERE CNCL_FLG = 0 ORDER BY [shift_ptrn_id]"></asp:SqlDataSource>


    </form>
</body>
</html>
