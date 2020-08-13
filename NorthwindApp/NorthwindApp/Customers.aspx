<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Customers.aspx.cs" Inherits="NorthwindApp.Customers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="customer">
        <asp:Repeater ID="repCustomers" runat="server" EnableViewState="false">
            <HeaderTemplate>
                <table>
                    <tr>
                        <th>
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
                    <tr>
                        <td colspan="7">
                            <hr />
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <%# ((NorthwindApp.Customer)Container.DataItem).CustomerID %>
                    </td>
                    <td>
                        <%# ((NorthwindApp.Customer)Container.DataItem).CompanyName %>
                    </td>
                    <td>
                        <%# ((NorthwindApp.Customer)Container.DataItem).ContactName %>
                    </td>
                    <td>
                        <%# ((NorthwindApp.Customer)Container.DataItem).ContactTitle %>
                    </td>
                    <td>
                        <%# ((NorthwindApp.Customer)Container.DataItem).Address %>
                    </td>
                    <td>
                        <%# ((NorthwindApp.Customer)Container.DataItem).City %>
                    </td>
                    <td>
                        <%# ((NorthwindApp.Customer)Container.DataItem).Country %>
                    </td>
                </tr>
            </ItemTemplate>
            <SeparatorTemplate>
                <tr>
                    <td colspan="7">
                        <hr />
                    </td>
                </tr>
            </SeparatorTemplate>
            <FooterTemplate>
                <tr>
                    <td colspan="7">
                        <hr />
                    </td>
                </tr>
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
    </div>
</asp:Content>
