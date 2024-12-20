using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NakayamaPJ;
using System.Windows.Input;
using NakayamaPJ.Repository;
using NakayamaPJ.Model;
using NakayamaPJ.View;


namespace NakayamaPJ.ViewModel
{
    public class MainViewModel:ViewModelBase

    {
        private IUserAccountModel _currentUserAcount = new IUserAccountModel();
        private IUserRepository userRepository = new UserRepository();

        private ViewModelBase _currentChildView;
        private String _titulo;
        private IconChar _icono;    


        //constructor de Account

        public IUserAccountModel CurrentUserAcount
        {
            get => _currentUserAcount;

            set
            {
                _currentUserAcount = value;
                OnpropertyChanged(nameof(CurrentUserAcount));
            }
        }






        //constructor supuestamente
        public MainViewModel()
        {
            MostrarHomeViewCommand = new ViewModelCommand(EjecutarMostrarHomeViewCommand);
            MostrarPedidoViewCommand = new ViewModelCommand(EjecutarMostrarPedidoViewCommand);
            MostrarTejedoraViewCommand = new ViewModelCommand(EjecutarMostrarTejedoraViewCommand);
            MostrarCalidadViewCommand = new ViewModelCommand(EjecutarMostrarCalidadViewCommand);
            MostrarNotaPagoViewCommand = new ViewModelCommand(EjecutarMostrarNotaPagoViewCommand);
            MostrarProduccionViewCommand = new ViewModelCommand(EjecutarMostrarProduccionViewCommand);
            MostrarSalidaMaterialViewCommand = new ViewModelCommand(EjecutarMostrarSalidaMaterialViewCommand);
            MostrarDesingViewCommand = new ViewModelCommand(EjecutarMostrarDesingViewCommand);
            MostrarEnvioViewCommand = new ViewModelCommand(EjecutarMostrarEnvioViewCommand);
            MostrarDashboardCommand = new ViewModelCommand(EjecutarMostrarDashboardCommand);




            //Vista predeterminada
            EjecutarMostrarHomeViewCommand(null);
            LoadCurrentUserData();

        }

        private void EjecutarMostrarDashboardCommand(object obj)
        {
            CurrentChildView = new DashboardViewModel();
            Titulo = "Dashboard";
            Icono = IconChar.Map;
        }

        private void EjecutarMostrarEnvioViewCommand(object obj)
        {
            CurrentChildView = new EnvioViewModel();
            Titulo = "Envío";
            Icono = IconChar.Truck;
        }

        private void EjecutarMostrarDesingViewCommand(object obj)
        {
            CurrentChildView = new DesingViewModel();
            Titulo = "Diseño";
            Icono = IconChar.Shirt;
        }

        private void EjecutarMostrarSalidaMaterialViewCommand(object obj)
        {
            CurrentChildView = new SalidaMaterialViewModel();
            Titulo = "Salida De Material";
            Icono = IconChar.CartFlatbed;
        }

        private void EjecutarMostrarProduccionViewCommand(object obj)
        {
            CurrentChildView = new ProduccionViewModel();
            Titulo = "producción";
            Icono = IconChar.CircleNodes;
        }

        private void EjecutarMostrarNotaPagoViewCommand(object obj)
        {
            CurrentChildView = new NotaPagoViewModel();
            Titulo = "Nota de Pago";
            Icono = IconChar.MoneyBill;
        }

        private void EjecutarMostrarTejedoraViewCommand(object obj)
        {

            CurrentChildView = new TejedoraViewModel();
            Titulo = "Tejedoras";
            Icono = IconChar.UserGroup;
        }

        private void EjecutarMostrarCalidadViewCommand(object obj)
        {

            CurrentChildView = new CalidadViewModel();
            Titulo = "Control de calidad";
            Icono = IconChar.Award;
        }

        private void EjecutarMostrarPedidoViewCommand(object obj)
        {

            CurrentChildView = new PedidoViewModel();
            Titulo = "Pedidos";
            Icono = IconChar.Book;
        }

        private void EjecutarMostrarHomeViewCommand(object obj)
        {

            CurrentChildView = new HomeViewModel();
            Titulo = "Pagina principal";
            Icono = IconChar.Leaf;
        }


        //Propiedades
        public ViewModelBase CurrentChildView 
        {
            get => _currentChildView;
            set 
            {
                _currentChildView = value;
                OnpropertyChanged(nameof(CurrentChildView)); 
            } 
        }
        public string Titulo 
        {
            get => _titulo;
            set
            {
                _titulo = value;
                OnpropertyChanged(nameof(Titulo));
            }
        }
        public IconChar Icono 
        { 
            get => _icono;
            set
            {
                _icono = value;
                OnpropertyChanged(nameof(Icono)); 
            }
        }

        //Comandos para vistas
        public ICommand MostrarHomeViewCommand { get; }
        public ICommand MostrarPedidoViewCommand { get; }
        public ICommand MostrarTejedoraViewCommand { get; }
        public ICommand MostrarCalidadViewCommand { get; }
        public ICommand MostrarNotaPagoViewCommand { get; }
        public ICommand MostrarProduccionViewCommand { get; }
        public ICommand MostrarSalidaMaterialViewCommand { get; }
        public ICommand MostrarDesingViewCommand { get; }
        public ICommand MostrarEnvioViewCommand { get; }
        public ICommand MostrarDashboardCommand { get; }


        //Cargar informacion de ususario

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {

                CurrentUserAcount.Username = user.Username;
                CurrentUserAcount.DisplayName = $"{user.Nombre} {user.Apellido}";
                CurrentUserAcount.ProfilePicture = null;

            }
            else
            {
                CurrentUserAcount.DisplayName = "Usuario no Valido";
            }
        }


    }

}
