using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSMPT.Entites.Tool
{
  public static  class SplitContact
    {

        /// <summary>
        /// 以分号分割抄送人和密送人
        /// </summary>
        /// <param name="str"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static bool GetCCArray(string str, out List<string> list)
        {
            list = new List<string>();

            if (string.IsNullOrEmpty(str))
            {
                return true;
            }

            if (str.Contains(';'))
            {
                string[] CCList = str.Split(';');

                foreach (var item in CCList)
                {
                    if (!item.Contains('@'))
                    {
                        return false;
                    }
                    list.Add(item);
                }
            }
            else
            {
                if (!str.Contains('@'))
                {
                    return false;
                }
                list.Add(str);
            }

            return true;
        }


    }
}
