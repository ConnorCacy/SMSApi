using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SMSApi.Services;
using System.Threading.Tasks;

namespace SMSApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMS : ControllerBase
    {
        private readonly IAgtDbRepository _agtDbRepository;
        private readonly SMSService _smsService;

        public SMS(IAgtDbRepository agtDbRepository, SMSService smsService)
        {
            _agtDbRepository = agtDbRepository;
            _smsService = smsService;
        }

        [HttpPost("SendMessageByAgtNumber")]
        public async Task<JsonResult> SendMessageByAgtNumber(string agtNumber, string msg)
        {
            try
            {
                var phoneNumber = await _agtDbRepository.GetPhoneByAgtNumber(agtNumber);
                return new JsonResult(_smsService.SendMessage(phoneNumber, msg));
            }
            catch (System.Exception ex)
            {
                return new JsonResult(new { Result="Error", Details=ex.Message });
            }
        }
        [HttpPost("SendMessage")]
        public JsonResult SendMessage(string phoneNumber, string msg)
        {
            return new JsonResult(_smsService.SendMessage(phoneNumber, msg));
        }
    }
}
