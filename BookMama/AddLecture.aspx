<%@ Page Title="Add Lecture" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddLecture.aspx.cs" Inherits="BookMama.AddLecture" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="page-header">
        <asp:Label runat="server" AssociatedControlID="LectureTitle" CssClass="control-label">Title</asp:Label>
        <asp:TextBox ID="LectureTitle" runat="server" CssClass="form-control" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="LectureTitle"
            CssClass="text-danger" ErrorMessage="The title field is required." />
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="NotesTextBox" CssClass="control-label">Edit or paste your notes here.</asp:Label>
                <asp:TextBox ID="NotesTextBox" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="12" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="NotesTextBox"
                    CssClass="text-danger" ErrorMessage="The notes field is required." />
            </div>
        </div>
        <div class="col-md-6">
            <div class="alert alert-warning" role="alert">
                <strong>Caution:</strong> You can only upload PDF, image, audio, and video files of up to 100 megabytes in size.
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="MaterialInput" CssClass="control-label">You can select multiple materials.</asp:Label>
                <asp:FileUpload ID="MaterialInput" runat="server" CssClass="form-control" AllowMultiple="true" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MaterialInput"
                    CssClass="text-danger" ErrorMessage="The material field is required." />
            </div>
            <table id="filesToUpload" class="table table-condensed"></table>
            <div class="form-group">
                <div class="col-md-offset-10">
                    <asp:Button runat="server" OnClick="SaveLecture" Text="Save" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
