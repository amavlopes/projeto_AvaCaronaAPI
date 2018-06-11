using AvaCarona.API.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositorios
{

    public class CaronaRepositorioIM : ARepositorioIM<Carona>
    {
        
        public List<Carona> GetCaronasPorOfertante(Colaborador _ofertante)
        {
            if ( _ofertante == null )
                throw new ArgumentNullException("CaronaRepositorio[GetCaronasPorOfertante]", "Ofertantenulo!");

            List<Carona> resultado = new List<Carona>();

            var lista = Listar(); //Retorna lista de Caronas

            foreach (var carona in lista)
            {
                if (carona.Ofertante.EID == _ofertante.EID)
                {
                    resultado.Add(carona);
                    
                }
            }

            if( resultado.Count == 0 )
                throw new ArgumentNullException("CaronaRepositorio[GetCaronasPorOfertante]", "Nenhuma Carona encontrada por este Ofertante!");

            return resultado;

        }

    }

}
