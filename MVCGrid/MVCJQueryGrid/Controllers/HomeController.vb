Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.Data

<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewData("Message") = "Welcome to ASP.NET MVC!"

        Return View()
    End Function

    Function About() As ActionResult
        Return View()
    End Function

    'Public Function Delete(ByVal sidx As String, ByVal sord As String, ByVal page As Integer, ByVal rows As Integer, ByVal CustomerID As Integer) As ActionResult

    '    Return Content(JsonHelper.JsonForJqgrid(DeleteCustomer(CustomerID), rows, GetTotalCount(), page), "application/json")
    'End Function

    'Public Function DeleteCustomer(ByVal CustomerID) As DataTable


    'End Function

    Public Function GetGridData(ByVal sidx As String, ByVal sord As String, ByVal page As Integer, ByVal rows As Integer) As ActionResult
        Return Content(JsonHelper.JsonForJqgrid(GetDataTable(sidx, sord, page, rows), rows, GetTotalCount(), page), "application/json")
    End Function

    Public Function GetDataTable(ByVal sidx As String, ByVal sord As String, ByVal page As Integer, ByVal pageSize As Integer) As DataTable
        Dim startIndex As Integer = (page - 1) * pageSize
        Dim endIndex As Integer = page * pageSize
        Dim sql As String = "WITH PAGED_CUSTOMERS AS ( SELECT CustomerID, ContactName, Address, City, PostalCode, ROW_NUMBER() OVER (ORDER BY " & sidx & " " & sord & ") AS RowNumber FROM CUSTOMERS ) SELECT CustomerID, ContactName, Address, City, PostalCode FROM PAGED_CUSTOMERS  WHERE RowNumber BETWEEN " & startIndex & " AND " & endIndex & ";"
        Dim dt As New DataTable()
        Dim conn As New SqlConnection(ConfigurationManager.ConnectionStrings("mainConnection").ConnectionString)
        Dim adap As New SqlDataAdapter(sql, conn)
        Dim rows = adap.Fill(dt)
        Return dt
    End Function

    Public Function GetTotalCount() As Integer
        Dim sql As String = "SELECT COUNT(*) FROM Customers"
        Dim conn As SqlConnection = Nothing
        Try
            conn = New SqlConnection(ConfigurationManager.ConnectionStrings("mainConnection").ConnectionString)
            Dim comm As New SqlCommand(sql, conn)
            conn.Open()
            Return CInt(comm.ExecuteScalar())
        Catch
        Finally
            Try
                If ConnectionState.Closed <> conn.State Then
                    conn.Close()
                End If
            Catch
            End Try
        End Try
        Return -1
    End Function


End Class
