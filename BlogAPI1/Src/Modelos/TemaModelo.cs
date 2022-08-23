using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogAPI1.Src.Modelos
{
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
