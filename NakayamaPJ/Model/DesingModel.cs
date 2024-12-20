using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NakayamaPJ.Model
{
    public class DesingModel
    {
        public int ID_Desing { get; set; }  // ID único del diseño, si es necesario para actualizar
        public string Tamano { get; set; }  // Tamaño del diseño (L, M, etc.)
        public decimal? Precio { get; set; }  // Precio del diseño
        public string Codigo { get; set; }  // Código único para el diseño
        public decimal? Peso { get; set; }  // Peso del diseño
        public bool Bordado { get; set; }  // Si el diseño tiene bordado o no
        public bool EsMuestra { get; set; }  // Si es una muestra o no

        // Lista de materias primas asociadas al diseño
        public List<MateriaPrimaModel> MateriasPrimas { get; set; }
    }

    public class MateriaPrimaModel
    {
        public int IDMateriaPrima { get; set; }  // ID de la materia prima
        public decimal CantidadMaterial { get; set; }  // Cantidad del material que se usa en el diseño
        public string Descripcion { get; set; }  // Descripción del material, opcional, solo para fines informativos
    }


}
