using AutoMapper;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Concrete
{
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDal categoryDal;
		private readonly IMapper mapper;
        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
			this.categoryDal = categoryDal;
			this.mapper = mapper;
        }

		public void Activity(int id)
		{
			categoryDal.Activity(id);
		}

		public void Add(CategoryDto categoryDto)
		{
			Category category = mapper.Map<Category>(categoryDto);
			categoryDal.Add(category);
		}

		public Task<List<Category>> GetActiveCategories()
		{
			return categoryDal.GetActiveCategories();
		}

		public List<Category> GetCategories()
		{
			return categoryDal.GetAll();
		}

        public Category GetCategory(int? id)
        {
			return categoryDal.Get(x => x.Id == id);
        }

        public void Update(CategoryDto categoryDto)
		{
			Category category = mapper.Map<Category>(categoryDto);
			categoryDal.Update(category);
		}
	}
}
