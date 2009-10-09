Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Data
Imports Newtonsoft.Json
Imports System.Text
Imports System.IO

Public Class JsonHelper
    Public Shared Function JsonForJqgrid(ByVal dt As DataTable, ByVal pageSize As Integer, ByVal totalRecords As Integer, ByVal page As Integer) As String
        Dim totalPages As Integer = CInt(Math.Ceiling(CSng(totalRecords) / CSng(pageSize)))
        Dim jsonBuilder As New StringBuilder()
        jsonBuilder.Append("{")
        jsonBuilder.Append("""total"":" & totalPages & ",""page"":" & page & ",""records"":" & (totalRecords) & ",""rows""")
        jsonBuilder.Append(":[")
        For i As Integer = 0 To dt.Rows.Count - 1
            jsonBuilder.Append("{""i"":" & (i) & ",""cell"":[")
            For j As Integer = 0 To dt.Columns.Count - 1
                jsonBuilder.Append("""")
                jsonBuilder.Append(dt.Rows(i)(j).ToString())
                jsonBuilder.Append(""",")
            Next
            jsonBuilder.Remove(jsonBuilder.Length - 1, 1)
            jsonBuilder.Append("]},")
        Next
        jsonBuilder.Remove(jsonBuilder.Length - 1, 1)
        jsonBuilder.Append("]")
        jsonBuilder.Append("}")
        Return jsonBuilder.ToString()
    End Function
End Class
