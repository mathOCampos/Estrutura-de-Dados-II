using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimento
{
    class Senhas
    {
        #region atributos
        private int proximoAtendimento;
        private Queue<Senha> filaSenhas;
        #endregion

        #region propriedades
        public int ProximoAtendimento { get => proximoAtendimento; set => proximoAtendimento = value; }
        #endregion

        #region proteção
        public Queue<Senha> FilaSenhas
        {
            get
            {
                return filaSenhas;
            }
        }
        #endregion

        #region construtor
        public Senhas()
        {
            filaSenhas = new Queue<Senha>();
            this.proximoAtendimento = 1;
        }
        #endregion

        #region metodos
        public void gerar()
        {
            FilaSenhas.Enqueue(new Senha(proximoAtendimento));
            proximoAtendimento++;
        }
        #endregion
    }
}
