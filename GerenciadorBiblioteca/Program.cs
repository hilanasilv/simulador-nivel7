using GerenciadorBiblioteca.Controllers;
using GerenciadorBiblioteca.Data;
using System;
using Unity;
using System.Windows.Forms;
using GerenciadorBiblioteca.IClass;



namespace LibraryManager
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            var container = new UnityContainer();

            // Registrar dependências
            container.RegisterType<BibliotecaData>();
            container.RegisterType<LibraryController>();

            // Inicializar dados
            var data = container.Resolve<BibliotecaData>();
            data.SeedData();

            // Exibe o formulário de usuário incialmente
            var usuárioForm = container.Resolve<UsuárioForm>();
            Application.Run(usuárioForm);

            // Após fechar o UsuárioForm, exibe o GerenciadorForm
            var gerenciadorForm = container.Resolve<GerenciadorForm>();
            Application.Run(gerenciadorForm);
        }
    }
}
