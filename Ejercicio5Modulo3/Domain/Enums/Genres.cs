using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Ejercicio5Modulo3.Domain.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum Genres
{
    [Description("male")]
    Male,
    [Description("female")]
    Female,
}

