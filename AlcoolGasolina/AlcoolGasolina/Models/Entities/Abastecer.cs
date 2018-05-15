using SQLite;

namespace AlcoolGasolina.Models.Entities
{
    public class Abastecer
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Data { get; set; }
        public double Valor { get; set; }
    }
}
