<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MastShiftMaint.aspx.vb" Inherits="MESLotTrace.MastShiftMaint" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Shift Maintenance</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" type="image/x-icon" href="~/images/favicon.ico">
    <link href="Scripts/dndod-popup.min.css" rel="stylesheet" />
    <script src="Scripts/dndod-popup.min.js"></script>
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <%--  <script src="https://cdn.jsdelivr.net/timepicker.js/latest/timepicker.min.js"></script>
    <link href="https://cdn.jsdelivr.net/timepicker.js/latest/timepicker.min.css" rel="stylesheet" />--%>

    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-timepicker/0.5.2/css/bootstrap-timepicker.min.css">
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.16.0/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-timepicker/0.5.2/js/bootstrap-timepicker.min.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.1/css/bootstrap.min.css">
</head>
<body>
    <form id="form1" runat="server" style="z-index: 1; font: calibri; width: auto; height: auto;">
        <div id="formheader" runat="server"
            style="z-index: 1; position: absolute; top: 1px; left: 1px; border: 1px black solid; width: 100%; height: 80px; background-color: aquamarine;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/FormHeader01.png"
                Style="z-index: 1; border-image-repeat: stretch; padding: 5px 5px 2px 2px; width: 100%; height: 100%;" />
        </div>
        <div id="formtitle" runat="server" style="z-index: 1; position: absolute; top: 86px; left: 1px; width: 100%; height: 50px; text-align: center; border: 1px solid black; background-color: azure;">
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="SHIFT MASTER MAINTENANCE" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/BackBlue01v1.png" Style="z-index: 1; left: 95%; top: 8px; position: absolute; width: 50px; height: 38px" Width="25px" />

        </div>
        <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 550px; border: 1px black solid;">
            <asp:Label ID="Label1" runat="server" Text="Defined Data" Style="z-index: 1; position: absolute; top: 5px; left: 1px;" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue"></asp:Label>
            <asp:Button ID="btnNew" runat="server" Style="z-index: 1; position: absolute; top: 2px; left: 200px; font-size: large;" Text="Create New" CssClass="button1" />
            <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 491px; border: 1px black solid; top: 55px; left: 4px;">
                <asp:GridView ID="gvContent" runat="server"
                    Font-Size="Medium"
                    ShowFooter="True" OnRowCommand="gvContent_RowCommand"
                    EmptyDataText="No Data Defined" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="MastShiftSDA" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="Actions">
                            <ItemStyle Width="100px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="detailsLnkView" runat="server" CommandName="Select" CommandArgument='<%# Eval("shift_ptrn_id") %>' Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="shift_ptrn_id" HeaderText="Shift pattern description" SortExpression="shift_ptrn_id">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="wrk_shift_seq" HeaderText="Work Shift Seq" SortExpression="wrk_shift_seq">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="shift_ptrn_id" HeaderText="Shift ID" SortExpression="shift_ptrn_id">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="strt_time_utc" HeaderText="Start time" SortExpression="strt_time_utc">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="end_time_utc" HeaderText="End Time" SortExpression="end_time_utc">
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



                <asp:SqlDataSource ID="MastShiftSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [shift_ptrn_id], [wrk_shift_seq],[strt_time_utc],[end_time_utc]FROM [MAST_SHIFT] WHERE CNCL_FLG = 0 ORDER BY [shift_ptrn_id]"></asp:SqlDataSource>

            </div>
        </div>
        <div id="formfoot" style="z-index: 1; position: absolute; top: 698px; left: 1px; width: 100%; height: 50px; border: 1px black; background-color: aqua">
            <asp:Label ID="User" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 50%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 500px; border: 1px solid black; background-color: azure;">
            <asp:Label ID="Label3" runat="server" Text="SHIFT Data Entry" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 14px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:HiddenField ID="hfPopUpType" Value="" runat="server" />
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 34px; top: 70px; position: absolute" Text="Company Code "></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute" Text="Plant Code "></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute" Text="Shift pattern description "></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 1; left: 34px; top: 190px; position: absolute" Text="Work Shift Seq "></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 34px; top: 230px; position: absolute" Text="Start Time "></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 34px; top: 270px; position: absolute" Text="End Time "></asp:Label>
            <asp:Label ID="Label10" runat="server" Style="z-index: 1; left: 34px; top: 310px; position: absolute" Text="Shift code "></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 1; left: 36px; top: 350px; position: absolute" Text="Shift description name "></asp:Label>

            <asp:DropDownList ID="ddlCC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 66px; width: 168px; height: 25px; position: absolute" DataSourceID="ddlCCSDA" DataTextField="cmp_nm" DataValueField="cmp_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>


            <asp:DropDownList ID="ddlPC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 109px; width: 168px; height: 25px; position: absolute;" DataSourceID="ddlPCSDA" DataTextField="pltn_nm" DataValueField="pltn_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>

            <asp:TextBox ID="txtSPID" runat="server" Style="z-index: 1; left: 267px; top: 149px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>
            <asp:TextBox ID="txtWSS" runat="server" Style="z-index: 1; left: 267px; top: 190px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>

            <asp:TextBox ID="txtST" ClientIDMode="Static" type="text" class="timepicker" runat="server" Style="z-index: 1; left: 267px; top: 229px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>




            <asp:TextBox ID="txtET" type="text" class="timepicker" runat="server" Style="z-index: 1; left: 267px; top: 269px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>

            <asp:TextBox ID="txtSC" runat="server" Style="z-index: 1; left: 267px; top: 309px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtSDN" runat="server" Style="z-index: 1; left: 267px; top: 349px; width: 168px; height: 25px; position: absolute"></asp:TextBox>

            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 36px; top: 427px; width: 99px; height: 30px; position: absolute; font-size: medium; font-weight: 600;" Text="Save" CssClass="button1" />
            <asp:Button ID="btnDelete" runat="server" Style="z-index: 1; left: 250px; top: 427px; position: absolute; font-size: medium; font-weight: 600;" Text="Delete" Height="30px" Width="99px" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 450px; top: 427px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
            <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/Images/icon_del_canc_reject.png" Style="z-index: 1; left: 559px; top: 29px; position: absolute" Width="30px" />


        </div>
        <asp:SqlDataSource ID="ddlCCSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [cmp_nm],[cmp_cd], [REGR_ID] FROM [MAST_COMPANYCODE] WHERE CNCL_FLG = 0 ORDER BY [cmp_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlPCSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [pltn_nm],[pltn_cd], [REGR_ID] FROM [MAST_PLANTCODE] WHERE CNCL_FLG = 0 ORDER BY [pltn_nm]"></asp:SqlDataSource>


    </form>

</body>

<script>
   

    $(function () {
        // Initialize the timepicker
        $('#txtST').timepicker({
            showMeridian: false, // Set to false for 24-hour format
            minuteStep: 5, // Optional: set the time increment to 15 minutes
            defaultTime: null
        });

        $('#txtET').timepicker({
            showMeridian: false, // Set to false for 24-hour format
            minuteStep: 5,// Optional: set the time increment to 15 minutes
            defaultTime: null
        });
    });
</script>
</html>
