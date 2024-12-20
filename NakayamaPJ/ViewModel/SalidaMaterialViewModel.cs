using NakayamaPJ.Model;
using NakayamaPJ.Repository;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace NakayamaPJ.ViewModel
{
    public class SalidaMaterialViewModel : ViewModelBase
    {
        private readonly SalidaMaterialRepository _salidaMaterialRepository;
        private SalidaMaterialModel _nuevaSalidaMaterial;
        private SalidaMaterialModel _salidaMaterialSeleccionada;

        // Colección que contendrá las salidas de material
        public ObservableCollection<SalidaMaterialModel> SalidasMaterial { get; set; }

        // Propiedad para la nueva salida de material que se va a agregar
        public SalidaMaterialModel NuevaSalidaMaterial
        {
            get => _nuevaSalidaMaterial;
            set
            {
                _nuevaSalidaMaterial = value;
                OnpropertyChanged(nameof(NuevaSalidaMaterial));
            }
        }

        // Propiedad para la salida de material seleccionada
        public SalidaMaterialModel SalidaMaterialSeleccionada
        {
            get => _salidaMaterialSeleccionada;
            set
            {
                _salidaMaterialSeleccionada = value;
                OnpropertyChanged(nameof(SalidaMaterialSeleccionada));
            }
        }

        // Comandos
        public ICommand AgregarSalidaMaterialCommand { get; }
        public ICommand ActualizarSalidaMaterialCommand { get; }
        public ICommand EliminarSalidaMaterialCommand { get; }

        // Constructor
        public SalidaMaterialViewModel()
        {
            _salidaMaterialRepository = new SalidaMaterialRepository();
            SalidasMaterial = new ObservableCollection<SalidaMaterialModel>(_salidaMaterialRepository.ObtenerSalidasMaterial());

            NuevaSalidaMaterial = new SalidaMaterialModel();

            // Inicialización de comandos
            AgregarSalidaMaterialCommand = new ViewModelCommand(AgregarSalidaMaterial);
            ActualizarSalidaMaterialCommand = new ViewModelCommand(ActualizarSalidaMaterial, CanExecuteActualizarOEliminar);
            EliminarSalidaMaterialCommand = new ViewModelCommand(EliminarSalidaMaterial, CanExecuteActualizarOEliminar);
        }

        // Método para agregar una nueva salida de material
        private void AgregarSalidaMaterial(object parameter)
        {
            _salidaMaterialRepository.AgregarSalidaMaterial(NuevaSalidaMaterial);
            SalidasMaterial.Add(NuevaSalidaMaterial);
            NuevaSalidaMaterial = new SalidaMaterialModel(); // Reiniciar el formulario
        }

        // Método para actualizar una salida de material
        private void ActualizarSalidaMaterial(object parameter)
        {
            if (SalidaMaterialSeleccionada != null)
            {
                _salidaMaterialRepository.ActualizarSalidaMaterial(SalidaMaterialSeleccionada);
                // Refrescar la lista de salidas si es necesario
            }
        }

        // Método para eliminar una salida de material
        private void EliminarSalidaMaterial(object parameter)
        {
            if (SalidaMaterialSeleccionada != null)
            {
                _salidaMaterialRepository.EliminarSalidaMaterial(SalidaMaterialSeleccionada.ID_Salida_Material);
                SalidasMaterial.Remove(SalidaMaterialSeleccionada);
                SalidaMaterialSeleccionada = null; // Limpiar la selección después de eliminar
            }
        }

        // Método que define si se puede ejecutar el comando de actualizar o eliminar
        private bool CanExecuteActualizarOEliminar(object parameter)
        {
            return SalidaMaterialSeleccionada != null;
        }
    }
}
