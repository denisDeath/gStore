using gs.api.contracts.reseller.dto.goods;

namespace gs.api.contracts.reseller.services.interfaces
{
    public interface IGoodsService
    {
        GetGoodsResponse GetGoods();
        AddGoodResponse AddGood(AddGoodRequest request);
        void RemoveGoods(RemoveGoodsRequest request);
        void SaveGoodDetails(SaveGoodDetailsRequest request);
        GetGoodDetailsResponse GetGoodDetails(GetGoodDetailsRequest request);
    }
}