<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BookMama._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div id="wrap" class="container">
        <div id="larabidJumbotron">
            <div class="row">
                <div class="col-md-6">
                    <h1 style="font-size: 4em; font-weight: bolder"><em><span class="glyphicon glyphicon-paperclip"></span> BookMama</em></h1>
                    <p style="font-size: 1.3em">The new generation of E-learning.</p>
                </div>
                <div class="col-md-3">
                    <div class="thumbnail">
                        <img src="Content/Images/1.jpg" />
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="thumbnail">
                        <img src="Content/Images/2.jpg" />
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-3">
                    <div class="thumbnail">
                        <img src="Content/Images/3.jpg" />
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="thumbnail">
                        <img src="Content/Images/4.jpg" />
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="thumbnail">
                        <img src="Content/Images/5.jpg" />
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="thumbnail">
                        <img src="Content/Images/6.jpg" />
                    </div>
                </div>
            </div>
            <a runat="server" href="~/Account/Register" class="btn btn-warning">Get started</a>
        </div>
    </div>
    <style>
        #larabidJumbotron {
            text-align: right;
            margin-top: 40px;
            padding: 50px 40px;
            background-color: rgba(0, 0, 0, 0.2);
            border-radius: 100%;
        }
        .thumbnail {
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
</asp:Content>
