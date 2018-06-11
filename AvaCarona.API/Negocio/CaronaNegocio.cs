using AvaCarona.API.Dominio;
using AvaCarona.API.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Negocio
{

    public class CaronaNegocio
    {
        private IRepositorio<Carona> _repositorio;

        public CaronaNegocio( IRepositorio<Carona> repositorio )
        {
            _repositorio = repositorio;
        }

        public void CadastrarCarona( Carona carona )
        {

            if (carona == null)
                throw new ArgumentNullException("CaronaNegocio[CadastrarCarona]", "Carona nula!");

            // ID
            int ID = carona.ID;

            bool existe = _repositorio.GetPorID( ID ) != null ;
            
            // Se existir lança uma exceção
            if ( existe ) throw new CaronaJaExistenteException( ID );

            //Senão adiciona no repositorio
            _repositorio.Adicionar(carona);

        }

    }

}
