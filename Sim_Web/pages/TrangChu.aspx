<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/pages/TrangChu.aspx.cs" Inherits="Sim_Web.pages.TrangChu" %>

<%@ MasterType VirtualPath="~/Site.Master" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Qui định tính cước</h1>
        <p class="lead">Cước phí hàng tháng = cước thuê bao + giá cước * số phút.</p>
        <ul>

            <asp:Repeater runat="server" ID="rptBangGia">
                <ItemTemplate>
                    <li>Từ sau <%#Eval("GioBd") %> đến <%#Eval("GioKt") %> trong ngày: giá cước <%#Eval("GiaCuoc") %>đ/phút.</li>
                </ItemTemplate>

            </asp:Repeater>


        </ul>
    </div>


</asp:Content>
