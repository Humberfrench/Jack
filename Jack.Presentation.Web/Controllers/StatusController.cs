using Jack.DTO;
using Jack.Presentation.Web.Controllers.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Jack.Presentation.Web.Controllers
{
    public class StatusController : BaseController
    {
        // GET: Status
        public JsonResult Familia()
        {
            HttpStatusCode httpStatus;

            var listaStatus = GetApiMethod<List<DTOStatus>>("/StatusFamilia", null, out httpStatus);
            return Json(listaStatus,  JsonRequestBehavior.AllowGet);

        }
    }
}