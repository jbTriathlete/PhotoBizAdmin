Public Class Form2
    Public xConn As New Data.SqlClient.SqlConnection

    Dim dsItem As DataSet
    Public Sub dbconnection()
        Dim xstr As String
        Dim xCmd As New SqlClient.SqlCommand
        Dim xCnt As Integer = 0
        xConn = New Data.SqlClient.SqlConnection
        xstr = "Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Photobiz\PhotoBiz.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True"
        xConn.ConnectionString = xstr
        xConn.Open()
    End Sub
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'PhotoBizDataSet.x_Item' table. You can move, or remove it, as needed.
        Me.X_ItemTableAdapter.Fill(Me.PhotoBizDataSet.x_Item)
        dbconnection()

    End Sub
    Private Sub buildgrid()
        Dim xCmd As New SqlClient.SqlCommand
        Dim reader As New SqlClient.SqlDataAdapter
        xCmd.CommandText = "Select xitem,xprice from x_item where xinclude ='True'"
        xCmd.CommandType = CommandType.Text
        xCmd.Connection = xConn

        dsItem = New DataSet("x_item")
        reader.TableMappings.Add("table", "x_item")

        reader.SelectCommand = xCmd
        reader.Fill(dsItem)

        '  refreshgrid(dsItem)
    End Sub
End Class