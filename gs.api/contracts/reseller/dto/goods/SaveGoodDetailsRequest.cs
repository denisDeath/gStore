using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class SaveGoodDetailsRequest : BaseRequest
    {
        public SaveGoodDetailsRequest(Good good)
        {
            Good = good;
        }

        [DataMember(IsRequired = true)]
        public Good Good { get; set; }
    }
}