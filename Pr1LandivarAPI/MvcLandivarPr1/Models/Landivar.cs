using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace Pr1LandivarAPI.Models
{
    public enum Places
    {
        Santa_Cruz = 1,
        LaPaz,
        Beni,
        Tarija,
        Sucre

    };

    public class Landivar
    {
        [Key]
        public int LandivarID { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        [StringLength(24, MinimumLength = 2)]
        public string FriendofLandivar { get; set; }

        [Required]
        public Places Place { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessage = "Email no valido")]
        [EmailAddress]
        public String Email { get; set; }

        [Display(Name = "Cumpleaños")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }


    }
}