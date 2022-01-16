using System.Collections.Generic;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Straub_Bernadette_Lab10.Models
{
    public class Product
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Description { get; set; }
        [OneToMany]
        public List<ListProduct> ListProducts { get; set; }

    }
}