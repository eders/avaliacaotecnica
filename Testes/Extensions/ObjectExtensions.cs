using System.Reflection;

namespace Testes.Extensions
{
    public static class ObjectExtensions
    {
        public static void SetPrivateValue<T>(this T obj, string propertyName, object value)
        {
            var type = typeof(T);

            type.GetTypeInfo().GetDeclaredProperty(propertyName).SetValue(obj, value, null);
        }
    }
}
