namespace EntityProject
{
    using EntityProject.Utils;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ContainerPressure")]
    public partial class ContainerPressure : EntityBase
    {

        [Column(TypeName = "numeric")]
        public decimal Width { get; set; }

        public bool HasExhaust { get; set; }

        [Column(TypeName = "numeric")]
        public decimal Height { get; set; }

        public long IdModel { get; set; }

        public virtual Model Model { get; set; }
    }
}
