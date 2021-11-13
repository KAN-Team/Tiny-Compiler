using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiny_Compiler
{
    class Input
    {
        string input;
        public Input(string name)
        {
            setInput(name);
        }
        private void setInput(string name)
        {
            input = System.IO.File.ReadAllText(name);
        }
        public string getInput()
        {
            return input;
        }
    }
}
