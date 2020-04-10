using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestPrimitive.Entities;
using TestPrimitive.TestData;
using TestPrimitive.Services.Tests.Common;
using TestPrimitive.Services.Interfaces;
namespace TestPrimitive.Services.Tests
{

	[TestFixture]
	public class ProductServiceTest : CommonServiceTest<Product, IProductService>
	{
		[TestCase]
		public void SelectAllTest()
		{
			List<Product> items = this.Service.SelectAll();
			Assert.AreEqual(ProductTestData.ProductCount, items.Count);
		}

		[TestCase]
		public void SelectByTest()
		{
			Product itemTest = ProductTestData.CreateProduct1();

			List<Product> find = this.Service.SelectBy(new Product {Description = itemTest.Description}, new List<string> {"Description"});
			Assert.IsNotNull(find);

			foreach (Product item in find)
			{
				Assert.AreEqual(itemTest.Description, item.Description);
			}
		}

		[TestCase]
		public void SelectByIdTest()
		{
			Product itemTest = ProductTestData.CreateProduct1();

			Product find = this.Service.SelectById(new Product {Id = itemTest.Id});
			Assert.IsNotNull(find);

			ProductTestData.AssertAreEqual(itemTest, find);
		}

		[TestCase]
		public void DeleteTest()
		{
			Product itemTest = ProductTestData.CreateProduct2();
			int affectedRows = this.Service.Delete(itemTest, true);

			List<Product> items = this.Service.SelectAll();
			Assert.AreEqual(items.Count, ProductTestData.ProductCount - 1);
			Assert.AreEqual(-1, affectedRows);
		}

		[TestCase]
		public void InsertTest()
		{
			Product itemTest = new Product
			{
				Description = string.Empty, 
				Name = string.Empty, 
			};

			int affectedRows = this.Service.Insert(itemTest, true);

			List<Product> items = this.Service.SelectAll();
			Assert.AreEqual(items.Count, ProductTestData.ProductCount + 1);
			Assert.AreEqual(1, affectedRows);
		}

		[TestCase]
		public void UpdateTest()
		{
			Product itemTest = ProductTestData.CreateProduct1();

			Product beforeUpdate = this.Service.SelectById(new Product {Id = itemTest.Id});
			beforeUpdate.Description = string.Empty ;
			this.Service.Update(beforeUpdate, true);

			Product afterUpdate = this.Service.SelectById(new Product {Id = itemTest.Id});
			ProductTestData.AssertAreEqual(beforeUpdate, afterUpdate);
		}
	}

}
