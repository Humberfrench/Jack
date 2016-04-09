using System.Collections.Generic;


namespace Jack.Model
{
    public interface ICriancaMoralCristaApp
    {
        bool Delete(CriancaMoralCrista oTipo);
        CriancaMoralCrista Find(int Identifier);
        bool Insert(CriancaMoralCrista oTipo);
        IList<CriancaMoralCrista> LoadAll();
        bool Update(CriancaMoralCrista oTipo);
    }
}