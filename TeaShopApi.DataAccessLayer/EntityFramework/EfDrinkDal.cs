﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShopApi.DataAccessLayer.Abstract;
using TeaShopApi.DataAccessLayer.Concrete;
using TeaShopApi.DataAccessLayer.Context;
using TeaShopApi.EntityLayer.Concrete;

namespace TeaShopApi.DataAccessLayer.EntityFramework
{
	public class EfDrinkDal : GenericRepository<Drink>, IDrinkDal
	{
		public EfDrinkDal(TeaContext context) : base(context)
		{
		}
	}
}
