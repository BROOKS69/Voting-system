Imports MySql.Data.MySqlClient
Imports System.IO

Module dbconnection
    Dim result As Boolean
    Public conn As New MySqlConnection
    Public cmd As New MySqlCommand
    Public da As MySqlDataAdapter
    Public dt As DataTable
    Public dr As MySqlDataReader
    Public i As Integer

    Public Function dbconn() As Boolean
        Try
            If conn.State = ConnectionState.Closed Then
                conn.ConnectionString = "server=127.0.0.1;user=root;password=;port=3306;database=election_db"
                'conn.ConnectionString = "server=sql8.freesqldatabase.com;user=sql8680861;password=llbyVuwMpH;port=3306;database=sql8680861"
                result = True

            End If
        Catch ex As Exception
            result = False
            MsgBox("Server Not Connected !", vbExclamation)
        End Try
        Return result
    End Function

End Module
