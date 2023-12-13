namespace NovidadesDotNet8.Interfaces.InjecaoDependencia
{
    /// <summary>
    /// Vamos usar esse ID para comparar o ID gerado para os tipos de injeção que temos disponíveis
    /// </summary>
    public interface ITesteInjecao
    {
        Guid IdInstanciaValidacao { get; } 
    }
}
