using System.Collections.Generic;

namespace TinyCompiler.Core
{
    class Errors
    {
        public static List<KeyValuePair<int, string>> errorsList 
            = new List<KeyValuePair<int, string>>();

        public static List<string> parserErrors = new List<string>();

    }
}
