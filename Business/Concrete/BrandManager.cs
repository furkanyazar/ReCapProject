﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.Name.Length > 1)
            {
                _brandDal.Add(brand);
            }
        }

        public void Delete(Brand brand)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        public Brand GetById(int id)
        {
            return _brandDal.Get(b => b.Id == id);
        }

        public void Update(Brand brand)
        {
            throw new NotImplementedException();
        }
    }
}
