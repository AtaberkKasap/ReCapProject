using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;

        public InMemoryBrandDal(List<Brand> brands)
        {
            _brands = brands;
        }

        public void Add(Brand brand)
        {
            _brands.Add(brand);
        }

        public void Delete(Brand brand)
        {
            Brand brandToBeDeleted = _brands.SingleOrDefault(b => b.BrandId == brand.BrandId);

            _brands.Remove(brandToBeDeleted);
        }

        public List<Brand> GetAll()
        {
            return _brands;
        }

        public Brand GetById(int brandId)
        {
            return _brands.Find(b => b.BrandId == brandId);
        }

        public void Update(Brand brand)
        {
            Brand brandToBeUpdated = _brands.SingleOrDefault(c => c.BrandId == brand.BrandId);
            brandToBeUpdated = brand;
        }
    }
}
