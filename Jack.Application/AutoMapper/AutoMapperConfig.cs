using AutoMapper;
using Jack.Application.AutoMapper;
using Jack.Application.ViewModel;
using Jack.Domain.Entity;


namespace Jack.Application.AutoMapper
{                      
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<DomainToViewModelMappingProfile>();
                x.AddProfile<ViewModelToDomainMappingProfile>();
            });

        }
    }
}