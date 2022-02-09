
using Ardalis.GuardClauses;

namespace Themis.Core.Models
{
    public class Money : ValueObject<Money>
    {
        private Currency _currency;
        private decimal _amount;

        public static Money Toman(decimal amount)
        {
            return new Money(amount, Currency.IranianToman);
        }

        public Money(decimal amount, Currency currency)
        {
            _currency = Guard.Against.Null(currency, nameof(currency));
            _amount = Guard.Against.NegativeOrZero(amount, nameof(amount));
        }

        public Currency Currency => _currency;
        public decimal Amount => _amount;

        public Money Add(Money toAdd)
        {
            if (_currency == toAdd._currency)
                return new Money(_amount + toAdd._amount, _currency);
            else
                throw new NonMatchingCurrencyException("You cannot add money with different currencies.");
        }

        public Money Subtract(Money toSubtract)
        {
            if (_currency == toSubtract._currency)
                return new Money(_amount - toSubtract._amount, _currency);
            else
                throw new NonMatchingCurrencyException("You cannot remove money with different currencies.");
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }
}
