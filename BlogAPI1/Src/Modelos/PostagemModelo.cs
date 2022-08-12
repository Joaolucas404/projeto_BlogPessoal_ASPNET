using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BlogAPI1.Src.Modelos
{
    /// <summary>
    /// <para> Classe responsável por representar tb_postagem no banco.</para>
    /// <para> Criado por: João Lucas</para>
    /// <para> Versão: 1.0</para>
    /// <para> Data: 02/08/2022</para>
    /// </summary>
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
