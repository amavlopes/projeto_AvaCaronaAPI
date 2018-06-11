using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AvaCarona.API.Dominio
{
    public abstract class AEntidadeBase
    {

        //Define que o ID deste tipo será alimentado pelo DB
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public int ID { get; set; }
        public DateTime DataDeCriacao { get; set; }

        public AEntidadeBase()
        {
            DataDeCriacao = DateTime.Now;
        }

    }
}
