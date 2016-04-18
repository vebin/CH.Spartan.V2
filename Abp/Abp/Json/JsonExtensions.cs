using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Abp.Json
{
    public static class JsonExtensions
    {
        /// <summary>
        /// Json字符串转换为对象
        /// </summary>
        /// <param name="jsonString">Josn字符串</param>
        /// <returns>T</returns>
        public static T ToObject<T>(this string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString);
        }

        /// <summary>
        /// Converts given object to JSON string.
        /// </summary>
        /// <returns></returns>
        public static string ToJsonString(this object obj, bool camelCase = false, bool indented = false, bool isIgnoreNull = false, string dateTimeFormat = "yyyy'-'MM'-'dd' 'HH':'mm':'ss")
        {
            var options = new JsonSerializerSettings();

            if (camelCase)
            {
                options.ContractResolver = new CamelCasePropertyNamesContractResolver();
            }

            if (indented)
            {
                options.Formatting = Formatting.Indented;
            }
            options.NullValueHandling= isIgnoreNull ? NullValueHandling.Ignore : NullValueHandling.Include;
            options.DateFormatString = dateTimeFormat;
            return JsonConvert.SerializeObject(obj, options);
        }
    }
}
