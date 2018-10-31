﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="UmitAkinciWeb.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width-device-width, Intial-scale=1" />
    <link href="../Bootstrap/bootstrap.css" rel="stylesheet" />
  <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" />
  <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
  <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
                <link rel="Stylesheet" type="text/css" href="StyleSheet.css" />
    <title></title>
    </head>
<body style="background-color:dimgray">
    <div class="hero-img">
     <form class="form- form-horizontal" id="form1" role="form" runat="server">
        <div class="login-area">
                    <div class="col-sm-4 col-sm-offset-4">
                    <div style="margin-bottom: 25px" class="input-group">
          <span class="input-group-addon" ><i class="glyphicon glyphicon-user"  ></i></span>
                    <asp:TextBox ID="txt_kullaniciAdi" CssClass="form-control" class="form-control" PlaceHolder="Kullanıcı adı"  runat="server" Width="268px"></asp:TextBox>                      
        </div>

        <div style="margin-bottom: 25px" class="input-group">
            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                    <asp:TextBox ID="txt_sifre" CssClass="form-control" class="form-control" runat="server" OnTextChanged="txt_sifre_TextChanged" PlaceHolder="Şifre" Width="268px" TextMode="Password"></asp:TextBox>
        </div>
        <div style="margin-bottom: 25px" class="input-group">
        <asp:Label ID="Label3" class="p-3 mb-2 bg-danger text-white" runat="server" Text="Label" Width="268px"></asp:Label>
        </div>
        </div>
        <div class="col-sm-4 col-sm-offset-4">
        <asp:Button ID="btn_giris" runat="server" CssClass="btn btn-info" class="form-control" Width="268px" Text="GİRİŞ" OnClick="btn_giris_Click1" style="height: 36px" />
        </div>
        </div>
    </form>
    </div>
</body>
</html>
