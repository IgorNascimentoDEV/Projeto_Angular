using AutoMapper;
using back.Domain.Dtos;
using back.Domain.Models;

namespace back_end.Helpers
{
        public class ApiProfile : Profile
        {
            public ApiProfile()
            {
                CreateMap<ItensModel, ItensDto>();

                CreateMap<ItensDto, ItensModel>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

                CreateMap<SolicitacoesDto, SolicitacoesModel>()
                    .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));



            }
        }
    }
