namespace Core.Extensions.Objects
{
    public static class DictionaryExtension
    {
        public static T ToObject<T>(this IDictionary<string, object> source) where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in source)
            {
                someObjectType.GetProperty(item.Key).SetValue(someObject, item.Value, null);
            }

            return someObject;
        }
        public static IDictionary<string, object> Merge(this IDictionary<string, object> source, IDictionary<string, object> target)
        {
            foreach (var item in target)
            {
                source[item.Key] = item.Value;
            }

            return source;
        }
    }
}
