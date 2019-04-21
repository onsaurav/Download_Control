<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ctlViewDownload
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblUrl = New System.Windows.Forms.Label()
        Me.prgProgress = New System.Windows.Forms.ProgressBar()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lblProgress = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblUrl
        '
        Me.lblUrl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUrl.ForeColor = System.Drawing.Color.SteelBlue
        Me.lblUrl.Location = New System.Drawing.Point(15, 6)
        Me.lblUrl.Name = "lblUrl"
        Me.lblUrl.Size = New System.Drawing.Size(275, 14)
        Me.lblUrl.TabIndex = 0
        Me.lblUrl.Text = "..... ... ... "
        '
        'prgProgress
        '
        Me.prgProgress.Location = New System.Drawing.Point(18, 54)
        Me.prgProgress.Name = "prgProgress"
        Me.prgProgress.Size = New System.Drawing.Size(365, 12)
        Me.prgProgress.TabIndex = 1
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(308, 9)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblProgress
        '
        Me.lblProgress.Location = New System.Drawing.Point(16, 21)
        Me.lblProgress.Name = "lblProgress"
        Me.lblProgress.Size = New System.Drawing.Size(287, 31)
        Me.lblProgress.TabIndex = 3
        Me.lblProgress.Text = "..... ... ... "
        '
        'ctlViewDownload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblProgress)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.prgProgress)
        Me.Controls.Add(Me.lblUrl)
        Me.Name = "ctlViewDownload"
        Me.Size = New System.Drawing.Size(400, 77)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblUrl As System.Windows.Forms.Label
    Friend WithEvents prgProgress As System.Windows.Forms.ProgressBar
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblProgress As System.Windows.Forms.Label

End Class
