Imports DevExpress.Mvvm.UI
Imports DevExpress.Xpf.Docking

Namespace DockingThreads

	Public Interface ICustomService
		Sub BeginUpdate()
		Sub EndUpdate()
	End Interface

	Public Class CustomService
		Inherits ServiceBaseGeneric(Of DockLayoutManager)
		Implements ICustomService

		Public Sub BeginUpdate() Implements ICustomService.BeginUpdate
			Me.AssociatedObject.BeginUpdate()
		End Sub
		Public Sub EndUpdate() Implements ICustomService.EndUpdate
			Me.AssociatedObject.EndUpdate()
		End Sub
	End Class
End Namespace