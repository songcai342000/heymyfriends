using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public class IdName
    {
       
        #region
        private string id;
        public string Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        #endregion

        #region
        public IdName() { }

        public IdName(string Id, string Name)
        {
            id = Id;
            name = Name;
        }

        #endregion
    }
}
