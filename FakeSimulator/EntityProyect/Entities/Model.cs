namespace EntityProject
{
    using EntityProject.Utils;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Model")]
    public partial class Model : EntityBase
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Model()
        {
            ContainerPressure = new HashSet<ContainerPressure>();
            FanCapacity = new HashSet<FanCapacity>();
        }


        [Required]
        [StringLength(90)]
        public string Title { get; set; }

        public long IdMaterial { get; set; }

        [Required]
        public string Description { get; set; }

        public long IdUsuario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContainerPressure> ContainerPressure { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FanCapacity> FanCapacity { get; set; }

        public virtual Material Material { get; set; }

        public virtual User User { get; set; }
    }
}
