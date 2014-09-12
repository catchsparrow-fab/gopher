using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;

namespace Gopher.Areas.Admin.Controllers
{
    public class LanguagesController : Controller
    {
        private readonly ITranslationRepository translationRepository;

        public LanguagesController(ITranslationRepository translationRepository)
        {
            this.translationRepository = translationRepository;
        }

        public IEnumerable<Translation> GetAll(int? lang = null)
        {
            int languageId = (int)Language.Default;
            if (lang != null)
                languageId = (int)lang;

            return translationRepository.GetAll(languageId);
        }
    }
}