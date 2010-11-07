<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="HttpResponseSpike._Default" %>

<%--<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>--%>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div><asp:LinkButton ID="LinkButton1" OnClick="LinkButton1Click" Text="Get Track A" runat="server"  /></div>
    <div><asp:LinkButton ID="LinkButton2" OnClick="LinkButton2Click" Text="Get Track B" runat="server" /></div>
</asp:Content>
