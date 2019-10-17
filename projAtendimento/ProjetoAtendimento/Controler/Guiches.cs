using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAtendimento
{
    class Guiches
    {
        #region atributos
        private List<Guiche> listaGuiches;
        #endregion

        #region propriedades
        internal List<Guiche> ListaGuiches { get => listaGuiches; set => listaGuiches = value; }
        #endregion

        #region construtor
        public Guiches()
        {
            listaGuiches = new List<Guiche>();
        }

        public void adicionar(Guiche guiche)
        {
            listaGuiches.Add(guiche);
        }
        #endregion

    }
}
