
using B2BTecnology.Financeiro.DataBase;

namespace B2BTecnology.Financeiro.Negocio
{
    public abstract class DadosPessoais<T, E> where T : class
    {
        public abstract void Salvar(T entidade, E atual);

        public virtual void Incluir(T entidade)
        {

        }

        public virtual void Alterar(T entidade, E atual)
        {

        }

    }
}
