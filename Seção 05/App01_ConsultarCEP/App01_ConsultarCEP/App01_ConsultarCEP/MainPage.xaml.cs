using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

			buttonBuscarCEP.Clicked += BuscarCEP;
		}

		public void BuscarCEP(object sender, EventArgs args)
		{
			if (IsCEPValido(entryCEP.Text.Trim()))
			{
				try
				{
					Endereco endereco = ViaCEPServico.BuscarEnderecoPorCEP(entryCEP.Text.Trim());

					if (endereco == null)
					{
						DisplayAlert("ERRO", "Endereço não encontrado!", "OK");
					}
					else
					{
						txtResultado.Text = string.Format(
							"Endereco: {0}, {1} - {2}/{3}",
							endereco.logradouro,
							endereco.bairro,
							endereco.localidade,
							endereco.uf);
					}
				}
				catch (Exception e)
				{
					DisplayAlert("ERRO", e.Message, "OK");
				}
			}
		}

		private bool IsCEPValido(string cep)
		{
			if (cep.Length != 8)
			{
				DisplayAlert("ERRO", "O CEP deve conter 8 caracteres", "OK");

				return false;
			}

			if (!int.TryParse(cep, out int I))
			{
				DisplayAlert("ERRO", "O CEP deve conter apenas números", "OK");

				return false;
			}

			return true;
		}
	}
}
