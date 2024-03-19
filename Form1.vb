Imports MySql.Data.MySqlClient
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text





Public Class Form1

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dbconn()


    End Sub

    Private Sub btn_exit_Click(sender As Object, e As EventArgs) Handles btn_exit.Click
        If MsgBox("Are You Sure You Want To Exit.??", vbQuestion + vbYesNo, "VOTE") = vbYes Then
            frm_StudentMain.Show()

            End
        Else
            Return


        End If

    End Sub

    Private Sub btn_login_Click(sender As Object, e As EventArgs) Handles btn_login.Click
        If txt_Password.Text = String.Empty Or txt_Username.Text = String.Empty Then
            MsgBox("Missing Required Fields !!", vbExclamation)
            Return
        Else
            Try
                '             conn.Open()
                '            cmd = New MySqlCommand("SELECT * FROM `tbluser` WHERE `UserName`=@UserName AND `Password`=@Password", conn)
                '           cmd.Parameters.Clear()
                '          cmd.Parameters.AddWithValue("@UserName", txt_Username.Text)
                '         cmd.Parameters.AddWithValue("@Password", txt_Password.Text)
                '        dr = cmd.ExecuteReader
                '       If (dr.Read = True) Then
                'Dim username As String = dr.Item("UserName")
                'Dim password As String = dr.Item("Password")
                'txt_Username.Clear()
                'txt_Password.Clear()
                'Me.Hide()
                'frm_adminMain.Show()
                'Else
                'MsgBox("Warning : Username or Password Invalid !!", vbExclamation, "Vote")
                'End If

                '   conn.Open()
                ' Establish a MySQL connection (replace with your actual connection details)
                '   Using conn As New MySqlConnection(""SELECT * FROM `tbluser` WHERE `UserName`=@UserName AND `Password`=@Password", conn")
                conn.Open()

                ' Create a MySqlCommand
                Using cmd As New MySqlCommand("SELECT * FROM `tbluser` WHERE `UserName`=@UserName AND `Password`=@Password", conn)
                    cmd.Parameters.AddWithValue("@UserName", txt_Username.Text)
                    cmd.Parameters.AddWithValue("@Password", HashPassword(txt_Password.Text))

                    ' Execute the query
                    Using dr As MySqlDataReader = cmd.ExecuteReader()
                        If dr.Read() Then
                            ' User found
                            Dim username As String = dr("UserName").ToString()
                            Dim hashedPasswordFromDB As String = dr("Password").ToString()

                            If hashedPasswordFromDB = HashPassword(txt_Password.Text) Then
                                ' Passwords match
                                txt_Username.Clear()
                                txt_Password.Clear()
                                frm_adminMain.Show()
                            Else
                                MsgBox("Warning: Username or Password Invalid!", vbExclamation, "Vote")
                            End If
                        Else
                            MsgBox("Warning: Username or Password Invalid!", vbExclamation, "Vote")
                        End If
                    End Using
                End Using

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            conn.Close()

        End If


    End Sub

    Private Function HashPassword(ByVal password As String) As String
        Using sha256 As SHA256 = sha256.Create()
            Dim hashedBytes As Byte() = sha256.ComputeHash(Encoding.UTF8.GetBytes(password))
            Dim builder As New StringBuilder()
            For Each b As Byte In hashedBytes
                builder.Append(b.ToString("x2"))
            Next
            Return builder.ToString()

        End Using
    End Function


    Private Sub txt_Password_TextChanged(sender As Object, e As EventArgs) Handles txt_Password.TextChanged

    End Sub
End Class
