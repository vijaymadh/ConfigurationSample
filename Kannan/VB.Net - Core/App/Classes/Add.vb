Imports System.Collections.Generic
Imports System.IO
Imports System.Globalization
Imports System.Data
Imports System.Text
Imports System.Environment
Imports VI.DB.Specialized
Imports VI.DataImport
Imports System.Xml

Public Class Add
Public Function CCC_PrerequestAccess(
ByVal sUID_DCCode As String,
ByVal sUID_Org As String,
ByVal sUID_Locality As String,
ByVal sPersonInserted As String,
ByVal sUID_PersonOrdered As String) As String


			Dim f As ISqlFormatter = Connection.SqlFormatter
			Dim sWhere As String = ""
			Dim uidOrg As String = ""
			Dim cccValue As String = ""
			Dim sOrderReason As String = "access"

			Dim sWhere2 = Query.From("CCC_Access").Select("CCC_Value").Where(f.AndRelation(f.Comparison("CCC_JobCode", sUID_Org, ValType.String, CompareOperator.Equal, FormatterOptions.None),
f.Comparison("CCC_DepartmentCode", sUID_DCCode, ValType.String, CompareOperator.Equal, FormatterOptions.None),
f.Comparison("CCC_Country", sUID_Locality, ValType.String, CompareOperator.Equal, FormatterOptions.None))).Select("CCC_Category", "CCC_Subcategory", "CCC_Value").OrderBy("CCC_Category")

			Dim xmlList As Dictionary(Of String, String) = New Dictionary(Of String, String)()
			Dim uid_Org = String.Empty
			Dim sbXml As StringBuilder = New StringBuilder()
			Dim currentApp = String.Empty
			Dim ccc_value As String = String.Empty
			Dim cccValues As IEntityCollection = Session.Source.GetCollection(DirectCast(sWhere2, Query), EntityCollectionLoadType.Default)
			For Each cccValue2 As IEntity In cccValues

				If currentApp <> cccValue2.GetValue("CCC_Category") Then

					If sbXml.Length > 0 Then
						xmlList.Add(uid_Org, sbXml.ToString)
						sbXml.Append("</AppData>")
						ccc_value = String.Empty
						
					End If
					sbXml = New StringBuilder()
					sbXml.Append("<AppData>")
				End If




				If cccValue2.GetValue("CCC_SubCategory") <> "uidOrg" Then

					If cccValue2.GetValue("CCC_SubCategory") = "LoginID" Then
						Dim loginid = Connection.GetSingleProperty("person", "Centralaccount", f.UidComparison("UID_person", sUID_PersonOrdered)).String
						sbXml.Append("<Entry>")
						sbXml.Append("<Key>" & cccValue2.GetValue("CCC_SubCategory").ToString & "</Key>")
						sbXml.Append("<Value>" & loginid & "</Value>")
						sbXml.Append("</Entry>")
					Else
						If cccValue2.GetValue("CCC_SubCategory") = "ID" Then
							Dim userid = Connection.GetSingleProperty("person", "centralaccount", f.UidComparison("UID_person", sUID_PersonOrdered)).String
							sbXml.Append("<Entry>")
							sbXml.Append("<Key>" & cccValue2.GetValue("CCC_SubCategory").ToString & "</Key>")
							sbXml.Append("<Value>" & userid & "</Value>")
							sbXml.Append("</Entry>")
						Else
							If Not sbXml.ToString.Contains(cccValue2.GetValue("CCC_SubCategory")) Then
								ccc_value = CCC_GetCCCvalue(cccValue2.GetValue("CCC_Category"), cccValue2.GetValue("CCC_SubCategory"))
								sbXml.Append("<Entry>")
								sbXml.Append("<Key>" & cccValue2.GetValue("CCC_SubCategory").ToString & "</Key>")
								sbXml.Append("<Value>" & ccc_value & "</Value>")
								sbXml.Append("</Entry>")

							End If

						End If
					End If

				Else
					uid_Org = cccValue2.GetValue("CCC_Value").ToString
					
				End If
				currentApp = cccValue2.GetValue("CCC_Category")

			Next

			xmlList.Add(uid_Org, sbXml.ToString())
			sbXml.Append("</AppData>")
			
			For Each key In xmlList.Keys
				Dim pBag As New PropertyBag()

				pBag.PutValue("UID_Org", key)
				pBag.PutValue("UID_PersonInserted", sPersonInserted)
				pBag.PutValue("UID_PersonOrdered", sUID_PersonOrdered)
				pBag.PutValue("Orderdetail1", xmlList(key))
				pBag.PutValue("OrderReason", sOrderReason)
				Dim iPWO As IEntity = Session.Source.CreateNew("PersonWantsOrg")
				iPWO.CallMethod("FillOrder", pBag)
				
				iPWO.Save(Session)
			Next



			Return "Completed Successfully"
		End Function

		Public Function CCC_GetCCCvalue(ByVal category As String, ByVal subcategory As String) As String
			Dim f As ISqlFormatter = Connection.SqlFormatter
			Dim ccc_value = String.Empty
			Dim final = String.Empty
			Dim swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Access", "RBAC", ValType.String, CompareOperator.Equal),
				f.Comparison("CCC_Category", category, ValType.String, CompareOperator.Equal))).Select("CCC_Subcategory", "CCC_Value")
			Dim cccvalues As IEntityCollection = Session.Source.GetCollection(swhere)
			For Each cccvalue As IEntity In cccvalues
				If cccvalue.GetValue("CCC_Subcategory") = subcategory Then
					If String.IsNullOrEmpty(ccc_value) Then
						ccc_value = cccvalue.GetValue("CCC_Value")
					Else
						If Not ccc_value.Contains(cccvalue.GetValue("CCC_Value")) Then
							ccc_value = String.Concat(ccc_value, ChrW(7), cccvalue.GetValue("CCC_Value"))

						End If
					End If

					final = ccc_value
				End If
			Next
			Return final
		End Function
End Class
