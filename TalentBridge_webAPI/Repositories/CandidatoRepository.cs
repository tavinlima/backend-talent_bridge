﻿using Microsoft.EntityFrameworkCore;
using talentbridge_webAPI.Domains;
using talentbridge_webAPI.Interfaces;
using talentbridge_webAPI.ViewModel;
using TalentBridge_webAPI.data;

namespace talentbridge_webAPI.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        readonly TalentBridgeContext ctx = new();
        private readonly IUsuarioRepository usuarioRepository;

        public CandidatoRepository(TalentBridgeContext ctx, IUsuarioRepository usuarioRepository)
        {
            this.ctx = ctx;
            this.usuarioRepository = usuarioRepository;
        }

        public async Task<Candidato> CreateCandidate(CadastroCandidato candidato)
        {
            using (var transaction = await ctx.Database.BeginTransactionAsync())
                try
                {

                    Usuario novoUsuario = await usuarioRepository.CreateUser(candidato.Usuario);

                    Candidato novoCandidato = new()
                    {
                        DataNascimento = candidato.DataNascimento,
                        Cpf = candidato.Cpf,
                        IdUsuario = novoUsuario.IdUsuario
                    };

                    await ctx.Candidatos.AddAsync(novoCandidato);

                    await ctx.SaveChangesAsync();

                    // Confirmar a transação
                    await transaction.CommitAsync();

                    return novoCandidato;

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
        }

        public async Task<string> DeleteCandidate(string cpf)
        {
            Candidato candidatoBuscado = await GetCandidateByCpf(cpf);
            if (candidatoBuscado != null)
            {
                ctx.Remove(candidatoBuscado);
                

                await ctx.SaveChangesAsync();

                return "Candidato excluído com sucesso";
            }
            return "Candidato não encontrada";
        }

        public async Task<List<Candidato>> GetAll()
        {
            return await ctx.Candidatos.AsNoTracking()
                .Include(c => c.IdUsuarioNavigation)
                .Include(u => u.IdUsuarioNavigation.IdContatoNavigation)
                .Include(u => u.IdUsuarioNavigation.IdEnderecoNavigation)
                .Include(c => c.Projetos)
                .Include(c => c.Skills)
                .Include(c => c.Aplicacos)
                .Include(c => c.Escolaridades)
                .Include(c => c.Certificacaos)
                .Include(c => c.Experiencia)
                .Include(c => c.Idiomas)
                .ToListAsync();
        }

        public async Task<Candidato> GetCandidateByCpf(string cpf)
        {
            return await ctx.Candidatos.AsNoTracking()
                .Include(c => c.IdUsuarioNavigation)
                .Include(u => u.IdUsuarioNavigation.IdContatoNavigation)
                .Include(u => u.IdUsuarioNavigation.IdEnderecoNavigation)
                .Include(c => c.Projetos)
                .Include(c => c.Skills)
                .Include(c => c.Aplicacos)
                .Include(c => c.Escolaridades)
                .Include(c => c.Certificacaos)
                .Include(c => c.Experiencia)
                .Include(c => c.Idiomas)
                .FirstOrDefaultAsync(c => c.Cpf == cpf) ?? throw new Exception("Candidato não encontrado. Tente com outro cpf"); ;
        }

        public async Task<Candidato> GetCandidateByEmail(string email)
        {
            return await ctx.Candidatos.AsNoTracking()
                .Include(e => e.IdUsuarioNavigation)
                .Include(e => e.IdUsuarioNavigation.IdEnderecoNavigation)
                .Include(e => e.IdUsuarioNavigation.IdContatoNavigation)
                .FirstOrDefaultAsync(e => e.IdUsuarioNavigation.Email == email);
        }

        public async Task<Candidato> UpdateCandidate(CadastroCandidato candidato)
        {
            using (var transaction = await ctx.Database.BeginTransactionAsync())
                try
                {

                    Candidato candidatoBuscado = await GetCandidateByCpf(candidato.Cpf);

                    Usuario novoUsuario = await usuarioRepository.UpdateUser(candidato.Usuario);

                    Candidato novoCandidato = new()
                    {
                        DataNascimento = candidato.DataNascimento,
                        Cpf = candidato.Cpf,
                        IdUsuario = candidatoBuscado.IdUsuario
                    };

                    ctx.Candidatos.Update(novoCandidato);

                    await ctx.SaveChangesAsync();

                    // Confirmar a transação
                    await transaction.CommitAsync();

                    return novoCandidato;

                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw new Exception(ex.Message);
                }
        }
    }
}
