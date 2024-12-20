using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using NakayamaPJ.Model;
using NakayamaPJ.Repository;

namespace NakayamaPJ.ViewModel
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly DashboardRepository _dashboardRepository;

        public DashboardViewModel()
        {
            _dashboardRepository = new DashboardRepository();
            CargarDatosDashboard();
        }

        // Propiedad: Prendas en Producción
        private int prendasEnProduccion;
        public int PrendasEnProduccion
        {
            get => prendasEnProduccion;
            set
            {
                if (prendasEnProduccion != value)
                {
                    prendasEnProduccion = value;
                    OnpropertyChanged(nameof(PrendasEnProduccion));
                }
            }
        }

        // Propiedad: Tejedoras Activas
        private int tejedorasActivas;
        public int TejedorasActivas
        {
            get => tejedorasActivas;
            set
            {
                if (tejedorasActivas != value)
                {
                    tejedorasActivas = value;
                    OnpropertyChanged(nameof(TejedorasActivas));
                }
            }
        }

        // Propiedad: Producción Semanal
        private ObservableCollection<ProduccionSemanal> produccionSemanal;
        public ObservableCollection<ProduccionSemanal> ProduccionSemanal
        {
            get => produccionSemanal;
            set
            {
                if (produccionSemanal != value)
                {
                    produccionSemanal = value;
                    OnpropertyChanged(nameof(ProduccionSemanal));
                }
            }
        }

        // Propiedad: Pagos Pendientes
        private ObservableCollection<PagosPendientes> pagosPendientes;
        public ObservableCollection<PagosPendientes> PagosPendientes
        {
            get => pagosPendientes;
            set
            {
                if (pagosPendientes != value)
                {
                    pagosPendientes = value;
                    OnpropertyChanged(nameof(PagosPendientes));
                }
            }
        }

        // Propiedad: Stock de Materia Prima
        private decimal stockMateriaPrima;
        public decimal StockMateriaPrima
        {
            get => stockMateriaPrima;
            set
            {
                if (stockMateriaPrima != value)
                {
                    stockMateriaPrima = value;
                    OnpropertyChanged(nameof(StockMateriaPrima));
                }
            }
        }

        // Carga inicial de datos
        public async void CargarDatosDashboard()
        {
            try
            {
                PrendasEnProduccion = _dashboardRepository.ObtenerPrendasEnProduccion();
                TejedorasActivas = _dashboardRepository.ObtenerTejedorasActivas();
                ProduccionSemanal = new ObservableCollection<ProduccionSemanal>(
                    _dashboardRepository.ObtenerProduccionSemanal()
                );
                PagosPendientes = new ObservableCollection<PagosPendientes>(
                    _dashboardRepository.ObtenerPagosPendientes()
                );
                StockMateriaPrima = await _dashboardRepository.ObtenerStockMateriaPrimaAsync(); // Llamada asíncrona
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar los datos del Dashboard.", ex);
            }
        }
    }
}
