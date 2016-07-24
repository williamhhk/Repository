using Repository.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Entities.Models
{
    public partial class Customer : IObjectState
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> Age { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }

    public partial class Stock : IObjectState
    {
        public int Id { get; set; }
        public int  MovieId { get; set; }

        [NotMapped]
        public ObjectState ObjectState { get; set; }
    }

}