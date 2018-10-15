using System;
using System.Collections.Generic;
using System.Text;

namespace App01_ConsultarCEP.Domain.Entidades
{
    public class Endereco : EntidadeBase
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }

        public override void Validar()
        {
            if (string.IsNullOrEmpty(logradouro))
                throw new ValidationException("O logradouro é obrigatório.");
            if (string.IsNullOrEmpty(bairro))
                throw new ValidationException("O bairro é obrigatório.");
            if (string.IsNullOrEmpty(uf))
                throw new ValidationException("A uf é obrigatório.");
        }
    }
}
