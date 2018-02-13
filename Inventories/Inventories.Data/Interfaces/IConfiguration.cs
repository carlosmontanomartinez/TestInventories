using System;
using System.Collections.Generic;
using System.Text;

namespace Inventories.Data.Interfaces
{
    public interface IApiConfiguration
    {
        string ApplicationName { get; set; }
        string Version { get; set; }
    }
}
