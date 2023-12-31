using AutoMapper;
using back.Domain.Dtos;
using back.Domain.Interfaces;
using back.Domain.Models;
using back.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace back_end.Controllers
{
    [ApiController]
    [Route("api/solicitacao")]
    public class SolicitacaoController : ControllerBase
    {
        private readonly IItensRepository _itensRepository;
        private readonly ISolicitacoesRepository _solicitacoesRepository;
        private readonly IMapper _mapper;

        public SolicitacaoController(ISolicitacoesRepository solicitacoesRepository, IItensRepository itensRepository, IMapper mapper)
        {
            this._solicitacoesRepository = solicitacoesRepository;
            this._itensRepository = itensRepository;
            this._mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> PostItens(SolicitacoesDto solicitacao)
        {
            if (solicitacao == null) return BadRequest("dados invalidos");


            var solicitacaoAdicionar = _mapper.Map<SolicitacoesModel>(solicitacao);


            solicitacaoAdicionar.Item = await _itensRepository.GetItensByCodigoAsync(solicitacao.CodigoItem);

            if (solicitacaoAdicionar.Item == null)
            {
                return BadRequest("Item não encontrado para o código fornecido.");
            }

            _solicitacoesRepository.Add(solicitacaoAdicionar);

            return await _solicitacoesRepository.SaveChangesAsync() ? Ok(solicitacaoAdicionar) : BadRequest("error ao salvar a solicitacao");
        }

        [HttpGet]
        public async Task<IActionResult> GetSolicitacoes()
        {
            var solicitacoes = _solicitacoesRepository.GetSolicitacoesAsync();

            return solicitacoes == null ? NotFound() : Ok(solicitacoes.Result);
    }
    }
}
