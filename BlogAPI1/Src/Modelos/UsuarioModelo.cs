using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogAPI.Src.Modelos
{
    /// <summary>
    /// <para> Classe responsável por representar tb_usuarios no banco.</para>
    /// <para> Criado por: João Lucas</para>
    /// <para> Versão: 1.0</para>
    /// <para> Data: 02/08/2022</para>
    /// </summary>
    [Table("tb_usuarios")]
    public class Usuario
    {
        #region Atributos 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Foto { get; set; }

        [JsonIgnore, InverseProperty("Criador")]
        public List<Postagem> MinhasPostagens { get; set; }
        #endregion
    }
}
