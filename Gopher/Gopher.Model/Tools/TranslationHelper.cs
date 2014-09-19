using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace Gopher.Model.Tools
{
    public static class TranslationHelper
    {
        private static ITranslationRepository repository = null;

        static TranslationHelper()
        {
            repository = DependencyResolver.Current.GetService<ITranslationRepository>();            
        }

        /// <summary>
        /// Retrieves a translation for the language code associated with the current user.
        /// Throws an exception if found is not found for the given labelName.
        /// (Meaning the actual page label is missing, not the translation.)
        /// </summary>
        /// <param name="labelName"></param>
        /// <returns></returns>
        public static Translation GetTranslation(string labelName)
        {
            var userRepository = DependencyResolver.Current.GetService<IUserRepository>();
            var currentUser = userRepository.GetSingle(HttpContext.Current.User.Identity.GetUserId());

            int languageId = currentUser.LanguageId;

            var cache = HttpContext.Current.Cache;

            IEnumerable<Translation> translations = cache[GetCacheKey(languageId)] as IEnumerable<Translation>;

            if (translations == null)
            {
                translations = repository.GetAll(languageId);
                cache[GetCacheKey(languageId)] = translations;
            }

            var result = translations.SingleOrDefault(item => item.LabelName == labelName);

            if (result == null)
                throw new ApplicationException("Label not found: " + labelName);

            return result;
        }

        public static string Get(string labelName)
        {
            return GetTranslation(labelName).Text;
        }

        private const string TRANSLATIONS_CACHE_KEY = "translations_{0}";
        
        private static string GetCacheKey(int lang)
        {
            return string.Format(TRANSLATIONS_CACHE_KEY, lang);
        }

        public static void ClearCache()
        {
            var cache = HttpContext.Current.Cache;

            cache.Remove(GetCacheKey((int)Language.English));
            cache.Remove(GetCacheKey((int)Language.Japanese));
        }
    }
}