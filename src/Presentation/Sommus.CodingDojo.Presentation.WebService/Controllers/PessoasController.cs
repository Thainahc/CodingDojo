using System;
using Microsoft.AspNetCore.Mvc;
using Sommus.CodingDojo.Application.Application;
using Sommus.CodingDojo.Application.ViewModel;

namespace Sommus.CodingDojo.Presentation.WebService.Controllers
{
    [Route("api/[controller]")]
    public class PessoasController : Controller
    {
        #region GET
        // GET api/pessoas
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pessoas = PessoaApplication.Get();

                if (PessoaApplication.ResponseType.Equals("Error"))
                {
                    return BadRequest(PessoaApplication.ResponseMessage);
                }
                else if (pessoas.Count == 0)
                {
                    return NotFound(new
                    {
                        Message = PessoaApplication.ResponseMessage,
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Message = PessoaApplication.ResponseMessage,
                        Type = PessoaApplication.ResponseType,
                        Pessoas = pessoas
                    });
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao recuperar cadastro de pessoas.");
            }
        }

        // GET api/pessoas/{id}
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var pessoa = PessoaApplication.Get(id);

                if (PessoaApplication.ResponseType.Equals("Error"))
                {
                    return BadRequest(PessoaApplication.ResponseMessage);
                }
                else if (pessoa.PessoaId == 0)
                {
                    return NotFound(new
                    {
                        Message = PessoaApplication.ResponseMessage,
                    });
                }
                else
                {
                    return Ok(new
                    {
                        Message = PessoaApplication.ResponseMessage,
                        Type = PessoaApplication.ResponseType,
                        Pessoa = pessoa
                    });
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao recuperar cadastro da pessoa.");
            }
        }
        #endregion

        #region POST
        [HttpPost]
        public IActionResult Post([FromBody]PessoaVM pessoaVM)
        {
            try
            {
                PessoaApplication.Add(pessoaVM);

                if (PessoaApplication.ResponseType.Equals("Error"))
                {
                    return BadRequest(PessoaApplication.ResponseMessage);
                }
                else
                {
                    return Ok(new
                    {
                        Message = PessoaApplication.ResponseMessage,
                        Type = PessoaApplication.ResponseType,
                        FieldsInvalids = PessoaApplication.FieldsInvalids
                    });
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao cadastrar pessoa.");
            }
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]PessoaVM pessoaVM)
        {
            try
            {
                PessoaApplication.Update(id, pessoaVM);

                if (PessoaApplication.ResponseType.Equals("Error"))
                {
                    return BadRequest(PessoaApplication.ResponseMessage);
                }
                else
                {
                    return Ok(new
                    {
                        Message = PessoaApplication.ResponseMessage,
                        Type = PessoaApplication.ResponseType,
                        FieldsInvalids = PessoaApplication.FieldsInvalids
                    });
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao atualizar cadastro da pessoa.");
            }
        }
        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                PessoaApplication.Delete(id);

                if (PessoaApplication.ResponseType.Equals("Error"))
                {
                    return BadRequest(PessoaApplication.ResponseMessage);
                }
                else
                {
                    return Ok(new
                    {
                        Message = PessoaApplication.ResponseMessage,
                        Type = PessoaApplication.ResponseType
                    });
                }
            }
            catch (Exception)
            {
                return BadRequest("Ocorreu um erro ao excluir pessoa.");
            }
        }
        #endregion
    }
}