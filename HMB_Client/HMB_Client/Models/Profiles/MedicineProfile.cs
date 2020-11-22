using AutoMapper;
using Domain = HMB_DA.Domain;

namespace HMB_Client.Models.Profiles
{
    class MedicineProfile : Profile
	{
		public MedicineProfile()
		{
			CreateMap<Medicine, Domain.Medicine>().ForMember(x => x.Id, opt => opt.Ignore());
			CreateMap<Domain.Medicine, Medicine>();
		}
	}
}
