﻿<%@ Page Title="Edit Lecture" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditLecture.aspx.cs" Inherits="BookMama.EditLecture" %>

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
            <asp:GridView runat="server" ID="MaterialsList" BorderWidth="0" CellSpacing="0" BorderStyle="NotSet"
                AutoGenerateColumns="false" EmptyDataText="No materials added here." CssClass="table"
                DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" Visible="false" />
                    <asp:CheckBoxField HeaderText="Include?" />
                    <asp:BoundField DataField="Filename" HeaderText="Materials" />
                </Columns>
            </asp:GridView>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="MaterialInput" CssClass="control-label">You can select multiple materials.</asp:Label>
                <asp:FileUpload ID="MaterialInput" runat="server" CssClass="form-control" AllowMultiple="true" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="MaterialInput"
                    CssClass="text-danger" ErrorMessage="The material field is required." />
            </div>
            <table id="filesToUpload" class="table table-condensed"></table>
            <div class="form-group">
                <div class="col-md-offset-10">
                    <asp:Button runat="server" OnClick="UpdateLecture" Text="Save" CssClass="btn btn-primary" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
