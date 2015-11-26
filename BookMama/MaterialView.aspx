<%@ Page Title="Material View" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MaterialView.aspx.cs" Inherits="BookMama.Material1" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="page-header">
        <h2>
            <asp:Label ID="Filename" runat="server" />
        </h2>
    </div>

    <div class="row">
        <div class="col-md-7">
            <div class="thumbnail">
                <asp:Literal ID="RenderedContent" runat="server" />
            </div>
        </div>
        <div class="col-md-5">
            <h4>Details</h4>
            <asp:HiddenField ID="DetailSource" runat="server" />
            <asp:HiddenField ID="DetailId" runat="server" />
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DetailFilename" CssClass="control-label">Filename: </asp:Label>
                <asp:Label ID="DetailFilename" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DetailLength" CssClass="control-label">Size: </asp:Label>
                <asp:Label ID="DetailLength" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DetailType" CssClass="control-label">Type: </asp:Label>
                <asp:Label ID="DetailType" runat="server" />
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="DetailLecture" CssClass="control-label">From Lecture: </asp:Label>
                <asp:HyperLink ID="DetailLecture" runat="server" />
            </div>
            <asp:Label ID="DownloadTimes" runat="server" />
            <div class="form-group">
                <asp:Button ID="DownloadLink" OnClick="DownloadMaterial" Text="Download" runat="server" CssClass="btn btn-primary btn-lg" />
            </div>
        </div>
    </div>
</asp:Content>
