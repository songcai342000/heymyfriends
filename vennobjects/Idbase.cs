using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public class Idbase: IId
    {
        #region Data Members
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        #endregion

        #region constructors
        public Idbase()
        {}

        public Idbase(int Id)
        {
            id = Id;
        }
        #endregion


        #region IId Members

        int IId.Id
        {
            get
            {
                return Id;
            }
            set
            {
                Id = value;
            }
        }

        #endregion
    }
}
