using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public void Add(Color color)
        {
            if (color.ColorName.Length > 1)
            {
                _colorDal.Add(color);
            }
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public Color Get(int colorId)
        {
            return _colorDal.Get(c => c.ColorId == colorId);
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
