using LibraryBLL.QeuryHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBLL
{
    public interface IQueries
    {
        public IEnumerable<HelpClassInnerJoinClientSubscription> GetInnerJoin();
    }
}
