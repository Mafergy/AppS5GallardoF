﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppS5GallardoF
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class viewInsertar : ContentPage
    {
        public viewInsertar()
        {
            InitializeComponent();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var parametros = new System.Collections.Specialized.NameValueCollection();

                parametros.Add("codigo", txtCodigo.Text);
                parametros.Add("nombre", txtNombre.Text);
                parametros.Add("apellido", txtApellido.Text);
                parametros.Add("edad", txtEdad.Text);

                cliente.UploadValues("http://192.168.1.7/moviles/post.php","POST",parametros);
                DisplayAlert("Mensaje", "Ingreso correcto", "ok");
            }
            catch(Exception ex)
            {
                DisplayAlert("Mensaje",ex.Message, "ok");

            }
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());   
        }
    }
}