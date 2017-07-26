using System;
using Sommus.CodingDojo.Application.Application;
using Sommus.CodingDojo.Application.ViewModel;
using Sommus.CodingDojo.Domain.Enums;
using Xunit;

namespace Sommus.CodingDojo.ApplicationTest.Application
{
    public class PessoaApplicationTest : BaseApplicationTest
    {
        private PessoaVM GetPessoaVM()
        {
            return new PessoaVM()
            {
                Nome = "Teste",
                CPF = "99999999999"
            };
        }

        [Fact]
        public void Pessoa_Add_ComSucesso()
        {
            //Given
            var pessoaVM = GetPessoaVM();
            //When
            PessoaApplication.Add(pessoaVM);
            //Then
            Assert.Equal(ResponseTypeEnum.Success.ToString(), PessoaApplication.ResponseType);
        }

        [Fact]
        public void Pessoa_Update_ComSucesso()
        {
            //Given
            var pessoaId = 1;
            var pessoaVM = GetPessoaVM();
            pessoaVM.Nome += " (Alterado)";
            //When
            PessoaApplication.Update(pessoaId, pessoaVM);
            //Then
            Assert.Equal(ResponseTypeEnum.Success.ToString(), PessoaApplication.ResponseType);
        }

        [Fact]
        public void Pessoa_Delete_ComSucesso()
        {
            //Given
            var pessoaId = 2;
            //When
            PessoaApplication.Delete(pessoaId);
            //Then
            Assert.Equal(ResponseTypeEnum.Success.ToString(), PessoaApplication.ResponseType);
        }
    }
}