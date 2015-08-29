Imports Microsoft.VisualBasic.FileIO
Imports System.Xml
Imports System.IO

Imports System.Drawing.Imaging

Public Class print
    '
    ' This Prints Avery 5160/8160 Address Lables and 5163 Shipping Labels
    ' I was only using 4 lines, I've included coordinates for a 5 line per label
    ' It would be a 2nd Address line, adjust the lines accordingly

    ' This example is using a BindingSource with a Table as the DataSource
    ' Adjust the 'Text String' in DrawString as Needed to fit your DataSource
    Dim bsList As New BindingSource

    ' Variables used in this program
    Dim x, y As Integer ' x= horiz ; y = vertical - These are the current print coordinates
    Dim mNextTop(10) ' Starting y Position for each label on the page 
    Dim mNextAcross(3) ' Starting x Position for each label on the page 
    Dim mLabelsDown, mLabelsAcross As Integer ' 10x3 and 5x2 for Address and Shipping Labels, Respectively - Set w/SetLabelType
    Dim mStartRow, mStartCol As Integer '  Set the starting row and column for the first page of labels
    Dim sCount As Integer ' Counter that compares to mStartingLabel to decide when the first label prints.
    ' This is so you don't have to waste a partially printed page of labels.  You have a page of labels
    ' where the 1st 6 have been used, set this value to 7 and printing will start there on the 1st page only.
    ' Label count starts with upper left and goes left to right advancing each line
    Dim pindex As Integer ' DataSource Index of currently printing label
    Dim mCSZ As String ' City, St  Zip for Label

    Dim PrintDialog1 As New PrintDialog ' You can also pull this from the ToolBox
    '
    ' These values should be set with form controls (ComboBox, CheckBox, etc.)
    Dim mLabelType As String = "5160 - address labels"
    'Dim mLabelType As String = "5160 - Address Labels"
    Dim mPrintReturn As Boolean = True ' Print Return Address when printing Shipping Labels
    Dim mStartingLabel As Integer  ' On the 1st page, start printing at this label - Don't let it exceed the total labels on the page
    Dim mFont As String = "Microsoft Sans Serif" ' Font used for printing
    Dim ds As New DataSet
    ' sCount should also be set from a form control before printing

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' This is where I get my DataSource
        ' Get_Data()
        For Each foundDirectory As String In FileSystem.GetDirectories(Form1.order)
            If IO.File.Exists(foundDirectory & "\customerinfo.xml") Then
                '' MsgBox(foundDirectory)
                ds.ReadXml(foundDirectory & "\customerinfo.xml")

                ''  Dim reader As New XmlTextReader(foundDirectory & "\customerinfo.xml")

            End If
        Next



        Me.bsList.DataSource = ds.Tables("Customer")
        '  MsgBox(bsList.Count)
        ' Call this after you pick which type of label to print 
        SetLabelType()
    End Sub

    Private Sub btnPrint_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If txtStart.Text = "" Then
            MsgBox("Please add a value to the start label")
            Exit Sub
        End If
        mStartingLabel = txtStart.Text
        '
        ' I have a Boolean "dPrint" in my Table that is True for the Labels I want to Print
        '  bsList.Filter = "dPrint = True"
        '  bsList.Sort = "dCompany"
        sCount = 1 ' This is the starting position of the 1st label on the 1st page - see above.
        pindex = 0 ' Index for you're DataSource - BindingSource, DataView, Etc.

        PrintDialog1.Document = PrintDocument1

        If bsList.Count > 0 Then ' Make sure at least one label is marked to print
            If PrintDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                Try
                    PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
                    PrintDocument1.Print()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        End If

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Drag or Double-Click PrintDocument from the ToolBox

        ' Max Label length should be about 40 chars. - normal mix of caps and lower case seems to work ok
        ' If your DataSource is All Caps it may be less
        '
        For j = 1 To mLabelsDown
            '
            y = mNextTop(j)
            '
            For i = 1 To mLabelsAcross
                '
                x = mNextAcross(i)
                '
                If mLabelType = "5163 - Shipping Labels" And mPrintReturn Then
                    ' Print Return Label - Shipping Labels Only
                    If sCount >= mStartingLabel Then ' On the 1st page only, start printing at the mStartingLabel selected label position
                        Try
                            Using the_font As New Font(mFont, 8, FontStyle.Regular)
                                '                e.Graphics.DrawString(tbReturn.Text, the_font, Brushes.Black, x, y)
                            End Using
                        Catch ex As Exception
                            ' Keep Null Values from causing an error if they are present
                        End Try

                    End If

                End If

                If sCount >= mStartingLabel Then ' On the 1st page only, start printing at the mStartingLabel selected label position

                    Try
                        ' Set font and print at coordinate
                        Using the_font As New Font(mFont, 9, FontStyle.Regular)
                            ' Define City, State  Zip Code
                            While bsList(pindex)("Customer_city") = ""
                                pindex = pindex + 1
                            End While


                            mCSZ = bsList(pindex)("Customer_city") & ", " & bsList(pindex)("Customer_state") & "  " & bsList(pindex)("Customer_zip")
                            If mLabelType = "5163 - Shipping Labels" Then
                                ' Shipping Label - Print 120 over and 100 down
                                e.Graphics.DrawString(bsList(pindex)("Customer_Fullname"), the_font, Brushes.Black, x + 120, y + 100)
                                e.Graphics.DrawString(bsList(pindex)("Customer_address"), the_font, Brushes.Black, x + 120, y + 15 + 100)
                                e.Graphics.DrawString(mCSZ, the_font, Brushes.Black, x + 120, y + 30 + 100)
                                '  e.Graphics.DrawString(mCSZ, the_font, Brushes.Black, x + 120, y + 45 + 100)
                                'e.Graphics.DrawString("5th Line", the_font, Brushes.Black, x + 120, y + 60 + 100)
                            Else
                                ' Address Label
                                e.Graphics.DrawString(bsList(pindex)("Customer_Fullname").ToString.ToUpper, the_font, Brushes.Black, x + 20, y)
                                e.Graphics.DrawString(bsList(pindex)("Customer_address").ToString.ToUpper, the_font, Brushes.Black, x + 20, y + 15)
                                e.Graphics.DrawString(mCSZ.ToUpper, the_font, Brushes.Black, x + 20, y + 30)
                                'e.Graphics.DrawString(mCSZ, the_font, Brushes.Black, x, y + 45)
                                'e.Graphics.DrawString("5th Line", the_font, Brushes.Black, x, y + 60)
                            End If
                            '   End If
                            '
                        End Using
                    Catch ex As Exception
                        ' Keep Null Values from causing an error if they are present
                    End Try
                    '
                    pindex = pindex + 1
                    '
                    ' If EOF Exit
                    If pindex > bsList.Count - 1 Then
                        Exit For
                    End If
                    '
                End If
                '
                ' Once this has passed it's count on the 1st page, it's Irrelevant 
                sCount = sCount + 1
                '
            Next
            '
            ' If EOF Exit
            If pindex > bsList.Count - 1 Then
                Exit For
            End If
            '
        Next
        '
        ' if page is full And Not EOF, print the next page
        If pindex <= bsList.Count - 1 Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub

    Private Sub SetLabelType()
        If mLabelType = "5163 - Shipping Labels" Then
            ' 5163 Shipping Labels

            ' Set the number of labels per page
            mLabelsDown = 5
            mLabelsAcross = 2

            ' y value for top of each new label (5 Rows)
            mNextTop(1) = 50
            mNextTop(2) = 250
            mNextTop(3) = 450
            mNextTop(4) = 650
            mNextTop(5) = 850

            ' Starting x value for each label column (2 columns)
            mNextAcross(1) = 10
            mNextAcross(2) = 415
            '
        Else
            ' 8160 or 5160 Address Labels 

            ' Set the number of labels per page
            mLabelsDown = 10
            mLabelsAcross = 3

            ' y value for top of each new label (10 Rows)
            mNextTop(1) = 50
            mNextTop(2) = 150
            mNextTop(3) = 250
            mNextTop(4) = 350
            mNextTop(5) = 450
            mNextTop(6) = 550
            mNextTop(7) = 650
            mNextTop(8) = 750
            mNextTop(9) = 850
            mNextTop(10) = 950
            '
            ' Starting x value for each label column (3 columns)
            mNextAcross(1) = 0
            mNextAcross(2) = 270
            mNextAcross(3) = 545
            '
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        buildEmail()
        MsgBox("Email List Complete")
    End Sub
    Private Sub buildEmail()
        Dim custname As String = ""
        Dim custemail As String = ""
        For Each foundDirectory As String In FileSystem.GetDirectories(Form1.order)
            If IO.File.Exists(foundDirectory & "\customerinfo.xml") Then
                '' MsgBox(foundDirectory)

                Dim reader As New XmlTextReader(foundDirectory & "\customerinfo.xml")
                While reader.Read()
                    If reader.NodeType = XmlNodeType.Element Then

                        If reader.Name = "Customer_Fullname" Then
                            reader.Read()
                            '  MsgBox(reader.Value)
                            custname = reader.Value
                        End If

                        If reader.Name = "Customer_email" Then
                            reader.Read()
                            ' MsgBox(reader.Value)
                            If reader.Value.Trim <> "" Then
                                custemail = reader.Value
                                My.Computer.FileSystem.WriteAllText("c:\orders\customeremail.txt", custname & "," & custemail & vbCrLf, True)
                            End If
                        End If
                        '' End If

                    End If
                End While
                reader.Close()
            End If
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form2.ShowDialog()
    End Sub

    Private Sub btnSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetup.Click
        Dim setup As New setup
        setup.ShowDialog()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        GetFiles(Form1.workpath)
        MsgBox("Complete")
    End Sub

    Dim position As Integer = 1

    Public Sub GetFiles(ByVal path As String)

        If File.Exists(path) Then


            ' This path is a file

            ProcessFile(path)

        ElseIf Directory.Exists(path) Then

            ' This path is a directory

            ProcessDirectory(path)

        End If

    End Sub

    ' Process all files in the directory passed in, recurse on any directories

    ' that are found, and process the files they contain.

    Public Sub ProcessDirectory(ByVal targetDirectory As String)

        ' Process the list of files found in the directory.

        Dim fileEntries As String() = Directory.GetFiles(targetDirectory)
        ''  Dim fn As String
        For Each fileName As String In fileEntries
            If File.Exists(Replace(fileName, Form1.workpath, Form1.workshare)) Then
                Exit For
            End If
            ProcessFile(fileName)

        Next
        '   Dim x As New StreamWriter(fn.Substring(0, fn.LastIndexOf("\") & "\aaa.txt"))
        ' Recurse into subdirectories of this directory.

        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)

        For Each subdirectory As String In subdirectoryEntries

            ProcessDirectory(subdirectory)

        Next

    End Sub

    ' Insert logic for processing found files here.

    Public Sub ProcessFile(ByVal path As String)

        SaveJPGWithCompressionSetting(path, Replace(path, Form1.workpath, Form1.workshare), 65)
        position += 1

    End Sub

    Private Sub SaveJPGWithCompressionSetting(ByVal inimage As _
    String, ByVal szFileName As String, ByVal lCompression _
    As Long)
        ' Dim image As Image

        If inimage.ToUpper.Contains(".JPG") Then
            Dim bmi As Bitmap = Image.FromFile(inimage)
            Dim eps As EncoderParameters = New EncoderParameters(1)
            eps.Param(0) = New EncoderParameter(Encoder.Quality, _
                lCompression)
            Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
            If Not IO.Directory.Exists(szFileName) Then
                IO.Directory.CreateDirectory(szFileName.Substring(0, szFileName.LastIndexOf("\")))
            End If
            bmi.Save(szFileName, ici, eps)
            ' image.Save(
        End If
       

    End Sub

    Private Function GetEncoderInfo(ByVal mimeType As String) _
    As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next j
        Return Nothing
    End Function
End Class