using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace fls.DAL
{
    public class ContextFactoy
    {
        public static flsDbContext GetCurrentContext()
        {
            flsDbContext _fContext = CallContext.GetData("flsContext") as flsDbContext;
            if(_fContext == null)
            {
                _fContext = null;
                CallContext.SetData("flsContext", _fContext);
            }
            return _fContext;
        }
    }
}
