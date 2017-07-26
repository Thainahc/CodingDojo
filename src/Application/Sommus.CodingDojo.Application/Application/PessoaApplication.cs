using System;
using System.Collections.Generic;
using AutoMapper;
using Sommus.CodingDojo.Application.DependencyInjection.Services;
using Sommus.CodingDojo.Application.ViewModel;
using Sommus.CodingDojo.Domain.Entities;
using Sommus.CodingDojo.Domain.Interfaces.Repositories;
using Sommus.CodingDojo.Domain.Services;

namespace Sommus.CodingDojo.Application.Application
{
    public class PessoaApplication
    {
        private static readonly PessoaService _pessoaService = new PessoaService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IPessoaRepository>());

        public static string ResponseMessage
        {
            get { return _pessoaService.ResponseService.Message; }
        }

        public static string ResponseType
        {
            get { return _pessoaService.ResponseService.Type.ToString(); }
        }

        public static List<string> FieldsInvalids
        {
            get { return _pessoaService.ResponseService.FieldsInvalids; }
        }

        public static void Add(PessoaVM pessoaVM)
        {
            var pessoa = Mapper.Map<PessoaVM, Pessoa>(pessoaVM);
            _pessoaService.Add(pessoa);
        }

        public static void Update(int pessoaId, PessoaVM pessoaVM)
        {
            var pessoa = Mapper.Map<PessoaVM, Pessoa>(pessoaVM);
            _pessoaService.Update(pessoaId, pessoa);
        }

        public static void Delete(int pessoaId)
        {
            _pessoaService.Delete(pessoaId);
        }

        public static List<PessoaVM> Get()
        {
            var pessoas = _pessoaService.Get();
            return Mapper.Map<List<Pessoa>, List<PessoaVM>>(pessoas);
        }

        public static PessoaVM Get(int pessoaId)
        {
            var pessoa = _pessoaService.Get(pessoaId);
            return Mapper.Map<Pessoa, PessoaVM>(pessoa);
        }
    }
}