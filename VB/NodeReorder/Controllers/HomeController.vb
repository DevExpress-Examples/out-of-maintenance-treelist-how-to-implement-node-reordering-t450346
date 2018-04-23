Imports DevExpress.Web.Mvc
Imports NodeReorder.Models
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Mvc

Namespace NodeReorder.Controllers
	Public Class HomeController
		Inherits Controller

		Private dataHelper As New DataHelper()

		Public Function Index() As ActionResult
			Return View()
		End Function

		<ValidateInput(False)>
		Public Function TreeListAction() As ActionResult
			Return PartialView("_TreeListPartial", dataHelper.Data)
		End Function

		<HttpPost, ValidateInput(False)>
		Public Function TreeListNodeMove(ByVal key? As Integer, ByVal parentKey? As Integer) As ActionResult
			If key.HasValue AndAlso parentKey.HasValue Then
				Dim child As SampleDataItem = dataHelper.Data.Find(Function(i) i.Key = key)
				Dim newParent As SampleDataItem = dataHelper.Data.Find(Function(i) i.Key = parentKey)
				child.ParentKey = newParent.Key
			End If

			Return PartialView("_TreeListPartial", dataHelper.Data)
		End Function

		Public Function TreeListCustomAction(ByVal draggedKey? As Integer, ByVal targetKey? As Integer, ByVal isSwap? As Boolean) As ActionResult
			If isSwap.HasValue AndAlso isSwap.Value AndAlso draggedKey.HasValue AndAlso targetKey.HasValue Then
                dataHelper.SwapDataItems(dataHelper.Data.Find(Function(i) i.Key = draggedKey.Value), dataHelper.Data.Find(Function(i) i.Key = targetKey.Value))
            End If
			Return PartialView("_TreeListPartial", dataHelper.Data)
		End Function

	End Class
End Namespace