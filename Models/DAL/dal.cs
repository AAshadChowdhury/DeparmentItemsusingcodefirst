using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoreShortProject.Models.DAL
{
    public class dal
    {
    }
    public class dept2
    {
        [Key]
        public string deptid { get; set; }
        public string deptname { get; set; }
        public string location { get; set; }
        public IList<items2> items2 { get; set; }
    }
    public partial class items2
    {
        [Key]
        public string itemcode { get; set; }
        public string itemname { get; set; }
        [ForeignKey("dept2")]
        public string deptid { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> cost { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public Nullable<decimal> rate { get; set; }
        public DateTime date { get; set; }
        public bool? available { get; set; }
        public string picture { get; set; }

        public dept2 dept2 { get; set; }
    }
    public class ItemCount
    {
        public string deptid { get; set; }
        public string deptname { get; set; }
        public int count { get; set; }
    }

}
