﻿using Core.DataAccess;
using EntityLayer.Concrete;
using System;


namespace DataAccessLayer.Abstract
{
	public interface IProductDal : IRepositoryBase<Product>
	{
		void Activity(int id);
	}
}
