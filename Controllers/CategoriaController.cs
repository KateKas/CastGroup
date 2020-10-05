using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CastGroup.Config;
using CastGroup.Data.DTO;
using CastGroup.Entities;
using CastGroup.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace CastGroup.Controllers
{

    [ApiController]
    [Route("v1")]
    public class CategoriaController : ControllerBase
    {
        private readonly ILogger<CategoriaController> _logger;
        private ICategoriaRepository _categoriaRepository;
        private IMapper _mapper;

        public CategoriaController(
            ILogger<CategoriaController> logger,
            IMapper mapper,
            ICategoriaRepository categoriaRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _categoriaRepository = categoriaRepository;
        }

        [HttpPost]
        [Route("categoria")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Cria uma nova categoria")]
        public async Task<IActionResult> Create([FromBody] CategoriaDTO categoriaDTO)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDTO);

             try
            {
                // save 
               await _categoriaRepository.Create(categoria);
                return Ok();
            }
            catch (BusinessException ex)
            {
                // return error message if there was an exception
                return BadRequest(new ErrorResponse() { Message = ex.Message });
            }
        }

        [HttpGet]
        [Route("categoria/")]
        [ProducesResponseType(typeof(IEnumerable<CategoriaDTO>), 200)]
        [SwaggerOperation(Summary = "Retorna todos as categorias cadastradas")]

        public IActionResult GetAll()
        {
            return Ok(_categoriaRepository.GetAll());
        }

        [HttpGet]
        [Route("categoria/{id}")]
        [ProducesResponseType(typeof(Categoria), 200)]
        [SwaggerOperation(Summary = "Retorna os dados de uma categoria de acordo com o id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _categoriaRepository.GetById(id));
        }

        [HttpPut]
        [Route("categoria/{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Atualiza os dados de uma categoria de acordo com o id")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CategoriaDTO categoriaDTO)
        {
            var oldCategoria = await _categoriaRepository.GetById(id);

            var mapped = _mapper.Map<Categoria>(categoriaDTO);
            await _categoriaRepository.Update(id, mapped);
            return Ok();
        }

        [HttpDelete]
        [Route("categoria/{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Exclui os dados de uma categoria de acordo com o id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoriaRepository.Delete(id);
            return Ok();
        }
    }
}