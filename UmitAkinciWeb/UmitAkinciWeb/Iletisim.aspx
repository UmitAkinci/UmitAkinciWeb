<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="UmitAkinciWeb.Iletisim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
</head>
<body style="background-color:whitesmoke">
    <form id="form1" runat="server">
        <nav class="navbar navbar-default" style="background-color:white;">
            <div>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="43px" ImageUrl="~/instagram.png" Width="54px" />
                <asp:ImageButton ID="ImageButton2" runat="server" Height="43px" ImageUrl="~/facebook.png" Width="54px" />
                &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/maill.png" Height="43px" Width="54px" />
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/twitter.png" AlternateText="ddddddddddddddd" />
               <img src="logo3.jpg" style="width:200px; margin-left:350px" />
&nbsp;<asp:Button ID="btn_hakkimda" runat="server" CssClass="btn btn-default" style="margin-left:300px;margin-top:-45px;" Text="HAKKIMDA" BackColor="Black" BorderColor="White" BorderStyle="Outset" BorderWidth="3px" Font-Names="Corbel" ForeColor="White" OnClick="btn_hakkimda_Click" />
<asp:Button ID="btn_iletisim" runat="server" CssClass="btn btn-default" style="margin-left:1200px; margin-top:-267px" BackColor="Black" BorderColor="White" BorderStyle="Outset" BorderWidth="3px" Font-Names="Corbel" ForeColor="White" Text="İLETİŞİM" OnClick="btn_iletisim_Click" />
            </div>
            <div class="container-fluid" style="background-color:black";>
                <div class="search">
                 <asp:Menu CssClass="navbar-brand nav" orientation="Horizontal" style="margin-left:250px;" ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
                     <Items>
                          <asp:MenuItem NavigateUrl="~/Anasayfa.aspx"  Text="  ANASAYFA" Value="ANASAYFA" ImageUrl="~/home7.png"></asp:MenuItem>
                     </Items>
                     <StaticHoverStyle Font-Bold="True" Font-Underline="True" />
                     <StaticMenuItemStyle Font-Bold="False"  Font-Names="Corbel" ForeColor="White" Font-Size="13pt" />
                 </asp:Menu>
                </div>
                </div>
        </nav>
        <div class="container">
            <div class="col-sm-9">
                <div class="page-header">
                    <h1 style="font-family:Corbel">
                        İLETİŞİM
                    </h1>
                    <hr />
                    <div>
                        <p style="font-family:Corbel">
                         E-posta : umit__akinci@hotmail.com                         
                        </p>
                        <p style="font-family:Corbel">
                         İnstagram : instagram.com/akinciiumit
                        </p>
                        <p style="font-family:Corbel">
                         Twitter : twitter.com/akinciyim                            
                        </p>
                        <p style="font-family:Corbel">
                         LinkedIn : linkedin.com/Ümit Akıncı
                        </p>
                    </div>
                </div>
            </div>

        </div>
        <div class="container-fluid" style="background-color:black;color:white; height:100px;">
            <h3>            
                <asp:Label ID="Label2" runat="server" Text="Ümit AKINCI © Copyright 2018, Tüm Hakları Saklıdır." ForeColor="White" Font-Names="Corbel" Font-Size="15pt"></asp:Label>
            </h3>
             <a href="Login.aspx" style="margin-left:1250px; color:white;">
                   Login
                </a> 
        </div>
    </form>
</body>
</html>
