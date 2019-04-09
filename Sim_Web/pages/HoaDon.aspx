<%@ Page Title="HoaDon" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/pages/HoaDon.aspx.cs" Inherits="Sim_Web.pages.HoaDon" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-xs-6">
            <asp:Button runat="server" ID="btnLogSms" CssClass="btn btn-primary" Text="Đọc file log" OnClick="btnLogSms_Click" />
            <asp:GridView runat="server" ID="gvLogSms" CssClass="table table-bordered">
                <%--Code behind--%>
            </asp:GridView>
        </div>
        <div class="col-xs-6">
            Mã khách hàng
            <asp:DropDownList runat="server" AutoPostBack="True" ID="rdlKh" OnSelectedIndexChanged="rdlKh_SelectedIndexChanged" />
            <asp:GridView runat="server" ID="gvLogSmsKh" CssClass="table table-bordered ">
                <%--Code behind--%>
            </asp:GridView>


            <asp:Button runat="server" CssClass="btn btn-primary" Text="Lập hóa đơn" ID="btnLapHoaDon" OnClick="btnLapHoaDon_Click" />
        </div>
    </div>


    <hr />
    <div class="row">
        <div class="col-xs-6">
            <div class="lead">Danh sách hóa đơn</div>

            <asp:Button runat="server" ID="btnHoaDon" CssClass="btn btn-primary" Text="Tải hóa đơn" OnClick="btnHoaDon_Click" />
            <asp:GridView runat="server" ID="gvHoaDon" CssClass="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvHoaDon_SelectedIndexChanging" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="MaHd" HeaderText="MaHd" />
                    <asp:BoundField DataField="MaKh" HeaderText="MaKh" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-xs-6">
            <div class="lead">Chi tiết hóa đơn</div>

            <asp:Label runat="server" ID="lbHoaDonChiTiet"></asp:Label>
            <asp:GridView runat="server" ID="gvHoaDonChiTiet" CssClass="table-bordered table"></asp:GridView>
            <div class="input-group">
                <input type="text" runat="server" id="iptMaHd" class="form-control" placeholder="Nhập mã hóa đơn" aria-label="" aria-describedby="basic-addon1" />
                <input type="text" runat="server" id="iptEmail" class="form-control" placeholder="Nhập email" aria-label="" aria-describedby="basic-addon1" />
                <div class="input-group-btn">
                    <asp:Button runat="server" ID="btnSendMail" CssClass="btn btn-danger" Text="Gửi mail thông báo" OnClick="btnSendMail_Click" />

                </div>
            </div>
        </div>

    </div>

</asp:Content>
