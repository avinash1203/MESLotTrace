<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="LineMasterDE.aspx.vb" Inherits="MESLotTrace.LineMasterDE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="DataEntryScr" runat="server"
            style="z-index: 9999; position: absolute; top: 15%; left: 39%;  width: 599px; height: 600px; border: 1px solid black; background-color: azure;">
            <asp:HiddenField ID="hfPopUpType" Value="" runat="server" />

            <asp:Label ID="Label3" runat="server" Text="Line Information Data Entry" Font-Bold="True"
                Style="z-index: 1; left: 10px; top: 14px; position: absolute; width: 582px; text-align: center"></asp:Label>
            <asp:Label ID="Label4" runat="server" Style="z-index: 1; left: 34px; top: 66px; position: absolute" Text="Company Code "></asp:Label>
            <asp:Label ID="Label5" runat="server" Style="z-index: 1; left: 34px; top: 101px; position: absolute" Text="Plant Code "></asp:Label>
            <asp:Label ID="Label8" runat="server" Style="z-index: 1; left: 34px; top: 139px; position: absolute" Text="Line ID  "></asp:Label>
            <asp:Label ID="Label9" runat="server" Style="z-index: 1; left: 34px; top: 174px; position: absolute" Text="Line Description "></asp:Label>
            <asp:Label ID="Label6" runat="server" Style="z-index: 1; left: 34px; top: 209px; position: absolute" Text="Line Process ID"></asp:Label>
            <asp:Label ID="Label7" runat="server" Style="z-index: 1; left: 34px; top: 244px; position: absolute" Text="Line Name Local"></asp:Label>
            <asp:Label ID="Label10" runat="server" Style="z-index: 1; left: 34px; top: 279px; position: absolute" Text="Notes "></asp:Label>
            <asp:Label ID="Label11" runat="server" Style="z-index: 1; left: 34px; top: 311px; position: absolute" Text="Shift ID "></asp:Label>
            <asp:Label ID="Label2" runat="server" Style="z-index: 1; left: 34px; top: 349px; position: absolute" Text="Cost center "></asp:Label>
            <asp:Label ID="Label12" runat="server" Style="z-index: 1; left: 34px; top: 384px; position: absolute" Text="Storage Location "></asp:Label>
            <asp:DropDownList ID="ddlCC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 65px; width: 168px; height: 25px; position: absolute" DataSourceID="ddlCCSDA" DataTextField="cmp_nm" DataValueField="cmp_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>
            <asp:DropDownList ID="ddlPC" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 100px; width: 168px; height: 25px; position: absolute;" DataSourceID="ddlPCSDA" DataTextField="pltn_nm" DataValueField="pltn_cd">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>
            <asp:TextBox ID="txtLID" runat="server" Style="z-index: 1; left: 267px; top: 135px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>
            <asp:TextBox ID="txtLD" runat="server" Style="z-index: 1; left: 267px; top: 170px; width: 100px; height: 25px; position: absolute; width: 168px" Height="25px"></asp:TextBox>
            <asp:TextBox ID="txtLprocId" runat="server" Style="z-index: 1; left: 267px; top: 205px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtLNL" runat="server" Style="z-index: 1; left: 267px; top: 240px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtNotes" runat="server" Style="z-index: 1; left: 267px; top: 275px; width: 274px; height: 25px; position: absolute"></asp:TextBox>
            <asp:DropDownList ID="ddlShift" runat="server" AppendDataBoundItems="True" Style="z-index: 1; left: 267px; top: 310px; width: 168px; height: 25px; position: absolute;" DataSourceID="ddlShiftSDA" DataTextField="shift_ptrn_id" DataValueField="shift_ptrn_id">
                <asp:ListItem Text="-- Select Option --" Value="" />
            </asp:DropDownList>
            <asp:TextBox ID="txtCostCenter" runat="server" Style="z-index: 1; left: 267px; top: 345px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:TextBox ID="txtSL" runat="server" Style="z-index: 1; left: 267px; top: 380px; width: 168px; height: 25px; position: absolute"></asp:TextBox>
            <asp:Button ID="btnSave" runat="server" Style="z-index: 1; left: 39px; top: 459px; width: 99px; height: 30px; position: absolute; font-size: medium; font-weight: 600; right: 461px;" Text="Save" CssClass="button1" />
            <asp:Button ID="btnDelete" runat="server" Style="z-index: 1; left: 239px; top: 459px; position: absolute; font-size: medium; font-weight: 600;" Text="Delete" Height="30px" Width="99px" CssClass="button1" />
            <asp:Button ID="btnCancel" runat="server" Style="z-index: 1; left: 448px; top: 459px; position: absolute; font-size: medium; font-weight: 600;" Text="Cancel" Height="30px" Width="99px" CssClass="button1" />
            <asp:ImageButton ID="ImageButton1" runat="server" Height="30px" ImageUrl="~/Images/icon_del_canc_reject.png" Style="z-index: 1; left: 559px; top: 29px; position: absolute" Width="30px" />
        </div>
    </form>
</body>
</html>
