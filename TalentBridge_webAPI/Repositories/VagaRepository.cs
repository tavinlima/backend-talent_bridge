﻿using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using TalentBridge_webAPI.data;
using TalentBridge_webAPI.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace talentbridge_webAPI.Repositories
{
    public class VagaRepository : IVagaRepository
    {
        private readonly TalentBridgeContext ctx = new();
        readonly IUsuarioRepository usuarioRepository;
        readonly IEmpresaRepository empresaRepository;
        public VagaRepository(TalentBridgeContext ctx, IEmpresaRepository empresaRepository, IUsuarioRepository usuarioRepository)
        {
            this.ctx = ctx;
            this.empresaRepository = empresaRepository;
            this.usuarioRepository = usuarioRepository;
        }
        public async Task<Vaga> Create(CadastroVagasViewModel vaga)
        {
            try
            {
                Vaga novaVaga = new Vaga()
                {
                    Titulo = vaga.Titulo,
                    Senioridade = vaga.Senioridade,
                    Cnpj = vaga.Cnpj,
                    Descricao = vaga.Descricao,
                    ModeloTrabalho = vaga.ModeloTrabalho,
                    DataInicio = vaga.DataInicio,
                    DataFim = vaga.DataFim,
                    Disponivel = vaga.Disponivel
                };

                ctx.Vagas.Add(novaVaga);
                await ctx.SaveChangesAsync();

                return novaVaga;

            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            
        }

        public Task<Vaga> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> UpdateSituation(int Id)
        {
            try
            {
                Vaga vagaBuscada = await GetById(Id);

                if (vagaBuscada != null)
                {
                    await ctx.Vagas
                        .Where(x => x.IdVaga == Id)
                        .ExecuteUpdateAsync(x => x.SetProperty(x => x.Disponivel, x => !x.Disponivel));

                    return "Status alterado com sucesso!";
                }

                return "Ops! Não foi encontrad a avaga informada";
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            


        }

        public async Task<List<Vaga>> GetAll()
        {
            try
            {
                return await ctx.Vagas.AsNoTracking()
                    .Include(e => e.CnpjNavigation)
                    .ThenInclude(e => e.IdUsuarioNavigation)
                    .ToListAsync();
            }
            catch (Exception error)
            {
                throw new Exception(error.Message);
            }
            
        }

        public async Task<List<Vaga>> GetByCNPJ(string CNPJ)
        {
            return await ctx.Vagas.AsNoTracking()
                .Include(e => e.CnpjNavigation)
                .Where(v => v.CnpjNavigation.Cnpj == CNPJ)
                .ToListAsync();
        }

        public async Task<Vaga> GetById(int Id)
        {
            return await ctx.Vagas.Include(e => e.CnpjNavigation).FirstOrDefaultAsync(v => v.IdVaga == Id);
        }
    }
}
