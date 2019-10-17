using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimento
{
    class Guiche
    {

        #region atributos
        private int id;
        private Queue<Senha> atendimentos;
        #endregion

        #region propriedades
        public int Id { get => id; set => id = value; }
        internal Queue<Senha> Atendimentos { get => atendimentos; set => atendimentos = value; }

        #endregion

        #region construtor
        public Guiche()
        {
            this.id = 0;
            this.atendimentos = new Queue<Senha>();
        }

        public Guiche(int id)
        {
            this.id = id;
            this.atendimentos = new Queue<Senha>();
        }
        #endregion

        #region metodos
        public bool chamar(Queue<Senha> filaSenhas)
        {
            //deixei de ser fumado HEHEHEHEHE
            Boolean temSenha = (filaSenhas.Count > 0);

            if (temSenha)
            {
                Senha senhaAtendida = filaSenhas.Dequeue();
                senhaAtendida.DataAtend = DateTime.Now;
                senhaAtendida.HoraAtend = DateTime.Now;
                atendimentos.Enqueue(senhaAtendida);
            }
            return temSenha;
        }
        public override bool Equals(object obj)
        {
            Guiche g = (Guiche)obj;
            return this.id.Equals(g.id);
        }
        #endregion
    }
}
