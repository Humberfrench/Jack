
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Web.Http;

namespace Controllers.API
{
	public class TipoItemController : ApiController
	{

		[HttpGet()]
		public IList<Model.TipoItem> GetValues()
		{

			List<Model.TipoItem> lstRetorno = null;
			Business.TipoItem oBusiness = default(Business.TipoItem);

			try {
				oBusiness = new Business.TipoItem();
				lstRetorno = oBusiness.LoadAll();

			} catch (Exception ex) {
				lstRetorno = null;
			} finally {
				oBusiness = null;
			}

			return lstRetorno;

		}

		[HttpGet()]
		public Model.TipoItem GetValue(		[FromUri()]
int ID)
		{

			Model.TipoItem oRetorno = default(Model.TipoItem);
			Business.TipoItem oBusiness = default(Business.TipoItem);

			try {
				oBusiness = new Business.TipoItem();
				oRetorno = oBusiness.Find(ID);

			} catch (Exception ex) {
				oRetorno = null;
			} finally {
				oBusiness = null;
			}

			return oRetorno;

		}

		[HttpPost()]
		public void Salvar(		[FromUri()]

Model.TipoItem oFamily)
		{
			Business.TipoItem oBusiness = default(Business.TipoItem);
			try {
				oBusiness = new Business.TipoItem();
				oBusiness.Update(oFamily);
			} finally {
				oBusiness = null;
			}

		}

		[HttpDelete()]
		public void Delete(		[FromUri()]
int ID)
		{
			Business.TipoItem oBusiness = default(Business.TipoItem);
			Model.TipoItem oDelete = default(Model.TipoItem);
			try {
				oBusiness = new Business.TipoItem();
				oDelete = new Model.TipoItem();
				oDelete.Codigo = ID;
				oBusiness.Delete(oDelete);

			} finally {
				oBusiness = null;
			}

		}
	}
}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
