//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace mvcCACSLA.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Indicadores_detalle
    {
        public int IdFundamentacion { get; set; }
        public string Descripcion { get; set; }
        public int IdEstandar { get; set; }
        public int IdVariable { get; set; }
        public int IdCarrera { get; set; }
        public int IdUsuario { get; set; }
    
        public virtual Carreras Carreras { get; set; }
        public virtual Indicadores Indicadores { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}
