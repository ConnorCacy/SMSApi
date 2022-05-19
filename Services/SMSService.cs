using System;

namespace SMSApi.Services
{
    public class SMSService
    {
        public SMSResult SendMessage(string phoneNumber, string msg)
        {
            var result = new SMSResult();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                result.Result = SMSResult.ResultType.SMS_ERROR;
                result.Details = "Phone number invalid or not found";
            }
            else
            {
                //SMS API logic goes here...
                result.Result = SMSResult.ResultType.SMS_SUCCESS;
                result.Details = $"Message sent to {phoneNumber} @{DateTime.Now}: {msg}";
            }
            return result;
        }
        public class SMSResult
        {
            public ResultType Result { get; set; }
            public enum ResultType { SMS_SUCCESS, SMS_ERROR };
            public string Details { get; set; }
        }
    }
}
