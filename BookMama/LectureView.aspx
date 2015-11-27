<%@ Page Title="Lecture View" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LectureView.aspx.cs" Inherits="BookMama.LectureView" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="page-header">
        <h2>
            <asp:Label ID="LectureTitle" runat="server"></asp:Label>
            <br />
            <small>on <asp:Label ID="DateCreated" runat="server" /></small>
            <small>
                <asp:HyperLink ID="EditLectureLink" runat="server" Text="Edit" CssClass="btn btn-primary btn-sm"/>
            </small>
        </h2>
    </div>
    <p style="white-space: pre-line;">
        <asp:Label ID="LectureNotes" runat="server" />
    </p>

    <asp:GridView runat="server" ID="MaterialsList" BorderWidth="0" CellSpacing="0" BorderStyle="NotSet"
        AutoGenerateColumns="false" EmptyDataText="No materials added here." CssClass="table"
        DataKeyNames="Id">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false" />
            <asp:HyperLinkField DataTextField="Filename" HeaderText="Materials" SortExpression="Title"
                DataNavigateUrlFields="Id" DataNavigateUrlFormatString="MaterialView.aspx?Id={0}" DataTextFormatString=""/>
            <asp:BoundField DataField="ContentType" HeaderText="Type" SortExpression="ContentType" />
            <asp:BoundField DataField="ContentLength" HeaderText="Size (in bytes)" SortExpression="ContentLength" />
        </Columns>
    </asp:GridView>

</asp:Content>
