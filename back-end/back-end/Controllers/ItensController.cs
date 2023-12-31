using AutoMapper;
using back.Domain.Dtos;
using back.Domain.Interfaces;
using back.Domain.Models;
using back.Infrastructure.Repositories;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemById(long id)
        {
            var itemBuscado = _itensRepository.GetItensByIdAsync(id);

            return itemBuscado == null ? BadRequest("Item não encontrado") : Ok(itemBuscado.Result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(long id, ItensDto item)
        {
            var itemBuscado = await _itensRepository.GetItensByIdAsync(id);

            if (itemBuscado == null) return BadRequest("Item não encontrado");

            _mapper.Map(item, itemBuscado);

            _itensRepository.Update(itemBuscado);

            var saveResult = await _itensRepository.SaveChangesAsync();

            return saveResult ? Ok(itemBuscado) : BadRequest("Não foi possível atualizar o item");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(long id)
        {
            var itemBuscado = await _itensRepository.GetItensByIdAsync(id);

            if (itemBuscado == null) return BadRequest("Item não encontrado");

            _itensRepository.Delete(itemBuscado);

            return await _itensRepository.SaveChangesAsync() ? Ok(itemBuscado) : BadRequest("Error ao salvar");
        }

    }
}
