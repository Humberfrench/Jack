using System.Collections.Generic;

namespace Jack.Model
{
    public interface ICriancasRep
    {
        bool Insert(Criancas oTipo);
        bool Update(Criancas oTipo);
        bool Delete(Criancas oTipo);
        IList<Criancas> LoadAll();
        Criancas Find(int ID);
        Criancas ObterDados(int intIdade, string strMedidaIdade, string strSexo, bool blnIsNecessidadeEspecial);
        Criancas ObterDadosVestuario(int intIdade, string strMedidaIdade, string strSexo);
        IList<Criancas> ObterSacolasMae(int intMae);
        bool AtualizaDadosCrianca(int intCrianca, int intCalcado, string strRoupa);
    }
}
;