<%@ Page Title="PageSim" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/pages/Sim.aspx.cs" Inherits="Sim_Web.pages.PageSim" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-xs-4">
            <div class="lead">Thêm sim</div>

            Nhập số sim:
            <asp:TextBox runat="server" ID="txtSoSim"></asp:TextBox>
            <asp:Button runat="server" ID="btnThemSim" Text="Thêm" CssClass="btn-primary btn" OnClick="btnThemSim_Click" />
        </div>
        <div class="col-xs-4">
            <div class="lead">Danh sách sim</div>
            <asp:GridView runat="server" ID="gvSims" CssClass="table table-bordered">
            </asp:GridView>
        </div>
        <div class="col-xs-4">
            <div class="lead">Đăng ký sim</div>
            Phí đăng ký : <b>50000</b> <br/>
            Tên khách hàng: <asp:DropDownList runat="server" ID="rdlKh" /><br />
            Chọn sim (nhiều có thể ngăn cách bởi dấu ,):
            
            <asp:TextBox runat="server" ID="txtSims"></asp:TextBox>
            <asp:Button runat="server" id="btnDangKy" Text="Đăng ký" CssClass="btn btn-primary" OnClick="btnDangKy_Click"/>
        </div>
    </div>
</asp:Content>
