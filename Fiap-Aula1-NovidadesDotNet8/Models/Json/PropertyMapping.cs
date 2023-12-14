using System.Text.Json.Serialization;

namespace NovidadesDotNet8.Models.Json
{
    /// <summary>
    /// Define que caso seja enviado membros não mapeados, será apresentado erro
    /// </summary>
    [JsonUnmappedMemberHandling(JsonUnmappedMemberHandling.Disallow)]
    public class PropertyMapping
    {
        public string Nome { get; set; }

        public int Idade { get; set; }
    }
}
