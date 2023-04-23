using LibraryBLL;
using LibraryBLL.QeuryHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryUIL
{
    public class Commands : ICommands
    {
        private readonly IQueries _IQeuries;
        public Commands(IQueries queries)
        {
            _IQeuries = queries;
        }
        public void ShowInnerJoin()
        {
            var list = _IQeuries.GetInnerJoin();
            foreach (var client in list)
            {
                Console.WriteLine(client.ToString());
            }
        }
    }
}
