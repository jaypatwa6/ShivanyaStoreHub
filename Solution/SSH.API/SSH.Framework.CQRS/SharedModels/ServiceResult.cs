using Newtonsoft.Json.Converters;
using System.Text.Json.Serialization;

namespace SSH.Framework.CQRS.SharedModels
{
    public abstract class BaseServiceResult
    {
        public string Message { get; set; }
        public string MessageLocalizeKey { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public ServiceReturnCode ReturnCode { get; set; }

    }

    public class ServiceResult<TData> : BaseServiceResult
    {
        public TData Data { get; set; }
    }

    public sealed class DefaultServiceResult : ServiceResult<Object>
    {
        public static DefaultServiceResult ConvertFrom<TData>(ServiceResult<TData> serviceResult)
        {
            return new DefaultServiceResult
            {
                Data = serviceResult.Data,
                ReturnCode = serviceResult.ReturnCode,
                Message = serviceResult.Message,
                MessageLocalizeKey = serviceResult.MessageLocalizeKey

            };
        }

        public static ServiceResult<TData> ConvertFrom<TData>(DefaultServiceResult serviceResult)
        {
            return new ServiceResult<TData>
            {
                Data = (TData)serviceResult.Data,
                ReturnCode = serviceResult.ReturnCode,
                Message = serviceResult.Message,
                MessageLocalizeKey = serviceResult.MessageLocalizeKey
            };
        }
    }
}