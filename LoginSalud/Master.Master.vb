Public Class Master
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("tusuario") = 2 Then
            hide1.Visible = False
            hide2.Visible = False
            hide3.Visible = False
        ElseIf Session("tusuario") = 1 Then
            hide1.Visible = True
            hide2.Visible = True
            hide3.Visible = True
        End If
    End Sub

End Class