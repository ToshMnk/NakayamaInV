using NakayamaPJ.Model;
using NakayamaPJ.Repository;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NakayamaPJ.ViewModel
{
    public class ProduccionViewModel : ViewModelBase
    {
        private readonly ProduccionRepository _produccionRepository;

        // Listas para ComboBox
        public ObservableCollection<TejedoraModel> ListaTejedoras { get; set; }
        public ObservableCollection<PedidoModel> ListaPedidos { get; set; }

        public ObservableCollection<ProduccionModel> Producciones { get; set; }
        public ProduccionModel NuevaProduccion { get; set; }

        private ProduccionModel _produccionSeleccionada;
        public ProduccionModel ProduccionSeleccionada
        {
            get => _produccionSeleccionada;
            set
            {
                _produccionSeleccionada = value;
                OnpropertyChanged(nameof(ProduccionSeleccionada));
            }
        }

        private TejedoraModel _tejedoraSeleccionada;
        public TejedoraModel TejedoraSeleccionada
        {
            get => _tejedoraSeleccionada;
            set
            {
                _tejedoraSeleccionada = value;
                NuevaProduccion.ID_Tejedora = value?.ID_Tejedora ?? 0;
                OnpropertyChanged(nameof(TejedoraSeleccionada));
            }
        }

        private PedidoModel _pedidoSeleccionado;
        public PedidoModel PedidoSeleccionado
        {
            get => _pedidoSeleccionado;
            set
            {
                _pedidoSeleccionado = value;
                NuevaProduccion.ID_Pedido = value?.ID_Pedido ?? 0;
                OnpropertyChanged(nameof(PedidoSeleccionado));
            }
        }

        public string SearchText { get; set; }

        public ICommand AgregarProduccionCommand { get; }
        public ICommand SearchCommand { get; }

        //Vista Actual
        public object VistaActual { get; set; }

        public ICommand AbrirAñadirProduccionCommand { get; }
        public ICommand AbrirEditarProduccionCommand { get; }
        public ICommand AbrirEliminarProduccionCommand { get; }

        public ProduccionViewModel()
        {
            AbrirEditarProduccionCommand = new ViewModelCommand(_ => AbrirEditarProduccion());

            _produccionRepository = new ProduccionRepository();

            Producciones = new ObservableCollection<ProduccionModel>();
            ListaTejedoras = new ObservableCollection<TejedoraModel>();
            ListaPedidos = new ObservableCollection<PedidoModel>();

            NuevaProduccion = new ProduccionModel();

            AgregarProduccionCommand = new ViewModelCommand(EjecutarAgregarProduccion);
            SearchCommand = new ViewModelCommand(EjecutarBuscarProducciones);

            // Cargar datos
            CargarProducciones();
            CargarListas();
        }


    private void AbrirEditarProduccion()
    {
        VistaActual = new EditarProduccionViewModel();
        OnpropertyChanged(nameof(VistaActual));
    }


        private void CargarListas()
        {
            ListaTejedoras.Clear();
            ListaPedidos.Clear();

            var tejedoras = _produccionRepository.ObtenerTejedoras();
            var pedidos = _produccionRepository.ObtenerPedidosDisponibles();

            foreach (var tejedora in tejedoras)
            {
                ListaTejedoras.Add(tejedora);
            }

            foreach (var pedido in pedidos)
            {
                ListaPedidos.Add(pedido);
            }
        }

        private void CargarProducciones()
        {
            Producciones.Clear();
            var producciones = _produccionRepository.ObtenerProduccionesConTejedoras();

            foreach (var produccion in producciones)
            {
                Producciones.Add(produccion);
            }
        }

        private void EjecutarAgregarProduccion(object obj)
        {
            if (TejedoraSeleccionada == null || PedidoSeleccionado == null)
            {
                // Manejar error: campos obligatorios
                return;
            }

            _produccionRepository.AgregarProduccion(NuevaProduccion);
            CargarProducciones();
            NuevaProduccion = new ProduccionModel();
            TejedoraSeleccionada = null;
            PedidoSeleccionado = null;
            OnpropertyChanged(nameof(NuevaProduccion));
        }

        private void EjecutarBuscarProducciones(object obj)
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                CargarProducciones();
                return;
            }

            Producciones.Clear();
            var produccionesFiltradas = _produccionRepository.BuscarProducciones(SearchText);

            foreach (var produccion in produccionesFiltradas)
            {
                Producciones.Add(produccion);
            }
        }

    }

}
