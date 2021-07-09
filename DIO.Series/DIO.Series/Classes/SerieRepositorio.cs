using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;
using DIO.Series.Enum;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Series.Classes
{
    class SerieRepositorio : IRepositorio<Series>
    {

        private List<Series> ListaSeries = new List<Series>();


        public void Atualiza(int id, Series entidade)
        {
            ListaSeries[id] = entidade;
        }

        public void Exclui(int id)
        {
            ListaSeries[id].Excluir();
        }

        public void Insere(Series entidade)
        {
            ListaSeries.Add(entidade);
        }

        public List<Series> Lista()
        {
            return ListaSeries;
        }

        public int ProximoId()
        {
            return ListaSeries.Count;
        }

        public Series RetornaPorId(int id)
        {
            return ListaSeries[id];
        }
    }
}
