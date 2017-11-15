namespace EntityProject
{
    using EntityProject.Utils;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Configuration")]
    public partial class SimulationConfiguration: EntityBase
    {
        public long Id { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OneHourInterval { get; set; }

        public bool ShowFPS { get; set; }
    }
}
