using MessagePack;
using System.Net.Sockets;
using System.Text.Json;
using System.Text.Json.Serialization;

Console.WriteLine("Aprendendo sobre JSON");

var dados = new Dados { Id = 1, Nome = "Teste Nome", Endereco = "Teste Endereço"};

//Serializando de maneira convencional
Console.WriteLine(JsonSerializer.Serialize(dados));

//Serializando definindo o tipo da variável
Console.WriteLine(JsonSerializer.Serialize<Dados>(dados));

//Serializando e exibindo o resultado formatado
Console.WriteLine(JsonSerializer.Serialize(dados, options: new JsonSerializerOptions { WriteIndented = true }));

//Serializando com o MessagePack
var serializacao = MessagePackSerializer.Serialize<Dados>(dados);
Console.WriteLine(serializacao);
Console.WriteLine(MessagePackSerializer.ConvertToJson(serializacao));



[MessagePackObject]
public class Dados {
    [Key(0)]
    public int Id { get; set; }
    [Key(1)]
    public string Nome { get; set; }
    [Key(2)]
    public string Endereco { get; set; }
}