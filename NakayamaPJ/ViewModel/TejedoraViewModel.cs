using NakayamaPJ.Model;
using NakayamaPJ.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace NakayamaPJ.ViewModel
{
    public class TejedoraViewModel : ViewModelBase
    {
        private readonly TejedoraRepository _tejedoraRepository;

        public ObservableCollection<TejedoraModel> Tejedoras { get; set; }
        public TejedoraModel NuevaTejedora { get; set; }
        private TejedoraModel _tejedoraSeleccionada;

        public TejedoraModel TejedoraSeleccionada
        {
            get => _tejedoraSeleccionada;
            set
            {
                if (_tejedoraSeleccionada != value)
                {
                    _tejedoraSeleccionada = value;
                    OnpropertyChanged(nameof(TejedoraSeleccionada)); // Notificar a la vista cuando se selecciona una tejedora
                }
            }
        }

        // Comandos del CRUD
        public ICommand AgregarTejedoraCommand { get; }
        public ICommand EliminarTejedoraCommand { get; }
        public ICommand ActualizarTejedoraCommand { get; }
        public ICommand SeleccionarTejedoraCommand { get; }

        // Inicializar el ViewModel y los comandos
        public TejedoraViewModel()
        {
            _tejedoraRepository = new TejedoraRepository();
            Tejedoras = new ObservableCollection<TejedoraModel>();
            NuevaTejedora = new TejedoraModel();

            // Inicializar los comandos del CRUD
            AgregarTejedoraCommand = new ViewModelCommand(EjecutarAgregarTejedora);
            SeleccionarTejedoraCommand = new ViewModelCommand(EjecutarSeleccionarTejedora);
            ActualizarTejedoraCommand = new ViewModelCommand(EjecutarActualizarTejedora);
            EliminarTejedoraCommand = new ViewModelCommand(EjecutarEliminarTejedora);

            // Cargar las tejedoras desde la base de datos
            CargarTejedoras();
        }

        // Método para eliminar tejedora
        private void EjecutarEliminarTejedora(object obj)
        {
            if (TejedoraSeleccionada != null)
            {
                // Usamos ID_Tejedora
                _tejedoraRepository.EliminarTejedora(TejedoraSeleccionada.ID_Tejedora);
                CargarTejedoras(); // Recargar la lista de tejedoras después de eliminar
                TejedoraSeleccionada = null; // Limpiar la selección
            }
        }

        // Método para actualizar tejedora
        private void EjecutarActualizarTejedora(object obj)
        {
            if (TejedoraSeleccionada != null)
            {
                // Usamos ID_Tejedora
                _tejedoraRepository.ActualizarTejedora(TejedoraSeleccionada);
                CargarTejedoras(); // Recargar la lista de tejedoras después de actualizar
            }
        }

        // Método para seleccionar tejedora
        private void EjecutarSeleccionarTejedora(object tejedoraSeleccionada)
        {
            if (tejedoraSeleccionada is TejedoraModel seleccionadaTejedora)
            {
                TejedoraSeleccionada = seleccionadaTejedora;
            }
        }

        // Cargar tejedoras desde la base de datos
        private void CargarTejedoras()
        {
            Tejedoras.Clear();
            var tejedoras = _tejedoraRepository.ObtenerTejedoras();
            foreach (var tejedora in tejedoras)
            {
                Tejedoras.Add(tejedora);
            }
        }

        // Método para agregar nueva tejedora
        private void EjecutarAgregarTejedora(object obj)
        {
            // Validación básica si los campos están llenos
            if (string.IsNullOrEmpty(NuevaTejedora.DNI) || string.IsNullOrEmpty(NuevaTejedora.Nombre) || string.IsNullOrEmpty(NuevaTejedora.Apellido))
            {
                // Aquí podrías agregar alguna validación o mensaje de error.
                return;
            }

            _tejedoraRepository.AgregarTejedora(NuevaTejedora);
            CargarTejedoras();
            NuevaTejedora = new TejedoraModel(); // Limpiar el formulario de agregar
            OnpropertyChanged(nameof(NuevaTejedora)); // Notificar a la vista para limpiar los TextBox
        }
    }


}
