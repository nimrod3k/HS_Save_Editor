using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HS_Save_Editor
{
    public class HSJsonData
    {
        public string? position { get; set; }
        public byte[]? values { get; set; }
        public List<string>? hearts { get; set; }
        public Dictionary<string, bool>? flags { get; set; }
        public Int64 playtime { get; set; }
        public int deaths { get; set; }
        public string? label { get; set; }
        
	}
}
