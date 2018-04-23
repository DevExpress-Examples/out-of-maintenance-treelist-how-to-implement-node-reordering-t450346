@Imports NodeReorder.Models
@ModelType List(Of SampleDataItem)

@Code
    Dim treeList = Html.DevExpress().TreeList(Sub(settings)
                                                  settings.Name = "TreeList"
                                                  settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "TreeListAction"}
                                                  settings.CustomActionRouteValues = New With {Key .Controller = "Home", Key .Action = "TreeListCustomAction"}
                                                  settings.SettingsEditing.NodeDragDropRouteValues = New With {Key .Controller = "Home", Key .Action = "TreeListNodeMove"}
                                                  settings.Width = Unit.Pixel(300)
                                                  settings.KeyFieldName = "Key"
                                                  settings.ParentFieldName = "ParentKey"
                                                  settings.Columns.Add(Sub(column) column.FieldName = "Title")
                                                  settings.Columns.Add(Sub(column) column.FieldName = "Key")
                                                  settings.SettingsPager.Visible = True
                                                  settings.SettingsSelection.Enabled = False
                                                  settings.ClientSideEvents.Init = String.Format(
            "function (s, e) {{ s.reorderHelper = new ReorderHelper(s, '{0}', '{1}'); }}",
            Url.Content("~/Content/Images/004_54.gif"),
            Url.Content("~/Content/Images/004_32.gif")
            )
                                                  settings.Styles.Node.CssClass = "tree-node"
                                                  settings.Settings.GridLines = GridLines.Both
                                                  settings.SettingsBehavior.AllowSort = False
                                                  settings.Init = Sub(s, e) TryCast(s, ASPxTreeList).SettingsEditing.AllowNodeDragDrop = True
                                                  settings.PreRender = Sub(s, e) TryCast(s, MVCxTreeList).ExpandToLevel(3)
                                                  settings.CustomJSProperties = Sub(s, e)
                                                                                    Dim tree = CType(s, MVCxTreeList)
                                                                                    e.Properties("cpSiblingKeys") = tree.GetAllNodes().ToDictionary(Function(n) n.Key, Function(n) n.ParentNode.ChildNodes.OfType(Of TreeListNode)().Select(Function(c) c.Key))
                                                                                End Sub
                                              End Sub)
End Code
@treeList.Bind(Model).GetHtml()
