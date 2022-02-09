#nullable disable

namespace Themis.Application.Contracts.Persistance
{
    public class CarEntity
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Generation { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }
    }
}
