using Ardalis.SmartEnum;

namespace Themis.Domain
{
    public enum ExhibitionOrderStateCategory
    {
        New,
        InProgress,
        Done
    }

    public sealed class OrderType : SmartEnum<OrderType, string>
    {
        public static readonly OrderType Exhibition = new(nameof(Exhibition));

        private OrderType(string value) : base(value, value)
        {
        }
    }

    public abstract class OrderState : SmartEnum<OrderState, string>
    {
        protected OrderState(string name, string value) : base(name, value)
        {
        }
    }

    public abstract class ExhibitionOrderState : OrderState
    {
        public static readonly ExhibitionOrderState New = new NewExhibitionOrderStateType();

        protected ExhibitionOrderState(string name, string value) : base(name, value)
        { }

        public abstract ExhibitionOrderStateCategory Category { get; }

        private sealed class NewExhibitionOrderStateType : ExhibitionOrderState
        {
            public NewExhibitionOrderStateType() : base("New", "New")
            { }

            public override ExhibitionOrderStateCategory Category => ExhibitionOrderStateCategory.New;

        }
    }
}
