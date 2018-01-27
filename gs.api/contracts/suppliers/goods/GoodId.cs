using System.Runtime.Serialization;

namespace gs.api.contracts.suppliers.goods
{
    [DataContract]
    public class GoodId : IGoodId
    {
        public GoodId(long id)
        {
            Id = id;
        }

        [DataMember]
        public long Id { get; }
    }
}