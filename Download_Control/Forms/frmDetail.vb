Imports System.IO
Imports System.Net
Imports System.Threading
Public Class frmDetail
    Inherits System.Windows.Forms.Form

    Public _DownloadItem As DownloadItem

    Private Sub frmDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            'PictureBox1.Image = GetImage(_DownloadItem.ScreenShot)
            lblName.Text = _DownloadItem.Name
            lblDetail.Text = _DownloadItem.TemplateFile

            URL_TO_DOWNLOAD_MESSAGE = _DownloadItem.PreviewUrl
        Catch ex As Exception
            MessageBox.Show("Sorry, Unable to loading.", "Loading", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnDownload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDownload.Click

        'VERIFY A DIRECTORY WAS PICKED AND THAT IT EXISTS
        If Not IO.Directory.Exists(DIR_TO_SAVE_MESSAGE) Then
            MessageBox.Show("Not a valid directory to download to, please pick a valid directory", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        'DO THE DOWNLOAD
        Try

            Dim _ctlViewDownload As New ctlViewDownload()

            Application.DoEvents()
            _ctlViewDownload.Top = sl * 90
            _ctlViewDownload.Tag = sl.ToString()

            _ctlViewDownload.lblProgress.Text = URL_TO_DOWNLOAD_MESSAGE
            _ctlViewDownload.lblUrl.Text = _DownloadItem.Name
            listctlViewDownload.Add(_ctlViewDownload)

            Me.Hide()
            _frmViewDownloads.Show()
            _frmViewDownloads.Activate()
            _frmViewDownloads.BringToFront()
            sl = sl + 1

            Application.DoEvents()
            Dim MyThreade As System.Threading.Thread = New System.Threading.Thread(AddressOf Me.Download)
            MyThreade.Start(_ctlViewDownload)

            Application.DoEvents()
            Me.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Function GetFileNameFromURL(ByVal URL As String) As String
        If URL.IndexOf("/"c) = -1 Then Return String.Empty
        Return "\" & URL.Substring(URL.LastIndexOf("/"c) + 1)
    End Function

    Private Sub Download(ByVal _ctlViewDownload As ctlViewDownload)
        Application.DoEvents()
        _ctlViewDownload.DownloadFileWithProgress(URL_TO_DOWNLOAD_MESSAGE, DIR_TO_SAVE_MESSAGE.TrimEnd("\"c) & GetFileNameFromURL(URL_TO_DOWNLOAD_MESSAGE))
    End Sub

End Class