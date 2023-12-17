using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Concrete
{
	public class ProductManager : IProductService
	{
		private readonly IProductDal productDal;
		private readonly IMapper mapper;
        public ProductManager(IProductDal productDal,IMapper mapper)
        {
            this.productDal = productDal;
			this.mapper=mapper;
        }

        public void Activity(int id)
		{
			productDal.Activity(id);
		}

		public async Task AddAsync(ProductDto productDto)
		{
			Product product = mapper.Map<Product>(productDto);
			await productDal.AddAsync(product);
		}

		public void Delete(int? id)
		{
			Product product = productDal.Get(x => x.Id == id);
			productDal.Delete(product);
		}

        public async Task<Product> GetProductAsync(int? id)
        {
			return await productDal.GetAsync(x => x.Id == id);
        }

        public async Task<List<Product>> GetProductsWithPaged(int take, int page)
        {
			return await productDal.GetProductsWithPaged(take, page);
        }

        public async Task<int> PageCount(double take)
        {
            return await productDal.PageCount(take);
        }

        public async Task UpdateAsync(ProductDto productDto)
		{
			Product product = mapper.Map<Product>(productDto);
			await productDal.UpdateAsync(product);
		}
	}
}
