<%@ Page Title="My Lectures" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Lectures.aspx.cs" Inherits="BookMama.Lectures" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="page-header">
        <h2><%: Title %>
            <small>
                <asp:HyperLink NavigateUrl="AddLecture" runat="server" Text="Add" CssClass="btn btn-primary btn-sm"/>
            </small>
        </h2>
    </div>

    <div class="row">
        <asp:GridView runat="server" ID="LecturesList" BorderWidth="0" CellSpacing="0" BorderStyle="NotSet"
            AutoGenerateColumns="false" EmptyDataText="No lectures added yet." CssClass="table table-collapsed"
            OnRowDeleting="LecturesList_RowDeleting" AllowSorting="true"
            OnSorting="LecturesList_Sorting" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false" />
                <asp:HyperLinkField DataTextField="Title" HeaderText="Lecture Title" SortExpression="Title"
                    DataNavigateUrlFields="Id" DataNavigateUrlFormatString="LectureView.aspx?Id={0}" />
                <asp:BoundField DataField="DateCreated" HeaderText="Date Created" SortExpression="DateCreated" />
                <asp:CommandField ShowDeleteButton="true" ButtonType="Link" HeaderText="Action" />
                <asp:HyperLinkField HeaderText="Edit?" Text="Edit"
                    DataNavigateUrlFields="Id" DataNavigateUrlFormatString="EditLecture.aspx?Id={0}" />
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
