<!-- default file list -->
*Files to look at*:

* [HomeController.cs](./CS/NodeReorder/Controllers/HomeController.cs) (VB: [HomeController.vb](./VB/NodeReorder/Controllers/HomeController.vb))
* [DataHelper.cs](./CS/NodeReorder/Models/DataHelper.cs) (VB: [DataHelper.vb](./VB/NodeReorder/Models/DataHelper.vb))
* [ReorderHelper.js](./CS/NodeReorder/Scripts/ReorderHelper.js) (VB: [ReorderHelper.js](./VB/NodeReorder/Scripts/ReorderHelper.js))
* [_TreeListPartial.cshtml](./CS/NodeReorder/Views/Home/_TreeListPartial.cshtml)
* [Index.cshtml](./CS/NodeReorder/Views/Home/Index.cshtml)
<!-- default file list end -->
# TreeList - How to implement node reordering
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t450346/)**
<!-- run online end -->


<p>Currently, the TreeList extension only allows node insertion (a modification of the current node's parent node). <br>This example demonstrates how to implement node reordering and also provides the implementation of custom reorder/insert icons. <br><br>Here is how you can implement this scenario

* Get all of the sibling nodes of the node that is currently being dragged and calculate its bounds in the client-side <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxTreeListScriptsASPxClientTreeList_StartDragNodetopic.aspx">ASPxClientTreeList.StartDragNode</a> event handler.
* Ensure that the <a href="http://www.w3schools.com/jsref/event_onmousemove.asp">mousemove</a> handler is attached to the <a href="http://www.w3schools.com/jsref/dom_obj_document.asp">document</a> object. In the client-side mousemove event handler, check whether it is possible to reorder/insert nodes and change the reorder/insert image.
* In the client-side <a href="https://documentation.devexpress.com/AspNet/DevExpressWebASPxTreeListScriptsASPxClientTreeList_EndDragNodetopic.aspx">ASPxClientTreeList.EndDragNode</a> event handler, get the e.htmlEvent object and see if reordering is possible. If so, set the e.cancel property to false and perform a custom callback to the TreeList extension.<br><br><br>In order to check whether it is possible to reorder nodes, iterate through the neighboring nodes' bounds you've saved in the StartDragNode event handler. In order to get the current cursor position, use the ASPx.Evt.GetEventX and ASPx.Evt.GetEventY methods. <br><br>In order to get the drag & drop image, use the GetDragAndDropNodeImage method of the ASPxClientTreeList object. Note that this is private API, so we do not guarantee that we will not change it in our further releases. Even though in the case of the GetDragAndDropNodeImage method it is hardly possible that we will change it, I still encourage you to test this solution while upgrading to the next releases.</p>
<p> </p>
<p><strong>Node reorder functionality limitation:</strong> It is not possible to keep a custom order of the nodes when the control is sorted by any column. Thus, it is necessary to disable the sorting functionality via the TreeListSettings.SettingsBehavior.AllowSort property.<br><br><strong>See also:</strong> <br><a href="https://www.devexpress.com/Support/Center/Example/Details/E3850">How to reorder ASPxTreeList sibling nodes, using buttons or drag-and-drop</a><br><a href="https://www.devexpress.com/Support/Center/p/T604737">ASPxTreeList - How to implement node reordering</a> - WebForms Version</p>

<br/>


