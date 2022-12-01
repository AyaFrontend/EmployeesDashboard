using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL2.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Id { set; get; }
    }
}
