using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IM.DAL;

namespace IM.Facade
{
    public interface IGeneralFacade
    {
        void Dispose();

        List<Advertise> GetAllAdvertise();

        Advertise GetAdvertiseByIID(long CurrentAddID);

        
    }
    class GeneralFacade : CoreFacade, IGeneralFacade
    {
        public GeneralFacade(IDSDBDataContext database)
            : base(database)
        {
        }

        public List<Advertise> GetAllAdvertise()
        {
            return Database.Advertises.ToList();
        }

        public Advertise GetAdvertiseByIID(long currentAddID)
        {
            return Database.Advertises.Where(a => a.IID == currentAddID).FirstOrDefault();
        }
        

    }
}
