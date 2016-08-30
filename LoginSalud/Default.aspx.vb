﻿Imports MySql.Data.MySqlClient
Public Class _Default
    Inherits System.Web.UI.Page
    'Dim con As Conexion
    Dim conect As New Conexion
    Dim oComando As MySqlCommand
    Dim conexion As String = conect.CrearConexion.ConnectionString
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Label3.Visible = False
        inputPassword.TextMode = inputPassword.TextMode.Password
    End Sub
    Protected Sub login_Click(sender As Object, e As EventArgs) Handles login.Click
        ingreso()
    End Sub
    Private Sub ingreso()
        Dim Conectar_ As New MySqlConnection(conexion)
        If Conectar_.State = ConnectionState.Closed Then
            Conectar_.Open()
        End If
        Try
            Using cmd As New MySqlCommand("PA_consulta", Conectar_)
                cmd.CommandTimeout = 900000000
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add("cd", MySqlDbType.VarChar).Value = inputEmail.Text
                cmd.Parameters.Add("nt", MySqlDbType.VarChar).Value = inputPassword.Text
                Dim dt As New DataTable()
                Dim da As New MySqlDataAdapter(cmd)
                da.Fill(dt)
                Dim r As String
                Dim t As String
                If dt.Rows.Count > 0 Then
                    r = dt.Rows(0).Item(1).ToString()
                    Session("usuario") = r
                    t = dt.Rows(0).Item(2).ToString()
                    Session("tusuario") = t
                    Response.Redirect("Principal", False)
                End If
                Conectar_.Close()
                Label3.Visible = True
            End Using
        Catch ex As Exception
            ClientScript.RegisterStartupScript(Me.GetType(), "alert", "alert('Error Ingresar');", True)
        End Try
    End Sub
End Class

