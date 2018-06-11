using AvaCarona.API.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Repositorios
{

    public class ColaboradorRepositorioIM : ARepositorioIM<Colaborador>, IColaboradorRepositorio
    {

        public Colaborador GetPorEID(string _EID)
        {

            if ( _EID == null )
                throw new ArgumentNullException("ColaboradorRepositorio[GetPorEID]", "EID informado nulo!");

            //Só vai procurar se a lista não for vazia
            //Não tem lógica percorrer um enumerador nulo, lança NullReferenceExcpetion
            if (this.Count > 0)
            { 

                bool encontrado = false;

                // IEnumerator criado posiciona-se antes do primeiro elemento
                var enumerador = Listar().GetEnumerator();

                // Vai para o primeiro registro
                enumerador.MoveNext();

                do
                {// Executa no mínimo uma vez passando para o primeiro registro

                    if (enumerador.Current.EID == _EID)
                    {
                        encontrado = true;
                        return enumerador.Current;
                    }

                    // Enquanto não encontrado e houver próximos registros
                    // Se passar do último elemento enumerador.MoveNext() retorna false
                } while (!encontrado && enumerador.MoveNext());

            }

            return null;

            //Se Lista vazia ou não encontrou EID, lança exceção
            //throw new ArgumentNullException("ColaboradorRepositorio[GetPorEID]", "Colaborador com EID informado não encontrado!");

        }

        public Colaborador GetPorPID(int _PID)
        {

            if (this.Count > 0)
            {

                bool encontrado = false;
                var enumerador = Listar().GetEnumerator();
                enumerador.MoveNext();
                Colaborador _colaborador_atual = enumerador.Current;

                do
                {
                    //enumerador.MoveNext();
                    if (_colaborador_atual.PID == _PID)
                    {
                        encontrado = true;
                        return _colaborador_atual;
                    }

                } while (!encontrado && enumerador.MoveNext());

            }

            throw new ArgumentNullException("ColaboradorRepositorio[GetPorPID]", "Colaborador com PID informado não encontrado!");
        }

    }

}
