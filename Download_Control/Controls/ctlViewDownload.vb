
Imports System.Net
Imports System.IO

Public Class ctlViewDownload
    Dim MAX As Integer
    Dim CLENGTH As Integer
    Dim ALLDOWN As Integer
    Public Remarks As String
    Public Event AmountDownloadedChanged(ByVal iNewProgress As Long)
    Public Event FileDownloadSizeObtained(ByVal iFileSize As Long)
    Public Event FileDownloadComplete()
    Public Event FileDownloadFailed(ByVal ex As Exception)

    Private mCurrentFile As String = String.Empty


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Dim count As Integer = 0
        For i = 0 To (Me.Parent.Controls.Count() - 1)
            If Val(Me.Tag) <> i Then
                'Me.Parent.Controls(i).Top = count * 90
                Me.Parent.Controls(i).Location = New Point(0, (count * 90))
                count = count + 1
            End If
        Next
        listctlViewDownload.Remove(Me)
        Me.Parent.Controls.Remove(Me)
    End Sub

    Public ReadOnly Property CurrentFile() As String
        Get
            Return mCurrentFile
        End Get
    End Property
    Public Function DownloadFile(ByVal URL As String, ByVal Location As String) As Boolean
        Try
            mCurrentFile = GetFileName(URL)
            Dim WC As New WebClient
            WC.DownloadFile(URL, Location)
            RaiseEvent FileDownloadComplete()
            Return True
        Catch ex As Exception
            RaiseEvent FileDownloadFailed(ex)
            Return False
        End Try
    End Function

    Private Function GetFileName(ByVal URL As String) As String
        Try
            Return URL.Substring(URL.LastIndexOf("/") + 1)
        Catch ex As Exception
            Return URL
        End Try
    End Function
    Public Function DownloadFileWithProgress(ByVal URL As String, ByVal Location As String) As Boolean
        Dim FS As FileStream
        Try
            mCurrentFile = GetFileName(URL)
            Dim wRemote As WebRequest
            Dim bBuffer As Byte()
            ReDim bBuffer(256)
            Dim iBytesRead As Integer
            Dim iTotalBytesRead As Integer

            FS = New FileStream(Location, FileMode.Create, FileAccess.Write)
            wRemote = WebRequest.Create(URL)
            Dim myWebResponse As WebResponse = wRemote.GetResponse
            CLENGTH = myWebResponse.ContentLength

            RaiseEvent FileDownloadSizeObtained(myWebResponse.ContentLength)
            Dim sChunks As Stream = myWebResponse.GetResponseStream
            Do
                iBytesRead = sChunks.Read(bBuffer, 0, 256)
                FS.Write(bBuffer, 0, iBytesRead)
                iTotalBytesRead += iBytesRead
                If myWebResponse.ContentLength < iTotalBytesRead Then
                    RaiseEvent AmountDownloadedChanged(myWebResponse.ContentLength)
                Else
                    CLENGTH = iTotalBytesRead
                    RaiseEvent AmountDownloadedChanged(iTotalBytesRead)
                End If
            Loop While Not iBytesRead = 0
            sChunks.Close()
            FS.Close()
            RaiseEvent FileDownloadComplete()
            Return True
        Catch ex As Exception
            If Not (FS Is Nothing) Then
                FS.Close()
                FS = Nothing
            End If
            RaiseEvent FileDownloadFailed(ex)
            Return False
        End Try
    End Function

    Public Shared Function FormatFileSize(ByVal Size As Long) As String
        Try
            Dim KB As Integer = 1024
            Dim MB As Integer = KB * KB
            ' Return size of file in kilobytes.
            If Size < KB Then
                Return (Size.ToString("D") & " bytes")
            Else
                Select Case Size / KB
                    Case Is < 1000
                        Return (Size / KB).ToString("N") & "KB"
                    Case Is < 1000000
                        Return (Size / MB).ToString("N") & "MB"
                    Case Is < 10000000
                        Return (Size / MB / KB).ToString("N") & "GB"
                End Select
            End If
        Catch ex As Exception
            Return Size.ToString
        End Try
    End Function

    'FIRES WHEN WE HAVE GOTTEN THE DOWNLOAD SIZE, SO WE KNOW WHAT BOUNDS TO GIVE THE PROGRESS BAR
    Private Sub _Downloader_FileDownloadSizeObtained(ByVal iFileSize As Long) Handles Me.FileDownloadSizeObtained

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf AccessControlObtained))
        Else
            prgProgress.Value = 0
            prgProgress.Maximum = Convert.ToInt32(iFileSize)
            MAX = Convert.ToInt32(iFileSize)
        End If
    End Sub

    'FIRES WHEN DOWNLOAD IS COMPLETE
    Private Sub _Downloader_FileDownloadComplete() Handles Me.FileDownloadComplete

        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf AccessControlComplete))
        Else
            prgProgress.Value = prgProgress.Maximum
            'MessageBox.Show("File Download Complete")
            lblProgress.Text = "File Download Complete"
        End If

    End Sub

    'FIRES WHEN DOWNLOAD FAILES. PASSES IN EXCEPTION INFO
    Private Sub _Downloader_FileDownloadFailed(ByVal ex As System.Exception) Handles Me.FileDownloadFailed


        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf AccessControlFailed))
        Else
            'MessageBox.Show("An error has occured during download: " & ex.Message)
            lblProgress.Text = "An error has occured during download"
        End If

    End Sub

    'FIRES WHEN MORE OF THE FILE HAS BEEN DOWNLOADED
    Private Sub _Downloader_AmountDownloadedChanged(ByVal iNewProgress As Long) Handles Me.AmountDownloadedChanged
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf AccessControl))
        Else
            prgProgress.Value = Convert.ToInt32(iNewProgress)
            lblProgress.Text = Me.FormatFileSize(iNewProgress) & " of " & Me.FormatFileSize(MAX) & " downloaded"
        End If
    End Sub

    Private Sub AccessControl()
        prgProgress.Value = Convert.ToInt32(CLENGTH)
        lblProgress.Text = Me.FormatFileSize(CLENGTH) & " of " & Me.FormatFileSize(MAX) & " downloaded"
    End Sub

    Private Sub AccessControlFailed()
        'MessageBox.Show("An error has occured during download: " & ex.Message)
        lblProgress.Text = "An error has occured during download"
    End Sub

    Private Sub AccessControlComplete()
        prgProgress.Value = prgProgress.Maximum
        'MessageBox.Show("File Download Complete")
        lblProgress.Text = "File Download Complete"
    End Sub

    Private Sub AccessControlObtained()
        prgProgress.Value = 0
        prgProgress.Maximum = Convert.ToInt32(CLENGTH)
        MAX = Convert.ToInt32(CLENGTH)
    End Sub

End Class
