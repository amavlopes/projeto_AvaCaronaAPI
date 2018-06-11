using System;
using System.Collections.Generic;
using System.Text;

namespace AvaCarona.API.Dominio
{
    //Herda de AEntidadeBase ID e DataDeCriacao
    public class Endereco : AEntidadeBase
    {

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }

        //Gera uma DataDeCriacao ao criar um Obj deste tipo
        public Endereco() : base()
        {}

    }
}