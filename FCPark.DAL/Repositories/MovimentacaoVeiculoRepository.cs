using FCPark.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FCPark.DAL.Repositories
{
    public class MovimentacaoVeiculoRepository : RepositoryBaseEF<MovimentacaoVeiculo>, IMovimentacaoVeiculoRepository
    {
        public MovimentacaoVeiculoRepository(FCParkDbContext context)
    : base(context)
        { }
        public Task<MovimentacaoVeiculo> GetMovimentacaoPorPlaca(string prPlaca)
        {
            var mVeiculoResult = from mveiculo in FCParkDbContext.MovimentacaoVeiculos
                                 join veiculo in FCParkDbContext.Veiculos
                                 on mveiculo.VeiculoId equals veiculo.Id
                                 where veiculo.Placa == prPlaca
                                 select mveiculo;

            return mVeiculoResult.FirstOrDefaultAsync();
        }
        public Task<MovimentacaoVeiculo> GetMovimentacaoPorCPF(string prCPF)
        {
            var mVeiculoResult = from mveiculo in FCParkDbContext.MovimentacaoVeiculos
                                 join veiculo in FCParkDbContext.Veiculos
                                 on mveiculo.VeiculoId equals veiculo.Id
                                 join cliente in FCParkDbContext.Clientes
                                 on mveiculo.ClienteId equals cliente.Id
                                 where cliente.CPF == prCPF
                                 select mveiculo;


            return mVeiculoResult.FirstOrDefaultAsync();
        }
        public Task<MovimentacaoVeiculo> GetMovimentacaoPlacaHoje(string prPlaca)
        {

            var mVeiculoResult = from mveiculo in FCParkDbContext.MovimentacaoVeiculos
                          join veiculo in FCParkDbContext.Veiculos
                          on mveiculo.VeiculoId equals veiculo.Id
                          where veiculo.Placa == prPlaca 
                          && mveiculo.DataEntrada.Value.Date == DateTime.Today.Date
                          && mveiculo.DataSaida == null
                          select mveiculo;

            return mVeiculoResult.FirstOrDefaultAsync();
        }

        public Task<List<MovimentacaoVeiculo>> GetMovimentacaoPlacaDia(DateTime prData)
        {
            var mVeiculoResult = from mveiculo in FCParkDbContext.MovimentacaoVeiculos
                                 join veiculo in FCParkDbContext.Veiculos
                                 on mveiculo.VeiculoId equals veiculo.Id
                                 where mveiculo.DataEntrada == prData
                                 select mveiculo;

            return mVeiculoResult.ToListAsync();
        }

        public Task<List<MovimentacaoVeiculo>> GetMovimentacaoSemSaida(DateTime prData)
        {
            return FCParkDbContext.MovimentacaoVeiculos.Where(a => a.DataEntrada == prData && a.DataSaida == null).ToListAsync();
        }

        public Task<List<TotalsReport>> GetTotalEntradaDiaHora(DateTime prData)
        {
            var retorno = FCParkDbContext.MovimentacaoVeiculos
                .Where(x => x.DataEntrada.Value.Date == prData.Date)
                        .GroupBy(row => new
                        {
                            Date = row.DataEntrada.Value.Date,
                            Hour = row.DataEntrada.Value.Hour
                        })
                        .Select(grp => new TotalsReport
                        {
                            Dia = grp.Key.Date,
                            Movimento = "ENTRADA",
                            Hora = grp.Key.Hour,
                            Total = grp.Count()
                        });

            return retorno.ToListAsync();
        }

        public Task<List<TotalsReport>> GetTotalSaidaDiaHora(DateTime prData)
        {
            var retorno = FCParkDbContext.MovimentacaoVeiculos
                .Where(x => x.DataSaida.Value.Date == prData.Date)
                        .GroupBy(row => new
                        {
                            Date = row.DataSaida.Value.Date,
                            Hour = row.DataSaida.Value.Hour
                        })
                        .Select(grp => new TotalsReport
                        {
                            Dia = grp.Key.Date,
                            Hora = grp.Key.Hour,
                            Movimento = "SAÍDA",
                            Total = grp.Count()
                        });

            return retorno.ToListAsync();
        }

        public Task<List<TotalsReport>> GetTotalEntradaSaidaDia(DateTime prData)
        {
            var retorno = FCParkDbContext.MovimentacaoVeiculos.Where(x => x.DataEntrada != null && x.DataEntrada.Value.Date == prData.Date)
                        .GroupBy(row => new
                        {
                            Date = row.DataEntrada.Value.Date
                        })
                        .Select(grp => new TotalsReport
                        {
                            Dia = grp.Key.Date,
                            Movimento = "ENTRADA",
                            Total = grp.Count()
                        }).Union(FCParkDbContext.MovimentacaoVeiculos.Where(x => x.DataSaida != null && x.DataSaida.Value.Date == prData.Date)
                        .GroupBy(row => new
                        {
                            Date = row.DataSaida.Value.Date
                        })
                        .Select(grp => new TotalsReport
                        {
                            Dia = grp.Key.Date,
                            Movimento = "SAIDA",
                            Total = grp.Count()
                        }));

            return retorno.ToListAsync();
        }


        private FCParkDbContext FCParkDbContext
        {
            get { return _context as FCParkDbContext; }
        }
    }
}