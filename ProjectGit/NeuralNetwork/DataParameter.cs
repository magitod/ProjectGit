using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public class DataParameter
    {
        /// <summary>
        /// Название параметра (eng)
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Альтернативное название (например, rus)
        /// </summary>
        public string AlternativeName { get; set; }

        public DataParameter(string name)
        {
            Name = name;
            AlternativeName = name;
        }
        public DataParameter(string name, string alternativeName)
        {
            Name = name;

            if (alternativeName == string.Empty)
                AlternativeName = name;
            else
                AlternativeName = alternativeName;
        }
    }
}
