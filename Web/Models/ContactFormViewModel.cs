﻿using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
        public class ContactFormViewModel
        {
            [Required(ErrorMessage = "Please enter your name")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Please enter your email")]
            [EmailAddress(ErrorMessage = "Invalid email address")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Please enter a subject")]
            public string Subject { get; set; }

            [Required(ErrorMessage = "Please enter your message")]
            public string Message { get; set; }
        }

    }

