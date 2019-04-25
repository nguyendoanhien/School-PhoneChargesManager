<%@ Page Title="HoaDon" Language="C#" MaintainScrollPositionOnPostback="true" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="~/pages/HoaDon.aspx.cs" Inherits="Sim_Web.pages.HoaDon" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        <div class="col-md-6">
            <div class="row">
                <div class="col-xs-12">
                    <div class="btn-group">
                        <asp:Button runat="server" ID="btnLogSmsRandom" CssClass="btn btn-danger" Text="Sinh ngẫu nhiên file log" OnClick="btnLogSmsRandom_Click" />
                        <asp:Button runat="server" ID="btnLogSms" CssClass="btn btn-primary" Text="Đọc file log" OnClick="btnLogSms_Click" />
                        <asp:Button runat="server" ID="btnLogSmsFilter" CssClass="btn btn-primary" Text="Lọc" OnClick="btnLogSmsFilter_Click" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-xs-6 table-responsive">
                    <asp:TextBox runat="server" ID="txtDateFrom"></asp:TextBox>
                    <asp:ImageButton runat="server" id="ibtnShowDateFrom" OnClick="ibtnShowDateFrom_OnClick" ImageUrl="/images/calendar.png" Height="32px" Width="32px"/>
                    <asp:Calendar DayNameFormat="FirstLetter" Caption="Thời gian bắt đầu" OnDayRender="cldFrom_OnDayRender"  CssClass="table table-condensed" runat="server" ID="cldFrom" OnSelectionChanged="cldFrom_OnSelectionChanged"></asp:Calendar>
                </div>
                <div class="col-xs-6 table-responsive">
                    <asp:TextBox runat="server" ID="txtDateTo"></asp:TextBox>
                    <asp:ImageButton runat="server" OnClick="ibtnShowDateTo_OnClick" id="ibtnShowDateTo" ImageUrl="/images/calendar.png" Width="32px" Height="32px"/>
                    <asp:Calendar DayNameFormat="FirstLetter" Caption="Thời gian kết thúc" OnDayRender="cldTo_OnDayRender" CssClass="table table-condensed" runat="server" ID="cldTo" OnSelectionChanged="cldTo_OnSelectionChanged"></asp:Calendar>
                </div>
            </div>


            <asp:GridView runat="server" ID="gvLogSms" CssClass="table table-bordered" OnPageIndexChanging="gvLogSms_PageIndexChanging" AllowPaging="True">
            </asp:GridView>
        </div>
        <div class="col-md-6">
            Mã khách hàng
            <asp:DropDownList runat="server" AutoPostBack="True" ID="rdlKh" OnSelectedIndexChanged="rdlKh_SelectedIndexChanged" />
            <asp:GridView runat="server" ID="gvLogSmsKh" CssClass="table table-bordered " AllowPaging="True" OnPageIndexChanging="gvLogSmsKh_PageIndexChanging">
            </asp:GridView>


            <asp:Button runat="server" CssClass="btn btn-primary" Text="Lập hóa đơn" ID="btnLapHoaDon" OnClick="btnLapHoaDon_Click" />
        </div>
    </div>


    <hr />
    <div class="row">
        <div class="col-xs-6">
            <div class="lead">Danh sách hóa đơn</div>

            <asp:Button runat="server" ID="btnHoaDon" CssClass="btn btn-primary" Text="Tải hóa đơn" OnClick="btnHoaDon_Click" />
            <asp:GridView runat="server" ID="gvHoaDon" CssClass="table table-bordered" AutoGenerateSelectButton="True" OnSelectedIndexChanging="gvHoaDon_SelectedIndexChanging" AutoGenerateColumns="False" AllowPaging="True">
                <Columns>
                    <asp:BoundField DataField="MaHd" HeaderText="MaHd" />
                    <asp:BoundField DataField="MaKh" HeaderText="MaKh" />
                </Columns>
            </asp:GridView>
        </div>
        <div class="col-xs-6">
            <div class="lead">Chi tiết hóa đơn</div>

            <asp:Label runat="server" ID="lbHoaDonChiTiet"></asp:Label>
            <asp:GridView runat="server" ID="gvHoaDonChiTiet" CssClass="table-bordered table" AllowPaging="True" OnPageIndexChanging="gvHoaDonChiTiet_PageIndexChanging"></asp:GridView>
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
