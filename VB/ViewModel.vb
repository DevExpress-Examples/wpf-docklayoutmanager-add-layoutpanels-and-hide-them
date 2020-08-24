Imports DevExpress.Mvvm
Imports System.Collections.ObjectModel
Imports System.Linq
Imports System.Windows.Input

Namespace DockingThreads
	Public Class ViewModel
		Inherits ViewModelBase

		Public ReadOnly Property DockLayoutManagerService() As ICustomService
			Get
				Return Me.GetService(Of ICustomService)()
			End Get
		End Property
		Private privateAddNewCommand As ICommand
		Public Property AddNewCommand() As ICommand
			Get
				Return privateAddNewCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateAddNewCommand = value
			End Set
		End Property
		Private privateHideAllCommand As ICommand
		Public Property HideAllCommand() As ICommand
			Get
				Return privateHideAllCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateHideAllCommand = value
			End Set
		End Property

		Public Property Source() As ObservableCollection(Of DataItem)
			Get
				Return GetValue(Of ObservableCollection(Of DataItem))()
			End Get
			Set(ByVal value As ObservableCollection(Of DataItem))
				SetValue(value)
			End Set
		End Property

		Public Sub New()
			Source = New ObservableCollection(Of DataItem)()
			For i As Integer = 0 To 9
				Source.Add(New DataItem() With {
					.Name = "Name" & i.ToString(),
					.Value = i,
					.TargetName = "host"
				})
			Next i
			AddNewCommand = New DelegateCommand(AddressOf AddNew)
			HideAllCommand = New DelegateCommand(AddressOf HideAll)
		End Sub

		Private Sub AddNew()
			DockLayoutManagerService.BeginUpdate()
			For i As Integer = 0 To 9
				Source.Add(New DataItem() With {
					.Name = "Name" & i.ToString(),
					.Value = i,
					.TargetName = "host"
				})
			Next i
			DockLayoutManagerService.EndUpdate()
		End Sub
		Private Sub HideAll()
			DockLayoutManagerService.BeginUpdate()
			Source.ToList().ForEach(Sub(x) x.IsHidden = True)
			DockLayoutManagerService.EndUpdate()
		End Sub

	End Class
End Namespace
