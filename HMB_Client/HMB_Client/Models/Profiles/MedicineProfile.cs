using AutoMapper;
using HMB_Domain.BusinessObjects;

namespace HMB_Client.Models.Profiles
{
    class MedicineProfile : Profile
	{
		public MedicineProfile()
		{
			CreateMap<MedicineModel, Medicine>().ForMember(x => x.Id, opt => opt.Ignore());
			CreateMap<Medicine, MedicineModel>();
		}
	}
}
