using SPADemo.BusinessEntities;
using System.Collections.Generic;


namespace SPADemo.BusinessServices.Interface
{
    public interface IProductService
    {
        IEnumerable<ProductEntity> GetProducts();
        ProductEntity GetProductById(int id);

        void SaveProduct(ProductEntity customer);
        void DeleteProduct(int id);
    }
}
