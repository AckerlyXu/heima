using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cn.itcast.bookshop.Model
{
    [Serializable]
    public partial class Publishers
    {
        /// <summary>
        /// Publishers:实体类(属性说明自动提取数据库字段的描述信息)
        /// </summary>
       
     
            public Publishers()
            { }
            #region Model
            private int _id;
            private string _name;
            /// <summary>
            /// 
            /// </summary>
            public int Id
            {
                set { _id = value; }
                get { return _id; }
            }
            /// <summary>
            /// 
            /// </summary>
            public string Name
            {
                set { _name = value; }
                get { return _name; }
            }
            #endregion Model
        }
    }
