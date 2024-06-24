<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="MastTrace.aspx.vb" Inherits="MESLotTrace.Mast_Trace" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Master Trace</title>
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
            <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="Trace Master" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
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
                                <asp:LinkButton ID="detailsLnkView" runat="server" CommandName="Select" CommandArgument='<%# Eval("proc_flow_id") & "_" & Eval("line_id")%>' Text="Select" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="proc_flow_id" HeaderText="Process Flow ID" SortExpression="proc_flow_id">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>


                        <asp:BoundField DataField="step_cd" HeaderText="Step code" SortExpression="step_cd">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>

                        <asp:BoundField DataField="equip_id" HeaderText="Equipment Code" SortExpression="equip_id">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="trace_name" HeaderText="Trace Name" SortExpression="trace_name">
                            <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="trace_div" HeaderText="Trace Division" SortExpression="trace_div">
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



                <asp:SqlDataSource ID="MastSetupSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [cmp_cd],[plnt_cd],[item_cd],[proc_flow_id],[step_cd],[equip_id],[trace_cd],[trace_name],[equip_gp],[trace_div]
                  ,[spec_min],[spec_max],[units],[rep_code_flg],[col_nm_1],[data_type_1],[col_nm_2],[data_type_2],[col_nm_3]
                  ,[data_type_3],[col_nm_4],[data_type_4],[col_nm_5],[data_type_5],[col_nm_6],[data_type_6],[col_nm_7],[data_type_7],[col_nm_8]
                  ,[data_type_8],[col_nm_9],[data_type_9],[col_nm_10]
                  ,[data_type_10],[inf_flg],[line_id]
                   FROM [dbo].[MAST_TRACE] WHERE CNCL_FLG = 0"></asp:SqlDataSource>

            </div>
        </div>
        <div id="formfoot" style="z-index: 1; position: absolute; top: 698px; left: 1px; width: 100%; height: 50px; border: 1px black; background-color: aqua">
            <asp:Label ID="User" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 5px; left: 1px;" Text="User name"></asp:Label>
            <asp:Label ID="Version" runat="server" Style="z-index: 1; position: absolute; font-size: small; top: 30px; left: 1px;" Text="Version"></asp:Label>
        </div>

        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 150%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 1600px; border: 1px solid black; background-color: azure;">
            <asp:Label ID="Label3" runat="server" Text="Setup Data Entry" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 24px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:HiddenField ID="hfPopUpType" Value="" runat="server" />
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 34px; top: 70px; position: absolute" Text="Company Code "></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute" Text="Plant Code "></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute" Text="Model Code "></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 1; left: 34px; top: 190px; position: absolute" Text="Line ID "></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 34px; top: 230px; position: absolute" Text="Process Flow ID "></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 34px; top: 270px; position: absolute" Text="Step Code "></asp:Label>
            <asp:Label ID="Label10" runat="server" Style="z-index: 1; left: 34px; top: 310px; position: absolute" Text="Equipment Code "></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 1; left: 36px; top: 350px; position: absolute" Text="Trace Code"></asp:Label>
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 37px; top: 390px; position: absolute" Text="Trace Name "></asp:Label>
            <asp:Label ID="Label12" runat="server" Style="z-index: 1; left: 39px; top: 430px; position: absolute" Text="Equipment Group "></asp:Label>
            <asp:Label ID="Label13" runat="server" Style="z-index: 1; left: 39px; top: 470px; position: absolute" Text="Trace Division "></asp:Label>


            <asp:Label ID="Label36" runat="server" Style="z-index: 1; left: 39px; top: 510px; position: absolute" Text="Spec Min"></asp:Label>
            <asp:Label ID="Label37" runat="server" Style="z-index: 1; left: 39px; top: 550px; position: absolute" Text="Spec Max "></asp:Label>
            <asp:Label ID="Label38" runat="server" Style="z-index: 1; left: 39px; top: 590px; position: absolute" Text="Units "></asp:Label>


            <asp:Label ID="Label14" runat="server" Style="z-index: 1; left: 39px; top: 630px; position: absolute" Text="Represent Code Flag "></asp:Label>
            <asp:Label ID="Label15" runat="server" Style="z-index: 1; left: 39px; top: 670px; position: absolute" Text="Collection Name 1 "></asp:Label>
            <asp:Label ID="Label16" runat="server" Style="z-index: 1; left: 39px; top: 710px; position: absolute" Text="Data Type 1 "></asp:Label>

            <asp:Label ID="Label17" runat="server" Style="z-index: 1; left: 39px; top: 750px; position: absolute" Text="Collection Name 2 "></asp:Label>
            <asp:Label ID="Label18" runat="server" Style="z-index: 1; left: 39px; top: 790px; position: absolute" Text="Data Type 2 "></asp:Label>

            <asp:Label ID="Label19" runat="server" Style="z-index: 1; left: 39px; top: 830px; position: absolute" Text="Collection Name 3 "></asp:Label>
            <asp:Label ID="Label20" runat="server" Style="z-index: 1; left: 39px; top: 870px; position: absolute" Text="Data Type 3 "></asp:Label>
            <asp:Label ID="Label21" runat="server" Style="z-index: 1; left: 39px; top: 910px; position: absolute" Text="Collection Name 4 "></asp:Label>
            <asp:Label ID="Label22" runat="server" Style="z-index: 1; left: 39px; top: 950px; position: absolute" Text="Data Type 4 "></asp:Label>

            <asp:Label ID="Label23" runat="server" Style="z-index: 1; left: 39px; top: 990px; position: absolute" Text="Collection Name 5 "></asp:Label>
            <asp:Label ID="Label24" runat="server" Style="z-index: 1; left: 39px; top: 1030px; position: absolute" Text="Data Type 5 "></asp:Label>

            <asp:Label ID="Label25" runat="server" Style="z-index: 1; left: 39px; top: 1070px; position: absolute" Text="Collection Name 6 "></asp:Label>
            <asp:Label ID="Label26" runat="server" Style="z-index: 1; left: 39px; top: 1110px; position: absolute" Text="Data Type 6 "></asp:Label>

            <asp:Label ID="Label27" runat="server" Style="z-index: 1; left: 39px; top: 1150px; position: absolute" Text="Collection Name 7 "></asp:Label>
            <asp:Label ID="Label28" runat="server" Style="z-index: 1; left: 39px; top: 1190px; position: absolute" Text="Data Type 7 "></asp:Label>

            <asp:Label ID="Label29" runat="server" Style="z-index: 1; left: 39px; top: 1230px; position: absolute" Text="Collection Name 8 "></asp:Label>
            <asp:Label ID="Label30" runat="server" Style="z-index: 1; left: 39px; top: 1270px; position: absolute" Text="Data Type 8 "></asp:Label>

            <asp:Label ID="Label31" runat="server" Style="z-index: 1; left: 39px; top: 1310px; position: absolute" Text="Collection Name 9 "></asp:Label>
            <asp:Label ID="Label32" runat="server" Style="z-index: 1; left: 39px; top: 1350px; position: absolute" Text="Data Type 9 "></asp:Label>

            <asp:Label ID="Label33" runat="server" Style="z-index: 1; left: 39px; top: 1390px; position: absolute" Text="Collection Name 10 "></asp:Label>
            <asp:Label ID="Label34" runat="server" Style="z-index: 1; left: 39px; top: 1430px; position: absolute" Text="Data Type 10 "></asp:Label>

            <asp:Label ID="Label39" runat="server" Style="z-index: 1; left: 39px; top: 1470px; position: absolute" Text="Inf "></asp:Label>

            <asp:Label ID="Label35" runat="server" Style="z-index: 1; left: 39px; top: 1510px; position: absolute" Text="Remarks "></asp:Label>

            <asp:DropDownList ID="ddlCC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 70px; width: 168px; height: 25px; position: absolute" DataSourceID="ddlCCSDA" DataTextField="cmp_nm" DataValueField="cmp_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>


            <asp:DropDownList ID="ddlPC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 110px; width: 168px; height: 25px; position: absolute;" DataSourceID="ddlPCSDA" DataTextField="pltn_nm" DataValueField="pltn_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>

            <asp:DropDownList ID="ddlMC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 150px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px" DataSourceID="ddlICSDA" DataTextField="item_nm" DataValueField="item_nm">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>

            <asp:DropDownList ID="ddlLineId" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 190px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px" DataSourceID="ddlLINESDA" DataTextField="line_nm" DataValueField="line_id">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>

            <asp:DropDownList ID="ddlProcId" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 230px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px" DataSourceID="ddlPFIDSDA" DataTextField="proc_flow_id" DataValueField="proc_flow_id">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>



            <asp:TextBox ID="txtSC" ClientIDMode="Static" type="text" runat="server" Style="z-index: 1; left: 267px; top: 270px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>

            <asp:TextBox ID="txtEC" type="text" runat="server" Style="z-index: 1; left: 267px; top: 310px; width: 168px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>

            <asp:TextBox ID="txtTC" runat="server" Style="z-index: 1; left: 267px; top: 350px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtTN" runat="server" Style="z-index: 1; left: 267px; top: 390px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtEG" runat="server" Style="z-index: 1; left: 267px; top: 430px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtTD" runat="server" Style="z-index: 1; left: 267px; top: 470px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtSMi" ClientIDMode="Static" runat="server" Style="z-index: 1; left: 267px; top: 510px; width: 168px; height: 25px; position: absolute"></asp:TextBox>

            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1"
                ControlToValidate="txtSMi" runat="server" Style="z-index: 1; left: 467px; top: 510px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Spec min Only Numbers allowed"
                Display="Dynamic" EnableClientScript="true"
                ValidationExpression="/^\d*\.?\d*$/">
            </asp:RegularExpressionValidator>--%>
            <asp:TextBox ID="txtSMa" runat="server" Style="z-index: 1; left: 267px; top: 550px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2"
                ControlToValidate="txtSMa" runat="server" Style="z-index: 1; left: 467px; top: 550px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Spec max Only Numbers allowed"
                Display="Dynamic"
                EnableClientScript="true"
                ValidationExpression="/^\d*\.?\d*$/">
            </asp:RegularExpressionValidator>--%>
            <asp:TextBox ID="txtUnits" runat="server" Style="z-index: 1; left: 267px; top: 590px; width: 168px; height: 25px; position: absolute"></asp:TextBox>

            <asp:TextBox ID="txtRGF" runat="server" Style="z-index: 1; left: 267px; top: 630px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtCN1" runat="server" Style="z-index: 1; left: 267px; top: 670px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT1" runat="server" Style="z-index: 1; left: 267px; top: 710px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator3"
                ControlToValidate="txtDT1" runat="server" Style="z-index: 1; left: 467px; top: 710px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 1 Only Numbers allowed"
                Display="Dynamic"
                EnableClientScript="true"
                ValidationExpression="\d+">
            </asp:RegularExpressionValidator>
            <asp:TextBox ID="txtCN2" runat="server" Style="z-index: 1; left: 267px; top: 750px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT2" runat="server" Style="z-index: 1; left: 267px; top: 790px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator4"
                ControlToValidate="txtDT2" runat="server" Style="z-index: 1; left: 467px; top: 790px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 2 Only Numbers allowed"
                ValidationExpression="\d+" />
            <asp:TextBox ID="txtCN3" runat="server" Style="z-index: 1; left: 267px; top: 830px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT3" runat="server" Style="z-index: 1; left: 267px; top: 870px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator5"
                ControlToValidate="txtDT3" runat="server" Style="z-index: 1; left: 467px; top: 870px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 3 Only Numbers allowed"
                ValidationExpression="\d+" />
            <asp:TextBox ID="txtCN4" runat="server" Style="z-index: 1; left: 267px; top: 910px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT4" runat="server" Style="z-index: 1; left: 267px; top: 950px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator6"
                ControlToValidate="txtDT4" runat="server" Style="z-index: 1; left: 467px; top: 950px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 4 Only Numbers allowed"
                ValidationExpression="\d+" />
            <asp:TextBox ID="txtCN5" runat="server" Style="z-index: 1; left: 267px; top: 990px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT5" runat="server" ClientIDMode="Static" Style="z-index: 1; left: 267px; top: 1030px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator7"
                ControlToValidate="txtDT5" runat="server" Style="z-index: 1; left: 467px; top: 1030px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 5 Only Numbers allowed"
                ValidationExpression="\d+" />
            <asp:TextBox ID="txtCN6" runat="server" Style="z-index: 1; left: 267px; top: 1070px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT6" runat="server" ClientIDMode="Static" Style="z-index: 1; left: 267px; top: 1110px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator8"
                ControlToValidate="txtDT6" runat="server" Style="z-index: 1; left: 467px; top: 1110px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 6 Only Numbers allowed"
                ValidationExpression="\d+" />
            <asp:TextBox ID="txtCN7" runat="server" Style="z-index: 1; left: 267px; top: 1150px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT7" runat="server" ClientIDMode="Static" Style="z-index: 1; left: 267px; top: 1190px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator9"
                ControlToValidate="txtDT7" runat="server" Style="z-index: 1; left: 467px; top: 1190px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 7 Only Numbers allowed"
                ValidationExpression="\d+" />
            <asp:TextBox ID="txtCN8" runat="server" Style="z-index: 1; left: 267px; top: 1230px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT8" runat="server" ClientIDMode="Static" Style="z-index: 1; left: 267px; top: 1270px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator10"
                ControlToValidate="txtDT8" runat="server" Style="z-index: 1; left: 467px; top: 1270px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 8 Only Numbers allowed"
                ValidationExpression="\d+" />
            <asp:TextBox ID="txtCN9" runat="server" Style="z-index: 1; left: 267px; top: 1310px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT9" runat="server" ClientIDMode="Static" Style="z-index: 1; left: 267px; top: 1350px; width: 168px; height: 25px; position: absolute"></asp:TextBox>

            <asp:RegularExpressionValidator ID="RegularExpressionValidator11"
                ControlToValidate="txtDT9" runat="server" Style="z-index: 1; left: 467px; top: 1350px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 9 Only Numbers allowed"
                ValidationExpression="\d+" />
            <asp:TextBox ID="txtCN10" runat="server" Style="z-index: 1; left: 267px; top: 1390px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtDT10" ClientIDMode="Static" runat="server" Style="z-index: 1; left: 267px; top: 1430px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator12"
                ControlToValidate="txtDT10" runat="server" Style="z-index: 1; left: 467px; top: 1430px; width: 168px; height: 25px; position: absolute;color:red;"
                ErrorMessage="Data Type 10 Only Numbers allowed"
                ValidationExpression="\d+" />
            <asp:CheckBox ID="chkInf" ClientIDMode="Static" runat="server" Style="z-index: 1; left: 267px; top: 1470px; width: 168px; height: 25px; position: absolute" />
            <asp:TextBox ID="txtRe" ClientIDMode="Static" runat="server" Style="z-index: 1; left: 267px; top: 1510px; width: 168px; height: 25px; position: absolute"></asp:TextBox>

            <asp:ValidationSummary ID="valSummary" ShowSummary="false"  runat="server" DisplayMode="BulletList" ShowMessageBox="true" />
            <asp:Button ID="btnSave"   runat="server" Style="z-index: 1; left: 36px; top: 1550px; width: 99px; height: 30px; position: absolute; font-size: medium; font-weight: 600;" Text="Save" CssClass="button1" />
            <asp:Button ID="btnDelete" runat="server" Style="z-index: 1; left: 250px; top: 1550px; position: absolute; font-size: medium; font-weight: 600;" Text="Delete" Height="30px" Width="99px" CssClass="button1" />
            <asp:Button ID="btnCancel" CausesValidation="False" runat="server" Style="z-index: 1; left: 450px; top: 1550px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
            <asp:ImageButton ID="ImageButton1" CausesValidation="False" runat="server" Height="30px" ImageUrl="~/Images/icon_del_canc_reject.png" Style="z-index: 1; left: 559px; top: 29px; position: absolute" Width="30px" />
        </div>
        <asp:SqlDataSource ID="ddlCCSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [cmp_nm],[cmp_cd], [REGR_ID] FROM [MAST_COMPANYCODE] WHERE CNCL_FLG = 0 ORDER BY [cmp_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlPCSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [pltn_nm],[pltn_cd], [REGR_ID] FROM [MAST_PLANTCODE] WHERE CNCL_FLG = 0 ORDER BY [pltn_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlLINESDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [lproc_id],[line_id], [line_nm] FROM [MAST_LINE] WHERE CNCL_FLG = 0 ORDER BY [line_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlICSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT item_nm FROM [MAST_ITEM] WHERE CNCL_FLG = 0 ORDER BY [item_nm]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="ddlPFIDSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT [proc_flow_id] from MAST_PROC3 WHERE CNCL_FLG = 0"></asp:SqlDataSource>

    </form>

</body>
<script type="text/javascript">
    function HideValidationSummary(summaryControl) {
        console.log("HideValidationSummary")
        document.getElementById(summaryControl).style.display = 'none';
    }
</script>
</html>


