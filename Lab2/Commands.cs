using LibraryBLL;
using LibraryBLL.QeuryHelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryDAL;
namespace LibraryUIL
{
    public class Commands : ICommands
    {
        private readonly IQueries _IQeuries;
        private readonly IXMLClassWriters _xMLClassWriters;
        private readonly IXMLClassDeserializer _xMLClassDeserializer;
        private readonly IXMLClassReader _xMLClassReader;
        private readonly IXSDValidation _xSDValidation;
        public Commands(IQueries queries, IXMLClassWriters xMLClassWriters,
            IXMLClassDeserializer xMLClassDeserializer, IXMLClassReader xMLClassReader,
            IXSDValidation xSDValidation)
        {
            _IQeuries = queries;
            _xMLClassWriters = xMLClassWriters;
            _xMLClassDeserializer = xMLClassDeserializer;
            _xMLClassReader = xMLClassReader;
            _xSDValidation = xSDValidation;
        }
        public void ShowInnerJoin()
        {
            var list = _IQeuries.GetInnerJoin();
            foreach (var client in list)
            {
                Console.WriteLine(client.ToString());
            }
        }
        public void ShowAuthorDeserialize(string fileName)
        {
            if (_xSDValidation.MakeValidation(fileName))
            {
                var list = _xMLClassDeserializer.AuthorDeserialize(fileName);
                foreach (var client in list) Console.WriteLine(client.ToString());
            }
        }
    }
}
