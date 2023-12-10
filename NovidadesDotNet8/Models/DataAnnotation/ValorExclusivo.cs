using System.ComponentModel.DataAnnotations;

namespace NovidadesDotNet8.Models.DataAnnotation
{
    public class ValorExclusivo
    {
        [Range(minimum: 10, maximum: 30)]
        public int TesteMinimoMaximo { get; set; }

        [Range(minimum: 10, maximum: 30, MinimumIsExclusive = true, MaximumIsExclusive = true)]
        public int TesteMinimoMaximoExlusivo { get; set; }
    }
}
