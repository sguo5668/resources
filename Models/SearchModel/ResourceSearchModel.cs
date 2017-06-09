using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Models.SearchModel
{
    public class ResourceSearchModel
    {
    
        public string Key { get; set; }
        public ResourceType ResourceType { get; set; }
        public Culture Culture { get; set; }
    }
}
