''' <summary>
''' 
''' </summary>
Public Class DownloadItem

#Region "Member"
    Private _template As String
    Private _name As String
    Private _category As String
    Private _releasedate As Date
    Private _version As String
    Private _screenshot As String
    Private _templateFile As String
    Private _previewUrl As String
    Private _templateFileMD5 As String
    Private _slno As Integer
#End Region

#Region "Propertices"
    Public Property Template() As String
        Get
            Return _template
        End Get
        Set(ByVal value As String)
            _template = value
        End Set
    End Property

    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property

    Public Property ReleaseDate() As Date
        Get
            Return _releasedate
        End Get
        Set(ByVal value As Date)
            _releasedate = value
        End Set
    End Property

    Public Property Version() As String
        Get
            Return _version
        End Get
        Set(ByVal value As String)
            _version = value
        End Set
    End Property

    Public Property ScreenShot() As String
        Get
            Return _screenshot
        End Get
        Set(ByVal value As String)
            _screenshot = value
        End Set
    End Property

    Public Property TemplateFile() As String
        Get
            Return _templateFile
        End Get
        Set(ByVal value As String)
            _templateFile = value
        End Set
    End Property

    Public Property PreviewUrl() As String
        Get
            Return _previewUrl
        End Get
        Set(ByVal value As String)
            _previewUrl = value
        End Set
    End Property

    Public Property TemplateFileMD5() As String
        Get
            Return _templateFileMD5
        End Get
        Set(ByVal value As String)
            _templateFileMD5 = value
        End Set
    End Property

    Public Property SlNo As Integer
        Get
            Return _slno
        End Get
        Set(ByVal value As Integer)
            If _slno = value Then
                Return
            End If
            _slno = value
        End Set
    End Property
#End Region
End Class
