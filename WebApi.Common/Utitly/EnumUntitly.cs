using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace WebApi.Common.Utitly
{
    public class EnumUntitly
    {

        /// <summary>
        /// 获取枚举的描述值
        /// </summary>
        /// <param name="singleEnum"></param>
        /// <returns></returns>
        public static string GetEnumDirection(Enum singleEnum)
        {
            var obj = singleEnum.GetType().GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            if (obj == null)
            {
                return string.Empty;
            }

            var directionAttribute = obj as DescriptionAttribute;

            return directionAttribute.Description;
        }
    }
}
