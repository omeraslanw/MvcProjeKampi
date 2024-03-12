using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Writer
    {
        [Key]
        public int WriterID { get; set; }

        [StringLength(20)]
        public string WriterName { get; set; }

        [StringLength(20)]
        public string WriterSurName { get; set; }

        [StringLength(250)]
        public string WriterImage { get; set; }

        [StringLength(100)]
        public string WriterAbout { get; set; }

        [StringLength(100)]
        public string WriterMail { get; set; }

        [StringLength(100)]
        public string WriterPassword { get; set; }

        [StringLength(20)]
        public string WriterTitle { get; set; }

        public bool WriterStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }
        //Burası bire çok ilişkinin çok kısmıdır
        //Heading sınıfıyla ICollection türünde ilişki kurduk

        public ICollection<Content> Contents { get; set; }
    }
}
