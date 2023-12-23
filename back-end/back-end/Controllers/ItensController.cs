using AutoMapper;
using back.Domain.Dtos;
using back.Domain.Interfaces;
using back.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace back.Controllers
{
    [ApiController]
    [Route("api/itens")]
    public class ItensController : ControllerBase
    {
        private readonly IItensRepository _itensRepository;
        private readonly IMapper _mapper;

        public ItensController(IItensRepository itensRepository, IMapper mapper)
        {
            this._itensRepository = itensRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetItens()
        {
            var itens = _itensRepository.GetItensAsync();

            return itens == null ? NotFound() : Ok(itens.Result);
        }


        [HttpPost]
        public async Task<IActionResult> PostItens(ItensDto item)
         {
            if (item == null) return BadRequest("dados invalidos");


            var itemAdicionar = _mapper.Map<ItensModel>(item);

            _itensRepository.Add(itemAdicionar);

            return await _itensRepository.SaveChangesAsync() ? Ok(itemAdicionar) : BadRequest("error ao salvar o item");
        }

    }
}
