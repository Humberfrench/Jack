using System.Collections.Generic;

namespace Jack.Model
{
    public interface IKitItemRep
    {
        bool Delete(KitItem oTipo);
        KitItem Find(int Identifier);
        bool Insert(KitItem oTipo);
        IList<KitItem> LoadAll();
        IList<KitItem> LoadKitItemByKit(int intKit);
        bool Update(KitItem oTipo);
    }
}