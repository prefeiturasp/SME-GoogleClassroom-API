using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace SME.GoogleClassroom.Dominio.Extensoes
{
    public static class EnumExtensao
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
        where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }

        public static string Name(this Enum enumValue)
                => enumValue.GetAttribute<DisplayAttribute>().Name;

        public static string ShortName(this Enum enumValue)
                => enumValue.GetAttribute<DisplayAttribute>().ShortName;

        public static string Description(this Enum enumValue)
                => enumValue.GetAttribute<DisplayAttribute>().Description;

        public static string GroupName(this Enum enumValue)
                => enumValue.GetAttribute<DisplayAttribute>().GroupName;
    }
}
