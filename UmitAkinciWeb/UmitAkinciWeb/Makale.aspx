<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Makale.aspx.cs" Inherits="UmitAkinciWeb.Kategori" %>

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
            left:15px;
        }
        .search{
            margin-left:250px;
        }
</style>
</head>
<body style="background-color:whitesmoke">
    
    <form id="form1" runat="server">

                <nav class="navbar navbar-default" style="background-color:white">
                <div>
                <asp:ImageButton ID="ImageButton1" runat="server" Height="43px" ImageUrl="~/instagram.png" Width="54px" />
                <asp:ImageButton ID="ImageButton2" runat="server" Height="43px" ImageUrl="~/facebook.png" Width="54px" />
                &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/maill.png" Height="43px" Width="54px" />
                <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/twitter.png" AlternateText="ddddddddddddddd" />
               <img src="logo3.jpg" style="width:200px; margin-left:350px" />
               <asp:Button ID="btn_hakkimda" runat="server" CssClass="btn btn-default" style="margin-left:300px;margin-top:-45px" Text="HAKKIMDA" BackColor="Black" BorderColor="White" BorderStyle="Outset" BorderWidth="3px" Font-Names="Corbel" ForeColor="White" OnClick="btn_hakkimda_Click" />
               <asp:Button ID="btn_iletisim" runat="server" CssClass="btn btn-default" style="margin-left:1200px; margin-top:-267px" BackColor="Black" BorderColor="White" BorderStyle="Outset" BorderWidth="3px" Font-Names="Corbel" ForeColor="White" Text="İLETİŞİM" OnClick="btn_iletisim_Click" />              
                     </div>
                    <div class="container-fluid" style="background-color:black";>
                    <div class="search">
           <asp:Menu ID="Menu2" CssClass="navbar-brand nav" orientation="Horizontal" runat="server" OnMenuItemClick="Menu2_MenuItemClick" Font-Bold="False">
               <Items>
                   <asp:MenuItem NavigateUrl="~/Anasayfa.aspx" Text="ANASAYFA" Value="ANASAYFA"></asp:MenuItem>
               </Items>
                        <StaticHoverStyle Font-Bold="True" Font-Underline="True" />
                        <StaticMenuItemStyle ForeColor="White" Font-Names="Corbel" Font-Underline="False" />
                        <StaticSelectedStyle BorderColor="Black" />
                        </asp:Menu>
                    </div>
                    </div>


         </nav>
    <div>
    
        <div class="sabitle">
            <div class="panel panel-default" style="width: 230px;background-color:white" >
            <div class="panel-heading">
        <asp:Label ID="lbl_kategoriAdi" runat="server" Text="Label" Font-Bold="True" Font-Names="Corbel" Font-Size="13pt"></asp:Label>
        <br />
            </div>

        <asp:Menu ID="Menu1" runat="server" OnMenuItemClick="Menu1_MenuItemClick" Font-Names="Corbel" Font-Size="13pt" Font-Overline="False" Font-Strikeout="False">
            <DynamicSelectedStyle Font-Names="Times New Roman" />
            <StaticHoverStyle Font-Underline="True" Font-Bold="True" />
            <StaticMenuItemStyle ForeColor="Black" VerticalPadding="10px" />
        </asp:Menu>
            </div>
        </div>
   </div>
    


        <div style="width:1000px" class="container">
            <div class="col-sm-9">
                <div style="width:1000px" class="body" >
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
                <div class="panel panel-warning">
                    <div class="panel-heading">
                        KULLANICI YORUMLARI
                    </div>
                    <div class="panel panel-warning">
                <div class="container">
                    <div class="col-sm-9">
          <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333"> 
                          <ItemTemplate>
                    <div class="media">
                        <div class="media-left">
                        <img src="user2.png" class="media-object" style="width:60px" /></div>
                        <div class="media-body">

                            <h4 class="media-heading" style="font-size:15px"> <label> <%# Eval("YorumAdSoyad")%></label></h4>
                            <h6><label><%# Eval("YorumMetni")%></label></h6>
                            <h5 style="font-size:11px;margin-left:450px; color:gray"><label> <%# Eval("YorumTarihi") %></label></h5>
                            <hr />
                        </div>
                    </div>         
                    </div>
                         </ItemTemplate>       
               </asp:DataList>
                    </div>
                    </div>
                    </div>
                </div>
                </div>

                        <asp:Label ID="Label1" runat="server" Text="SORU VE GÖRÜŞLERİNİZİ YAZABİLİRSİNİZ" Font-Names="Corbel"></asp:Label>
                        <br />
         <asp:TextBox ID="txt_yorum" runat="server" PlaceHolder="Yorumunuzu buraya yazabilirsiniz" TextMode="MultiLine" Height="117px" Width="238px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txt_adi" runat="server" PlaceHolder="Kullanıcı Adınız" Width="128px"></asp:TextBox>
        <br />
        <asp:TextBox ID="txt_eposta" PlaceHolder="E-posta adresiniz" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn_gonder" runat="server" OnClick="btn_gonder_Click" Text="GÖNDER" Font-Names="Corbel" />
            </div>
        </div>
                <div class="container-fluid" style="background-color:black;color:white; height:100px;">
            <h3>            
                <asp:Label ID="Label4" runat="server" Text="Ümit AKINCI © Copyright 2018, Tüm Hakları Saklıdır." ForeColor="White" Font-Names="Corbel" Font-Size="15pt"></asp:Label>
            </h3>
        </div>
    </form>
</body>
</html>
