using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using cn.itcast.bookshop.Model;
using cn.itcast.bookshop.DAL;
using cn.itcast.bookshop.Common;

namespace cn.itcast.bookshop.BLL
{
    public class SettingsBll
    {
        private SettingsDal dal = new SettingsDal();

        public string GetValue(string name)
        {
            string value = CacheHelper.GetCacheValue(name) as string ;
            if (value == null) {
                value = dal.GetValue(name);
                CacheHelper.SetCacheValue(name, value);
            }
            return value;
        }
        public int SetValue(string name, string value)
        {

            CacheHelper.SetCacheValue(name, value);
            return dal.SetValue(name, value);
        }

    }
}
