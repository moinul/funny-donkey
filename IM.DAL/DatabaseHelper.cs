using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;

using System.Text;
using System.Configuration;
using System.Reflection;

namespace IM.DAL
{
    public static class DatabaseHelper
    {
        private const string ConnectionStringName = "IMConnectionString";

        public static IDSDBDataContext GetData()
        {
            var db = new IDSDBDataContext(ConfigurationManager.ConnectionStrings[ConnectionStringName].ConnectionString);
            return db;  
        }

        /// <summary>
        /// insert a new entity into DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        public static void Insert<T>(T obj) where T : class
        {
            var Database = DatabaseHelper.GetData();
            Database.GetTable<T>().InsertOnSubmit(obj);

            //finally submit an add/updated entity object to database
            try
            {
                Database.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException e)
            {
                foreach (ObjectChangeConflict cc in Database.ChangeConflicts)
                {
                    //No database values are automerged into current
                    cc.Resolve(RefreshMode.KeepCurrentValues);
                }
            }
        }

        /// <summary>
        /// update single entity of a table
        /// </summary>
        /// <typeparam name="BookingDJDataContext"></typeparam>
        /// <param name="obj"></param>
        public static void Update<T>(IDSDBDataContext Database, T obj) where T : class
        {
            //finally submit an add/updated entity object to database
            try
            {
                Database.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException e)
            {
                foreach (ObjectChangeConflict cc in Database.ChangeConflicts)
                {
                    //No database values are automerged into current
                    cc.Resolve(RefreshMode.KeepCurrentValues);
                }
            }
        }

        /// <summary>
        /// update multiple entities of a single table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="update"></param>
        public static void UpdateAll<T>(List<T> items, Action<IDSDBDataContext, T> update) where T : class
        {
            var Database = DatabaseHelper.GetData();
            foreach (T item in items)
            {
                update(Database, item);
            }

            //finally submit all add/update entity object to database
            try
            {
                Database.SubmitChanges(ConflictMode.ContinueOnConflict);
            }
            catch (ChangeConflictException e)
            {
                foreach (ObjectChangeConflict cc in Database.ChangeConflicts)
                {
                    //No database values are automerged into current
                    cc.Resolve(RefreshMode.KeepCurrentValues);
                }
            }
        }

        public static void Delete<T>(IDSDBDataContext Database, T entity) where T : class, new()
        {
            //var Database = DatabaseHelper.GetBookingDJData();
            //Database.GetTable<T>().Attach(entity);
            Database.GetTable<T>().DeleteOnSubmit(entity);

            try
            {
                Database.SubmitChanges();
            }
            catch (ChangeConflictException e)
            {
                foreach (ObjectChangeConflict cc in Database.ChangeConflicts)
                {
                    //No database values are automerged into current
                    cc.Resolve(RefreshMode.OverwriteCurrentValues);
                }
            }
        }

        private static T Clone<T>(T objsrc, T objdest)
        {
            PropertyInfo[] propertyInfos = (typeof(T).GetProperties());

            foreach (PropertyInfo pInfo in propertyInfos)
            {
                bool isAssosiation = false;
                foreach (object a in pInfo.GetCustomAttributes(true))
                {
                    // Returns if the property is in Assosiation
                    if (a.GetType() == typeof(System.Data.Linq.Mapping.AssociationAttribute))
                    {
                        isAssosiation = true;
                        break;
                    }
                }
                // Set the Properties source value
                if (isAssosiation == false && pInfo.Name != "CreateDate")
                {
                    pInfo.SetValue(objdest, pInfo.GetValue(objsrc, null), null);
                }
            }
            return objdest;
        }

        private static T FillCommonFields<T>(T obj, long currentuser, bool isInserting)
        {
            PropertyInfo[] propertyInfos = (typeof(T).GetProperties());

            foreach (PropertyInfo pInfo in propertyInfos)
            {
                switch (pInfo.Name)
                {
                    case "TimeCheck":
                        {
                            pInfo.SetValue(obj, DateTime.Now, null);
                            break;

                        }

                    case "UpdatedBy":
                        {
                            pInfo.SetValue(obj, currentuser, null);
                            break;

                        }
                }
                if (isInserting == true)
                {
                    switch (pInfo.Name)
                    {
                        case "CreatedBy":
                            {
                                pInfo.SetValue(obj, currentuser, null);
                                break;

                            }
                        case "CreateDate":
                            {
                                pInfo.SetValue(obj, DateTime.Now, null);
                                break;
                            }
                        case "IsRemoved":
                            {
                                pInfo.SetValue(obj, 0, null);
                                break;
                            }
                    }
                }
            }
            return obj;
        }

    }
}
