<%@ Page Language="vb"  AutoEventWireup="false" CodeBehind="ScanByProcess.aspx.vb" Inherits="MESLotTrace.ScanByProcess" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MAMM MES Scanner</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link href="Scripts/dndod-popup.min.css" rel="stylesheet" />
    <script src="Scripts/dndod-popup.min.js"></script>
    <script type="text/javascript">
      <%--  function handleKeyPress(event) {
            if (event.keyCode === 112) { // F1 key code is 112
                __doPostBack('<%= btnF1.ClientID %>', '');
                return false; // Prevent default browser behavior for F1 key
            }
        }--%>

        document.addEventListener('keydown', function (event) {
            if (event.key === "F1") {
                event.preventDefault(); // Prevent the default browser help
                __doPostBack('F1KeyPressed', ''); // Trigger a postback
            }
        });


    </script>
</head>
<body>
    <form id="form1" runat="server" style="z-index: 1; width: 400px; height: 600px">
        <div id="main" style="z-index: 1; width: 400px; height: 576px; background-color: #66CCFF;">
            <asp:Label ID="Label11" runat="server" Text="Scan Tag By Process"
                Style="z-index: 1; left: 12px; top: 17px; position: absolute; text-align: center; border: 2px solid blue; padding: 1px 1px 1px 1px; width: 365px; height: 24px" Font-Bold="True"></asp:Label>

            <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium"
                Style="z-index: 1; left: 22px; top: 54px; position: absolute;" Text="Operator ID"></asp:Label>
            <asp:TextBox ID="txtOprID" runat="server" Font-Size="Medium" Style="z-index: 1; left: 22px; top: 80px; position: absolute; width: 348px; height: 21px;"></asp:TextBox>


            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium"
                Style="z-index: 1; left: 22px; top: 112px; position: absolute;" Text="Line ID"></asp:Label>
            <asp:TextBox ID="txtLineID" runat="server" Font-Size="Medium"
                Style="z-index: 1; left: 22px; top: 140px; position: absolute; width: 348px; height: 21px;"></asp:TextBox>

            <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium"
                Style="z-index: 1; left: 22px; top: 174px; position: absolute; width: 121px;" Text="Process Code"></asp:Label>
            <asp:TextBox ID="txtProcCd" runat="server" Font-Size="Medium"
                Style="z-index: 1; left: 22px; top: 200px; position: absolute; width: 348px; height: 21px;"></asp:TextBox>


            <asp:Label ID="Label4" runat="server" Font-Bold="True" Font-Size="Medium"
                Style="z-index: 1; left: 22px; top: 234px; position: absolute; width: 121px;" Text="Step Code"></asp:Label>
            <asp:TextBox ID="txtStepCd" runat="server" Font-Size="Medium"
                Style="z-index: 1; left: 23px; top: 260px; position: absolute; width: 348px; height: 21px;"></asp:TextBox>

            <asp:Label ID="Label5" runat="server" Text="Shift" Font-Bold="True"
                Style="z-index: 1; left: 22px; top: 292px; position: absolute; width: 102px; height: 23px;"></asp:Label>
            <asp:TextBox ID="txtShiftcd" runat="server" Font-Size="Medium"
                Style="z-index: 1; left: 22px; top: 320px; position: absolute; width: 154px; height: 21px; bottom: 429px;"></asp:TextBox>

            <asp:Label ID="Label6" runat="server" Text="Status" Font-Bold="True"
                Style="z-index: 1; left: 216px; top: 292px; position: absolute; width: 90px; height: 23px;"></asp:Label>
            <asp:TextBox ID="txtStatus" runat="server" Font-Size="Medium"
                Style="z-index: 1; left: 216px; top: 320px; position: absolute; width: 154px; height: 21px;"></asp:TextBox>


            <asp:Label ID="Label7" runat="server" Text="Manufacturing Lot No." Font-Bold="True"
                Style="z-index: 1; left: 22px; top: 352px; position: absolute; width: 341px; height: 23px;"></asp:Label>
            <asp:TextBox ID="txtManuLotNo" runat="server" Font-Size="Medium"
                Style="z-index: 1; left: 22px; top: 380px; position: absolute; width: 334px; height: 21px;"></asp:TextBox>


            <asp:Label ID="Label8" runat="server" Text="Input Time" Font-Bold="True"
                Style="z-index: 1; left: 22px; top: 412px; position: absolute; width: 157px"></asp:Label>
            <asp:TextBox ID="txtInTime" runat="server" Font-Size="Medium"
                Style="z-index: 1; left: 22px; top: 440px; position: absolute; width: 334px; height: 21px;"></asp:TextBox>

            <asp:Button ID="btnF1" runat="server" Style="display: none;" OnClick="btnF1_Click" />
            <asp:Button ID="btnF1a" runat="server" Font-Underline="True" Style="z-index: 1; border-radius: 10px; left: 19px; top: 526px; position: absolute; height: 56px; width: 59px" Text="F1 Reg" Font-Size="Small" />
            <asp:Button ID="btnF2" runat="server" Font-Underline="True" Style="z-index: 1; border-radius: 10px; left: 109px; top: 526px; position: absolute; height: 56px; width: 59px" Text="F2" BackColor="#CCCCCC" />
            <asp:Button ID="btnF3" runat="server" Font-Underline="True" Style="z-index: 1; border-radius: 10px; left: 207px; top: 526px; position: absolute; height: 56px; width: 59px" Text="F3" BackColor="#CCCCCC" />
            <asp:Button ID="btnF4" runat="server" Font-Underline="True" Style="z-index: 1; border-radius: 10px; left: 302px; top: 526px; position: absolute; height: 56px; width: 59px" Text="F4 Back" BackColor="#CCCCCC" />
        </div>

    </form>
</body>
</html>
