﻿using System.Collections.Generic;

namespace Jack.Model
{
    public interface IKitRep
    {
        bool Delete(Kit oTipo);
        Kit Find(int Identifier);
        bool Insert(Kit oTipo);
        IList<Kit> LoadAll();
        bool Update(Kit oTipo);
    }
}