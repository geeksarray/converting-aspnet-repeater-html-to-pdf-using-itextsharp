<%@ Page Title="Exporting Customer details to PDF using iTextSharp by dotnetmentors.com"
    Language="C#" MasterPageFile="~/Site.Master"  EnableEventValidation="false"   AutoEventWireup="true" CodeBehind="CustomerExport.aspx.cs"
    Inherits="NorthwindApp.CustomerExport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="repCustomers" runat="server">
        <HeaderTemplate>
            <table cellspacing="0" cellpadding="5" rules="all" border="1" id="gvDetails" style="border-collapse: collapse;">
                <tr style="color: White; background-color: #DF5015; font-weight: bold;">
                    <th scope="col">
                        CustomerID
                    </th>
                    <th>
                        CompanyName
                    </th>
                    <th>
                        ContactName
                    </th>
                    <th>
                        ContactTitle
                    </th>
                    <th>
                        Address
                    </th>
                    <th>
                        City
                    </th>
                    <th>
                        Country
                    </th>
                </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).CustomerID%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).CompanyName%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).ContactName%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).ContactTitle%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).Address%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).City%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).Country%>
                </td>
            </tr>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <tr>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).CustomerID%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).CompanyName%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).ContactName%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).ContactTitle%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).Address%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).City%>
                </td>
                <td>
                    <%# ((NorthwindApp.Customer)Container.DataItem).Country%>
                </td>
            </tr>
        </AlternatingItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
    <br />
    <table>
        <tr style="width: 100%">
            <td style="padding-left: 300px">
                <asp:PlaceHolder ID="plcPaging" runat="server" />
            </td>
        </tr>
    </table>
    <asp:Button ID="btnPDF" runat="server" Text="Export to PDF"   OnClick="btnPDF_Click" />
    <asp:Button ID="btnExportAllCustomer" runat="server" 
        Text="Export All Customers to PDF" onclick="btnExportAllCustomer_Click" 
         />
    <asp:Button ID="btnExportPage" runat="server" 
        Text="Export web page" onclick="btnExportPage_Click" 
         />    
</asp:Content>
