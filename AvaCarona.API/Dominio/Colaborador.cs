using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Dominio
{
    //Herda de AEntidadeBase [ID, DataDeCriacao] e IBloqueavel
    public class Colaborador : AEntidadeBaseBloqueavel
    {

        public string Nome { get; set; }
        public string EID { get; set; }
        public int PID { get; set; }

        private Colaborador(string _EID) : base()
        {
            EID = _EID;
        }

        private Colaborador(string _EID, int _PID) : this( _EID ) 
        {
            PID = _PID;
        }

        private Colaborador(string _EID, int _PID, string _nome) : this( _EID, _PID )
        {
            Nome = _nome;
        }

        private static void ValidaEID(string _EID)
        {
            if (_EID == null)
                throw new ArgumentNullException("CriarColaborador", "EID do colaborador não informado!");

            if (_EID.Length < 3 || _EID.Length > 20)
                throw new EIDInvalidoException(_EID.Length);
        }

        public static Colaborador CriarColaborador( string _EID )
        {
            ValidaEID( _EID );
            return new Colaborador( _EID );
        }

        public static Colaborador CriarColaborador(string _EID, int _PID)
        {
            ValidaEID(_EID);
            return new Colaborador( _EID, _PID );
        }

        public static Colaborador CriarColaborador(string _EID, int _PID, string _nome)
        {
            ValidaEID(_EID);
            return new Colaborador( _EID, _PID, _nome );
        }

    }
}
