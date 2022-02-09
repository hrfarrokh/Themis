
namespace Themis.Core.Models
{
    public class Currency : ValueObject<Currency>
    {
        public static readonly  Currency IranianToman = new Currency("Iranian Toman", "IRT");

        public Currency(string name, string symbol)
        {
            Name = name;
            Symbol = symbol;
        }

        public string Name { get; }
        public string Symbol { get; }

    }
}
