'Imports System.Collections.Generic
'Imports System.IO
'Imports System.Globalization
'Imports System.Data
'Imports System.Text
'Imports System.Environment
'Imports VI.DB.Specialized
'Imports VI.DataImport
'Imports System.Xml

'Public Class UtilitiesChanged

'    Public Function RemoveAccess(ByVal sUID_DCCode As String,ByVal sUID_Org As String,ByVal sUID_Locality As String,
'                                         ByVal sPersonInserted As String,ByVal sUID_PersonOrdered As String) As String

        
'        Dim uidOrg As String = ""
'        Dim cccValue As String = ""
'        Dim sOrderReason As String = "access"

'        Dim sQuery = "select * from cccAccess where CC_JobCode='" & sUID_Org & "' and CCC_DepartmentCode='"& sUID_DCCode & "' and CCC_Country='" & sUID_Locality & "'"
        
'        Dim xmlList As Dictionary(Of String, String) = New Dictionary(Of String, String)()
'        Dim uid_Org = String.Empty
'        Dim sbXml As StringBuilder = New StringBuilder()
'        Dim currentApp = String.Empty
'        Dim ccc_value As String = String.Empty

'        Dim cccValues As IDataReader=DBConnection.GetInstanc().ExecuteReader(sQuery)
     
'        While(cccValues.Read())
            
'            If currentApp <> cccValues.GetValue("CCC_Category") Then

'                If sbXml.Length > 0 Then
'                    xmlList.Add(uid_Org, sbXml.ToString)
'                    sbXml.Append("</AppData>")
'                    ccc_value = String.Empty

'                End If
'                sbXml = New StringBuilder()
'                sbXml.Append("<AppData>")
'            End If

'            If cccValues.GetValue("CCC_SubCategory") <> "uidOrg" Then

'                If cccValues.GetValue("CCC_SubCategory") = "LoginID" Then                    
'                    sbXml.Append("<Entry>")
'                    sbXml.Append("<Key>" & cccValues.GetValue("CCC_SubCategory").ToString & "</Key>")
'                    sbXml.Append("<Value>" & cccValues.GetValue("CCC_Access").ToString & "</Value>")
'                    sbXml.Append("</Entry>")
'                Else
'                    'If cccValues.GetValue("CCC_SubCategory") = "ID" Then
                     
'                    '    sbXml.Append("<Entry>")
'                    '    sbXml.Append("<Key>" & cccValues.GetValue("CCC_SubCategory").ToString & "</Key>")
'                    '    sbXml.Append("<Value>" & cccValues.GetValue("CCC_Access").ToString & "</Value>")
'                    '    sbXml.Append("</Entry>")
'                    'Else
'                    '    If Not sbXml.ToString.Contains(cccValue2.GetValue("CCC_SubCategory")) Then
'                    '        ccc_value = CCC_GetCCCvalue(cccValues.GetValue("CCC_Category"), cccValues.GetValue("CCC_SubCategory"))
'                    '        sbXml.Append("<Entry>")
'                    '        sbXml.Append("<Key>" & cccValues.GetValue("CCC_SubCategory").ToString & "</Key>")
'                    '        sbXml.Append("<Value>" & ccc_value & "</Value>")
'                    '        sbXml.Append("</Entry>")

'                    '    End If

'                    'End If
'                End If

'            Else
'                uid_Org = cccValues.GetValue("CCC_Access").ToString

'            End If
'            currentApp = cccValues.GetValue("CCC_Category")

'     End While


'        xmlList.Add(uid_Org, sbXml.ToString())
'        sbXml.Append("</AppData>")

'        For Each key In xmlList.Keys
'            Dim personWantOrg As New PersonWantsOrg
            
            
'            personWantOrg.UID_Org= key
'            personWantOrg.UID_PersonInserted=sPersonInserted
'            personWantOrg.UID_PersonOrdered= sUID_PersonOrdered
'            personWantOrg.Orderdetail1=xmlList(key)
'            personWantOrg.OrderReason=sOrderReason
            
'            personWantOrg.SaveSingle(personWantOrg)            
                
'        Next

'        Return "Completed Successfully"
'        End Function

'    'Public Function CCC_GetCCCvalue(ByVal category As String, ByVal subcategory As String) As String
'    '    Dim f As ISqlFormatter = Connection.SqlFormatter
'    '    Dim ccc_value = String.Empty
'    '    Dim final = String.Empty
'    '    Dim swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Access", "RBAC", ValType.String, CompareOperator.Equal),
'    '        f.Comparison("CCC_Category", category, ValType.String, CompareOperator.Equal))).Select("CCC_Subcategory", "CCC_Value")
'    '    Dim cccvalues As IEntityCollection = Session.Source.GetCollection(swhere)
'    '    For Each cccvalue As IEntity In cccvalues
'    '        If cccvalue.GetValue("CCC_Subcategory") = subcategory Then
'    '            If String.IsNullOrEmpty(ccc_value) Then
'    '                ccc_value = cccvalue.GetValue("CCC_Value")
'    '            Else
'    '                If Not ccc_value.Contains(cccvalue.GetValue("CCC_Value")) Then
'    '                    ccc_value = String.Concat(ccc_value, ChrW(7), cccvalue.GetValue("CCC_Value"))

