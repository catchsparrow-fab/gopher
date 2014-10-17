using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using Gopher.Model.Tools;
using Gopher.Tools;

namespace Gopher.Model.Domain
{
    public class User : IPersistent
    {
        [Required]
        [MinLength(2)]
        [TranslatableDisplayName("Generic_Name")]
        public string Name { get; set; }

        [TranslatableDisplayName("Generic_IsAdmin")]
        public bool IsAdmin { get; set; }

        public string Id { get; set; }

        [TranslatableDisplayName("Generic_Language")]
        public int LanguageId { get; set; }

        [Required]
        [EmailAddress]
        [TranslatableDisplayName("Generic_Email")]
        public string Email { get; set; }

        public void Init(IDataReader reader)
        {
        }
    }
}
