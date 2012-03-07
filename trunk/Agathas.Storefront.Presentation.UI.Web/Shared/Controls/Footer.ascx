<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="Agathas.Storefront.Presentation.UI.Web.Shared.Controls.Footer" %>

<div id="prefooter">
    <span style="float: left; margin-left: 20px;">
        <table>
            <tr>
                <td>
                    <ul>
                        <li class="footer-list-header">Help:</li>
                        <li><a href="#">Neque porro quisquam est</a></li>
                        <li><a href="#">ipsum quia dolor sit amet</a></li>
                    </ul>
                </td>
                <td>
                    <ul>
                        <li class="footer-list-header">About:</li>
                        <li><a href="#">quisquam Nequeporro est</a></li>
                        <li><a href="#">dolor sit amet ipsum quia </a></li>
                    </ul>
                </td>
                <td>
                    <ul>
                        <li class="footer-list-header">Social:</li>
                       <li><a href="#">porro Neque quisquam est</a></li>
                        <li><a href="#">sit amet ipsum quia dolor</a></li>
                    </ul>
                </td>               
            </tr>
        </table>
    </span>
    <span style="float: right; margin-top: 60px; margin-right: 10px;">
        <a href="<%= Page.GetRouteUrl("") %>">
        <img alt="Agatha's Clothing Store"  height="43" src="../../Shared/../Content/Images/Structure/sm_logo.png" width="173" /></a>
   </span>
</div>
<div id="footer">
    
</div>