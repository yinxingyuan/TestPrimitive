using MetaShare.Common.Core.Daos;
using TestPrimitive.Entities;
using TestPrimitive.Daos.Interfaces;
using TestPrimitive.TestData;

namespace TestPrimitive.Daos.Mocks
{
	public class ProductDaoMock : MockDao<Product>, IProductDao
	{
		public ProductDaoMock() : base(ProductTestData.CreateProduct())
		{
		}
	}
}
