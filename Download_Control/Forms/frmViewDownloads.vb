Public Class frmViewDownloads

    Private Sub frmViewDownloads_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub frmViewDownloads_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        e.Cancel = True
        Me.Hide()
    End Sub

    Private Sub frmViewDownloads_Activated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Activated
        LoadDownloads()
        Me.BringToFront()
    End Sub

    Private Sub LoadDownloads()
        Me.Panel1.Controls.Clear()
        For i = 0 To (listctlViewDownload.Count - 1)
            Me.Panel1.Controls.Add(listctlViewDownload(i))
        Next
    End Sub

End Class