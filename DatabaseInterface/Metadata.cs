using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseInterface
{
    [Table("METADATA")]
    public class Metadata
    {
        [Key]
        public Guid MetadataId { get; set; }
        [Required]
        public String Version { get; set; }
    }
}
