using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public class NeuralNetworkStructureConfig
    {
        public DataItem<DataParameter> DataConfig { get; set; }
        public List<int> NeuronsOfHiddenLayers { get; set; }
    }
}
