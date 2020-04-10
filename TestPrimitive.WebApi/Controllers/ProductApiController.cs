using System;
using System.Web.Http;
using System.Collections.Generic;
using TestPrimitive.Entities;
using TestPrimitive.Services.Interfaces;
using TestPrimitive.WebApi.Models;

namespace TestPrimitive.WebApi.Controllers
{
	public class ProductApiController : CommonApiController<Product, IProductService>
	{


	}
}
