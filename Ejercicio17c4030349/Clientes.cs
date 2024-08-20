using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio17c4030349
{
    [Table("cliente")]
    public class Clientes
    {
        [PrimaryKey]
        [AutoIncrement]
        [Column("id")]
        public int Id { get; set; }
        [Column("nombrecliente")]
        public string? NombreCliente { get; set; }
        [Column("area")]
        public string? Area { get; set; }
        [Column("tasaporcuadrado")]
        public string? TasaPorCuadrado { get; set; }
        [Column("Presupuesto")]
        public string? Presupuesto { get; set; }
    }
}
