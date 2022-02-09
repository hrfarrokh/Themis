namespace Themis.Domain
{

    public interface ITrackingCodeGenrationPolicy
    {
        string Next();
        string Verify(string value);
    }
}
