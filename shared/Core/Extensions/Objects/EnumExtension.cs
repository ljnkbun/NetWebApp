using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Core.Extensions.Objects
{
    public static class EnumExtension
    {
        public static bool IsTypeNullable(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        public static Type GetBaseType(Type type)
        {
            return IsTypeNullable(type) ? type.GetGenericArguments()[0] : type;
        }

        public static bool In<T>(this T val, params T[] values) where T : IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            return values.Contains(val);
        }

        public static string ToDescription(this Enum val)
        {
            return val.GetType()
                    .GetMember(val.ToString())
                    .First()
                    .GetCustomAttribute<DescriptionAttribute>()?
                    .Description ?? string.Empty;
        }
        static public string GetDisplayName<T>(this T myenum)
        {
            var enumName = myenum.GetType().GetMember(myenum.ToString()).FirstOrDefault().GetCustomAttribute<DisplayAttribute>().GetName();
            return enumName ?? myenum.ToString();
        }
    }
}
