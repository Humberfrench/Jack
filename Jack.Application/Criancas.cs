﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Jack.Application
{

    public class Criancas : ICrud<Model.Criancas, int>
    {

        public bool Delete(Model.Criancas oTipo)
        {

            Repository.Criancas oDataCrianca = null;
            bool blnDados = false;

            try
            {
                oDataCrianca = new Repository.Criancas();
                oDataCrianca.Delete(oTipo);
                blnDados = true;
            }
            catch (Exception ex)
            {
                blnDados = false;
                throw ex;
            }
            finally
            {
                oDataCrianca = null;
            }
            return blnDados;

        }

        public bool Delete(Model.Criancas oTipo, int intFamilia)
        {

            Repository.FamiliaCrianca oDataFamiliaCrianca = null;
            bool blnDados = false;
            try
            {
                oDataFamiliaCrianca = new Repository.FamiliaCrianca();
                if (oDataFamiliaCrianca.DeleteCrianca(intFamilia, oTipo.Codigo))
                {
                    blnDados = Delete(oTipo);
                }
                else {
                    throw new Exception("Erro Excluindo Criança da Família");
                }
            }
            catch (Exception ex)
            {
                blnDados = false;
                throw ex;
            }
            finally
            {
                oDataFamiliaCrianca = null;
            }
            return blnDados;
        }

        public Model.Criancas Find(int Identifier)
        {

            Repository.Criancas oDataCrianca = null;
            Model.Criancas objRetorno = null;

            try
            {
                oDataCrianca = new Repository.Criancas();
                objRetorno = oDataCrianca.Find(Identifier);
            }
            catch (Exception ex)
            {
                objRetorno = null;
                throw ex;
            }
            finally
            {
                oDataCrianca = null;
            }
            return objRetorno;

        }

        public bool Insert(Model.Criancas oTipo)
        {

            Repository.Criancas oDataCrianca = null;
            bool blnDados = false;

            try
            {
                oDataCrianca = new Repository.Criancas();
                oDataCrianca.Insert(oTipo);
                blnDados = true;
            }
            catch (Exception ex)
            {
                blnDados = false;
                throw ex;
            }
            finally
            {
                oDataCrianca = null;
            }
            return blnDados;

        }

        public bool Insert(Model.Criancas oTipo, int intFamilia)
        {

            Repository.FamiliaCrianca oDataFamiliaCrianca = null;
            bool blnDados = false;

            try
            {
                oDataFamiliaCrianca = new Repository.FamiliaCrianca();
                if (Insert(oTipo))
                {
                    //intCrianca = ObterCriancaPorNome(oTipo.Nome)
                    blnDados = oDataFamiliaCrianca.Insert(intFamilia, oTipo.Codigo);
                }
                else {
                    throw new Exception("Erro Inclindo Criança da Família");
                }
            }
            catch (Exception ex)
            {
                blnDados = false;
                throw ex;
            }
            finally
            {
                oDataFamiliaCrianca = null;
            }
            return blnDados;

        }

        public IList<Model.Criancas> LoadAll()
        {

            Repository.Criancas oDataCrianca = null;
            IList<Model.Criancas> lstDados = null;

            try
            {
                oDataCrianca = new Repository.Criancas();
                lstDados = oDataCrianca.LoadAll();
            }
            catch (Exception ex)
            {
                lstDados = null;
                throw ex;
            }
            finally
            {
                oDataCrianca = null;
            }
            return lstDados;

        }

        public IList<Model.Criancas> ObterSacolasMae(int intMae)
        {

            Repository.Criancas oDataCrianca = null;
            IList<Model.Criancas> lstDados = null;

            try
            {
                oDataCrianca = new Repository.Criancas();
                lstDados = oDataCrianca.ObterSacolasMae(intMae);
            }
            catch (Exception ex)
            {
                lstDados = null;
                throw ex;
            }
            finally
            {
                oDataCrianca = null;
            }
            return lstDados;

        }

        public bool Update(Model.Criancas oTipo)
        {

            Repository.Criancas oDataCrianca = null;
            bool blnDados = false;

            try
            {
                oDataCrianca = new Repository.Criancas();
                oDataCrianca.Update(oTipo);
                blnDados = true;
            }
            catch (Exception ex)
            {
                blnDados = false;
                throw ex;
            }
            finally
            {
                oDataCrianca = null;
            }
            return blnDados;

        }

        public int ObterCriancaPorNome(string strName)
        {

            IList<Model.Criancas> listCriancas = default(IList<Model.Criancas>);
            int intCrianca = 0;

            try
            {
                listCriancas = LoadAll();

                //Dim iPesq = From oDado As Model.Criancas In listCriancas Where oDado.Nome = strName
                //            Select oDado

                //intCrianca = iPesq.ToList(0).Codigo
                //iPesq = Nothing

                intCrianca = listCriancas.Where(x => x.Nome == strName).ToList()[0].Codigo;


            }
            catch (Exception ex)
            {
                intCrianca = 0;
                throw ex;
            }
            finally
            {
                listCriancas = null;
            }
            return intCrianca;

        }
    }
}