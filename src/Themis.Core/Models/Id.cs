
namespace Themis.Core.Models
{
    public interface IGuidGenerator
    {
        Guid Generate();
    }

    public class GuidGenerator : IGuidGenerator
    {
        public Guid Generate() => Guid.NewGuid();
    }

    public abstract class Id : ValueObject<Id>
    {
    }
}
