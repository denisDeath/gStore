using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace gs.api.infrastructure
{
    /// <summary>
    /// Класс-расширение для работы с сериализаций и десериализацией json.
    /// </summary>
    public static class JsonExtensions
    {
        private static readonly JsonSerializerSettings Settings;
        private static readonly JsonSerializer JsonSerializer;

        static JsonExtensions()
        {
            Settings = new JsonSerializerSettings();
            Settings.Initialize();
            JsonSerializer = JsonSerializer.Create(Settings);
        }

        public static void Initialize(this JsonSerializerSettings settings)
        {
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver
            {
                // Необходимо игнорировать лишние поля, которые включаются в результат из-за интерфейса ISerializable класса Exception.
                IgnoreSerializableInterface = true
            };
            settings.Formatting = Formatting.Indented;
            settings.Converters = new List<JsonConverter>
            {
                new IsoDateTimeConverter
                {
                    DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
                }
            };
        }

        public static string ToJson<T>(this T value)
        {
            return JsonConvert.SerializeObject(value, Settings);
        }

        public static T FromJson<T>(this string value)
        {
            return JsonConvert.DeserializeObject<T>(value, Settings);
        }

        public static object FromJson(this string value)
        {
            return JsonConvert.DeserializeObject(value, Settings);
        }

        public static object FromJson(this string value, Type type)
        {
            return JsonConvert.DeserializeObject(value, type, Settings);
        }

        public static T FromJson<T>(this byte[] value)
        {
            return JsonConvert.DeserializeObject<T>(Encoding.UTF8.GetString(value), Settings);
        }

        public static object FromJson(this byte[] value)
        {
            return JsonConvert.DeserializeObject(Encoding.UTF8.GetString(value), Settings);
        }

        public static T FromJsonObject<T>(this object value)
        {
            return JObject.FromObject(value, JsonSerializer).ToObject<T>(JsonSerializer);
        }
    }
}