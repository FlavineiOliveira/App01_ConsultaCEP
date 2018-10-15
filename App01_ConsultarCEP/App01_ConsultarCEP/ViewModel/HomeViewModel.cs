using App01_ConsultarCEP.Domain.Entidades;
using App01_ConsultarCEP.Interface;
using App01_ConsultarCEP.Services.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App01_ConsultarCEP.ViewModel
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string resultado;

        private ICommand buscarEndereco;

        public IMessage Message { get; set; }

        public string Cep { get; set; }

        public string Resultado
        {
            get
            {
                return resultado;
            }
            set
            {
                resultado = value;
                RaisePropertyChanged("Resultado");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }

        public HomeViewModel()
        {
        }

        public ICommand BuscarEndereco
        {
            get
            {
                return buscarEndereco ?? (buscarEndereco = new Command( objeto => {

                    string cep = Cep.Trim();

                    if (ValidarCep(cep))
                    {
                        Endereco endereco = ViaCepServico.BuscarEnderecoCep(cep);
                        endereco.Validar();

                        Resultado = string.Format("Endereço: {0} {1} {2}", endereco.logradouro, endereco.bairro, endereco.uf);
                    }
                    
                }));
            }
        }

        public bool ValidarCep(string cep)
        {
            if(cep.Length != 8)
            {
                Message.DisplayAlert("Erro", "CEP inválido! O CEP deve possuir 8 dígitos.", "Ok");
                return false;
            }

            if (!int.TryParse(cep, out int conversao))
            {
                Message.DisplayAlert("Erro", "CEP inválido! Deve ser inserido apenas números.", "Ok");
                return false;
            }

            return true;
        }


    }
}
