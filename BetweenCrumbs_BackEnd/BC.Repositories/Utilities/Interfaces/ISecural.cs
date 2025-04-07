using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BC.Repositories.Utilities.Interfaces
{
    public interface ISecural
    {
        string CreateConnectionKey(string valor);
        string ConnectionKey(string valor);
        string CreateKey(string valor);
        string DecryptKey(string valor);        
    }
}
