using NovidadesDotNet8.Interfaces.InjecaoDependencia;

namespace NovidadesDotNet8.Implementations.InjecaoDependencia
{
    public class TesteInjecao : ITesteInjecao
    {
        /// <summary>
        /// Definindo o Guid para validarmos o comportamento
        /// </summary>
        public Guid IdInstanciaValidacao { get; } = Guid.NewGuid();
    }
}
