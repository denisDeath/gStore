using System.Runtime.Serialization;

namespace gs.api.contracts.suppliers.goods
{
    public interface IGoodId
    {
        [DataMember]
        long Id { get; }
    }
}