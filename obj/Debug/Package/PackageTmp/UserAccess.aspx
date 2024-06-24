<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="UserAccess.aspx.vb" Inherits="MESLotTrace.UserAccess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">

        <div id="AccessDataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 5%; left: 3%; transform: translate(-50%,-50%); width: 1262px; height: 694px; border: 1px solid black; background-color: azure;">
            <asp:Label ID="Label3" runat="server" Text="USER Access Rights" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 7px; position: absolute; vertical-align: middle; width: 1245px; text-align: center; height: 33px;" Font-Size="24px" BackColor="#6699FF"></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 35px; top: 70px; position: absolute; width: auto;"
                Text="Employee No."></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 110px; position: absolute; width: auto;"
                Text="Employee Name"></asp:Label>


            <asp:TextBox ID="txtEmpno" runat="server" Style="z-index: 1; left: 218px; top: 69px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtEmpNm" runat="server" Style="z-index: 1; left: 218px; top: 109px; position: absolute; width: 318px"></asp:TextBox>


            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 261px; top: 646px; width: 99px; height: 30px; position: absolute" Text="Save" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 740px; top: 642px; position: absolute" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />

          
            <asp:CheckBox ID="CheckBox43" runat="server" Style="z-index: 1; left: 34px; top: 170px; position: absolute; right: 1084px;" Text="Administration" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="CheckBox44" runat="server" Style="z-index: 1; left: 51px; top: 200px; position: absolute" Text="User Administration" />
            <asp:CheckBox ID="CheckBox45" runat="server" Style="z-index: 1; left: 51px; top: 230px; position: absolute" Text="Access Control" />
      
            <asp:CheckBox ID="CheckBox28" runat="server" Style="z-index: 1; left: 252px; top: 170px; position: absolute" Text="Master Maintenance" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="CheckBox29" runat="server" Style="z-index: 1; left: 272px; top: 200px; position: absolute" Text="Line State" />
            <asp:CheckBox ID="CheckBox30" runat="server" Style="z-index: 1; left: 272px; top: 230px; position: absolute" Text="Standard UOM" />
            <asp:CheckBox ID="CheckBox31" runat="server" Style="z-index: 1; left: 272px; top: 260px; position: absolute" Text="Shift" />
            <asp:CheckBox ID="CheckBox32" runat="server" Style="z-index: 1; left: 272px; top: 290px; position: absolute" Text="Prod. Capa. By shift" />
            <asp:CheckBox ID="CheckBox33" runat="server" Style="z-index: 1; left: 272px; top: 320px; position: absolute" Text="Line" />
            <asp:CheckBox ID="CheckBox34" runat="server" Style="z-index: 1; left: 272px; top: 350px; position: absolute" Text="Process" />
            <asp:CheckBox ID="CheckBox35" runat="server" Style="z-index: 1; left: 272px; top: 380px; position: absolute" Text="Company Code" />
            <asp:CheckBox ID="CheckBox36" runat="server" Style="z-index: 1; left: 272px; top: 410px; position: absolute" Text="Equipment" />
            <asp:CheckBox ID="CheckBox37" runat="server" Style="z-index: 1; left: 272px; top: 440px; position: absolute" Text="Step & Equipment " />
            <asp:CheckBox ID="CheckBox38" runat="server" Style="z-index: 1; left: 272px; top: 470px; position: absolute" Text="Trace Master" />
            <asp:CheckBox ID="CheckBox39" runat="server" Style="z-index: 1; left: 272px; top: 501px; position: absolute" Text="Comp. Cons. by Step" />
            <asp:CheckBox ID="CheckBox40" runat="server" Style="z-index: 1; left: 272px; top: 530px; position: absolute" Text="Reason Master" />
            <asp:CheckBox ID="CheckBox41" runat="server" Style="z-index: 1; left: 272px; top: 560px; position: absolute" Text="Worker Registration" />
            <asp:CheckBox ID="CheckBox42" runat="server" Style="z-index: 1; left: 272px; top: 590px; position: absolute" Text="Plant Code" />


            <asp:CheckBox ID="CheckBox22" runat="server" Style="z-index: 1; left: 452px; top: 170px; position: absolute" Text="Operations" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="CheckBox23" runat="server" Style="z-index: 1; left: 470px; top: 200px; position: absolute" Text="Lot Management" />
            <asp:CheckBox ID="CheckBox24" runat="server" Style="z-index: 1; left: 470px; top: 230px; position: absolute" Text="Rework" />
            <asp:CheckBox ID="CheckBox25" runat="server" Style="z-index: 1; left: 470px; top: 260px; position: absolute" Text="Scrap Item" />
            <asp:CheckBox ID="CheckBox26" runat="server" Style="z-index: 1; left: 470px; top: 290px; position: absolute" Text="Print Tag" />
            <asp:CheckBox ID="CheckBox27" runat="server" Style="z-index: 1; left: 470px; top: 320px; position: absolute" Text="PLC Data Amend" />



            <asp:CheckBox ID="CheckBox10" runat="server" Style="z-index: 1; left: 632px; top: 170px; position: absolute" Text="Reporting" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="CheckBox11" runat="server" Style="z-index: 1; left: 651px; top: 200px; position: absolute" Text="Line State" />
            <asp:CheckBox ID="CheckBox12" runat="server" Style="z-index: 1; left: 651px; top: 230px; position: absolute" Text="SNo. Current" />
            <asp:CheckBox ID="CheckBox13" runat="server" Style="z-index: 1; left: 651px; top: 260px; position: absolute" Text="SNo. History" />
            <asp:CheckBox ID="CheckBox14" runat="server" Style="z-index: 1; left: 651px; top: 290px; position: absolute" Text="SNo. Skip &amp; NG" />
            <asp:CheckBox ID="CheckBox15" runat="server" Style="z-index: 1; left: 651px; top: 320px; position: absolute" Text="Parts Consumption" />
            <asp:CheckBox ID="CheckBox16" runat="server" Style="z-index: 1; left: 651px; top: 350px; position: absolute" Text="Lot Traceability" />
            <asp:CheckBox ID="CheckBox17" runat="server" Style="z-index: 1; left: 651px; top: 380px; position: absolute" Text="Motor docking Comp." />
            <asp:CheckBox ID="CheckBox18" runat="server" Style="z-index: 1; left: 651px; top: 410px; position: absolute" Text="Part Balance" />
            <asp:CheckBox ID="CheckBox19" runat="server" Style="z-index: 1; left: 651px; top: 440px; position: absolute" Text="Worker Log Information" />
            <asp:CheckBox ID="CheckBox20" runat="server" Style="z-index: 1; left: 651px; top: 470px; position: absolute" Text="Manu. Lot Info History." />
            <asp:CheckBox ID="CheckBox21" runat="server" Style="z-index: 1; left: 651px; top: 500px; position: absolute" Text="Parts Scrap Information" />

            <asp:CheckBox ID="CheckBox5" runat="server" Style="z-index: 1; left: 823px; top: 170px; position: absolute" Text="Import from SAP" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="CheckBox6" runat="server" Style="z-index: 1; left: 841px; top: 200px; position: absolute" Text="Material Master" />
            <asp:CheckBox ID="CheckBox7" runat="server" Style="z-index: 1; left: 841px; top: 230px; position: absolute" Text="Production Order" />
            <asp:CheckBox ID="CheckBox8" runat="server" Style="z-index: 1; left: 841px; top: 260px; position: absolute" Text="Prod. Order Comp." />
            <asp:CheckBox ID="CheckBox9" runat="server" Style="z-index: 1; left: 841px; top: 290px; position: absolute" Text="Vendor UOM" />

            <asp:CheckBox ID="CheckBox4" runat="server" Style="z-index: 1; left: 1015px; top: 170px; position: absolute" Text="Export to SAP" Font-Bold="True" Font-Size="12pt" />
            <asp:CheckBox ID="CheckBox1" runat="server" Style="z-index: 1; left: 1034px; top: 200px; position: absolute" Text="Work Result" />
            <asp:CheckBox ID="CheckBox2" runat="server" Style="z-index: 1; left: 1034px; top: 230px; position: absolute" Text="Parts Consumed" />
            <asp:CheckBox ID="CheckBox3" runat="server" Style="z-index: 1; left: 1034px; top: 260px; position: absolute" Text="Scrap Informationt" />
        </div>

    </form>
</body>
</html>
