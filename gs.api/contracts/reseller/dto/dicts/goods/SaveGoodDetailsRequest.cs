using System.Runtime.Serialization;
using gs.api.contracts.reseller.dto.dicts.goods;

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