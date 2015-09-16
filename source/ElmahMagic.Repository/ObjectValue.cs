using Newtonsoft.Json;

namespace ElmahMagic.Repository
{
    public class ObjectValue
    {
        public ObjectValue(object value)
        {
            Type = value.GetType().ToString();
            Value = JsonConvert.SerializeObject(value);
        }
        
        public string Type { get; }
        public string Value { get; }
    }
}