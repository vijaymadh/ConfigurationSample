Option Strict On


Imports System.Collections.Generic
Imports System.IO
Imports System.Globalization
Imports System.Data
Imports System.Text
Imports System.Environment
Imports VI.DB.Specialized
Imports VI.DataImport
Imports System.Xml

Public Class Utilities

    Public Sub UpdateAccess(ByVal newCountryCode As String, ByVal newJobCode As String, ByVal newDepartmentCode As String,
                            ByVal oldCountryCode As String, ByVal oldJobCode As String, ByVal oldDepartmentCode As String)
#Region "Reading New Data"
        Dim newDataReader = DBConnection.GetInstanc().ExecuteReader($"Select * from cccAccess where ccc_country='{newCountryCode}' and ccc_departmentcode='{newDepartmentCode}' and ccc_jobcode='{newJobCode}' order by ccc_category")
#End Region

#Region "Reading Old Data"
        Dim oldDataReader = DBConnection.GetInstanc().ExecuteReader($"Select * from cccAccess where ccc_country='{oldCountryCode}' and ccc_departmentcode='{oldDepartmentCode}' and ccc_jobcode='{oldJobCode}' order by ccc_category")
#End Region

#Region "Compare differences and add or remove"

        Dim dataTable As DataTable = New DataTable()
        dataTable.Columns.Add("ccc_category")
        dataTable.Columns.Add("ccc_subcategory")
        dataTable.Columns.Add("ccc_value")
        dataTable.Columns.Add("ccc_country")
        dataTable.Columns.Add("ccc_departmentcode")
        dataTable.Columns.Add("ccc_jobcode")

        dataTable.Columns.Add("type")

        Dim newApps As List(Of String) = New List(Of String)

        ' Add all to a data table

        While newDataReader.Read()
            Dim dr As DataRow = dataTable.NewRow()
            dr("ccc_category") = newDataReader("ccc_category")
            dr("ccc_subcategory") = newDataReader("ccc_subcategory")
            dr("ccc_value") = newDataReader("ccc_value")
            dr("ccc_country") = newDataReader("ccc_country")
            dr("ccc_departmentcode") = newDataReader("ccc_departmentcode")
            dr("ccc_jobcode") = newDataReader("ccc_jobcode")
            dr("type") = "add"

            dataTable.Rows.Add(dr)
            If Not newApps.Contains(newDataReader("ccc_category").ToString) Then
                newApps.Add(newDataReader("ccc_category").ToString)
            End If

        End While

        While oldDataReader.Read()
            Dim dr As DataRow = dataTable.NewRow()
            dr("ccc_category") = oldDataReader("ccc_category")
            dr("ccc_subcategory") = oldDataReader("ccc_subcategory")
            dr("ccc_value") = oldDataReader("ccc_value")
            dr("ccc_country") = oldDataReader("ccc_country")
            dr("ccc_departmentcode") = oldDataReader("ccc_departmentcode")
            dr("ccc_jobcode") = oldDataReader("ccc_jobcode")
            dr("type") = "delete"

            If Not newApps.Contains(oldDataReader("ccc_category").ToString) Then

                dataTable.Rows.Add(dr)
            Else
                Dim result = dataTable.Select("ccc_category='" & oldDataReader("ccc_category").ToString & "'")
                If (result.Length > 0) Then
                    Dim selectedIndex = dataTable.Rows.IndexOf(result(0))
     
                dataTable.Rows.RemoveAt(selectedIndex)
                End If
            End If

        End While

        

        AddAccess(dataTable)
        RemoveAccessFromTable(dataTable)

#End Region
    End Sub

    Public Function AddAccess(ByVal cccValues As DataTable) As String

        Dim xmlList As Dictionary(Of String, String) = New Dictionary(Of String, String)()
        Dim uid_Org = String.Empty
        Dim sbXml As StringBuilder = New StringBuilder()
        Dim currentApp = String.Empty
        Dim ccc_value As String = String.Empty

        For Each row as DataRow In cccValues.Rows

            If row.Item("type").ToString() = "delete" Then
                Continue For
            End If

            If currentApp <> row("ccc_category").ToString() Then

                If sbXml.Length > 0 Then
                    xmlList.Add(uid_Org, sbXml.ToString)
                    sbXml.Append("</AppData>")
                    ccc_value = String.Empty

                End If
                sbXml = New StringBuilder()
                sbXml.Append("<AppData>")
            End If

            If row("ccc_subcategory").ToString() <> "uidOrg" Then 
                    sbXml.Append("<Entry>")
                    sbXml.Append("<Key>" & row("ccc_subcategory").ToString & "</Key>")
                    sbXml.Append("<Value>" & row("ccc_value").ToString & "</Value>")
                    sbXml.Append("</Entry>")  
            Else
                uid_Org = row("ccc_value").ToString

            End If
            currentApp = row("ccc_category").ToString()

        Next


        xmlList.Add(uid_Org, sbXml.ToString())
        sbXml.Append("</AppData>")

        For Each key In xmlList.Keys
            Dim personWantOrg As New PersonWantsOrg


            personWantOrg.UID_Org = key
            personWantOrg.UID_PersonInserted = "Something"
            personWantOrg.UID_PersonOrdered = "Something"
            personWantOrg.Orderdetail1 = xmlList(key)
            personWantOrg.OrderReason = "Something"

            personWantOrg.SaveSingle(personWantOrg)

        Next

        Return "Completed Successfully"
    End Function


    Public Function RemoveAccessFromTable(ByVal cccValues As DataTable) As String

        'For Each row In cccValues.Rows

        '    If(row("type")="delete")

        '            If Not String.IsNullOrEmpty(req.GetValue("OrderDetail1")) Then
        '                Dim obj As ISingleDbObject = Connection.CreateSingle("PersonwantsOrg", req.GetValue("UID_PersonWantsOrg"))
        '                Dim params As String() = New String() {suid_personordered, "Transfer"}
        '                obj.Custom.CallMethod("Unsubscribe", params)
        '                obj.Save()
        '            End If



        '    End If



        'Next
        Return String.Empty

    End Function
End Class
