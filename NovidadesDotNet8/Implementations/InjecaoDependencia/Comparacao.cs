namespace NovidadesDotNet8.Implementations.InjecaoDependencia
{
    public class Comparacao
    {
        public ComparacaoInstancia ComparacaoInstanciaUm { get; set; }
        public ComparacaoInstancia ComparacaoInstanciaDois { get; set; }
    }
    
    public class ComparacaoInstancia
    {
        public string KeyInjecao { get; set; }
        public Guid InstanciaGeradaConstrutor { get; set; }
        public Guid InstanciaGeradaParametro { get; set; }
    }
}
