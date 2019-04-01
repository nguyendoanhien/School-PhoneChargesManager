<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/pages/TrangChu.aspx.cs" Inherits="Sim_Web.pages.TrangChu" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Qui định tính cước</h1>
        <p class="lead">Cước phí hàng tháng = cước thuê bao + giá cước * số phút.</p>
        <ul>
            <li>Từ sau 7h đến 23h trong ngày: giá cước 200đ/phút.
            </li>
            <li>Từ sau 23h đến 7h sáng hôm sau: giá cứơc 150đ/phút.
            </li>
        </ul>
    </div>


</asp:Content>
