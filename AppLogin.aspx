<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AppLogin.aspx.vb" Inherits="MESLotTrace.AppLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>System Login</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
     <link rel="icon" type="image/x-icon" href="~/images/favicon.ico">
    <link href="Scripts/dndod-popup.min.css" rel="stylesheet" />
    <script src="Scripts/dndod-popup.min.js"></script>
    <link href="Styles/StyleSheet.css" rel="stylesheet" />
    <script>
        function ShowPWD() {
            var inp = document.getElementById("txtPwd");
            //window.alert("I am here");
            if (inp.type == 'password') {
                inp.setAttribute('type', 'SingleLine');
                eyebtn.setAttribute("ImageURL", " ~/Images/eyeopen.png");
            }
            else {
                inp.setAttribute('type', 'password');
                eyebtn.setAttribute("ImageURL", " ~/Images/eyeclosed.png");
            }
        }
    </script>

 <style>
        #footer {
            position: absolute;
            bottom: 0;
            width: 99%;
            /* Height of the footer*/
            height: 40px;
            background: #FF9933;
        }

        .auto-style1 {
            width: 320px;
            height: 66px;
        }
    </style>

</head>
<body style="font-family: Verdana;">
    <form id="form1" runat="server" autocomplete="off" autopostback="false">
          <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/MinebeaMit.JPG" Style="z-index: 1;
            left: 7px; top: 14px; position: absolute; height: 81px; bottom: 718px" />
        <div id="Login" runat="server"
            style="z-index: 1; border-radius: 8px; top: 50%; left: 50%; transform: translate(-50%,-50%); border: 1px ridge #0000FF; width: 460px; height: 300px; margin: auto; position: absolute; background-color: azure;">

            <asp:Label ID="Label7" runat="server"
                Style="z-index: 1; position: absolute; top: 1px; left: 8px; width: 446px; height: 47px; text-align: center;"
                Text="MES Traceability System" Font-Bold="True" Font-Names="Calibri"
                Font-Size="XX-Large"></asp:Label>

            <div id="Div1" runat="server"
                style="z-index: 1; border-radius: 8px; top: 57px; left: 30px; border: 3px ridge #0000FF; width: 400px; height: 200px; margin: auto; position: absolute;">

                <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="Large" Style="z-index: 1; left: 110px; top: 9px; position: absolute"
                    Text="SYSTEM LOGIN"></asp:Label>
                <asp:Label ID="Label3" runat="server" Text="Login ID" Font-Bold="True"
                    Style="z-index: 1; left: 61px; top: 53px; position: absolute"></asp:Label>
                <asp:TextBox ID="txtLogonID" runat="server" BorderStyle="Solid"
                    BorderWidth="1px" BorderRadius="10px" Font-Bold="True"
                    TabIndex="1"
                    Style="z-index: 1; font-size: large; left: 170px; top: 53px; position: absolute; width: 128px; height: auto"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="Password" Font-Bold="True"
                    Style="z-index: 1; left: 62px; top: 96px; position: absolute"></asp:Label>
                <asp:TextBox ID="txtPwd" runat="server" TextMode="Password" BorderStyle="Solid"
                     BorderWidth="1px" BorderRadius="5px" Font-Bold="True" padding="1px 1px 1px 1px"
                    TabIndex="2" 
                    Style="z-index: 1;font-size:large;    left: 170px; top: 96px; width: 127px; height:auto; position: absolute"></asp:TextBox>
                <asp:Button ID="btnLogin" runat="server" Text="Login" BackColor="blue" ForeColor ="White"
                    BorderColor="#FF9900" BorderStyle="Solid" BorderWidth="1px" Height="22px" 
                    Style="z-index: 1;font-size:x-large;  left: 174px; border-radius: 5px; top: 133px; position: absolute; height:auto; width: 120px" />
                <asp:ImageButton ID="eyebtn" runat="server" ImageUrl="~/Images/eyeclosed.png" OnClientClick="javascript:ShowPWD()"  PostBackUrl="javascript:void(0);"
                    Style="z-index: 1; left: 335px; top: 94px; position: absolute; width: 25px; height: 25px;" CausesValidation="False" />

            </div>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Small"
                Style="z-index: 1; left: 10px; position: absolute; width: 443px; height: 30px; top: 268px; text-align: center;"
                Text="[Version 1.0]"></asp:Label>
        </div>
        <div id="footer" runat="server" style="background-color: aqua;">
            <asp:Label ID="Label2" runat="server" Font-Bold="True"
                Style="z-index: 1; left: 2%; position: absolute; width: 380px; top: 10px;"
                Text="[Revised Date : 01 Dec 2023]" Font-Size="Small"></asp:Label>

        </div>
       
    </form>
</body>

</html>
