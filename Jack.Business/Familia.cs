using Jack.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Business
{
    public class Familia 
    {


        public Familia()
        {

        }

        public bool Delete(int ID)
        {
            Data.Familia oDados = null;
            bool blnRetorno = false;
            Model.Familia oTipo = null;

            try
            {
                oDados = new Data.Familia();
                oTipo = oDados.Find(ID);
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
                oTipo = null;
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

        public IList<DTOFamilia> Load()
        {
            Data.Familia oDados = null;
            IList<DTOFamilia> lstRetorno = null;

            try
            {
                oDados = new Data.Familia();
                lstRetorno = oDados.Load();
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

        public DTOFamilia Obter(int ID)
        {
            Model.Familia familia = null;
            DTOFamilia dtoFamilia = null;
            try
            {
                familia = Find(ID);
                dtoFamilia = new DTOFamilia(familia.Codigo, familia.Nome, familia.IsSacolinha,
                                            familia.IsConsistente, familia.Contato, familia.Nivel,
                                            familia.Status.Codigo, familia.Status.Descricao,
                                            familia.DataAtualizacao);
            }
            catch (Exception ex)
            {
                dtoFamilia = null;
                throw ex;
            }
            finally
            {
                familia = null;
            }

            return dtoFamilia; 
        }

        public bool Gravar(DTOFamilia family)
        {
            Model.Familia modelFamilia = null;
            bool blnRetorno = false;
            Model.Status modelStatus = null;
            Status oStatus = null;

            try
            {
                oStatus = new Status();
                modelStatus = oStatus.Find(family.StatusCodigo);
                modelFamilia = Find(family.Codigo);
                modelFamilia.Status = modelStatus;
                modelFamilia.Contato = family.Contato;
                modelFamilia.Nome = family.Nome;
                modelFamilia.IsConsistente = family.IsConsistente;
                modelFamilia.IsSacolinha = family.IsSacolinha;
                modelFamilia.Nivel = family.Nivel;
                if (family.Codigo == 0)
                {
                    Insert(modelFamilia);
                }
                else
                {
                    Update(modelFamilia);
                }
                blnRetorno = true;

            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                modelFamilia = null;
                modelStatus = null;
                oStatus = null;
            }

            return blnRetorno;

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
