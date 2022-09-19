Public Class PersonWantsOrg

    Private _UID_Org As String
    Public Property UID_Org() As String
        Get
            Return _UID_Org
        End Get
        Set(ByVal value As String)
            _UID_Org = value
        End Set
    End Property

    Private _UID_PersonInserted As String
    Public Property UID_PersonInserted() As String
        Get
            Return _UID_PersonInserted
        End Get
        Set(ByVal value As String)
            _UID_PersonInserted = value
        End Set
    End Property

    Private _UID_PersonOrdered As String
    Public Property UID_PersonOrdered() As String
        Get
            Return _UID_PersonOrdered
        End Get
        Set(ByVal value As String)
            _UID_PersonOrdered = value
        End Set
    End Property

    Private _Orderdetail1 As String
    Public Property Orderdetail1() As String
        Get
            Return _Orderdetail1
        End Get
        Set(ByVal value As String)
            _Orderdetail1 = value
        End Set
    End Property

    Private _OrderReason As String
    Public Property OrderReason() As String
        Get
            Return _OrderReason
        End Get
        Set(ByVal value As String)
            _OrderReason = value
        End Set
    End Property

    Public Sub SaveSingle(ByVal objectToSave As PersonWantsOrg)
          Dim strSaveCommand As String = "insert into PersonWantsOrg values('" & objectToSave.UID_Org & "','" & 
            objectToSave.UID_PersonInserted &    "','" & objectToSave.UID_PersonOrdered & "','" & 
            objectToSave.Orderdetail1 & "','" & objectToSave.OrderReason & "')"
         DBConnection.GetInstanc().ExecuteNonQuery(strSaveCommand)

        End Sub




End Class
