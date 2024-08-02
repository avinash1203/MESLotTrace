<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="SuspendLot.aspx.vb" Inherits="MESLotTrace.SuspendLot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
                   <div id="SuspendLotList" runat="server" style="z-index:1;position:absolute;border:1px black solid;width:1033px; height:400px; top: 95px; left: 316px;">

                       <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" style="z-index: 1; left: 272px; top: 27px; position: absolute" Text="List of Active Manufacturing Lots"></asp:Label>
                       <asp:GridView ID="gvMlot" runat="server" AutoGenerateColumns="False" style="z-index: 1; left: 24px; top: 144px; position: absolute; height: 215px; width: 994px" EmptyDataText="No Data Found" ShowHeaderWhenEmpty="True">
                           <Columns>
                               <asp:BoundField DataField="manu_lot_no" HeaderText="Manu. Lot No" />
                               <asp:BoundField DataField="item_cd" HeaderText="Item Code" />
                               <asp:BoundField DataField="proc_flow_id" HeaderText="Process Flow ID" />
                           </Columns>
                           <EmptyDataRowStyle Height="10px" />
                           <HeaderStyle Height="10px" />
                           <RowStyle Height="10px" />
                       </asp:GridView>
                       <asp:Label ID="Label2" runat="server" style="z-index: 1; left: 26px; top: 97px; position: absolute" Text="Process Flow ID"></asp:Label>
                       <asp:DropDownList ID="ddlProcID" runat="server" DataMember="proc_flow_id" Font-Size="Large" style="z-index: 1; left: 221px; top: 92px; position: absolute; width: 299px; right: 513px" AutoPostBack="True">
                       </asp:DropDownList>

                </div>
        <asp:HiddenField ID="hfProcID" runat="server" />
    </form>
</body>
</html>
