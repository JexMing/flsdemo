using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fls.Models;
using fls.IDAL;
namespace fls.DAL
{
    public class RepositoryFactory
    {
        public static ICustomRepository CustomRepository { get { return new CustomDAL(); } }
    }
}
