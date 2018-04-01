using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.goods
{
    [DataContract]
    public class AddGoodResponse
    {
        public AddGoodResponse(long addedGoodId)
        {
            AddedGoodId = addedGoodId;
        }

        [DataMember(IsRequired = true)]
        public long AddedGoodId { get; set; }
    }
}