using Codeplex.Data;
using JsonParserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParser
{
    public class DynamicJsonPaser : IJsonParser
    {
        public dynamic Parse(System.IO.Stream s)
        {
            return DynamicJson.Parse(s);
        }
    }
}
