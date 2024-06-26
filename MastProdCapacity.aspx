<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MastProdCapacity.aspx.vb" Inherits="MESLotTrace.MastProdCapacity" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Production Capacity</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="icon" type="image/x-icon" href="~/images/favicon.ico">
    <link href="Scripts/dndod-popup.min.css" rel="stylesheet" />
    <script src="Scripts/dndod-popup.min.js"></script>
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/jquery.validation/1.16.0/jquery.validate.min.js"></script>
    <style>
        label.error {
            color: red;
            font-style: italic;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="z-index: 1; font: calibri; width: auto; height: auto;">
        <div id="formheader" runat="server"
            style="z-index: 1; position: absolute; top: 1px; left: 1px; border: 1px black solid; width: 100%; height: 80px; background-color: aquamarine;">
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/FormHeader01.png"
                Style="z-index: 1; border-image-repeat: stretch; padding: 5px 5px 2px 2px; width: 100%; height: 100%;" />
        </div>
        <div id="formtitle" runat="server" style="z-index: 1; position: absolute; top: 86px; left: 1px; width: 100%; height: 50px; text-align: center; border: 1px solid black; background-color: azure;">
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="Master Production Capacity" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
   <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/BackBlue01v1.png" Style="z-index: 1; left: 95%; top: 8px; position: absolute; width: 50px; height: 38px" Width="25px" />
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
                                <asp:LinkButton ID="detailsLnkView" runat="server" CommandName="Select" CommandArgument="<%# Container.DataItemIndex %>"  Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="item_cd" HeaderText="Item Code" ReadOnly="True" SortExpression="item_cd" />
                        <asp:BoundField DataField="line_id" HeaderText="Line ID" ReadOnly="True" SortExpression="line_id" />

                        <asp:BoundField DataField="proc_flow_id" HeaderText="Process Flow Id" SortExpression="proc_flow_id">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="shift_num" HeaderText="No. of Shift" SortExpression="shift_num">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="production_capacity" HeaderText="Production Capacity" SortExpression="production_capacity">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="priority_order" HeaderText="Priority Order" SortExpression="priority_order">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="line_sym" HeaderText="Lot Rule" SortExpression="line_sym">
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



                <asp:SqlDataSource ID="MastSetupSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [cmp_cd],[plnt_cd],[item_cd],[line_id],[proc_flow_id],[shift_num],[production_capacity],[proc_seq],[priority_order],[line_sym],[proc_sym] FROM [dbo].[MAST_PROD_CAPACITY] WHERE CNCL_FLG = 0"></asp:SqlDataSource>

            </div>
        </div>
        <div id="formfoot" style="z-index: 1; position: absolute; top: 698px; left: 1px; width: 100%; height: 50px; border: 1px black; background-color: aqua">
            <asp:Label ID="User" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 60%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 580px; border: 1px solid black; background-color: azure;">
            <asp:Label ID="Label3" runat="server" Text="Setup Data Entry" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 24px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:HiddenField ID="hfPopUpType" Value="" runat="server" />

            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 34px; top: 70px; position: absolute" Text="Company Code "></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute" Text="Plant Code "></asp:Label>
            <asp:Label ID="Label13" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute" Text="Item Code "></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 1; left: 34px; top: 190px; position: absolute" Text="Line Id "></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 1; left: 34px; top: 230px; position: absolute" Text="Production Flow Id "></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 34px; top: 270px; position: absolute" Text="No. of Shift "></asp:Label>
            <asp:Label ID="Label10" runat="server" Style="z-index: 1; left: 34px; top: 310px; position: absolute" Text="Production Capacity "></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 1; left: 36px; top: 350px; position: absolute" Text="Priority Order"></asp:Label>
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 37px; top: 392px; position: absolute" Text="Lot Rule  "></asp:Label>
            <asp:Label ID="Label12" runat="server" Style="z-index: 1; left: 39px; top: 434px; position: absolute" Text="Manufacturing Lot Number code "></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 39px; top: 474px; position: absolute" Text="Remarks"></asp:Label>

            <asp:DropDownList ID="ddlCC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 317px; top: 70px; width: 168px; height: 25px; position: absolute" DataSourceID="ddlCCSDA" DataTextField="cmp_nm" DataValueField="cmp_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>


            <asp:DropDownList ID="ddlPC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 317px; top: 110px; width: 168px; height: 25px; position: absolute;" DataSourceID="ddlPCSDA" DataTextField="pltn_nm" DataValueField="pltn_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>
            

            <div style="z-index: 1; left: 317px; top: 150px; width: 388px; height: 25px; position: absolute;">
<asp:TextBox ID="txtIC" runat="server"></asp:TextBox>
                <asp:ImageButton ID="imgSearchIC" runat="server" Height="24px" ImageUrl="~/Images/search.png" Width="25px" style="z-index: 1; left: 181px; top: 0px; position: absolute" />

            </div>



            <asp:DropDownList ID="ddlLineId" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 317px; top: 190px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px" DataSourceID="ddlLINESDA" DataTextField="line_nm" DataValueField="line_id">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>

            <asp:DropDownList ID="ddlPFID" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 317px; top: 230px; width: 168px; height: 25px; position: absolute;" DataSourceID="ddlPFIDSDA" DataTextField="proc_flow_id" DataValueField="proc_flow_id">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>


            <div style="z-index: 1; left: 317px; top: 270px; width: 388px; height: 25px; position: absolute;">
                <asp:TextBox ID="txtNS" ClientIDMode="Static" type="text" runat="server" Style="width: 168px; display: inline-block;" Height="25px"></asp:TextBox>

                <div id="txtNS-error" style="display: inline-block;" class="error"></div>

            </div>

            <asp:TextBox ID="txtProdCap" type="text" runat="server" Style="z-index: 1; left: 317px; top: 310px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>

            <asp:TextBox ID="txtPO" ClientIDMode="Static" type="text" runat="server" Style="z-index: 1; left: 317px; top: 350px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>



            <asp:DropDownList ID="ddlLS" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 317px; top: 390px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px">
                <asp:ListItem Text="-- Select Option --" Value="" />
                <asp:ListItem Text="1" Value="1" />
                <asp:ListItem Text="2" Value="2" />
                <asp:ListItem Text="3" Value="3" />
            </asp:DropDownList>
            <div style="z-index: 1; left: 317px; top: 430px; width: 588px; height: 25px; position: absolute;">
                <asp:TextBox ID="txtPS" ClientIDMode="Static" type="text" runat="server" Height="25px"></asp:TextBox>
                <div id="txtPS-error" style="display: inline-block;" class="error"></div>
            </div>

            <asp:TextBox ID="txtRe" runat="server" Style="z-index: 1; left: 317px; top: 470px; width: 168px; height: 25px; position: absolute;" Height="25px"></asp:TextBox>

            <asp:Button ClientIDMode="Static" ID="btnDelete" runat="server" Style="z-index: 1; left: 250px; top: 520px; position: absolute; font-size: medium; font-weight: 600;" Text="Delete" Height="30px" Width="99px" CssClass="button1" />
            <asp:Button ClientIDMode="Static" ID="btnSave" OnClientClick="return ValidateForm();return false;" OnClick="btnSave_Click" runat="server" Style="z-index: 1; left: 37px; top: 520px; width: 99px; height: 30px; position: absolute; font-size: medium; font-weight: 600;" Text="Save" CssClass="button1" />
            <asp:Button ClientIDMode="Static" ID="btnCancel" CausesValidation="False" runat="server" Style="z-index: 1; left: 450px; top: 520px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
            <asp:ImageButton ClientIDMode="Static" ID="ImageButton1" CausesValidation="False" runat="server" Height="30px" ImageUrl="~/Images/icon_del_canc_reject.png" Style="z-index: 1; left: 559px; top: 29px; position: absolute" Width="30px" />


        </div>

        <div id="SearchScr" runat="server"
            style="z-index: 9999; position: absolute; top: 60%; left: 50%; transform: translate(-50%,-50%); width: 399px; height: 180px; border: 1px solid black; background-color: azure;">
            <asp:Label ID="Label14" runat="server" Text="Search Item Code" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 24px; position: absolute; width: 359px; text-align: center"></asp:Label>
            <asp:Label ID="Label15" runat="server" Style="z-index: 1; left: 64px; top: 70px; position: absolute" Text="Search Code"></asp:Label>
            <asp:TextBox ID="txtSearchIC" runat="server" Style="z-index: 1; left: 197px; top: 70px; width: 168px; height: 25px; position: absolute"></asp:TextBox>

            <asp:Button ID="btnSearch" runat="server" Style="z-index: 1; left: 84px; top: 130px; width: 99px; height: 30px; position: absolute; font-size: medium; font-weight: 600;" Text="Search" CssClass="button1" />
            <asp:Button ID="btnSearchCancel" runat="server" Style="z-index: 1; left: 229px; top: 131px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
        </div>

        <asp:SqlDataSource ID="ddlCCSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [cmp_nm],[cmp_cd], [REGR_ID] FROM [MAST_COMPANYCODE] WHERE CNCL_FLG = 0 ORDER BY [cmp_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlPCSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [pltn_nm],[pltn_cd], [REGR_ID] FROM [MAST_PLANTCODE] WHERE CNCL_FLG = 0 ORDER BY [pltn_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlPFIDSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [proc_flow_id] from MAST_PROC3 WHERE CNCL_FLG = 0"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlLINESDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [lproc_id],[line_id], [line_nm] FROM [MAST_LINE] WHERE CNCL_FLG = 0 ORDER BY [line_nm]"></asp:SqlDataSource>



    </form>

</body>



<script type="text/javascript">
    function ValidateForm() {
        //console.log("ValidateForm");
        //return true;
        ////console.log("ValidateForm");
        return $("#form1").valid();
    }



    $(document).ready(function () {

        $.validator.addMethod("oneChar", function (value, element) {
            console.log("ValidateForm");
            return value.length === 1 || 0;
        }, "Please enter only one character.");

        $('#btnDelete,#btnCancel,#ImageButton1').click(function () {
            $("#form1").validate().cancelSubmit = true;
        });

        $("#form1").validate({
            rules: {
                txtNS: {
                    /*  required: true,*/
                    digits: true
                },
                txtPS: {
                    maxlength: 1
                }
            },
            messages: {
                txtNS: {
                    /* required: "Please enter a value",*/
                    digits: "Please enter only digits"
                },
                txtPS: {
                    maxlength: "Please enter only one character."
                }
            },
            errorPlacement: function (error, element) {
                var errorId = element.attr("id") + "-error";
                error.insertAfter("#" + errorId);
            }
        });
    });


</script>
</html>

