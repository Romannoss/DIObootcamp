using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appcadastro.interfaces
{
    interface irepositorio<T>
    {
        List<T> Lista();

        T RetornaPorId(int id);

        void Insere(T entidade);

        void Excluir(int id);

        void Atualiza(int id, Task entidade);

        int ProximoId();
    }
}
