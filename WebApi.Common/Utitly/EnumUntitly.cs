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
            var enumFiled = singleEnum.GetType().GetField(singleEnum.ToString());
            var obj = enumFiled.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();

            if (obj == null)
            {
                return string.Empty;
            }

            var directionAttribute = obj as DescriptionAttribute;

            return directionAttribute.Description;
        }

        /// <summary>
        /// 获取枚举的描述值字典
        /// </summary>
        /// <param name="singleEnum"></param>
        /// <returns></returns>
        public static Dictionary<string,string> GetEnumArrayDirection(Type enumType)
        {
            var enumFileds = enumType.GetFields();
            Dictionary<string, string> enumDictionary = new Dictionary<string, string>();

            foreach (var enumFiled in enumFileds)
            {
                var obj = enumFiled.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault();
                if (obj == null)
                {
                    continue;
                }

                var directionAttribute = obj as DescriptionAttribute;

                enumDictionary.Add(enumFiled.Name, directionAttribute.Description);
            }

            return enumDictionary;
        }

    }
}
