<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        jQuery(document).ready(function() {
            jQuery("#list").jqGrid({
            url: '/Home/GetGridData/',
                datatype: 'json',
                mtype: 'GET',
                colNames: ['Customer ID', 'Contact Name', 'Address', 'City', 'Postal Code'],
                colModel: [
                  { name: 'CustomerID', index: 'CustomerID', width: 100, align: 'left' },
                  { name: 'ContactName', index: 'ContactName', width: 150, align: 'left' },
                  { name: 'Address', index: 'Address', width: 300, align: 'left' },
                  { name: 'City', index: 'City', width: 150, align: 'left' },
                  { name: 'PostalCode', index: 'PostalCode', width: 100, align: 'left' }
                ],
                pager: jQuery('#pager'),
                rowNum: 10,
                rowList: [5, 10, 20, 50],
                sortname: 'CustomerID',
                sortorder: "asc",
                viewrecords: true,
                imgpath: '/scripts/themes/steel/images',
                caption: 'Northwind Customer Information'
               }).navGrid(pager, { edit: true, add: true, del: true, refresh: true, search: true });
        });
    </script>

</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>
        Customers List</h2>
    <table id="list" class="scroll" cellpadding="0" cellspacing="0" width="100%">
    </table>
    <div id="pager" class="scroll" style="text-align: center;">
    </div>
</asp:Content>
