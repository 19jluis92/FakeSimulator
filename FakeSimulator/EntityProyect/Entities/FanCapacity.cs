namespace EntityProject
{
    using EntityProject.Utils;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FanCapacity")]
    public partial class FanCapacity: EntityBase
    {

        [Column(TypeName = "numeric")]
        public decimal Radius { get; set; }

        [Column(TypeName = "numeric")]
        public decimal BladeLength { get; set; }

        public bool ComplexDesign { get; set; }

        public long IdModel { get; set; }

        public virtual Model Model { get; set; }
    }
}
