using AutoMapper;
using FCPark.API.Resources;
using FCPark.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FCPark.API.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Veiculo, VeiculoResource>();
            CreateMap<Estabelecimento, EstabelecimentoResource>();
            CreateMap<MovimentacaoVeiculo, MovimentacaoVeiculoResource>();
            CreateMap<Cliente, ClienteResource>();

            // Resource to Domain
            CreateMap<SaveVeiculoResource, Veiculo>();
            CreateMap<VeiculoResource, Veiculo>();

            CreateMap<SaveEstabelecimentoResource, Estabelecimento>();
            CreateMap<EstabelecimentoResource, Estabelecimento>();


            CreateMap<SaveMovimentacaoVeiculoResource, MovimentacaoVeiculo>();
            CreateMap<MovimentacaoVeiculoResource, MovimentacaoVeiculo>();

            CreateMap<SaveClienteResource, Cliente>();
            CreateMap<ClienteResource, Cliente>();

        }
        
    }
}
