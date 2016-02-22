using Jack.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Business
{
    public class Familia : ICrud<Model.Familia, int>
    {


        public Familia()
        {

        }

        public bool Delete(Model.Familia oTipo)
        {
            Data.Familia oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Familia();
                blnRetorno = oDados.Delete(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return blnRetorno;

        }

        public Model.Familia Find(int Identifier)
        {

            Data.Familia oDados = null;
            Model.Familia oRetorno = null;

            try
            {
                oDados = new Data.Familia();
                oRetorno = oDados.Find(Identifier);
            }
            catch (Exception ex)
            {
                oRetorno = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return oRetorno;

        }

        public bool Insert(Model.Familia oTipo)
        {
            Data.Familia oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Familia();
                blnRetorno = oDados.Insert(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return blnRetorno;
        }

        public string LoadJSON()
        {
            return this.LoadAll().ToList().ToString();
        }
        public IList<Model.Familia> LoadAll()
        {
            Data.Familia oDados = null;
            IList<Model.Familia> lstRetorno = null;

            try
            {
                oDados = new Data.Familia();
                lstRetorno = oDados.LoadAll();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstRetorno;

        }

        public IList<DTOFamiliaChamada> ObterChamada(int intReuniao)
        {
            Data.Familia oDados = null;
            IList<DTOFamiliaChamada> lstRetorno = null;

            try
            {
                oDados = new Data.Familia();
                lstRetorno = oDados.ObterChamada(intReuniao);
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return lstRetorno;

        }



        public bool Update(Model.Familia oTipo)
        {
            Data.Familia oDados = null;
            bool blnRetorno = false;

            try
            {
                oDados = new Data.Familia();
                blnRetorno = oDados.Update(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oDados = null;
            }

            return blnRetorno;
        }

        public List<Model.FamiliaLote> GravarLote(List<string> lstNomeMaes)
        {

            List<Model.FamiliaLote> lstLote = null;
            Data.Familia oDados = null;
            string strRetorno = string.Empty;
            Model.Familia oFamilia = null;
            Model.FamiliaLote oFamiliaLote = null;

            try
            {
                oDados = new Data.Familia();
                lstLote = new List<Model.FamiliaLote>();

                foreach (string strMae in lstNomeMaes)
                {
                    oFamilia = new Model.Familia();
                    oFamiliaLote = new Model.FamiliaLote();

                    oFamilia.Codigo = 0;
                    oFamilia.Nome = strMae;
                    oFamilia.IsConsistente = "N";
                    oFamilia.IsSacolinha = "N";
                    strRetorno = oDados.GravarLote(oFamilia);

                    oFamiliaLote.Nome = strMae;
                    oFamiliaLote.Status = strRetorno;
                    lstLote.Add(oFamiliaLote);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oDados = null;
                strRetorno = string.Empty;
                oFamilia = null;
                oFamiliaLote = null;
            }

            return lstLote;

        }

    }
}
