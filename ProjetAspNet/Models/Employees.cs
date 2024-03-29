//------------------------------------------------------------------------------
// <auto-generated>
//    Ce code a été généré à partir d'un modèle.
//
//    Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//    Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetAspNet.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Employees
    {
        public Employees()
        {
            this.ExpanseReports = new HashSet<ExpanseReports>();
            this.ExpanseReports1 = new HashSet<ExpanseReports>();
            this.Poles1 = new HashSet<Poles>();
        }
    
        public Guid Employee_ID { get; set; }
        public string User_ID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Telephone { get; set; }
        public Guid? Pole_ID { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual Poles Poles { get; set; }
        public virtual ICollection<ExpanseReports> ExpanseReports { get; set; }
        public virtual ICollection<ExpanseReports> ExpanseReports1 { get; set; }
        public virtual ICollection<Poles> Poles1 { get; set; }
    }
}
