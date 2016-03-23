﻿using Jack.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Business
{
    public class Familia 
    {

        private readonly Data.Status repStatus;
        private readonly Data.Familia repFamilia;
        private readonly Data.IUnitWork unidadeTrabalho;

        public Familia()
        {
            unidadeTrabalho = new Data.UnitWork();
            repStatus = new Data.Status(unidadeTrabalho); 
            repFamilia = new Data.Familia(unidadeTrabalho);

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

            try
            {
                modelFamilia = Find(family.Codigo);
                modelFamilia.Status = repStatus.Find(family.StatusCodigo);
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

        public List<Model.FamiliaLote> GravarLote(List<string> lstNomeMaes)
        {

            List<Model.FamiliaLote> lstLote = null;
            string strRetorno = string.Empty;
            Model.Familia oFamilia = null;
            Model.FamiliaLote oFamiliaLote = null;

            try
            {
                lstLote = new List<Model.FamiliaLote>();

                foreach (string strMae in lstNomeMaes)
                {
                    oFamilia = new Model.Familia();
                    oFamiliaLote = new Model.FamiliaLote();

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
