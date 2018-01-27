using System;
using System.Collections.Generic;
using gs.api.contracts.suppliers.goods;
using gs.api.services.suppliers.interfaces;
using gs.api.storage.repositories.interfaces;
using JetBrains.Annotations;

namespace gs.api.services.suppliers
{
    public class GoodsService : IGoodsService
    {
        private readonly ISupplierGoodsRepository SupplierGoodsRepository;

        public GoodsService([NotNull] ISupplierGoodsRepository supplierGoodsRepository)
        {
            SupplierGoodsRepository = supplierGoodsRepository ?? throw new ArgumentNullException(nameof(supplierGoodsRepository));
        }

        public GetGoodsResponse GetGoods()
        {
            throw new NotImplementedException();
        }
    }
}