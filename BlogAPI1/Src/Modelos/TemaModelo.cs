using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogAPI1.Src.Modelos
{
    /// <summary>
    /// <para> Classe responsável por representar tb_temas no banco.</para>
    /// <para> Criado por: João Lucas</para>
    /// <para> Versão: 1.0</para>
    /// <para> Data: 02/08/2022</para>
    /// </summary>
    [Table("tb_tema")]
    public class Tema
    {
        #region Atributos

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Descricao { get; set; }

        [JsonIgnore, InverseProperty("Tema")]
        public List<Postagem> PostagensRelacionadas { get; set; }
        #endregion
    }
}
