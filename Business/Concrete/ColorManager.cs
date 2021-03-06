using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        private IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Add(Color color)
        {
            _colorDal.Add(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);

            return new SuccessResult(Messages.ColorDeleted);
        }

        public IDataResult<Color> GetByColorId(int colorId)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId), Messages.ColorsListed);
        }

        [CacheAspect]
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.ColorsListed);
        }

        [SecuredOperation("admin")]
        [CacheRemoveAspect("ICarService.Get")]
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);

            return new SuccessResult(Messages.ColorUpdated);
        }
    }
}
