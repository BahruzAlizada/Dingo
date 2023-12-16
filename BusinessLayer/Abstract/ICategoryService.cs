using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;

namespace BusinessLayer.Abstract
{
	public interface ICategoryService
	{
		void Activity(int id);
		Task<List<Category>> GetActiveCategories();
		List<Category> GetCategories();
		void Add(CategoryDto categoryDto);
		void Update(CategoryDto categoryDto);
	}
}
