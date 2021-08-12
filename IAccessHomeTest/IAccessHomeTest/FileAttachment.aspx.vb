Imports System.IO
Imports System.Data.SqlClient

Public Class FileAttachment
    Inherits System.Web.UI.Page
    Dim constr As String = System.Configuration.ConfigurationManager.AppSettings("constr")
    Dim STRPATH As String = System.Configuration.ConfigurationManager.AppSettings("FileAttachmentPath")
    Dim dt As DataTable = New DataTable()

    Protected Property CSVPath() As String
        Get
            Return DirectCast(ViewState("CSVPath"), String)
        End Get
        Set(ByVal Value As String)
            ViewState("CSVPath") = Value
        End Set
    End Property
    Protected Property CSVData() As String
        Get
            Return DirectCast(ViewState("CSVData"), String)
        End Get
        Set(ByVal Value As String)
            ViewState("CSVData") = Value
        End Set
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        pnlInsert.Visible = True
        PnlSearch.Visible = True

    End Sub
    Protected Sub btnInsertData_Click(sender As Object, e As EventArgs)
        Dim searchValue As String = txtSearch.Text.Trim()
        CSVPath = Server.MapPath("~/TEST.csv")

        dt.Columns.AddRange(New DataColumn(1) {New DataColumn("StringId", GetType(String)), New DataColumn("StringContent", GetType(String))})

        Dim CSVData = File.ReadAllText(CSVPath)
        For Each row As String In CSVData.Split(vbLf)
            If Not String.IsNullOrEmpty(row) Then
                Dim searchValueExist As Boolean = False
                dt.Rows.Add()
                Dim i As Integer = 0
                For Each cell As String In row.Split(","c)
                    dt.Rows(dt.Rows.Count - 1)(i) = cell
                    i += 1
                Next
            End If
        Next

        Try
            Using con As New SqlConnection(constr)
                Using cmd As New SqlCommand("spInsertTable")
                    Using sda As New SqlDataAdapter()
                        cmd.CommandType = CommandType.StoredProcedure
                        cmd.Parameters.AddWithValue("@DataTableTemp", dt)
                        cmd.Connection = con
                        con.Open()
                        cmd.ExecuteScalar()
                        con.Close()
                    End Using
                End Using
            End Using
            lblMessage.Visible = True
            lblMessage.Text = "Insert Data Successfully"
            PnlSearch.Visible = True
        Catch ex As Exception
            PnlSearch.Visible = False
            lblMessage.Text = "Insert Data Failed !! " & ex.Message
        End Try
    End Sub
    Protected Sub btnSearch_Click(sender As Object, e As EventArgs)
        Dim searchValue As String = txtSearch.Text.Trim()

        Dim strSql As String = "SELECT StringID ,StringContent,(LEN(StringContent) - LEN(REPLACE(StringContent,'" + txtSearch.Text.Trim() + "', ''))) / LEN('" + txtSearch.Text.Trim() + "') As MatchTimes from FileAttachmentDetail"

        Using con As New SqlConnection(constr)
            con.Open()
            Using sda As New SqlDataAdapter(strSql, con)
                sda.Fill(dt)
            End Using
            con.Close()
        End Using

        GV.DataSource = dt
        GV.DataBind()
    End Sub
End Class