Imports System.IO
Imports System.Xml
Imports System.Net
'Imports System.Linq
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraBars.Ribbon

Public Class frmDownload

    Dim _DownloadItem As DownloadItem
    Dim DownloadItemList As New List(Of DownloadItem)

    ''' <summary>
    ''' Handles the Resize event of the frmDownload control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub frmDownload_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ResizeControls()
    End Sub

    ''' <summary>
    ''' Handles the Load event of the frmDownload control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub frmDownload_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        SOURCE_FILE_FOR_TEMPLATE = Environment.CurrentDirectory() + "\xmlfeed.xml"
        txtSource.Text = SOURCE_FILE_FOR_TEMPLATE

        'just for testing
        DIR_TO_SAVE_MESSAGE = "C:\\TempDownload001"

        Try
            If Directory.Exists(DIR_TO_SAVE_MESSAGE) = False Then
                Directory.CreateDirectory(DIR_TO_SAVE_MESSAGE)
            End If
        Catch ex As Exception
            MessageBox.Show("Sorry! Unable to get the download di", "Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        ResizeControls()
    End Sub

    ''' <summary>
    ''' Resizes the controls.
    ''' </summary>
    Private Sub ResizeControls()
        Try
            Dim intX As Integer = Me.Width
            Dim intY As Integer = (Me.Height - 80)

            panDownload.Location = New System.Drawing.Point(0, 35)
            panDownload.Size = New System.Drawing.Size(intX, intY)
        Catch ex As Exception
            MessageBox.Show("Sorry! Unable to resize controls.", "Resize Controls", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Handles the Click event of the btnBrowse control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs" /> instance containing the event data.</param>
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        Try
            Dim strFileName As String

            'strFileName = GetSelectedFileName()
            strFileName = SOURCE_FILE_FOR_TEMPLATE

            If strFileName = String.Empty Then Return
            txtSource.Text = strFileName

            DownloadItemList = GetSelectedXMLNodes(strFileName, "template")
            If DownloadItemList.Count <= 0 Then Return

            LoadGalary(gcDownload, DownloadItemList)
        Catch ex As Exception
            MessageBox.Show("Sorry! Unable to process it.", "Browse", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Gets the name of the selected file.
    ''' </summary><returns></returns>
    Private Function GetSelectedFileName() As String
        Dim stFilePathAndName As String = ""
        Dim openFileDialog1 As New OpenFileDialog

        Try
            openFileDialog1.InitialDirectory = System.Environment.CurrentDirectory
            openFileDialog1.Title = "Open Text File"
            openFileDialog1.Filter = "XML files (*.xml)|*.xml"
            openFileDialog1.FilterIndex = 1
            openFileDialog1.RestoreDirectory = True

            If openFileDialog1.ShowDialog() = DialogResult.OK Then
                stFilePathAndName = openFileDialog1.FileName

                'Dim stFileName As String = ""
                'Dim MyFile As FileInfo = New FileInfo(stFilePathAndName)
                'stFileName = MyFile.Name
            End If
        Catch ex As Exception
            MessageBox.Show("Sorry! Unable to select xml file.", "Get Selected File Name", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return stFilePathAndName
    End Function

    ''' <summary>
    ''' Gets the selected XML nodes.
    ''' </summary>
    ''' <param name="FileName">Name of the file.</param>
    ''' <param name="TagName">Name of the tag.</param><returns></returns>
    Private Function GetSelectedXMLNodes(ByVal FileName As String, ByVal TagName As String) As List(Of DownloadItem)
        Dim xmlnode As XmlNodeList
        Dim xmldoc As New XmlDataDocument()
        Dim DownloadItemList As New List(Of DownloadItem)

        Try
            Dim fs As New FileStream(FileName, FileMode.Open, FileAccess.Read)
            xmldoc.Load(fs)
            xmlnode = xmldoc.GetElementsByTagName(TagName)

            For i = 0 To xmlnode.Count - 1
                Dim item As DownloadItem = New DownloadItem
                item.Template = i.ToString()
                If (xmlnode(i).ChildNodes.Count > 0) Then item.Name = xmlnode(i).ChildNodes.Item(0).InnerText.Trim()
                If (xmlnode(i).ChildNodes.Count > 1) Then item.Category = xmlnode(i).ChildNodes.Item(1).InnerText.Trim()

                Try
                    If (xmlnode(i).ChildNodes.Count > 2) Then item.ReleaseDate = Date.Parse(xmlnode(i).ChildNodes.Item(2).InnerText.Trim())
                Catch ex As Exception

                End Try

                If (xmlnode(i).ChildNodes.Count > 3) Then item.Version = xmlnode(i).ChildNodes.Item(3).InnerText.Trim()
                If (xmlnode(i).ChildNodes.Count > 4) Then item.ScreenShot = xmlnode(i).ChildNodes.Item(4).InnerText.Trim()
                If (xmlnode(i).ChildNodes.Count > 5) Then item.TemplateFile = xmlnode(i).ChildNodes.Item(5).InnerText.Trim()
                If (xmlnode(i).ChildNodes.Count > 6) Then item.PreviewUrl = xmlnode(i).ChildNodes.Item(6).InnerText.Trim()
                If (xmlnode(i).ChildNodes.Count > 7) Then item.TemplateFileMD5 = xmlnode(i).ChildNodes.Item(7).InnerText.Trim()
                item.SlNo = i
                DownloadItemList.Add(item)
            Next i

        Catch ex As Exception
            MessageBox.Show("Sorry! Unable to read from xml file.", "Get Selected XML Nodes", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return DownloadItemList
    End Function

    ''' <summary>
    ''' Loads the galary.
    ''' </summary>
    ''' <param name="_gControl">The _g control.</param>
    ''' <param name="xmlnode">The xmlnode.</param>
    Private Sub LoadGalary(ByRef _gControl As GalleryControl, ByVal DownloadItemList As List(Of DownloadItem))
        Try
            Dim Load As Boolean
            Dim CatageryList As List(Of String) = New List(Of String)
            For Each itemD As DownloadItem In DownloadItemList
                Load = True
                For Each itemC As String In CatageryList
                    If itemC = itemD.Category Then
                        Load = False
                        Exit For
                    End If
                Next

                If Load = True Then CatageryList.Add(itemD.Category)
            Next

            For Each itm As String In CatageryList

                Dim group1 As GalleryItemGroup = New GalleryItemGroup()
                group1.Caption = itm
                _gControl.Gallery.ItemImageLayout = ImageLayoutMode.ZoomInside
                _gControl.Gallery.ImageSize = New Size(100, 75)
                _gControl.Gallery.ShowItemText = True
                _gControl.Gallery.Groups.Add(group1)

                Dim NewDownloadItemList As List(Of DownloadItem) = New List(Of DownloadItem)

                For Each itemD As DownloadItem In DownloadItemList
                    If itm = itemD.Category Then
                        NewDownloadItemList.Add(itemD)
                    End If
                Next

                ProgressBar1.Visible = True
                ProgressBar1.Minimum = 0 : ProgressBar1.Value = 0
                If (NewDownloadItemList.Count > 0) Then ProgressBar1.Maximum = NewDownloadItemList.Count

                For j = 0 To NewDownloadItemList.Count - 1
                    Application.DoEvents()
                    ProgressBar1.Value = ProgressBar1.Value + 1

                    Dim description As String = ""
                    If NewDownloadItemList(j).PreviewUrl <> Nothing Then
                        Dim Temp = NewDownloadItemList(j).PreviewUrl.Split("/")
                        If Temp.Count > 0 Then description = Temp(Temp.Count - 1)
                    End If

                    Dim lNewGalleryItem As GalleryItem = New GalleryItem(GetImage(NewDownloadItemList(j).ScreenShot), NewDownloadItemList(j).Name, description)
                    lNewGalleryItem.Tag = NewDownloadItemList(j).SlNo.ToString()

                    group1.Items.Add(lNewGalleryItem)
                Next j

            Next

            ProgressBar1.Visible = False
        Catch ex As Exception
            MessageBox.Show("Sorry! Unable to Load Galary.", "Load Galary", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ''' <summary>
    ''' Gets the image.
    ''' </summary>
    ''' <param name="sURL">The s URL.</param><returns></returns>
    Public Function GetImage(ByVal sURL As String) As Image
        Dim newImage As Image
        Dim objImage As MemoryStream
        Dim objwebClient As WebClient = New WebClient()

        Try
            Application.DoEvents()
            sURL = Trim(sURL)
            If Not sURL.ToLower().StartsWith("http://") Then sURL = "http://" & sURL

            objImage = New MemoryStream(objwebClient.DownloadData(sURL))
            newImage = Image.FromStream(objImage)
        Catch ex As Exception
            newImage = My.Resources.image_png
            MessageBox.Show("Sorry! Unable to getting the image.", "Get Image", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return newImage
    End Function

    ''' <summary>
    ''' Handles the ItemClick event of the gcDownload_Gallery control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs" /> instance containing the event data.</param>
    Private Sub gcDownload_Gallery_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles gcDownload.Gallery.ItemClick
        Try
            Application.DoEvents()

            _DownloadItem = New DownloadItem()

            Dim _frmDetail As New frmDetail()
            Dim i As Integer = Val(e.Item.Tag)

            If DownloadItemList.Count > i Then
                _frmDetail._DownloadItem = DownloadItemList(i)
                _frmDetail.PictureBox1.Image = e.Item.Image
            End If

            _frmDetail.ShowDialog()
        Catch ex As Exception
            MessageBox.Show("Sorry! Unable to getting the item for download.", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
