using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Business = Jack.Business;
using Model = Jack.Model;


namespace Controllers.MVC
{
    public class RoupasController : Controller
	{

		// GET: Roupas
		public ActionResult Index()
		{
			Business.Roupa RoupaBusiness = null;
			List<Model.Roupa> RoupaRetorno = null;


            try
            {
                RoupaBusiness = new Business.Roupa();
                //fake init
                RoupaRetorno = new List<Model.Roupa>();
                RoupaRetorno.Add(new Model.Roupa());
                RoupaRetorno.Add(new Model.Roupa());
                RoupaRetorno.Add(new Model.Roupa());
                RoupaRetorno.Add(new Model.Roupa());
                RoupaRetorno.Add(new Model.Roupa());
                //fake end
                //RoupaRetorno = RoupaBusiness.LoadAll()

            }
            catch (Exception ex)
            {
                RoupaRetorno = new List<Model.Roupa>();
                throw ex;
            }
            finally
            {
                RoupaBusiness = null;
            }

			return View(RoupaRetorno);

		}
	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
