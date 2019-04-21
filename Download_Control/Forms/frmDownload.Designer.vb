<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDownload
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDownload))
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.panDownload = New System.Windows.Forms.Panel()
        Me.gcDownload = New DevExpress.XtraBars.Ribbon.GalleryControl()
        Me.GalleryControlClient1 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.panDownload.SuspendLayout()
        CType(Me.gcDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcDownload.SuspendLayout()
        Me.GalleryControlClient1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(594, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 1
        Me.btnBrowse.Text = "Load"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(142, 6)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ReadOnly = True
        Me.txtSource.Size = New System.Drawing.Size(447, 20)
        Me.txtSource.TabIndex = 2
        '
        'panDownload
        '
        Me.panDownload.Controls.Add(Me.gcDownload)
        Me.panDownload.Location = New System.Drawing.Point(0, 35)
        Me.panDownload.Name = "panDownload"
        Me.panDownload.Size = New System.Drawing.Size(670, 345)
        Me.panDownload.TabIndex = 3
        '
        'gcDownload
        '
        Me.gcDownload.Controls.Add(Me.GalleryControlClient1)
        Me.gcDownload.DesignGalleryGroupIndex = 0
        Me.gcDownload.DesignGalleryItemIndex = 0
        Me.gcDownload.Dock = System.Windows.Forms.DockStyle.Fill
        '
        'GalleryControlGallery1
        '
        Me.gcDownload.Gallery.ShowScrollBar = DevExpress.XtraBars.Ribbon.Gallery.ShowScrollBar.[Auto]
        Me.gcDownload.Location = New System.Drawing.Point(0, 0)
        Me.gcDownload.Name = "gcDownload"
        Me.gcDownload.Size = New System.Drawing.Size(670, 345)
        Me.gcDownload.TabIndex = 1
        Me.gcDownload.Text = "My Downloads"
        '
        'GalleryControlClient1
        '
        Me.GalleryControlClient1.GalleryControl = Me.gcDownload
        Me.GalleryControlClient1.Location = New System.Drawing.Point(2, 2)
        Me.GalleryControlClient1.Size = New System.Drawing.Size(666, 341)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(0, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Select the XML source"
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(460, 293)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(100, 23)
        Me.ProgressBar1.TabIndex = 0
        '
        'frmDownload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.ClientSize = New System.Drawing.Size(669, 389)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.panDownload)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.btnBrowse)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmDownload"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Download Control"
        Me.panDownload.ResumeLayout(False)
        CType(Me.gcDownload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcDownload.ResumeLayout(False)
        Me.GalleryControlClient1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents panDownload As System.Windows.Forms.Panel
    Friend WithEvents gcDownload As DevExpress.XtraBars.Ribbon.GalleryControl
    Friend WithEvents GalleryControlClient1 As DevExpress.XtraBars.Ribbon.GalleryControlClient
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
End Class
