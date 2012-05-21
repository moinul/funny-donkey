using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using IM.DAL;

namespace IM.Facade
{
    public class TheFacade : IDisposable
    {
        public TheFacade()
        {
            _Database = DatabaseHelper.GetData();
        }

        private IDSDBDataContext _Database;
        public IDSDBDataContext Database
        {
            get
            {
                if (_Database == null)
                    _Database = DatabaseHelper.GetData();

                return _Database;
            }
        }

        #region insert, update and delete method (common for all facade)
        public void Insert<T>(T obj) where T : class
        {
            DatabaseHelper.Insert<T>(obj);
        }

        public void Update<T>(T obj) where T : class
        {
            DatabaseHelper.Update<T>(Database, obj);
        }

        public void Delete<T>(T obj) where T : class, new()
        {
            DatabaseHelper.Delete<T>(Database, obj);
        }

        #endregion

        public void Dispose()
        {
            _Database.Dispose();

        }





        private IGeneralFacade _generalFacade = null;
        public IGeneralFacade GeneralFacade
        {
            get
            {
                if (_generalFacade == null)
                    _generalFacade = new GeneralFacade(Database);

                return _generalFacade;
            }
        }

        private ITanviFacade _tanviFacade = null;
        public ITanviFacade TanviFacade
        {
            get
            {
                if (_tanviFacade == null)
                    _tanviFacade = new TanviFacade(Database);

                return _tanviFacade;
            }
        }
        private IAdvertiseFacade _advertiseFacade = null;
        public IAdvertiseFacade AdvertiseFacade
        {
            get
            {
                if (_advertiseFacade == null)
                    _advertiseFacade = new AdvertiseFacade(Database);

                return _advertiseFacade;
            }
        }

        private IZiaFacade _ziaFacade = null;
        public IZiaFacade ZiaFacade
        {
            get
            {
                if (_ziaFacade == null)
                    _ziaFacade = new ZiaFacade(Database);

                return _ziaFacade;
            }
        }
        private ITransactionFacade _TransactionFacade = null;
        public ITransactionFacade TransactionFacade
        {
            get
            {
                if (_TransactionFacade == null)
                    _TransactionFacade = new TransactionFacade(Database);

                return _TransactionFacade;
            }
        }
        
    }
}
