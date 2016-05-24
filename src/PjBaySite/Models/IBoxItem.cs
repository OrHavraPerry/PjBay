using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PjBaySite.Models
{
    public interface IBoxItem
    {
        string Name { get; set; }
        string Description { get;}
        IEnumerable<IBoxItem> Childs { get; }
        
    }
}
