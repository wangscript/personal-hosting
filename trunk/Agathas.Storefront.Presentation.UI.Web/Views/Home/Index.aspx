<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/ProductCatalog.master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Agathas.Storefront.Presentation.UI.Web.Views.Home.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <img alt="" height="297" src="../../Content/Images/Products/product-lifestyle.jpg" style="border-width: 0px; padding: 0px; margin: 0px" width="559" />
    <div style="clear: both;"></div>
    <h2>Top Products</h2>
    <div id="items" style="border-width: 1px; padding: 0px; margin: 0px">
        <asp:Repeater runat="server">
            <HeaderTemplate>
                <ul class="items-list">
            </HeaderTemplate>
            <ItemTemplate>
                <li class="item-detail">
                    
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
