<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserAdmin.aspx.vb" Inherits="MESLotTrace.UserAdmin" %>

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
                <asp:Label ID="frmtitle" runat="server" Style="z-index: 1;" Text="USER ADMINISTRATION" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
            </div>
            <div id="formbody" runat="server" style="z-index: 1; position: absolute; top: 140px; left: 1px; width: 100%; height: 550px; border: 1px black solid;">
                <asp:Label ID="Label1" runat="server" Text="Defined Data" Style="z-index: 1; position: absolute; top: 5px; left: 1px;" Font-Bold="True" Font-Size="X-Large" ForeColor="Blue"></asp:Label>
                <asp:Button ID="btnNew" runat="server" Style="z-index: 1; position: absolute; top: 2px; left: 200px; font-size: large;" Text="Create New" CssClass="button1" />
                <div id="formcontent" runat="server" style="z-index: 1; position: absolute; width: 99%; height: 491px; border: 1px black solid; top: 55px; left: 4px;">
                    <asp:HiddenField ID="hfNewFlg" runat="server" />
                    <asp:GridView ID="gvContent" runat="server"
                        Font-Size="Large"
                        ShowFooter="True"
                        EmptyDataText="No Data Defined" ShowHeaderWhenEmpty="True" AutoGenerateColumns="False" DataSourceID="MastCompanyCodeSDA" Width="100%">
                        <Columns>
                            <asp:ButtonField CommandName="Edit" Text="Edit">
                            <ItemStyle Font-Names="Arial Rounded MT Bold" ForeColor="#99CCFF" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="Employee No" HeaderText="Employee No" SortExpression="Employee No">
                            <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                            <ItemStyle Width="50%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role">
                            <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status">
                            <ItemStyle Width="5%" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Label Printer" HeaderText="Label Printer" SortExpression="Label Printer">
                            <ItemStyle Width="20%" />
                            </asp:BoundField>
                            <asp:ButtonField CommandName="Access" Text="Access">
                            <ItemStyle Font-Names="Arial Rounded MT Bold" ForeColor="#FF99CC" />
                            </asp:ButtonField>
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
            style="z-index: 9999; position: absolute; top:50%; left: 50%; transform: translate(-50%,-50%); width: 599px; height: 399px; border: 1px solid black; background-color: azure;">
            <asp:Label ID="Label3" runat="server" Text="USER Administration" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 7px; position: absolute; vertical-align:middle; width: 582px; text-align: center; height: 33px;" Font-Size="24px" BackColor="#6699FF"></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 35px; top: 70px; position: absolute; width: auto;"
                Text="Employee No."></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute; width: auto;"
                Text="Employee Name"></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 34px; top: 150px; position: absolute; width: auto;"
                Text="Password"></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 34px; top: 187px; position: absolute; width: auto;"
                Text="User role"></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 1; left: 34px; top: 228px; position: absolute; width: auto;"
                Text="User Status"></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 1; left: 34px; top: 268px; position: absolute; width: auto;"
                Text="Assigned Printer"></asp:Label>


            <asp:TextBox ID="txtEmpno" runat="server" Style="z-index: 1; left: 218px; top: 69px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtEmpNm" runat="server" Style="z-index: 1; left: 218px; top: 109px; position: absolute; width: 318px"></asp:TextBox>
            <asp:TextBox ID="txtPwd" runat="server" Style="z-index: 1; left: 218px; top: 149px; position: absolute"></asp:TextBox>


            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 33px; top: 344px; width: 99px; height: 30px; position: absolute" Text="Save" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 460px; top: 344px; position: absolute" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />

            <asp:DropDownList ID="DropDownList1" runat="server" style="z-index: 1; left: 218px; top: 186px; position: absolute; width: 164px">
                <asp:ListItem Value="99">Admin</asp:ListItem>
                <asp:ListItem Value="1">Engineer</asp:ListItem>
                <asp:ListItem Value="2">Operation</asp:ListItem>
            </asp:DropDownList>
            <asp:DropDownList ID="DropDownList2" runat="server" style="z-index: 1; left: 218px; top: 227px; position: absolute; width: 150px">
                <asp:ListItem Value="9">Active</asp:ListItem>
                <asp:ListItem Value="-1">Disabled</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtAssignedIP" runat="server" style="z-index: 1; left: 218px; top: 267px; position: absolute; width: 240px"></asp:TextBox>

        </div>
            <div id="AccessDataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top:20%; left: 20%; transform: translate(-5%,-20%);  width: 1262px; height: 694px; border: 1px solid black; background-color: azure;">
            <asp:Label ID="Label2" runat="server" Text="USER Access Rights" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 7px; position: absolute; vertical-align: middle; width: 1245px; text-align: center; height: 33px;" Font-Size="24px" BackColor="#6699FF"></asp:Label>
            <asp:Label ID="Label10" runat="server" Style="z-index: 1; left: 35px; top: 70px; position: absolute; width: auto;"
                Text="Employee No."></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute; width: auto;"
                Text="Employee Name"></asp:Label>


            <asp:TextBox ID="txtEmpNoAcc" runat="server" Style="z-index: 1; left: 218px; top: 69px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtEmpNameAcc" runat="server" Style="z-index: 1; left: 218px; top: 109px; position: absolute; width: 318px"></asp:TextBox>


            <asp:Button ID="btnSaveAccess" runat="server" Style="z-index: 1; left: 261px; top: 646px; width: 99px; height: 30px; position: absolute" Text="Save" CssClass="button1" />
            <asp:Button ID="Button2" runat="server" Style="z-index: 1; left: 740px; top: 642px; position: absolute" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />

          
            <asp:CheckBox ID="cb1" runat="server" Style="z-index: 1; left: 34px; top: 170px; position: absolute; right: 1084px;" Text="Administration" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="cb11" runat="server" Style="z-index: 1; left: 51px; top: 200px; position: absolute" Text="User Administration" data-key="User_Administration" />
            <asp:CheckBox ID="cb12" runat="server" Style="z-index: 1; left: 51px; top: 230px; position: absolute" Text="Access Control" data-key="Access_Control" />
      
            <asp:CheckBox ID="cb2" runat="server" Style="z-index: 1; left: 252px; top: 170px; position: absolute; right: 815px;" Text="Master Maintenance" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="cb21" runat="server" Style="z-index: 1; left: 272px; top: 200px; position: absolute" Text="Line State" data-key="Maintenance_Line_State"  />
            <asp:CheckBox ID="cb22" runat="server" Style="z-index: 1; left: 272px; top: 230px; position: absolute" Text="Standard UOM" data-key="Standard_UOM"  />
            <asp:CheckBox ID="cb23" runat="server" Style="z-index: 1; left: 272px; top: 260px; position: absolute" Text="Shift" data-key="Shift" />
            <asp:CheckBox ID="cb24" runat="server" Style="z-index: 1; left: 272px; top: 290px; position: absolute" Text="Prod. Capa. By shift" data-key="Prod_Capa_shift" />
            <asp:CheckBox ID="cb25" runat="server" Style="z-index: 1; left: 272px; top: 320px; position: absolute" Text="Line" data-key="Line"/>
            <asp:CheckBox ID="cb26" runat="server" Style="z-index: 1; left: 272px; top: 350px; position: absolute" Text="Process" data-key="Process" />
            <asp:CheckBox ID="cb27" runat="server" Style="z-index: 1; left: 272px; top: 380px; position: absolute" Text="Company Code" data-key="Company_Code" />
            <asp:CheckBox ID="cb28" runat="server" Style="z-index: 1; left: 272px; top: 410px; position: absolute" Text="Equipment" data-key="Equipment" />
            <asp:CheckBox ID="cb29" runat="server" Style="z-index: 1; left: 272px; top: 440px; position: absolute" Text="Step & Equipment " data-key="Step_Equipment" />
            <asp:CheckBox ID="cb30" runat="server" Style="z-index: 1; left: 272px; top: 470px; position: absolute" Text="Trace Master" data-key="Trace_Master" />
            <asp:CheckBox ID="cb31" runat="server" Style="z-index: 1; left: 272px; top: 501px; position: absolute" Text="Comp. Cons. by Step" data-key="Comp_Cons_Step" />
            <asp:CheckBox ID="cb32" runat="server" Style="z-index: 1; left: 272px; top: 530px; position: absolute" Text="Reason Master" data-key="Reason_Master"/>
            <asp:CheckBox ID="cb33" runat="server" Style="z-index: 1; left: 272px; top: 560px; position: absolute" Text="Worker Registration" data-key="Worker_Registration" />
            <asp:CheckBox ID="cb34" runat="server" Style="z-index: 1; left: 272px; top: 590px; position: absolute" Text="Plant Code" data-key="Plant_Code"/>


            <asp:CheckBox ID="cb4" runat="server" Style="z-index: 1; left: 452px; top: 170px; position: absolute" Text="Operations" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="cb41" runat="server" Style="z-index: 1; left: 470px; top: 200px; position: absolute" Text="Lot Management" data-key="Lot_Management"/>
            <asp:CheckBox ID="cb42" runat="server" Style="z-index: 1; left: 470px; top: 230px; position: absolute" Text="Rework" data-key="Rework" />
            <asp:CheckBox ID="cb43" runat="server" Style="z-index: 1; left: 470px; top: 260px; position: absolute" Text="Scrap Item" data-key="Scrap_Item" />
            <asp:CheckBox ID="cb44" runat="server" Style="z-index: 1; left: 470px; top: 290px; position: absolute" Text="Print Tag" data-key="Print_Tag"/>
            <asp:CheckBox ID="cb45" runat="server" Style="z-index: 1; left: 470px; top: 320px; position: absolute" Text="PLC Data Amend" data-key="PLC_Data_Amend" />



            <asp:CheckBox ID="cb5" runat="server" Style="z-index: 1; left: 632px; top: 170px; position: absolute" Text="Reporting" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="cb51" runat="server" Style="z-index: 1; left: 651px; top: 200px; position: absolute" Text="Line State" data-key="Reporting_Line_State" />
            <asp:CheckBox ID="cb52" runat="server" Style="z-index: 1; left: 651px; top: 230px; position: absolute" Text="SNo. Current"  data-key="SNO_Current" />
            <asp:CheckBox ID="cb53" runat="server" Style="z-index: 1; left: 651px; top: 260px; position: absolute" Text="SNo. History"  data-key="SNO_History"/>
            <asp:CheckBox ID="cb54" runat="server" Style="z-index: 1; left: 651px; top: 290px; position: absolute" Text="SNo. Skip &amp; NG" data-key="Skip_NG" />
            <asp:CheckBox ID="cb55" runat="server" Style="z-index: 1; left: 651px; top: 320px; position: absolute" Text="Parts Consumption"  data-key="Parts_Consumption" />
            <asp:CheckBox ID="cb56" runat="server" Style="z-index: 1; left: 651px; top: 350px; position: absolute" Text="Lot Traceability"  data-key="Lot_Traceability"/>
            <asp:CheckBox ID="cb57" runat="server" Style="z-index: 1; left: 651px; top: 380px; position: absolute" Text="Motor docking Comp." data-key="Motor_docking_Comp" />
            <asp:CheckBox ID="cb58" runat="server" Style="z-index: 1; left: 651px; top: 410px; position: absolute" Text="Part Balance" data-key="Part_Balance" />
            <asp:CheckBox ID="cb59" runat="server" Style="z-index: 1; left: 651px; top: 440px; position: absolute" Text="Worker Log Information" data-key="Worker_Log_Information" />
            <asp:CheckBox ID="cb510" runat="server" Style="z-index: 1; left: 651px; top: 470px; position: absolute" Text="Manu. Lot Info History."  data-key="Manu_Lot_Info_History"/>
            <asp:CheckBox ID="cb511" runat="server" Style="z-index: 1; left: 651px; top: 500px; position: absolute" Text="Parts Scrap Information" data-key="Parts_Scrap_History" />

            <asp:CheckBox ID="cb6" runat="server" Style="z-index: 1; left: 823px; top: 170px; position: absolute" Text="Import from SAP" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="cb61" runat="server" Style="z-index: 1; left: 841px; top: 200px; position: absolute" Text="Material Master" data-key="Material_Master"  />
            <asp:CheckBox ID="cb62" runat="server" Style="z-index: 1; left: 841px; top: 230px; position: absolute" Text="Production Order" data-key="Production_Order" />
            <asp:CheckBox ID="cb63" runat="server" Style="z-index: 1; left: 841px; top: 260px; position: absolute" Text="Prod. Order Comp." data-key="Prod_Order_Comp" />
            <asp:CheckBox ID="cb64" runat="server" Style="z-index: 1; left: 841px; top: 290px; position: absolute" Text="Vendor UOM" data-key="Vendor_UOM"/>

            <asp:CheckBox ID="cb7" runat="server" Style="z-index: 1; left: 1015px; top: 170px; position: absolute" Text="Export to SAP" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="cb71" runat="server" Style="z-index: 1; left: 1034px; top: 200px; position: absolute" Text="Work Result" data-key="Work_Result" />
            <asp:CheckBox ID="cb72" runat="server" Style="z-index: 1; left: 1034px; top: 230px; position: absolute" Text="Parts Consumed" data-key="Parts_Consumed" />
            <asp:CheckBox ID="cb73" runat="server" Style="z-index: 1; left: 1034px; top: 260px; position: absolute" Text="Scrap Informationt" data-key="Scrap_Informationt" />
                
        </div>
        </div>
        <asp:SqlDataSource ID="MastCompanyCodeSDA" runat="server" ConnectionString="<%$ ConnectionStrings:MESLotTraceConnectionString %>" SelectCommand="SELECT a.EmpNo as [Employee No], a.username as [Name], b.roledesc as Role , c.UserStatusDesc as Status, 
case when a.PRINTIP is NULL OR a.printip ='' THEN 'Not Defined'
else a.printip
end as [Label Printer]
FROM [UserMaster] a
left join UserRole b on a.userrole = b.roleid
left join Userstatus c on a.UserStatus = c.UserStatus"></asp:SqlDataSource>
    </form>
</body>
</html>
