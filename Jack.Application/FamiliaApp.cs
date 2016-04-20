using Jack.DTO;
using Jack.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Application
{
    public class FamiliaApp : IFamiliaApp
    {

        private readonly Repository.StatusRep repStatus;
        private readonly Repository.FamiliaRep repFamilia;
        private readonly Repository.IUnitWork unidadeTrabalho;

        public FamiliaApp()
        {
            unidadeTrabalho = new Repository.UnitWork();
            repStatus = new Repository.StatusRep(unidadeTrabalho); 
            repFamilia = new Repository.FamiliaRep(unidadeTrabalho);

        }

    public bool Delete(int ID)
        {
            bool blnRetorno = false;
            Model.Familia oTipo = null;

            try
            {
                oTipo = repFamilia.Find(ID);
                blnRetorno = repFamilia.Delete(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }
            finally
            {
                oTipo = null;
            }

            return blnRetorno;

        }

        public Model.Familia Find(int Identifier)
        {

            Model.Familia oRetorno = null;

            try
            {
                oRetorno = repFamilia.Find(Identifier);
            }
            catch (Exception ex)
            {
                oRetorno = null;
                throw ex;
            }
            finally
            {
            }

            return oRetorno;

        }

        public bool Insert(Model.Familia oTipo)
        {
            bool blnRetorno = false;

            try
            {
                blnRetorno = repFamilia.Insert(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;
        }

        public string LoadJSON()
        {
            return this.LoadAll().ToList().ToString();
        }

        public IList<Model.Familia> LoadAll()
        {
            IList<Model.Familia> lstRetorno = null;

            try
            {
                lstRetorno = repFamilia.LoadAll();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;

        }

        public IList<DTOFamilia> Load()
        {
            IList<DTOFamilia> lstRetorno = null;

            try
            {
                lstRetorno = repFamilia.Load();
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
            }

            return lstRetorno;

        }

        public IList<DTOFamiliaChamada> ObterChamada(int intReuniao)
        {
            IList<DTOFamiliaChamada> lstRetorno = null;

            try
            {
                lstRetorno = repFamilia.ObterChamada(intReuniao);
            }
            catch (Exception ex)
            {
                lstRetorno = null;
                throw ex;
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
                                            (int)familia.Status, familia.DataAtualizacao);
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

            try
            {
                modelFamilia = Find(family.Codigo);
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
            }

            return blnRetorno;

        }

        public bool Update(Model.Familia oTipo)
        {
            bool blnRetorno = false;

            try
            {
                blnRetorno = repFamilia.Update(oTipo);
            }
            catch (Exception ex)
            {
                blnRetorno = false;
                throw ex;
            }

            return blnRetorno;
        }

        public List<FamiliaLote> GravarLote(List<string> lstNomeMaes)
        {

            List<FamiliaLote> lstLote = null;
            string strRetorno = string.Empty;
            Model.Familia oFamilia = null;
            FamiliaLote oFamiliaLote = null;

            try
            {
                lstLote = new List<FamiliaLote>();

                foreach (string strMae in lstNomeMaes)
                {
                    oFamilia = new Model.Familia();
                    oFamiliaLote = new FamiliaLote();

                    oFamilia.Codigo = 0;
                    oFamilia.Nome = strMae;
                    oFamilia.IsConsistente = "N";
                    oFamilia.IsSacolinha = "N";
                    strRetorno = repFamilia.GravarLote(oFamilia);

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
                strRetorno = string.Empty;
                oFamilia = null;
                oFamiliaLote = null;
            }

            return lstLote;

        }

    }
}
