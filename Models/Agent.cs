﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyEticketApplication.Models
{
    public class Agent
    {
        [Key]
        public int AgentId { get; set; }


        [Required(ErrorMessage = "This Field Must Be Fill!!!!")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Enter Minimum 2 or maximum 40 chacacter !!")]
        [Display(Name = "Agent Name", Description = "Name of the Agent")]
        public string Name { get; set; }


        [Required(ErrorMessage = "This Field Must Be Fill!!!!")]
        public string Address { get; set; }


        [Required(ErrorMessage = "This Field Must Be Fill!!!!")]
        [Range(18, 60, ErrorMessage = "Age Must be between 18 to 60")]
        public int Age { get; set; }


        [Required(ErrorMessage = "This Field Must Be Fill!!!!")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "This Field Must Be Fill!!!!")]
        [EmailAddress]
        public string Email { get; set; }



        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM dd, yyyy}", ApplyFormatInEditMode = false)]
        [Display(Name = "EntryDate")]
        public DateTime JoiningDate { get; set; }

        [Display(Name="Image")]
        public string UrlImage { get; set; }

        [NotMapped]
        public IFormFile ImageUrl { get; set; }
    }
}
