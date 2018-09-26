using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public interface IIdrepository
    {
        void Save();
       // void Add(IId Id, int id);
        void Add(IId Id);
        void Delete(IId Id);
        void Update(IId Id);
        //List<IId> GetTargetIn(string Id);
    }
}
