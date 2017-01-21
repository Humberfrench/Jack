using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jack.Application.Interfaces;
using Jack.Application.ViewModel;
using Jack.Library;

namespace Jack.Web.Controllers
{
    [RoutePrefix("Reuniao")]
    public class ReuniaoController : BaseController
    {
        #region Vars

        private readonly IReuniaoServiceApp reuniaoAppService;

        #endregion

        #region Ctor

        public ReuniaoController(IReuniaoServiceApp reuniaoAppService)
        {
            this.reuniaoAppService = reuniaoAppService;
        }

        #endregion

        #region Public Methods
        [Route("")]
        public ActionResult Index()
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Reunião",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Reunião", ActionName = "Index", ControllerName = "Reuniao"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Reuniao"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion
            ViewBag.Ano = 0;
            var listaDados = reuniaoAppService.ObterTodos();
            return View(listaDados);
        }

        [Route("{ano}")]
        public ActionResult Index(int ano)
        {
            #region BreadCrumb
            var breadCrumb = new BreadCrumbETitulo
            {
                Titulo = "Reunião",
                BreadCrumbs = new List<BreadCrumb>
                {
                 new BreadCrumb {LinkText = "Reunião", ActionName = "Index", ControllerName = "Reuniao"},
                 new BreadCrumb {LinkText = "Lista", ActionName = "Index", ControllerName = "Reuniao"}
                }
            };

            TempData["BreadCrumETitulo"] = breadCrumb;
            #endregion

            ViewBag.Ano = ano;

            var listaDados = reuniaoAppService.ObterReunioesNoAno(ano);

            return View(listaDados);
        }

        //[Route("CriarDatas")]
        //public ActionResult CriarDatas()
        //{
        //    {
        //        #region BreadCrumb
        //        var breadCrumb = new BreadCrumbETitulo
        //        {
        //            Titulo = "Criar Datas",
        //            BreadCrumbs = new List<BreadCrumb>
        //        {
        //         new BreadCrumb {LinkText = "Reunião", ActionName = "Index", ControllerName = "Reuniao"},
        //         new BreadCrumb {LinkText = "Criar Datas", ActionName = "CriarDatas", ControllerName = "Reuniao"}
        //        }
        //        };

        //        TempData["BreadCrumETitulo"] = breadCrumb;
        //        #endregion
        //        ViewBag.Ano = 0;
        //        var listaDados = new List<ReuniaoViewModel>();
        //        return View(listaDados);
        //    }
        //}

        //[Route("CriarDatas/{ano}")]
        //public ActionResult CriarDatas(int ano)
        //{
        //    {
        //        #region BreadCrumb
        //        var breadCrumb = new BreadCrumbETitulo
        //        {
        //            Titulo = "Criar Datas",
        //            BreadCrumbs = new List<BreadCrumb>
        //        {
        //         new BreadCrumb {LinkText = "Reunião", ActionName = "Index", ControllerName = "Reuniao"},
        //         new BreadCrumb {LinkText = "Criar Datas", ActionName = "CriarDatas", ControllerName = "Reuniao"}
        //        }
        //        };

        //        TempData["BreadCrumETitulo"] = breadCrumb;
        //        #endregion
        //        ViewBag.Ano = 0;
        //        var listaDados = reuniaoAppService.
        //        return View(listaDados);
        //    }
        //}

        [Route("Edit")]
        public ActionResult Edit(int id)
        {
            var reuniao = reuniaoAppService.ObterPorId(id);
            reuniao.FamiliaPresenca.Clear();
            return Json(reuniao, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateJsonAntiForgeryToken]
        [Route("Gravar")]
        public ActionResult Gravar(ReuniaoViewModel reuniao)
        {
            var gravarResult = reuniaoAppService .Gravar(reuniao);
            object retorno;
            if (gravarResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Gravado com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(gravarResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Route("Excluir")]
        public ActionResult Excluir(int id)
        {
            var excluirResult = reuniaoAppService.Excluir(id);

            object retorno;
            if (excluirResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Registro Excluído com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(excluirResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }

        [Route("MontarDataReuniao")]
        public ActionResult MontarDataReuniao(int ano)
        {
            var montarReuniaoResult = reuniaoAppService.MontarDataReuniao(ano);

            object retorno;
            if (montarReuniaoResult.IsValid)
            {
                retorno = new
                {
                    Mensagem = "Datas criadas com Sucesso",
                    Erro = false
                };
            }
            else
            {
                retorno = new
                {
                    Mensagem = RenderizeErros(montarReuniaoResult),
                    Erro = true
                };
            }

            return Json(retorno, JsonRequestBehavior.AllowGet);
        }      
        
        #endregion
    }
}