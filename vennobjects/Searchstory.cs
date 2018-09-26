using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vennobjects
{
    public class Searchstory
    {
        /*private string searchword;
        public string Searchword
        {
            get
            {
                return searchword;
            }
            set
            {
                searchword = value;
            }
        }*/

        private string type;
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        private string parameter;
        public string Parameter
        {
            get
            {
                return parameter;
            }
            set
            {
                parameter = value;
            }
        }

      
        public Searchstory(string Type, string Parameter)
        {
            type = Type;
            parameter = Parameter;
        }
        
    }
}
