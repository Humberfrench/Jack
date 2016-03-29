using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Application = Jack.Application;
using Model = Jack.Model;


namespace Controllers.MVC
{
    public class RoupasController : Controller
	{

		// GET: Roupas
		public ActionResult Index()
		{
			Application.Roupa RoupaBusiness = null;
			List<Model.Roupa> RoupaRetorno = null;


            try
            {
                RoupaBusiness = new Application.Roupa();
                //fake init
                RoupaRetorno = new List<Model.Roupa>();
                RoupaRetorno.Add(new Model.Roupa());
                RoupaRetorno.Add(new Model.Roupa());
                RoupaRetorno.Add(new Model.Roupa());
                RoupaRetorno.Add(new Model.Roupa());
                RoupaRetorno.Add(new Model.Roupa());
                //fake end
                //RoupaRetorno = RoupaApplication.LoadAll()

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
