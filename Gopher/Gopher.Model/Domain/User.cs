using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using SwankSpank.Domain.Abstractions;

namespace Gopher.Model.Domain
{
    public class User : IPersistent
    {
        [Required]
        [MinLength(2)]
        public string Name { get; set; }

        public bool IsAdmin { get; set; }

        public string Id { get; set; }

        public int LanguageId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public void Init(IDataReader reader)
        {
        }
    }
}
