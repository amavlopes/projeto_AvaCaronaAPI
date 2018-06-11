using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Dominio
{
    //Herda de AEntidadeBase [ID, DataDeCriacao] e IBloqueavel
    public class Carona : AEntidadeBaseBloqueavel
    {

        public DateTime DataHorario { get; set; }
        public Endereco EnderecoOrigem { get; set; }
        public Endereco EnderecoDestino { get; set; }

        private const int LIMITE_VAGAS_PERMITIDO = 6;
        public int VagasTotais { get; set; }
        public int VagasDisponiveis { get; private set; }

        public int OfertanteID { get; set; }
        public Colaborador Ofertante { get; set; }

        //public IList<Colaborador> Ocupantes { get; private set; } = new List<Colaborador>();
        // Lista da Tabela do Meio - CaronaColaborador
        public IEnumerable<CaronaColaborador> Ocupantes { get; set; }

        private Carona(int _vagas, Colaborador _ofertante) : base()
        {
            VagasTotais = _vagas;
            VagasDisponiveis = _vagas;
            Ofertante = _ofertante;
        }

        public static Carona CriarCarona(int _vagas, Colaborador _ofertante)
        {
            if ( _ofertante == null )
                throw new ArgumentNullException("Ofertante", "Ofertante da carona não informado!");

            if ( _vagas > LIMITE_VAGAS_PERMITIDO )
                throw new LimiteDeVagasExcedidoException( _vagas , LIMITE_VAGAS_PERMITIDO);

            return new Carona( _vagas, _ofertante );
        }

        public void OcuparVaga(Colaborador _ocupante)
        {
            //ELSE: Quando NÃO houver + vagas: VagasDisponiveis = 0. "Não há vagas disponíveis!"
            if (VagasDisponiveis > 0)
            {
                VagasDisponiveis -= 1;
                //Ocupantes.Add( _ocupante );
            }
            else throw new VagasInsuficientesException(); 
        }
        
        public void DesocuparVaga(Colaborador _ocupante)
        {
            if (VagasDisponiveis < VagasTotais)
            {
                VagasDisponiveis += 1;
                //Ocupantes.Remove( _ocupante );
            }
            else throw new InvalidOperationException();
        }

    }
}
