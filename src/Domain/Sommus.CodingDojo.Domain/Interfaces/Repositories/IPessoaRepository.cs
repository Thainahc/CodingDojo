using System.Collections.Generic;
using Sommus.CodingDojo.Domain.Entities;

namespace Sommus.CodingDojo.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        void Add(Pessoa pessoa);
        void Update(Pessoa pessoa);
        void Delete(int pessoaId);
        List<Pessoa> Get();
        Pessoa Get(int pessoaId);
    }
}