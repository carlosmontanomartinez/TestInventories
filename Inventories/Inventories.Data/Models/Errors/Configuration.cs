using System;
using System.Collections.Generic;
using System.Text;
using Inventories.Data.Interfaces;

namespace Inventories.Data.Models.Errors
{
    public class Configuration : IApiConfigurable
    {
        public string ApplicationName { get; set; }
        public string Version { get; set; }
    }

    
}
