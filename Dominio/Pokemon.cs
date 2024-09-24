using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pokemon
    {

        //El nombre de las columnas del dgv toman el mismo nombre de las propiedades, esta annotation me sirve para poder
        //corregir en nombre, debo poner encima de la propieda o atributo que deseo modificar
        public int Id { get; set; }
        [DisplayName("Número")] //Annotation
        public  int Numero { get; set; }
        public string Nombre { get; set; }

        [DisplayName("Descripción")]//Annotation
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public Elemento Tipo { get; set; }
        public Elemento Debilidad { get; set; }

    }
}
