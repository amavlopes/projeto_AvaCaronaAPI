using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Dominio
{

    public class CaronaColaborador
    {

        public int CaronaID { get; set; }
        public int ColaboradorID { get; set; }

        public Carona Carona { get; set; }
        public Colaborador Colaborador { get; set; }

    }

}
