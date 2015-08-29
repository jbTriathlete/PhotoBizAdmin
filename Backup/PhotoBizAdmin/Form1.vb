Imports Microsoft.VisualBasic.FileIO
'Imports Photoshop
Imports System.Xml

Public Class Form1
    Dim appRef As New Photoshop.Application

    Dim appRefBatch As New Photoshop.Application
    Dim currentDoc As Photoshop.Document
    Dim returnValue As System.IO.DirectoryInfo

    Public workpath As String
    Public workshare As String
    Public order As String

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        checksetup()
        setup()
        
    End Sub

    Private Sub checksetup()
        If Not IO.File.Exists(Application.StartupPath() & "setup.xml") Then
            Dim setup As New setup
            setup.ShowDialog()
        Else
            Dim ds As New System.Data.DataSet
            ds.ReadXml(Application.StartupPath() & "setup.xml")

            For xcnt = 0 To ds.Tables(0).Rows.Count - 1
                workpath = ds.Tables(0).Rows(xcnt).Item("setup_workfolder")
                If workpath.Last <> "\" Then
                    workpath = workpath & "\"
                End If
                workshare = ds.Tables(0).Rows(xcnt).Item("setup_worksharefolder")
                If workshare.Last <> "\" Then
                    workshare = workshare & "\"
                End If
                order = ds.Tables(0).Rows(xcnt).Item("setup_orderfolder")
                If order.Last <> "\" Then
                    order = order & "\"
                End If
            Next
        End If
    End Sub

    Private Sub setup()
        'Label3.Text = ""
        txtNotes.Text = ""
        DataGridView1.Rows.Clear()
        For Each foundDirectory As String In FileSystem.GetDirectories(order)
            If Not foundDirectory.Contains("@") Then

                DataGridView1.RowCount = DataGridView1.RowCount + 1
                DataGridView1.Item("OrderName", DataGridView1.RowCount - 1).Value = foundDirectory.Remove(0, order.Length)
                DataGridView1.Item("numberofpics", DataGridView1.RowCount - 1).Value = getpiccount(foundDirectory)
                DataGridView1.Item("amountDue", DataGridView1.RowCount - 1).Value = getamtdue(foundDirectory)
                returnValue = FileSystem.GetDirectoryInfo(foundDirectory)
                DataGridView1.Item("createtime", DataGridView1.RowCount - 1).Value = returnValue.CreationTime

            End If
        Next
        lblQ.Text = "Items in Que :  " & DataGridView1.RowCount
        DataGridView1.Sort(DataGridView1.Columns("createtime"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Function getpiccount(ByVal indir As String) As String
        Dim rtrnstr As String
        If IO.File.Exists(indir & "\customerinfo.xml") Then
            '' MsgBox(foundDirectory)

            Dim reader As New XmlTextReader(indir & "\customerinfo.xml")
            While reader.Read()
                If reader.NodeType = XmlNodeType.Element Then

                    If reader.Name = "Customer_pics" Then
                        reader.Read()
                        rtrnstr = reader.Value
                        reader.Close()
                        Return rtrnstr
                    End If
                End If
            End While
            reader.Close()
        End If
        Return 0
    End Function

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim founddirectory As String
        If e.ColumnIndex < 2 Then
            '  For Each foundDirectory As String In FileSystem.GetDirectories("c:\orders\orders\" & DataGridView1.Item("OrderName", e.RowIndex).Value)
            founddirectory = order & DataGridView1.Item("OrderName", e.RowIndex).Value
            processJPgs(founddirectory)
            getNote(founddirectory)
            'Next
        Else
            FileSystem.RenameDirectory(order & "\" & DataGridView1.Item("OrderName", e.RowIndex).Value, "@" & DataGridView1.Item("OrderName", e.RowIndex).Value)
            setup()
        End If
       
    End Sub

    Private Sub getNote(ByVal indir As String)
        If IO.File.Exists(indir & "\customerinfo.xml") Then
            '' MsgBox(foundDirectory)

            Dim reader As New XmlTextReader(indir & "\customerinfo.xml")
            While reader.Read()
                If reader.NodeType = XmlNodeType.Element Then

                    If reader.Name = "Customer_notes" Then
                        reader.Read()
                        '  MsgBox(reader.Value) 
                        txtNotes.Text = reader.Value
                        reader.Close()
                    End If
                End If
            End While
            reader.Close()
        End If

    End Sub

    Private Function getamtdue(ByVal indir As String) As String
        Dim str As String
        If IO.File.Exists(indir & "\customerinfo.xml") Then
            '' MsgBox(foundDirectory)

            Dim reader As New XmlTextReader(indir & "\customerinfo.xml")
            While reader.Read()
                If reader.NodeType = XmlNodeType.Element Then

                    If reader.Name = "Customer_total" Then
                        reader.Read()
                        str = reader.Value
                        reader.Close()
                        Return str
                    End If
                End If
            End While
            reader.Close()
        End If

        Return 0
    End Function

    Private Sub processJPgs(ByVal inPath As String)
        Dim folders() As String = IO.Directory.GetDirectories(inPath)
        Dim files() As String = IO.Directory.GetFiles(inPath, "*.jpg")
        For Each fl As String In files
            currentDoc = appRef.Open(fl)
        Next
        If folders.Count > 0 Then
            For Each folder In folders
                files = IO.Directory.GetFiles(folder, "*.jpg")
                For Each fl As String In files
                    currentDoc = appRef.Open(fl)
                Next
            Next
        End If
        
    End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim ofd As New OpenFileDialog
    '    Dim res As MsgBoxResult
    '    Dim pic As New PictureBox
    '    ofd.Multiselect = True

    '    ofd.ShowDialog()
    '    Label3.Text = "Downloading"
    '    If Not IO.Directory.Exists("c:\horse show\" & txtClass.Text & "\" & txtRun.Text) Then
    '        IO.Directory.CreateDirectory("c:\horse show\" & txtClass.Text & "\" & txtRun.Text)
    '    Else
    '        res = MsgBox("This directory already exists.  Are you sure this is the correct folder?", MsgBoxStyle.YesNo)
    '        If res = MsgBoxResult.No Then
    '            Exit Sub
    '        End If

    '    End If
    '    For Each file In ofd.FileNames

    '        Try
    '            Dim str As String
    '            str = file.Substring(file.LastIndexOf("\") + 1, file.Length - file.LastIndexOf("\") - 1)

    '            If IO.File.Exists("c:\horse show\" & txtClass.Text & "\" & txtRun.Text & "\" & str) Then
    '                '   rep = xsub.ToString & ".jpg"
    '                '   Str = Str.Substring(0, Str.Length - 4) & rep
    '                MsgBox("Files already exist!")
    '                Exit Sub
    '            End If
    '            FileCopy(file, "c:\horse show\" & txtClass.Text & "\" & txtRun.Text & "\" & str)
    '            '  pic.ImageLocation = "c:\horse show\" & txtClass.Text & "\" & txtRun.Text & "\" & str
    '            '  pic.Image.RotateFlip(RotateFlipType.Rotate90FlipXY)


    '        Catch ex As Exception

    '        End Try


    '    Next
    '    Label3.Text = "Download Complete!"

    '    '   MsgBox("Download Complete!")

    'End Sub

    Private Sub btnrefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrefresh.Click
        setup()

    End Sub

    Private Sub FileSystemWatcher1_Changed(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        setup()
    End Sub

    Private Sub btnUtil_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUtil.Click
        print.Show()
    End Sub
End Class
