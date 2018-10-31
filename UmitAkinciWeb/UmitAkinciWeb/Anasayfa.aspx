<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Anasayfa.aspx.cs" Inherits="UmitAkinciWeb.Anasayfa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
  <meta charset="utf-8" />
  <meta name="viewport" content="width=device-width, initial-scale=1" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <style type="text/css">
        .body  {
    background-color:whitesmoke;
}
        .container{
            margin-left:auto;
            margin-right:100px;
        }
        .sabitle{
            position:absolute;
            top:270px;
            margin-left:20px;
        }
        .makale{
            margin-left:20px;
        }
        .search{
            margin-left:250px;
        }
        </style>
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
               <asp:Button ID="btn_hakkimda" runat="server" PostBackUrl="~/Hakkimda.aspx" CssClass="btn btn-default" style="margin-left:300px;margin-top:-45px;" Text="HAKKIMDA" BackColor="Black" BorderColor="White" BorderStyle="Outset" BorderWidth="3px" Font-Names="Corbel" ForeColor="White" OnClick="btn_hakkimda_Click" />
               <asp:Button ID="btn_iletisim" runat="server" CssClass="btn btn-default" style="margin-left:1200px; margin-top:-267px" BackColor="Black" BorderColor="White" BorderStyle="Outset" BorderWidth="3px" Font-Names="Corbel" ForeColor="White" Text="İLETİŞİM" OnClick="btn_iletisim_Click" />
            </div>
            <div class="container-fluid" style="background-color:black";>
                <div class="search">
                 <asp:Menu CssClass="navbar-brand nav" orientation="Horizontal"  ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick">
                     <Items>
                          <asp:MenuItem NavigateUrl="~/Anasayfa.aspx" Text="  ANASAYFA" Value="ANASAYFA" ImageUrl="~/home7.png"></asp:MenuItem>
                     </Items>
                     <StaticHoverStyle Font-Bold="True" Font-Underline="True" />
                     <StaticMenuItemStyle Font-Bold="False"  Font-Names="Corbel" ForeColor="White" Font-Size="13pt" />
                 </asp:Menu>
                </div>

                </div>

        </nav>
                <div class="sabitle">
                    <div class="panel panel-default" style="width: 230px; background-color:white" >
            <div class="panel-heading">
               
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Names="Corbel" Text="SON YAYINLANAN MAKALELER"></asp:Label>
               
            </div>
        &nbsp;
        <asp:Menu ID="Menu2" runat="server" OnMenuItemClick="Menu2_MenuItemClick" Font-Underline="False">
            <DynamicHoverStyle Font-Bold="True" />
            <StaticHoverStyle Font-Underline="True" Font-Bold="True" />
            <StaticMenuItemStyle Font-Bold="False" Font-Size="13pt" VerticalPadding="10px" Font-Names="Corbel" ForeColor="Black" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" />
            <StaticSelectedStyle Font-Strikeout="False" Font-Underline="False" />
        </asp:Menu>
        </div>
        </div>
             <div style="width:1000px" class="container" >
               <div class="col-sm-9">
                 <div style="width:1000px" class="body">
            <div class="page-header">
            <h1>    
          <asp:Label ID="lbl_makaleBaslik" runat="server" Text="Label" Font-Names="Corbel" Font-Bold="True"></asp:Label>
          <br />
            </h1>
            </div>
            <h5>
          <asp:Label ID="lbl_makaleTarih" runat="server" Text="Label" Font-Names="Corbel"></asp:Label>   
           <br />    
            </h5>
            <p>
            <asp:Label ID="lbl_makaleIcerik" runat="server" Text="Label" Font-Names="Corbel" Font-Bold="True"></asp:Label>
             <br />
            </p>

        </div>          
        </div>
        &nbsp;&nbsp;&nbsp;
        </div>



        <div class="container-fluid" style="background-color:black;color:white; height:100px;">
            <h3>            
                <asp:Label ID="Label2" runat="server" Text="Ümit AKINCI © Copyright 2018, Tüm Hakları Saklıdır." ForeColor="White" Font-Names="Corbel" Font-Size="15pt"></asp:Label>
            </h3>
             <a href="Login.aspx" style="margin-left:1250px; color:white;">
                   Login
                </a> 
        </div>
<%--        <nav class="navbar navbar-inverse" style="">    
        </nav>--%>
    </form>
</body>
</html>
