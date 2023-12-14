using NovidadesCSharp12.Models;
using System.Text.Json;

Console.WriteLine("Demonstrando a Funcionalidade - Primary Constructo");

//Visualizando o resultado com o Primary Constructor
var primaryConstructor = new CadastroAluno("Aluno 1", "18", "(11) 99999-9999", "Cadastrado");
Console.WriteLine($"Esse é o resultado com primary constructor: {JsonSerializer.Serialize(primaryConstructor)}");

Console.WriteLine();

//Visualizando o resultado com o construtor padrão
var construtor = new CadastroAluno("Aluno 2");
Console.WriteLine($"Esse é o resultado com o construtor: {JsonSerializer.Serialize(construtor)}");