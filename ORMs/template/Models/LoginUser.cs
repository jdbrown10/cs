using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace template.Models
{
    public class LoginUser
    {
        //other features

        [Required]
        [DataType(DataType.Password)]
        public string LoginPassword {get;set;}

    }
}
