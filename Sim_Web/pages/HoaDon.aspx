<%@ Page Title="HoaDon" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/pages/HoaDon.aspx.cs" Inherits="Sim_Web.pages.HoaDon" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-xs-6">
            <asp:Button runat="server" ID="btnLogSms" Text="Đọc file log" OnClick="btnLogSms_Click" />
            <asp:GridView runat="server" ID="gvLogSms"></asp:GridView>
        </div>
        <div class="col-xs-6">
            Mã khách hàng <asp:DropDownList runat="server" AutoPostBack="True" ID="rdlKh" OnSelectedIndexChanged="rdlKh_SelectedIndexChanged"/>
            <asp:GridView runat="server" id="gvLogSmsKh" >

            </asp:GridView>

        </div>

    </div>
</asp:Content>
