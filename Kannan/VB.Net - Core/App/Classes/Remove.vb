﻿Public Class Remove
    Public Function CCC_RemoveAccess(ByVal suid_Departmentcode As String, ByVal suid_locality As String, ByVal suid_org As String, ByVal suid_personordered As String) As String

	Dim f As ISqlFormatter = Connection.SqlFormatter
	Dim swhere As Query
	
	If Not String.IsNullorEmpty(suid_Departmentcode) And Not String.IsNullorEmpty(suid_locality) And Not String.IsNullorEmpty(suid_org) Then
	
		swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Jobcode",suid_org,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Departmentcode",suid_Departmentcode,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Country",suid_locality,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Access","RBAC",valtype.String,CompareOperator.Equal))) _
															.Select("CCC_Subcategory","CCC_Value")	
	End If
	
	If Not String.IsNullorEmpty(suid_Departmentcode) And Not String.IsNullorEmpty(suid_locality) And String.IsNullorEmpty(suid_org) Then
	
		swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Departmentcode",suid_Departmentcode,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Country",suid_locality,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Access","RBAC",valtype.String,CompareOperator.Equal))) _
															.Select("CCC_Subcategory","CCC_Value")
															
	End If
	
	If Not String.IsNullorEmpty(suid_Departmentcode) And String.IsNullorEmpty(suid_locality) And Not String.IsNullorEmpty(suid_org) Then
	
		swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Jobcode",suid_org,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Departmentcode",suid_Departmentcode,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Access","RBAC",valtype.String,CompareOperator.Equal))) _
															.Select("CCC_Subcategory","CCC_Value")	
															
	End If	
	
	If String.IsNullorEmpty(suid_Departmentcode) And Not String.IsNullorEmpty(suid_locality) And Not String.IsNullorEmpty(suid_org) Then
	
		swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Jobcode",suid_org,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Country",suid_locality,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Access","RBAC",valtype.String,CompareOperator.Equal))) _
															.Select("CCC_Subcategory","CCC_Value")	
	End If
	
	If Not String.IsNullorEmpty(suid_Departmentcode) And String.IsNullorEmpty(suid_locality) And String.IsNullorEmpty(suid_org) Then
	
		swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Departmentcode",suid_Departmentcode,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Access","RBAC",valtype.String,CompareOperator.Equal))) _
															.Select("CCC_Subcategory","CCC_Value")	
	End If
	
	If String.IsNullorEmpty(suid_Departmentcode) And Not String.IsNullorEmpty(suid_locality) And String.IsNullorEmpty(suid_org) Then
	
		swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Country",suid_locality,valtype.String,CompareOperator.Equal), _
															f.Comparison("CCC_Access","RBAC",valtype.String,CompareOperator.Equal))) _
															.Select("CCC_Subcategory","CCC_Value")	
	End If
	
	If String.IsNullorEmpty(suid_Departmentcode) And String.IsNullorEmpty(suid_locality) And Not String.IsNullorEmpty(suid_org) Then
	
		swhere = Query.From("CCC_Access").Where(f.AndRelation(f.Comparison("CCC_Jobcode",suid_org,valtype.String,CompareOperator.Equal), _
																	f.Comparison("CCC_Access","RBAC",valtype.String,CompareOperator.Equal))) _
															.Select("CCC_Subcategory","CCC_Value")	
	End If
	

	
	Dim collect As IEntityCollection = Session.Source.GetCollection(DirectCast(swhere,query),EntityCollectionLoadType.Default)

		For Each elem In collect
			If elem.GetValue("CCC_SubCategory") = "uidOrg" Then

				Dim qreq = Query.From("PersonWantsOrg").Where(f.AndRelation(f.UidComparison("UID_org", elem.GetValue("CCC_Value")),
																	f.UidComparison("UID_PersonOrdered", suid_personordered),
																	f.Comparison("Orderstate", "Assigned", ValType.String, CompareOperator.Equal),
																	f.Comparison("OrderReason", "access", ValType.String, CompareOperator.Equal))).Select("UID_PersonWantsOrg", "Orderdetail1")
				Dim collectreq As IEntityCollection = Session.Source.GetCollection(qreq)

				For Each req In collectreq

					If Not String.IsNullOrEmpty(req.GetValue("OrderDetail1")) Then
						Dim obj As ISingleDbObject = Connection.CreateSingle("PersonwantsOrg", req.GetValue("UID_PersonWantsOrg"))
						Dim params As String() = New String() {suid_personordered, "Transfer"}
						obj.Custom.CallMethod("Unsubscribe", params)
						obj.Save()
					End If

				Next

			End If



	Next
	Return String.Empty

End Function
End Class
