using Angular.NET.Enums;

namespace Angular.NET.Models
{
    public class ConfigurationModel
    {
        public string          ConnectionString { get; set; }
        public ConnectionTypes ConnectionTypes  { get; set; }
    }
}
