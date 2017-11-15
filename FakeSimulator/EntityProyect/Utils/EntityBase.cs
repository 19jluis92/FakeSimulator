﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityProject.Utils
{
    public abstract class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}