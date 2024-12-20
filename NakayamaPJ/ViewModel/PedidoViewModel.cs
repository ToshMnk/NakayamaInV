using NakayamaPJ.Model;
using NakayamaPJ.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace NakayamaPJ.ViewModel
{
    public class PedidoViewModel : ViewModelBase
    {
        private readonly PedidoRepository _pedidoRepository;

        public ObservableCollection<PedidoModel> Pedidos { get; set; }
        public PedidoModel NuevoPedido { get; set; }
        private PedidoModel _pedidoSeleccionado;

        public PedidoModel PedidoSeleccionado
        {
            get => _pedidoSeleccionado;
            set
            {
                if (_pedidoSeleccionado != value)
                {
                    _pedidoSeleccionado = value;
                    OnpropertyChanged(nameof(PedidoSeleccionado)); // Notificar a la vista cuando se selecciona un pedido
                }
            }
        }

        // Comandos del CRUD
        public ICommand AgregarPedidoCommand { get; }
        public ICommand EliminarPedidoCommand { get; }
        public ICommand ActualizarPedidoCommand { get; }
        public ICommand SeleccionarPedidoCommand { get; }

        // Inicializar el ViewModel y los comandos
        public PedidoViewModel()
        {
            _pedidoRepository = new PedidoRepository();
            Pedidos = new ObservableCollection<PedidoModel>();
            NuevoPedido = new PedidoModel();

            // Inicializar los comandos del CRUD
            AgregarPedidoCommand = new ViewModelCommand(EjecutarAgregarPedido);
            SeleccionarPedidoCommand = new ViewModelCommand(EjecutarSeleccionarPedido);
            ActualizarPedidoCommand = new ViewModelCommand(EjecutarActualizarPedido);
            EliminarPedidoCommand = new ViewModelCommand(EjecutarEliminarPedido);

            // Cargar los pedidos desde la base de datos
            CargarPedidos();
        }

        // Método para eliminar pedido
        private void EjecutarEliminarPedido(object obj)
        {
            if (PedidoSeleccionado != null)
            {
                _pedidoRepository.EliminarPedido(PedidoSeleccionado.ID_Pedido);
                CargarPedidos(); // Recargar la lista de pedidos después de eliminar
                PedidoSeleccionado = null; // Limpiar la selección
            }
        }

        // Método para actualizar pedido
        private void EjecutarActualizarPedido(object obj)
        {
            if (PedidoSeleccionado != null)
            {
                _pedidoRepository.ActualizarPedido(PedidoSeleccionado);
                CargarPedidos(); // Recargar la lista de pedidos después de actualizar
            }
        }

        // Método para seleccionar pedido
        private void EjecutarSeleccionarPedido(object pedidoSeleccionado)
        {
            if (pedidoSeleccionado is PedidoModel seleccionadaPedido)
            {
                PedidoSeleccionado = seleccionadaPedido;
            }
        }

        // Cargar pedidos desde la base de datos
        private void CargarPedidos()
        {
            Pedidos.Clear();
            var pedidos = _pedidoRepository.ObtenerPedidos();
            foreach (var pedido in pedidos)
            {
                Pedidos.Add(pedido);
            }
        }

        // Método para agregar nuevo pedido
        private void EjecutarAgregarPedido(object obj)
        {
            // Validación básica si los campos están llenos (sin FechaPedido porque se asigna por trigger)
            if (NuevoPedido.ID_Desing == 0 || NuevoPedido.CantidadPrendas <= 0 || NuevoPedido.FechaEntrega == default)
            {
                // Aquí podrías agregar alguna validación o mensaje de error.
                return;
            }

            _pedidoRepository.AgregarPedido(NuevoPedido);
            CargarPedidos();
            NuevoPedido = new PedidoModel(); // Limpiar el formulario de agregar
            OnpropertyChanged(nameof(NuevoPedido)); // Notificar a la vista para limpiar los campos
        }
    }

}