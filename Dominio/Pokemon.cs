using System.Collections.Generic;
using System.ComponentModel;

namespace Dominio
{
    public class Pokemon
    {
        //El nombre de las columnas del dgv toman el mismo nombre de las propiedades, esta annotation me sirve para poder
        //corregir en nombre, debo poner encima de la propieda o atributo que deseo modificar
        public int Id { get; set; }
        [DisplayName("Número")] //Annotation
        public int Numero { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]//Annotation
        public string Bio { get; set; }
        public string Altura { get; set; }
        public string Peso { get; set; }
        public string ImgUrl { get; set; }
        public int EvolucionId { get; set; }
        public List<Elemento> Tipos { get; set; }
        public List<Elemento> Debilidades { get; set; }
        public List<Habilidad> Habilidades { get; set; }

    }
}
