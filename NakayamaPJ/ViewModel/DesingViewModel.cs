using NakayamaPJ.Model;
using NakayamaPJ.Repository;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NakayamaPJ.ViewModel
{
    public class DesingViewModel : ViewModelBase
    {
        private readonly DesingRepository _desingRepository;

        public ObservableCollection<DesingModel> Diseños { get; set; }
        public DesingModel NuevoDesing { get; set; }

        private DesingModel _desingSeleccionado;
        public DesingModel DesingSeleccionado
        {
            get => _desingSeleccionado;
            set
            {
                if (_desingSeleccionado != value)
                {
                    _desingSeleccionado = value;
                    OnpropertyChanged(nameof(DesingSeleccionado)); // Notificar a la vista cuando se selecciona un diseño
                }
            }
        }

        // Comandos del CRUD
        public ICommand AgregarDesingCommand { get; }
        public ICommand EliminarDesingCommand { get; }
        public ICommand ActualizarDesingCommand { get; }
        public ICommand SeleccionarDesingCommand { get; }

        // Inicializar el ViewModel y los comandos
        public DesingViewModel()
        {
            _desingRepository = new DesingRepository();
            Diseños = new ObservableCollection<DesingModel>();
            NuevoDesing = new DesingModel();

            // Inicializar los comandos del CRUD
            AgregarDesingCommand = new ViewModelCommand(EjecutarAgregarDesing);
            SeleccionarDesingCommand = new ViewModelCommand(EjecutarSeleccionarDesing);
            ActualizarDesingCommand = new ViewModelCommand(EjecutarActualizarDesing);
            EliminarDesingCommand = new ViewModelCommand(EjecutarEliminarDesing);

            // Cargar los diseños desde la base de datos
            CargarDiseños();
        }

        // Método para eliminar diseño
        private void EjecutarEliminarDesing(object obj)
        {
            if (DesingSeleccionado != null)
            {
                // Usamos ID_Desing
                _desingRepository.EliminarDesing(DesingSeleccionado.ID_Desing);
                CargarDiseños(); // Recargar la lista de diseños después de eliminar
                DesingSeleccionado = null; // Limpiar la selección
            }
        }

        // Método para actualizar diseño
        private void EjecutarActualizarDesing(object obj)
        {
            if (DesingSeleccionado != null)
            {
                // Validación básica
                if (string.IsNullOrEmpty(DesingSeleccionado.Tamano) || string.IsNullOrEmpty(DesingSeleccionado.Codigo))
                {
                    // Aquí podrías agregar alguna validación o mensaje de error.
                    return;
                }

                // Usamos ID_Desing
                _desingRepository.ActualizarDesing(DesingSeleccionado);
                CargarDiseños(); // Recargar la lista de diseños después de actualizar
            }
        }

        // Método para seleccionar diseño
        private void EjecutarSeleccionarDesing(object desingSeleccionado)
        {
            if (desingSeleccionado is DesingModel seleccionadoDesing)
            {
                DesingSeleccionado = seleccionadoDesing;
            }
        }

        // Cargar diseños desde la base de datos
        private void CargarDiseños()
        {
            Diseños.Clear();
            var disenios = _desingRepository.ObtenerDiseños();
            foreach (var diseño in disenios)
            {
                Diseños.Add(diseño);
            }
        }

        // Método para agregar nuevo diseño
        private void EjecutarAgregarDesing(object obj)
        {
            // Validación básica si los campos están llenos
            if (string.IsNullOrEmpty(NuevoDesing.Tamano) || string.IsNullOrEmpty(NuevoDesing.Codigo) || NuevoDesing.Precio == null)
            {
                // Aquí podrías agregar alguna validación o mensaje de error.
                return;
            }

            _desingRepository.AgregarDesing(NuevoDesing);
            CargarDiseños();
            NuevoDesing = new DesingModel(); // Limpiar el formulario de agregar
            OnpropertyChanged(nameof(NuevoDesing)); // Notificar a la vista para limpiar los TextBox
        }
    }
}
