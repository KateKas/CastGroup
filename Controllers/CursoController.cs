using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CastGroup.Data.DTO;
using CastGroup.Entities;
using CastGroup.Interfaces;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using CastGroup.Config;

namespace CastGroup.Controllers
{

    [ApiController]
    [Route("v1")]
    public class CursoController : ControllerBase
    {
        private readonly ILogger<CursoController> _logger;
        private ICursoRepository _cursoRepository;
        private IMapper _mapper;

        public CursoController(
            ILogger<CursoController> logger,
            IMapper mapper,
            ICursoRepository cursoRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _cursoRepository = cursoRepository;
        }

        [HttpPost]
        [Route("curso")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Cria um novo curso")]
        public async Task<IActionResult> Create([FromBody] CursoDTO cursoDTO)
        {
            var curso = _mapper.Map<Curso>(cursoDTO);

            if (curso.DataInicio.Equals(DateTime.MinValue))
            {
                return BadRequest(new ErrorResponse()
                {
                    Message = "O campo data de início é obrigatório."
                });
            }

            if (curso.DataFim.Equals(DateTime.MinValue))
            {
                return BadRequest(new ErrorResponse()
                {
                    Message = "O campo data de fim é obrigatório."
                });
            }

            if (curso.DataInicio.Date < DateTime.Today)
            {
                return BadRequest(new ErrorResponse()
                {
                    Message = "A data de início não pode ser menor que a data atual."
                });
            }

            if (string.IsNullOrEmpty(curso.Descricao))
            {
                return BadRequest(new ErrorResponse()
                {
                    Message = "O campo descrição é obrigatório."
                });
            }

            if (_cursoRepository.VerificarData(curso.DataInicio, curso.DataFim))
            {
                return BadRequest(new ErrorResponse()
                {
                    Message = "Existe(m) curso(s) planejados(s) dentro do período informado."
                });
            }

            try
            {
                // save 
                await _cursoRepository.Create(curso);
                return Ok();
            }
            catch (BusinessException ex)
            {
                // return error message if there was an exception
                return BadRequest(new ErrorResponse() { Message = ex.Message });
            }

        }

        [HttpGet]
        [Route("curso/")]
        [ProducesResponseType(typeof(IEnumerable<CursoDTO>), 200)]
        [SwaggerOperation(Summary = "Retorna todos os cursos cadastradas")]

        public IActionResult GetAll()
        {
            return Ok(_cursoRepository.Include<Curso>(c => c.Categoria));
        }

        [HttpGet]
        [Route("curso/{id}")]
        [ProducesResponseType(typeof(Curso), 200)]
        [SwaggerOperation(Summary = "Retorna os dados de um curso de acordo com o id")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _cursoRepository.GetById(id));
        }

        [HttpPut]
        [Route("curso/{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Atualiza os dados de um curso de acordo com o id")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CursoDTO cursoDTO)
        {
            if (id == null)
            {
                return BadRequest(new ErrorResponse() { Message = "Informe um Id." });
            }
            var oldCurso = await _cursoRepository.GetById(id);

            var mapped = _mapper.Map<Curso>(cursoDTO);
            await _cursoRepository.Update(id, mapped);
            return Ok();
        }

        [HttpDelete]
        [Route("curso/{id}")]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Exclui os dados de um curso de acordo com o id")]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return BadRequest(new ErrorResponse() { Message = "Informe um Id." });
            }
            await _cursoRepository.Delete(id);
            return Ok();
        }
    }
}