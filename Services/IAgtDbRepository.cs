using System.Threading.Tasks;

namespace SMSApi.Services
{
    public interface IAgtDbRepository
    {
        Task<string> GetPhoneByAgtNumber(string agtNumber);
    }
}
