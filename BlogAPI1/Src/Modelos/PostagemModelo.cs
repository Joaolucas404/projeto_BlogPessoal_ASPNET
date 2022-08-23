using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI1.Src.Modelos
{
    [Table("tb_postagens")]
    public class Postagem
    {
        #region Atributos 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Foto { get; set; }

        [ForeignKey("fk_criador")]
        public Usuario Criador { get; set; }

        [ForeignKey("fk_tema")]
        public Tema Tema { get; set; }

        #endregion
    }
}
