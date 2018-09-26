using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public interface IId
    {
        /// <summary>
        /// The Unique Identifier, always > 0, Mandatory
        /// </summary>
        int Id
        {
            get;
            set;
        }
    }
}
