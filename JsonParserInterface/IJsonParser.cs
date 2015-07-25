using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonParserInterface
{
    public interface IJsonParser
    {
        dynamic Parse(Stream s);
    }
}
