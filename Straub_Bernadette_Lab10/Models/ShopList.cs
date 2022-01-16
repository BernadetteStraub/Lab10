using System;
using SQLite;

namespace Straub_Bernadette_Lab10.Models
{
    public class ShopList
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}