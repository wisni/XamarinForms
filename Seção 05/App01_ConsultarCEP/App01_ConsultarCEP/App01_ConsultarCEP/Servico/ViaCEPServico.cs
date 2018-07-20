using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using App01_ConsultarCEP.Servico.Modelo;
using Newtonsoft.Json;

namespace App01_ConsultarCEP.Servico
{
    public class ViaCEPServico
    {
		private static string url = "http://viacep.com.br/ws/{0}/json/";

		public static Endereco BuscarEnderecoPorCEP(string cep)
		{
			string urlFormatada = string.Format(url, cep);

			WebClient client = new WebClient();
			string retorno = client.DownloadString(urlFormatada);

			Endereco endereco = JsonConvert.DeserializeObject<Endereco>(retorno);

			if (endereco.cep == null)
			{
				return null;
			}

			return endereco;
		}
    }
}
