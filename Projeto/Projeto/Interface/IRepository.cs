using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Interface
{
    public interface IRepository<T>
    {

        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Excluir(T entidade);
        T ObterPorId(int id);
        List<T> ObterTodos();
    }
}
