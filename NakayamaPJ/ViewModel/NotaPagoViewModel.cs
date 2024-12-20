using NakayamaPJ.Model;
using NakayamaPJ.Repository;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NakayamaPJ.ViewModel
{
    public class NotaPagoViewModel : ViewModelBase
    {
        private readonly NotaPagoRepository _notaPagoRepository;

        public ObservableCollection<NotaPagoModel> Pagos { get; set; }
        public NotaPagoModel NuevaNotaPago { get; set; }
        private NotaPagoModel _notaPagoSeleccionada;

        public NotaPagoModel NotaPagoSeleccionada
        {
            get => _notaPagoSeleccionada;
            set
            {
                if (_notaPagoSeleccionada != value)
                {
                    _notaPagoSeleccionada = value;
                    OnpropertyChanged(nameof(NotaPagoSeleccionada)); // Notificar a la vista cuando se selecciona una nota de pago
                }
            }
        }

        // Comandos del CRUD
        public ICommand AgregarNotaPagoCommand { get; }
        public ICommand EliminarNotaPagoCommand { get; }
        public ICommand ActualizarNotaPagoCommand { get; }
        public ICommand SeleccionarNotaPagoCommand { get; }

        // Inicializar el ViewModel y los comandos
        public NotaPagoViewModel()
        {
            _notaPagoRepository = new NotaPagoRepository();
            Pagos = new ObservableCollection<NotaPagoModel>();
            NuevaNotaPago = new NotaPagoModel();

            // Inicializar los comandos del CRUD
            AgregarNotaPagoCommand = new ViewModelCommand(EjecutarAgregarNotaPago);
            SeleccionarNotaPagoCommand = new ViewModelCommand(EjecutarSeleccionarNotaPago);
            ActualizarNotaPagoCommand = new ViewModelCommand(EjecutarActualizarNotaPago);
            EliminarNotaPagoCommand = new ViewModelCommand(EjecutarEliminarNotaPago);

            // Cargar las notas de pago desde la base de datos
            CargarNotasPago();
        }

        // Método para eliminar nota de pago
        private void EjecutarEliminarNotaPago(object obj)
        {
            if (NotaPagoSeleccionada != null)
            {
                _notaPagoRepository.EliminarNotaPago(NotaPagoSeleccionada.ID_Pago);
                CargarNotasPago(); // Recargar la lista de notas de pago después de eliminar
                NotaPagoSeleccionada = null; // Limpiar la selección
            }
        }

        // Método para actualizar nota de pago
        private void EjecutarActualizarNotaPago(object obj)
        {
            if (NotaPagoSeleccionada != null)
            {
                _notaPagoRepository.ActualizarNotaPago(NotaPagoSeleccionada);
                CargarNotasPago(); // Recargar la lista de notas de pago después de actualizar
            }
        }

        // Método para seleccionar nota de pago
        private void EjecutarSeleccionarNotaPago(object notaPagoSeleccionada)
        {
            if (notaPagoSeleccionada is NotaPagoModel seleccionadaNotaPago)
            {
                NotaPagoSeleccionada = seleccionadaNotaPago;
            }
        }

        // Cargar notas de pago desde la base de datos
        private void CargarNotasPago()
        {
            Pagos.Clear();
            var pagos = _notaPagoRepository.ObtenerNotaPagos();
            foreach (var pago in pagos)
            {
                Pagos.Add(pago);
            }
        }

        // Método para agregar nueva nota de pago
        private void EjecutarAgregarNotaPago(object obj)
        {
            // Validación básica si los campos están llenos
            if (NuevaNotaPago.ID_Tejedora == 0 || NuevaNotaPago.ID_Produccion == 0 || NuevaNotaPago.Monto <= 0 || NuevaNotaPago.FechaPago == default)
            {
                // Aquí podrías agregar alguna validación o mensaje de error.
                return;
            }

            _notaPagoRepository.AgregarNotaPago(NuevaNotaPago);
            CargarNotasPago(); // Recargar la lista de pagos después de agregar
            NuevaNotaPago = new NotaPagoModel(); // Limpiar el formulario de agregar
            OnpropertyChanged(nameof(NuevaNotaPago)); // Notificar a la vista para limpiar los campos
        }
    }
}
