﻿using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SmartBuy.Core.Entities
{
    public class Produto
    {
        [Key]
        [JsonIgnore]
        [Display(Name = "Código")]
        public int IdProduto { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} deve ser menor/igual {1} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Descrição")]
        [StringLength(250, ErrorMessage = "O campo {0} deve ser menor/igual {1} caracteres")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O {0} deve ser maior que zero.")]
        [Display(Name = "Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O {0} deve ser maior que zero.")]
        public int Estoque { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [Display(Name = "Categoria")]
        public int IdCategoria { get; set; }

        [JsonIgnore]
        public Categoria Categoria { get; set; }

        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        public byte[]? Imagem { get; set; }

        public string ImagemMimeType { get; set; }

        [JsonIgnore]
        public string IdVendedor { get; set; }

        //[NotMapped]
        //public Vendedor Vendedor { get; set; }

    }
}
