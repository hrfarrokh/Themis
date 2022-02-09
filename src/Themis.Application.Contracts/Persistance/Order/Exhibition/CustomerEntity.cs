#nullable disable

namespace Themis.Application.Contracts.Persistance
{
    public class CustomerEntity
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
