using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace TestMadeAstar.Models
{
    public class TennatPersonnelBD
    {
        [Required]
        public int TenantId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Give me your name Name please")]
        public virtual string FirstName { get; set; }
        [Required]
        [StringLength (50, MinimumLength = 4, ErrorMessage = "Give me your name middleName please")]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Give me your name LastName please")]
        public virtual string LastName { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "Give me your name NickName please")]
        public virtual string NickName { get; set; }
        public virtual DateTime DOB { get; set; }
        public virtual string Active { get; set; }
        [ForeignKey("GenderId")]
        public Gender GenderFk { get; set; }
        
        public int PrefixID { get; set; }
        [Required]
        public virtual Gender Gender { get; set; }
    }
}