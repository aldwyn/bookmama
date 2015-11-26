<%@ Page Title="My Students" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="BookMama.Students" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="page-header">
        <h2><%: Title %>
            <small>
                <asp:HyperLink NavigateUrl="AddStudent" runat="server" Text="Add" CssClass="btn btn-primary btn-sm"/>
            </small>
        </h2>
    </div>

    <div class="row">
        
    </div>

</asp:Content>
