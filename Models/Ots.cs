using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Ots
    {
        public int Id { get; set; }
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public string Reference { get; set; }
        public string Invoice { get; set; }
        public int Department { get; set; }
        public int Costcenter { get; set; }
        public string Account { get; set; }
        public string ProjectCode { get; set; }
        public string Description { get; set; }
        public string Contractor { get; set; }
        public decimal LaborPrice { get; set; }
        public decimal MaterialPrice { get; set; }
        public string StateProject { get; set; }
        public string Userid { get; set; }
        public string Comment { get; set; }
        public byte? State { get; set; }
        public DateTime CreatedAt { get; set; }
        public byte[] UpdatedAt { get; set; }
        public int Idteam { get; set; }
    }
}
