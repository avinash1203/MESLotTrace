﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MastProd3.aspx.vb" Inherits="MESLotTrace.MastProd3" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Production</title>
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
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="Master Production" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        </div>
        <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 550px; border: 1px black solid;">
            <asp:Label ID="Label1" runat="server" Text="Defined Data" Style="z-index: 1; position: absolute; top: 5px; left: 1px;" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue"></asp:Label>
            <asp:Button ID="btnNew" runat="server" Style="z-index: 1; position: absolute; top: 2px; left: 200px; font-size: large;" Text="Create New" CssClass="button1" />
            <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 491px; border: 1px black solid; top: 55px; left: 4px;">
                <asp:GridView ID="gvContent" runat="server"
                    Font-Size="Medium"
                    ShowFooter="True" OnRowCommand="gvContent_RowCommand"
                    EmptyDataText="No Data Defined" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="MastSetupSDA" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="detailsLnkView" runat="server" CommandName="Select" CommandArgument='<%# Eval("proc_flow_id") + "_" + Eval("assoc_flow_id") %>' Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="line_id" HeaderText="Line ID" SortExpression="line_id">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="item_cd" HeaderText="Item Code" SortExpression="item_cd">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="proc_flow_id" HeaderText="Process Flow Id" SortExpression="proc_flow_id">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="assoc_flow_id" HeaderText="Association Flow Id" SortExpression="assoc_flow_id">
                            <ItemStyle Width="100px" />
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



                <asp:SqlDataSource ID="MastSetupSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [line_id],[item_cd],[proc_flow_id],[assoc_flow_id] FROM [MAST_PROC3] WHERE CNCL_FLG = 0"></asp:SqlDataSource>

            </div>
        </div>
        <div id="formfoot" style="z-index: 1; position: absolute; top: 698px; left: 1px; width: 100%; height: 50px; border: 1px black; background-color: aqua">
            <asp:Label ID="User" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 320px; border: 1px solid black; background-color: azure;">
            <asp:Label ID="Label3" runat="server" Text="Setup Data Entry" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 24px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:HiddenField ID="hfPopUpType" Value="" runat="server" />
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 34px; top: 70px; position: absolute" Text="Line ID "></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute" Text="Item Code "></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute" Text="Process Flow ID "></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 1; left: 34px; top: 190px; position: absolute" Text="Associate Flow ID"></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 34px; top: 230px; position: absolute" Text="Remarks "></asp:Label>




            <asp:DropDownList ID="ddlLineId" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 70px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px" DataSourceID="ddlLINESDA" DataTextField="line_nm" DataValueField="line_id">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>

            <asp:DropDownList ID="ddlIC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 110px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px" DataSourceID="ddlICSDA" DataTextField="item_nm" DataValueField="item_nm">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>
            <asp:TextBox ID="txtPFID" runat="server" Style="z-index: 1; left: 267px; top: 150px; width: 168px; height: 25px; position: absolute"></asp:TextBox>


            <asp:TextBox ID="txtAFID" runat="server" Style="z-index: 1; left: 267px; top: 190px; width: 168px; height: 25px; position: absolute"></asp:TextBox>

            <asp:TextBox ID="txtRe" runat="server" Style="z-index: 1; left: 267px; top: 230px; width: 168px; height: 25px; position: absolute"></asp:TextBox>

            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 36px; top: 287px; width: 99px; height: 30px; position: absolute; font-size: medium; font-weight: 600;" Text="Save" CssClass="button1" />
            <asp:Button ID="btnDelete" runat="server" Style="z-index: 1; left: 250px; top: 287px; position: absolute; font-size: medium; font-weight: 600;" Text="Delete" Height="30px" Width="99px" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 450px; top: 287px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
            <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/Images/icon_del_canc_reject.png" Style="z-index: 1; left: 559px; top: 29px; position: absolute" Width="30px" />


        </div>
        <asp:SqlDataSource ID="ddlLINESDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [lproc_id],[line_id], [line_nm] FROM [MAST_LINE] WHERE CNCL_FLG = 0 ORDER BY [line_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlICSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT item_nm FROM [MAST_ITEM] WHERE CNCL_FLG = 0 ORDER BY [item_nm]"></asp:SqlDataSource>


    </form>

</body>

<script>

</script>
</html>


