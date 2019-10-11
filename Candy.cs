using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Candy2.Data
{
    public class Candy
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CID { get; set; }
        [Display(Name ="Candy Flavor")]
        public string CFlavor { get; set; }
        [Display(Name = "Candy Size")]

        public string CSize { get; set; }
        public int CSID { get; set; }
        [ForeignKey("CSID")]
        public CandyStore CandStore { get; set; }



    }
}
