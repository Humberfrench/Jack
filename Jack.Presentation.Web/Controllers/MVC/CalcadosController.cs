using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Application = Jack.Application;
using Model = Jack.Model;


namespace Controllers.MVC
{
	public class CalcadosController : Controller
	{

		// GET: Calcados
		public ActionResult Index()
		{

			Application.Calcado CalcadoApplication = null;
			IList<Model.Calcado> CalcadoRetorno = null;


            try
            {
                CalcadoApplication = new Application.Calcado();
                CalcadoRetorno = CalcadoApplication.LoadAll();

            }
            catch (Exception ex)
            {
                CalcadoRetorno = new List<Model.Calcado>();
                throw ex;
            }
            finally
            {
                CalcadoApplication = null;
            }

			return View(CalcadoRetorno);

		}

		public ActionResult Meninos()
		{

			Application.Calcado CalcadoApplication = null;
			IList<Model.Calcado> CalcadoRetorno = null;


            try
            {
                CalcadoApplication = new Application.Calcado();
                CalcadoRetorno = CalcadoApplication.LoadAll().Where(x => x.Sexo == "M").ToList();

            }
            catch (Exception ex)
            {
                CalcadoRetorno = new List<Model.Calcado>();
                throw ex;
            }
            finally
            {
                CalcadoApplication = null;
            }

			return View(CalcadoRetorno);

		}

		public ActionResult Meninas()
		{

			Application.Calcado CalcadoApplication = null;
			IList<Model.Calcado> CalcadoRetorno = null;


            try
            {
                CalcadoApplication = new Application.Calcado();
                CalcadoRetorno = CalcadoApplication.LoadAll().Where(x => x.Sexo == "F").ToList();

            }
            catch (Exception ex)
            {
                CalcadoRetorno = new List<Model.Calcado>();
                throw ex;
            }
            finally
            {
                CalcadoApplication = null;
            }

			return View(CalcadoRetorno);

		}

	}
}
