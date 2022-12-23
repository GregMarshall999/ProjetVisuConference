using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisioConference.Data;

namespace VisioConference.DAO
{
    public class AbstractDAO
    {
        public MyContext context;

        public AbstractDAO(MyContext context)
        {
            this.context = context;
        }
    }

}
