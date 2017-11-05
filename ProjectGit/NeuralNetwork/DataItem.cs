using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectGit
{
    public class DataItem<T>
    {
        private T[] input_ = null;
        private T[] output_ = null;

        public DataItem()
        {
        }

        public DataItem(T[] input, T[] output)
        {
            input_ = input;
            output_ = output;
        }

        public T[] Input
        {
            get { return input_; }
            set { input_ = value; }
        }

        public T[] Output
        {
            get { return output_; }
            set { output_ = value; }
        }
    }
}
