<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Categories.ascx.cs" Inherits="Agathas.Storefront.Presentation.UI.Web.Shared.Controls.Categories" %>

<h2>Categories</h2>

<asp:Repeater ID="rptCategories" runat="server">
    <HeaderTemplate>
        <ul class="refine-attributes">
    </HeaderTemplate>
    <ItemTemplate>
        <li><a href="<%$RouteUrl:CategoryId=Eval(""), routename=CategoryUrl %>"></a></li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
