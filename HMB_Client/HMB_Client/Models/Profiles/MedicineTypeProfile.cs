using AutoMapper;
using Domain = HMB_DA.Domain;

namespace HMB_Client.Models.Profiles
{
    public class MedicineTypeProfile : Profile
    {
        public MedicineTypeProfile()
        {
            CreateMap<MedicineType, Domain.MedicineType>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<Domain.MedicineType, MedicineType>();
        }
    }
}
