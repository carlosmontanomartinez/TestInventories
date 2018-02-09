using System;
using System.Collections.Generic;
using System.Text;

namespace Inventories.Data.Interfaces
{
    public interface IApiConfigurable
    {
        string ApplicationName { get; set; }
        string Version { get; set; }
    }
}
