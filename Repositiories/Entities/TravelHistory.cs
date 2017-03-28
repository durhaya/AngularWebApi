using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repositories
{
    public class TravelHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public DateTime DateTime { get; set; }

        public long TimeStamp { get; set; }

    }
}
