<%@ Page Title="Whoops!" Language="C#" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div class="page-header">
        <h2>
            <%: Title %>
            <small> | You have to do something.</small>
        </h2>
    </div>
    <div class="col-md-offset-3">
        <h1 style="font-size: 10em">
            <span class="glyphicon glyphicon-eye-close"></span>
            <span>404</span>
        </h1>
    </div>
</asp:Content>
