using AutoMapper;
using Jack.Application.AutoMapper;
using Jack.DomainValidator;

namespace Jack.Application
{
    public class AppServiceBase
    {
        protected readonly IMapper Mapper;
        protected ValidationResult ValidationalidationResult;
        public AppServiceBase()
        {
            Mapper = AutoMapperConfig.Config.CreateMapper();

        }
    }

}