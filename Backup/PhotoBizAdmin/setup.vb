Imports System.Xml

Public Class setup

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        
        If vaildate() Then
            writeXmlfile()
            Form1.workpath = txtworkfolder.Text
            Form1.workshare = txtworkshare.Text
            Form1.order = txtorder.Text
            Close()
        Else
            Exit Sub
        End If
       

    End Sub

    Private Function vaildate() As Boolean
        If txtworkfolder.Text = "" Then
            MsgBox("Please enter a value for the work folder.")
            Return False
        End If
        If Not IO.Directory.Exists(txtworkfolder.Text) Then
            MsgBox("The work share folder path entered does not exist!  Please try again!  ex. \\computername\horse show work")
            Return False
        End If
        If txtworkshare.Text = "" Then
            MsgBox("Please enter a value for the work share folder.")
            Return False
        End If
        If Not IO.Directory.Exists(txtworkshare.Text) Then
            MsgBox("The work share folder path entered does not exist!  Please try again!  ex. \\computername\horse show")
            Return False
        End If
        If txtorder.Text = "" Then
            MsgBox("Please enter a value for the order folder.")
            Return False
        End If
        If Not IO.Directory.Exists(txtorder.Text) Then
            MsgBox("The order share folder path entered does not exist!  Please try again!  ex. \\computername\orders\orders")
            Return False
        End If
        Return True
    End Function
    Private Sub writeXmlfile()
        Try
            Dim writer As New XmlTextWriter(Application.StartupPath & "setup.xml", System.Text.Encoding.UTF8)
            writer.WriteStartDocument(True)
            writer.Formatting = Formatting.Indented
            writer.Indentation = 2
            writer.WriteStartElement("Setup")

            ' writer.WriteStartElement("Product")
            writer.WriteStartElement("setup_workfolder")
            writer.WriteString(txtworkfolder.Text)
            writer.WriteEndElement()
            writer.WriteStartElement("setup_worksharefolder")
            writer.WriteString(txtworkshare.Text)
            writer.WriteEndElement()
            writer.WriteStartElement("setup_orderfolder")
            writer.WriteString(txtorder.Text)
            writer.WriteEndElement()


            writer.WriteEndElement()
            writer.WriteEndDocument()
            writer.Close()

        Catch e As Exception
            Console.WriteLine("Exception: {0}", e.ToString())
        End Try
    End Sub
End Class