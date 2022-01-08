using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Calus_Mario_GymMobileApp.Models
{
    public class ListItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(GymList))]
        public int GymListID { get; set; }
        public int ItemID { get; set; }
    }
}
