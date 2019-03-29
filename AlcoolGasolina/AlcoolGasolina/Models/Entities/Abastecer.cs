using SQLite;

namespace AlcoolGasolina.Models.Entities
{
    [Xamarin.Forms.Internals.Preserve(AllMembers = true)]
    public class Abastecer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Data { get; set; }
        public string Combustivel { get; set; }
        public string ValorLitro { get; set; }
        public string Valor { get; set; }
    }
}
