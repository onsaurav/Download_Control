<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctDownload
    Inherits System.Windows.Forms.UserControl

    'UserControl1 overrides dispose to clean up the component list.
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
        Me.lblSource = New System.Windows.Forms.Label()
        Me.txtSource = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.panDownload = New System.Windows.Forms.Panel()
        Me.gcDownload = New DevExpress.XtraBars.Ribbon.GalleryControl()
        Me.GalleryControlClient1 = New DevExpress.XtraBars.Ribbon.GalleryControlClient()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.panDownload.SuspendLayout()
        CType(Me.gcDownload, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gcDownload.SuspendLayout()
        Me.GalleryControlClient1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblSource
        '
        Me.lblSource.AutoSize = True
        Me.lblSource.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSource.ForeColor = System.Drawing.Color.White
        Me.lblSource.Location = New System.Drawing.Point(1, 7)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(74, 13)
        Me.lblSource.TabIndex = 8
        Me.lblSource.Text = "XML source"
        '
        'txtSource
        '
        Me.txtSource.Location = New System.Drawing.Point(80, 6)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.ReadOnly = True
        Me.txtSource.Size = New System.Drawing.Size(535, 20)
        Me.txtSource.TabIndex = 7
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(621, 4)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(63, 23)
        Me.btnBrowse.TabIndex = 5
        Me.btnBrowse.Text = "Load"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'panDownload
        '
        Me.panDownload.BackColor = System.Drawing.Color.White
        Me.panDownload.Controls.Add(Me.gcDownload)
        Me.panDownload.Location = New System.Drawing.Point(2, 32)
        Me.panDownload.Name = "panDownload"
        Me.panDownload.Size = New System.Drawing.Size(681, 386)
        Me.panDownload.TabIndex = 9
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
        Me.gcDownload.Location = New System.Drawing.Point(0, 0)
        Me.gcDownload.Name = "gcDownload"
        Me.gcDownload.Size = New System.Drawing.Size(681, 386)
        Me.gcDownload.TabIndex = 7
        Me.gcDownload.Text = "My Downloads"
        '
        'GalleryControlClient1
        '
        Me.GalleryControlClient1.GalleryControl = Me.gcDownload
        Me.GalleryControlClient1.Location = New System.Drawing.Point(2, 2)
        Me.GalleryControlClient1.Size = New System.Drawing.Size(660, 382)
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(378, 366)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(282, 13)
        Me.ProgressBar1.TabIndex = 0
        '
        'ucDownload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SteelBlue
        Me.Controls.Add(Me.panDownload)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.btnBrowse)
        Me.Name = "ucDownload"
        Me.Size = New System.Drawing.Size(685, 427)
        Me.panDownload.ResumeLayout(False)
        CType(Me.gcDownload, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gcDownload.ResumeLayout(False)
        Me.GalleryControlClient1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents panDownload As System.Windows.Forms.Panel
    Friend WithEvents gcDownload As DevExpress.XtraBars.Ribbon.GalleryControl
    Friend WithEvents GalleryControlClient1 As DevExpress.XtraBars.Ribbon.GalleryControlClient
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar

End Class
