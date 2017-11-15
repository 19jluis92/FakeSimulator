namespace EntityProject
{
    using EntityProject.Utils;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Report")]
    public partial class Report : EntityBase
    {

        public bool Pass { get; set; }

        [Column("Report")]
        [Required]
        public string Report1 { get; set; }
    }
}
