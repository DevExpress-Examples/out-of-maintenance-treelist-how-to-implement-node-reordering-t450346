using DevExpress.Web.Mvc;
using NodeReorder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NodeReorder.Controllers
{
    public class HomeController : Controller
    {
        DataHelper dataHelper = new DataHelper();

        public ActionResult Index() {
            return View();
        }

        [ValidateInput(false)]
        public ActionResult TreeListAction() {
            return PartialView("_TreeListPartial", dataHelper.Data);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListNodeMove(int? key, int? parentKey) {
            if (key.HasValue && parentKey.HasValue) {
                SampleDataItem child = dataHelper.Data.Find(i => i.Key == key);
                SampleDataItem newParent = dataHelper.Data.Find(i => i.Key == parentKey);
                child.ParentKey = newParent.Key;
            }

            return PartialView("_TreeListPartial", dataHelper.Data);
        }

        public ActionResult TreeListCustomAction(int? draggedKey, int? targetKey, bool? isSwap) {
            if (isSwap.HasValue && isSwap.Value && draggedKey.HasValue && targetKey.HasValue)
                dataHelper.SwapDataItems(dataHelper.Data.Find(i => i.Key == draggedKey.Value), dataHelper.Data.Find(i => i.Key == targetKey.Value));
            return PartialView("_TreeListPartial", dataHelper.Data);
        }

    }
}