<%@ Page Title="KhachHang" Theme="Sim" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/pages/KhachHang.aspx.cs" Inherits="Sim_Web.pages.KhachHang" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <div class="form-group">
            <label class="control-label">Họ tên</label>
            <asp:TextBox ID="txtHoTen" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtHoTen" runat="server" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label class="control-label">Nghề nghiệp</label>
            <asp:TextBox ID="txtNgheNhgiep" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label class="control-label">Chức vụ</label>
            <asp:TextBox ID="txtChucVu" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group">
            <label class="control-label">Địa chỉ</label>
            <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <asp:Button runat="server" ID="btnDangKy" SkinID="btnPrimary" Text="Đăng ký" OnClick="btnDangKy_Click" />

    </div>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />

</asp:Content>
