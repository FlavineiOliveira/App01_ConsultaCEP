using App01_ConsultarCEP.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Services
{
    public class ViaCepServico
    {
        private static readonly string enderecoUrl = "https://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoCep(string cep)
        {
            var novoEnderecoUrl = string.Format(enderecoUrl, cep);

            WebClient wc = new WebClient();
            var conteudo = wc.DownloadString(novoEnderecoUrl);

            return JsonConvert.DeserializeObject<Endereco>(conteudo);
        }
    }
}
