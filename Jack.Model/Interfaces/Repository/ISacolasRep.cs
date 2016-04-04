using System.Collections.Generic;

namespace Jack.Model
{
    public interface ISacolasRep
    {
        //bool Insert(Model.Sacola oTipo);
        //bool Update(Model.Calcado oTipo);
        //bool Insert(Model.Calcado oTipo);
        //bool Delete(Model.Calcado oTipo);
        //IList<Calcado> LoadAll();
        //Calcado Find(int ID);
        IList<DTO.Sacolas> ProcessaSacolas(int intAno);
        IList<DTO.Sacolas> ObterSacolas(int intKit, int intNivel, string isPrinted);
        IList<DTO.Sacolas> ObterSacolasLivres(int intKit, int intNivel, string isPrinted);
        IList<DTO.Sacolas> ObterSacolas();
        IList<DTO.Sacolas> ObterSacolas(string strListSacolasIn);
        IList<DTO.KitSacola> ObterKitSacolas(int intKit);
        void GravarLogSacolas(int intSacola);
        bool AddSacolaCrianca(int intCrianca);
        bool AddSacolaColaboradorCrianca(int intCrianca, int intColaborador, int intAno, bool isDevolvida);
        bool AddSacolaColaboradorSacola(int intSacola, int intColaborador, int intAno, bool isDevolvida);

    }
}
