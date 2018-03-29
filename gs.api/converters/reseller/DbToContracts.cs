using gs.api.contracts.reseller.dto.goods;
using GoodDb = gs.api.storage.model.resellers.goods.Good;

namespace gs.api.converters.reseller
{
    public static class DbToContracts
    {
        public static Good ConvertToGood(this GoodDb source)
        {
            return new Good(source.Id, source.Name,
                source.Description,
                source.ImageUris?.Split(';'),
                source.Barcode,
                source.VendorCode,
                source.Unit);
        }
    }
}