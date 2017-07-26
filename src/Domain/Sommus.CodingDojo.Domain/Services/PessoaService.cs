using System;
using System.Collections.Generic;
using Sommus.CodingDojo.Domain.Entities;
using Sommus.CodingDojo.Domain.Enums;
using Sommus.CodingDojo.Domain.Interfaces.Repositories;

namespace Sommus.CodingDojo.Domain.Services
{
    public class PessoaService
    {
        private readonly IDataContext _dataContext;

        private readonly IPessoaRepository _pessoaRepository;
        private ResponseService _responseService;

        public ResponseService ResponseService
        {
            get { return _responseService ?? new ResponseService(); }
            set { _responseService = value; }
        }

        private PessoaService()
        {

        }

        public PessoaService(
            IDataContext dataContext,
            IPessoaRepository pessoaRepository
        )
        {
            _dataContext = dataContext;
            _pessoaRepository = pessoaRepository;
        }

        public void Add(Pessoa pessoa)
        {
            try
            {
                _dataContext.BeginTransaction();

                if (ValidaPessoa(pessoa))
                {
                    _pessoaRepository.Add(pessoa);

                    _dataContext.Commit();
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Success,
                        Message = "Cadastrado realizado com sucesso."
                    };
                }
            }
            catch (Exception)
            {
                _dataContext.Rollback();
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Ocorreu um erro ao realizar cadastro."
                };
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public void Update(int pessoaId, Pessoa pessoa)
        {
            try
            {
                _dataContext.BeginTransaction();

                if (_pessoaRepository.Get(pessoaId).PessoaId == 0)
                {
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Warning,
                        Message = "Pessoa não cadastrada."
                    };
                }
                else if (ValidaPessoa(pessoa))
                {
                    pessoa.PessoaId = pessoaId;
                    _pessoaRepository.Update(pessoa);

                    _dataContext.Commit();
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Success,
                        Message = "Cadastro atualizado com sucesso."
                    };
                }
            }
            catch (Exception)
            {
                _dataContext.Rollback();
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Ocorreu um erro ao atualizar cadastro."
                };
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public void Delete(int pessoaId)
        {
            try
            {
                _dataContext.BeginTransaction();
                if (_pessoaRepository.Get(pessoaId).PessoaId == 0)
                {
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Warning,
                        Message = "Pessoa não cadastrada."
                    };
                }
                else
                {
                    _pessoaRepository.Delete(pessoaId);
                    _dataContext.Commit();
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Success,
                        Message = "Pessoa excluído com sucesso."
                    };
                }
            }
            catch (Exception)
            {
                _dataContext.Rollback();
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Ocorreu um erro ao excluir pessoa."
                };
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public List<Pessoa> Get()
        {
            try
            {
                _dataContext.BeginTransaction();

                var pessoas = _pessoaRepository.Get();
                if (pessoas.Count == 0)
                {
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Warning,
                        Message = "Não existe pessoas cadastrados."
                    };
                }
                else
                {
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Success,
                        Message = "Pessoas recuperados com sucesso."
                    };
                }
                return pessoas;
            }
            catch (Exception)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Ocorreu um erro ao recuperar cadastro de pessoas."
                };
                return new List<Pessoa>();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        public Pessoa Get(int pessoaId)
        {
            try
            {
                _dataContext.BeginTransaction();

                var pessoa = _pessoaRepository.Get(pessoaId);
                if (pessoa.PessoaId == 0)
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Warning,
                        Message = "Pessoa não encontrada."
                    };
                else
                {
                    ResponseService = new ResponseService()
                    {
                        Type = ResponseTypeEnum.Success,
                        Message = "Pessoa recuperada com sucesso."
                    };
                }
                return pessoa;
            }
            catch (Exception)
            {
                ResponseService = new ResponseService()
                {
                    Type = ResponseTypeEnum.Error,
                    Message = "Ocorreu um erro ao recuperar cadastro da pessoa."
                };
                return new Pessoa();
            }
            finally
            {
                _dataContext.Finally();
            }
        }

        private bool ValidaPessoa(Pessoa pessoa)
        {
            ResponseService = new ResponseService();

            if (string.IsNullOrEmpty(pessoa.Nome))
            {
                ResponseService.FieldsInvalids.Add("Nome");
            }
            if (string.IsNullOrEmpty(pessoa.CPF))
            {
                ResponseService.FieldsInvalids.Add("CPF");
            }

            if (ResponseService.FieldsInvalids.Count > 0)
            {
                ResponseService.Message += "Informe os dados corretamente.";
            }

            ResponseService.Type =
                string.IsNullOrEmpty(ResponseService.Message) ?
                    ResponseTypeEnum.Success :
                    ResponseTypeEnum.Warning;

            return ResponseService.Type == ResponseTypeEnum.Success;
        }
    }
}