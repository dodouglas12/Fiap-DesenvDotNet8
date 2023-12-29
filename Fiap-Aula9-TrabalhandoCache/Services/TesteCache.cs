using Fiap_Aula9_TrabalhandoCache.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Hosting;

namespace Fiap_Aula9_TrabalhandoCache.Services
{
    public class TesteCache : ITesteCache
    {
        private readonly IServiceProvider _serviceProvider;
        private const string VALOR_INSERIR_CACHE = "Variável com valor padrão";

        public TesteCache(IServiceProvider serviceProvider) 
        {
            _serviceProvider = serviceProvider;
        }

        public string RetornaValorCache()
        {
            var retorno = string.Empty;

            // Recupera a Interface IMemoryCache com o Service Provider
            var cache = _serviceProvider.GetRequiredService<IMemoryCache>();

            // Configura o tempo de expiração do cache
            MemoryCacheEntryOptions options = new()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) //A cada 10 minutos o nosso cache vai ser limpo
            };

            // Vamos verificar se existe alguma informação no cache
            cache.TryGetValue("ValorCache", out object? valor);

            if (valor is null)
            {
                cache.Set("ValorCache", $"Retornado do Cache {VALOR_INSERIR_CACHE}");
                return VALOR_INSERIR_CACHE;
            }

            return (string)valor;
        }
    }
}
