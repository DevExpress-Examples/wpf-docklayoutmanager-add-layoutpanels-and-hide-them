Imports DevExpress.Mvvm
Imports DevExpress.Xpf.Docking

Namespace DockingThreads
	Public Class DataItem
		Inherits BindableBase
		Implements IMVVMDockingProperties

		Public Property Name() As String
			Get
				Return GetValue(Of String)()
			End Get
			Set(ByVal value As String)
				SetValue(value)
			End Set
		End Property
		Public Property Value() As Integer
			Get
				Return GetValue(Of Integer)()
			End Get
			Set(ByVal value As Integer)
				SetValue(value)
			End Set
		End Property
		Public Property IsHidden() As Boolean
			Get
				Return GetValue(Of Boolean)()
			End Get
			Set(ByVal value As Boolean)
				SetValue(value)
			End Set
		End Property

		Public Property TargetName() As String

		Public Overrides Function ToString() As String
			Return Name
		End Function
	End Class
End Namespace
