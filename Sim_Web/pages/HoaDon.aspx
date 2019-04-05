<%@ Page Title="HoaDon" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/pages/HoaDon.aspx.cs" Inherits="Sim_Web.pages.HoaDon" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-xs-6">
            <asp:Button runat="server" ID="btnLogSms" CssClass="btn btn-primary" Text="Đọc file log" OnClick="btnLogSms_Click" />
            <asp:GridView runat="server" ID="gvLogSms">
                <%--Code behind--%>
            </asp:GridView>
        </div>
        <div class="col-xs-6">
            Mã khách hàng
            <asp:DropDownList runat="server" AutoPostBack="True" ID="rdlKh" OnSelectedIndexChanged="rdlKh_SelectedIndexChanged" />
            <asp:GridView runat="server" ID="gvLogSmsKh">
                <%--Code behind--%>
            </asp:GridView>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Lập hóa đơn" ID="btnLapHoaDon" OnClick="btnLapHoaDon_Click" />
        </div>

    </div>
    <div class="row">
        <div class="col-xs-6">
            Danh sách hóa đơn
        <asp:Button runat="server" ID="btnHoaDon" CssClass="btn btn-primary" Text="Tải hóa đơn" OnClick="btnHoaDon_Click" />
            <asp:GridView runat="server" ID="gvHoaDon" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvHoaDon_SelectedIndexChanging" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="MaHd" HeaderText="MaHd" />
                    <asp:BoundField DataField="MaKh" HeaderText="MaKh" />   
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-xs-6">
            <asp:GridView runat="server" ID="gvHoaDonChiTiet"></asp:GridView>
        </div>

    </div>
</asp:Content>
