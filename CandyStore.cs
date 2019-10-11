using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Candy2.Data
{
    public class CandyStore
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CSID { get; set; }
        public string CSAreaSize { get; set; }
        public string CSLocation { get; set; }

    }
}
