using System.Collections.Generic;


namespace Jack.Model
{
    public interface ICriancasApp
    {
        bool Delete(Criancas oTipo);
        bool Delete(Criancas oTipo, int intFamilia);
        Criancas Find(int Identifier);
        bool Insert(Criancas oTipo);
        bool Insert(Criancas oTipo, int intFamilia);
        IList<Criancas> LoadAll();
        int ObterCriancaPorNome(string strName);
        IList<Criancas> ObterSacolasMae(int intMae);
        bool Update(Criancas oTipo);
    }
}