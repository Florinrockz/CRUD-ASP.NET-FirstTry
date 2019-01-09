using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_ASP.Models
{
    [MetadataType(typeof(UserMetaData))]
    public partial class User
    {

    }

    public class UserMetaData
    {
        [Required (AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string name
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string email
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string phone
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string country
        {
            get;
            set;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        public string city
        {
            get;
            set;
        }
    }
}