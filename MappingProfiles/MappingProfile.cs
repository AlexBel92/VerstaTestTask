using AutoMapper;
using VerstaTestTask.Core.Models;
using VerstaTestTask.Models;

namespace VerstaTestTask.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderViewModel, Order>()
                .ForMember(
                    cm => cm.RecipientCity,
                    options => options.MapFrom(vm => vm.RecipientAddress))
                .ForMember(
                    cm => cm.RecipientAddress,
                    options => options.MapFrom(vm => vm.RecipientAddress))
                .ForMember(
                    cm => cm.SenderCity,
                    options => options.MapFrom(vm => vm.SenderAddress))
                .ForMember(
                    cm => cm.SenderAddress,
                    options => options.MapFrom(vm => vm.SenderAddress));

            CreateMap<AddressViewModel, City>()
                .ForMember(
                    cm => cm.Name,
                    options => options.MapFrom(vm => vm.CityName));

            CreateMap<AddressViewModel, Address>();

            CreateMap<Order, OrderViewModel>()
                .ForMember(
                    vm => vm.RecipientAddress,
                    options => options.MapFrom(cm => cm.RecipientAddress))
                .ForMember(
                    vm => vm.SenderAddress,
                    options => options.MapFrom(cm => cm.SenderAddress));

            CreateMap<Address, AddressViewModel>()
                .ForMember(
                    vm => vm.CityName,
                    options => options.MapFrom(cm => cm.City.Name));
        }
    }
}
