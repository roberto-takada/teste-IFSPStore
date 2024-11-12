using AutoMapper;
using FluentValidation;
using IFSPStore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Services.Service
{
    public class BaseService<TEntity>: IBaseService<TEntity> where TEntity: IBaseEntity
    {
        private readonly IBaseRepository<TEntity> _baseRepository;
        private readonly IMapper _mapper;

        public BaseService(IBaseRepository<TEntity> baseRepository, IMapper mapper)
        {
            _baseRepository = baseRepository;
            _mapper = mapper;
        }

        public TOutputModel Add<TInputModel, TOutputModel, TValidator>(TInputModel InputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(InputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Insert(entity);
            var OutputModel = _mapper.Map<TOutputModel>(entity);
            return OutputModel;
        }

        public void AttachObject(object obj)
        {
            _baseRepository.AtachObject(obj);
        }

        public void Delete(int id)
        {
            _baseRepository.Delete(id);
        }

        public IEnumerable<TOutputModel> Get<TOutputModel>(IList<string>? includes = null) where TOutputModel : class
        {
            var entities = _baseRepository.Select(includes);
            var OutputModel = entities.Select(s => _mapper.Map<TOutputModel>(s));
            return OutputModel;
        }

        public TOutputModel GetById<TOutputModel>(int id, IList<string>? includes = null) where TOutputModel : class
        {
            var entity = _baseRepository.Select(includes);
            var OutputModel = _mapper.Map<TOutputModel>(entity);
            return OutputModel;
        }

        public TOutputModel Update<TInputModel, TOutputModel, TValidator>(TInputModel InputModel)
            where TInputModel : class
            where TOutputModel : class
            where TValidator : AbstractValidator<TEntity>
        {
            var entity = _mapper.Map<TEntity>(InputModel);
            Validate(entity, Activator.CreateInstance<TValidator>());
            _baseRepository.Update(entity);
            var OutputModel = _mapper.Map<TOutputModel>(entity);
            return OutputModel;
        }

        private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        {
            if(obj == null)
            {
                throw new Exception("Objeto inválido");
            }
            validator.ValidateAndThrow(obj);
        }
    }
}
