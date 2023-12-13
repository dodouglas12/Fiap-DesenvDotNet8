using System.ComponentModel.DataAnnotations;

namespace NovidadesDotNet8.Models.DataAnnotation
{
    public class ValorExclusivo
    {
        /// <summary>
        /// Valores 10 e 30 são aceitos
        /// </summary>
        [Range(minimum: 10, maximum: 30)]
        public int TesteMinimoMaximo { get; set; }

        /// <summary>
        /// Valores 10 e 30 também são recusados
        /// </summary>

        [Range(minimum: 10, maximum: 30, MinimumIsExclusive = true, MaximumIsExclusive = true)]
        public int TesteMinimoMaximoExlusivo { get; set; }
    }
}
