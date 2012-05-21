using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.DAL;

namespace IM.Facade
{
    class CoreFacade : IDisposable
    {
        private IDSDBDataContext _Database;

        public IDSDBDataContext Database
        {
            get
            {
                return _Database;
            }
        }

        public CoreFacade(IDSDBDataContext database)
        {
            _Database = database;
        }

        public CoreFacade()
        {


        }

        public void Dispose()
        {
            _Database.Dispose();
        }
    }
}
