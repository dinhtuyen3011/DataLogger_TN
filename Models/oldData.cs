using DataLogger.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;


namespace DataLogger.Model
{
    class OldData
    {
        [Key, Column(Order = 1)]
        public int Ms { get; set; }
        
        [Required]
        public string OldTime { get; set; }

        public Chanel Chanel { get; set; }

        [Key, Required, ForeignKey("Chanel"), Column(Order = 2)]
        public int ChanelId { get; set; }

        [Required]
        public float Value { get; set; }
    }
}