'    '                End If
'    '            End If

'    '            final = ccc_value
'    '        End If
'    '    Next
'    '    Return final
'    'End Function

'    Public Function CCC_RemoveAccess(ByVal suid_Departmentcode As String, ByVal suid_locality As String, ByVal suid_org As String, ByVal suid_personordered As String) As String

'        Dim f As ISqlFormatter = Connection.SqlFormatter
'        Dim swhere As Query

'        If Not String.IsNullorEmpty(suid_Departmentcode) And Not String.IsNullorEmpty(suid_locality) And Not String.IsNullorEmpty(suid_org) Then

'            swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Jobcode", suid_org, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Departmentcode", suid_Departmentcode, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Country", suid_locality, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Access", "RBAC", valtype.String, CompareOperator.Equal))) _
'                                                                .Select("CCC_Subcategory", "CCC_Value")
'        End If

'        If Not String.IsNullorEmpty(suid_Departmentcode) And Not String.IsNullorEmpty(suid_locality) And String.IsNullorEmpty(suid_org) Then

'            swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Departmentcode", suid_Departmentcode, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Country", suid_locality, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Access", "RBAC", valtype.String, CompareOperator.Equal))) _
'                                                                .Select("CCC_Subcategory", "CCC_Value")

'        End If

'        If Not String.IsNullorEmpty(suid_Departmentcode) And String.IsNullorEmpty(suid_locality) And Not String.IsNullorEmpty(suid_org) Then

'            swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Jobcode", suid_org, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Departmentcode", suid_Departmentcode, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Access", "RBAC", valtype.String, CompareOperator.Equal))) _
'                                                                .Select("CCC_Subcategory", "CCC_Value")

'        End If

'        If String.IsNullorEmpty(suid_Departmentcode) And Not String.IsNullorEmpty(suid_locality) And Not String.IsNullorEmpty(suid_org) Then

'            swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Jobcode", suid_org, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Country", suid_locality, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Access", "RBAC", valtype.String, CompareOperator.Equal))) _
'                                                                .Select("CCC_Subcategory", "CCC_Value")
'        End If

'        If Not String.IsNullorEmpty(suid_Departmentcode) And String.IsNullorEmpty(suid_locality) And String.IsNullorEmpty(suid_org) Then

'            swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Departmentcode", suid_Departmentcode, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Access", "RBAC", valtype.String, CompareOperator.Equal))) _
'                                                                .Select("CCC_Subcategory", "CCC_Value")
'        End If

'        If String.IsNullorEmpty(suid_Departmentcode) And Not String.IsNullorEmpty(suid_locality) And String.IsNullorEmpty(suid_org) Then

'            swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Country", suid_locality, valtype.String, CompareOperator.Equal), _
'                                                                f.Comparison("CCC_Access", "RBAC", valtype.String, CompareOperator.Equal))) _
'                                                                .Select("CCC_Subcategory", "CCC_Value")
'        End If

'        If String.IsNullorEmpty(suid_Departmentcode) And String.IsNullorEmpty(suid_locality) And Not String.IsNullorEmpty(suid_org) Then

'            swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Jobcode", suid_org, valtype.String, CompareOperator.Equal), _
'                                                                        f.Comparison("CCC_Access", "RBAC", valtype.String, CompareOperator.Equal))) _
'                                                                .Select("CCC_Subcategory", "CCC_Value")
'        End If



'        Dim collect As IEntityCollection = Session.Source.GetCollection(DirectCast(swhere, query), EntityCollectionLoadType.Default)

'        For Each elem In collect
'            If elem.GetValue("CCC_SubCategory") = "uidOrg" Then

'                Dim qreq = Query.From("PersonWantsOrg").Where(f.AndRelation(f.UidComparison("UID_org", elem.GetValue("CCC_Value")),
'                                                                    f.UidComparison("UID_PersonOrdered", suid_personordered),
'                                                                    f.Comparison("Orderstate", "Assigned", ValType.String, CompareOperator.Equal),
'                                                                    f.Comparison("OrderReason", "access", ValType.String, CompareOperator.Equal))).Select("UID_PersonWantsOrg", "Orderdetail1")
'                Dim collectreq As IEntityCollection = Session.Source.GetCollection(qreq)

'                For Each req In collectreq

'                    If Not String.IsNullOrEmpty(req.GetValue("OrderDetail1")) Then
'                        Dim obj As ISingleDbObject = Connection.CreateSingle("PersonwantsOrg", req.GetValue("UID_PersonWantsOrg"))
'                        Dim params As String() = New String() {suid_personordered, "Transfer"}
'                        obj.Custom.CallMethod("Unsubscribe", params)
'                        obj.Save()
'                    End If

'                Next

'            End If



'        Next
'        Return String.Empty

'    End Function
'End Class
