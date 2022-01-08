using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace Calus_Mario_GymMobileApp.Models
{
    public class GymList
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
