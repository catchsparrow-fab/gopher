using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Gopher.Model.Tools;

namespace Gopher.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TranslationsController : Controller
    {
        private readonly ITranslationRepository translationRepository;

        public TranslationsController(ITranslationRepository translationRepository)
        {
            this.translationRepository = translationRepository;
        }

        public ActionResult Index(int? lang = null)
        {
            int languageId = (int)Language.Default;
            if (lang != null)
                languageId = (int)lang;

            ViewBag.CurrentLanguage = (Language)languageId;
            ViewBag.ActiveTab = "translations";

            var model = translationRepository.GetAll(languageId);
            return View(model);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult ClearCache(int? lang = null)
        {
            TranslationHelper.ClearCache();
            ViewBag.CacheCleared = true;

            return Index(lang);
        }

        public ActionResult Edit(int label, int lang)
        {
            var model = translationRepository.GetSingle(label, lang);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Translation translation)
        {
            var existingTranslation = translationRepository.GetSingle(translation.PageLabelId, translation.LanguageId);
            if (existingTranslation == null)
                return new HttpNotFoundResult();
            existingTranslation.Text = translation.Text;
            translationRepository.Update(existingTranslation);
            if (!string.IsNullOrEmpty(Request.QueryString["lang"]))
                return RedirectToAction("Index", new { lang = Request.QueryString["lang"] });
            else
                return RedirectToAction("Index");
        }
    }
}