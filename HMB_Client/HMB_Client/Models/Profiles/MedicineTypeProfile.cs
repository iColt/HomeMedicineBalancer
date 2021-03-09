using AutoMapper;
using HMB_Domain.BusinessObjects;

namespace HMB_Client.Models.Profiles
{
    public class MedicineTypeProfile : Profile
    {
        public MedicineTypeProfile()
        {
            CreateMap<MedicineTypeModel, MedicineType>().ForMember(x => x.Id, opt => opt.Ignore());
            CreateMap<MedicineType, MedicineTypeModel>();
        }
    }
}
