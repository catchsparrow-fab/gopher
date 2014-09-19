using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gopher.Model.Abstractions;
using Gopher.Model.Domain;
using Gopher.Model.Tools;

namespace Gopher.Model.Repositories
{
    public class TranslationRepository : ITranslationRepository
    {
        public Translation GetSingle(string label, int languageId)
        {
            return DbHelper.GetItem<Translation>("SELECT p.PageLabelId, p.LabelName, @languageId as LanguageId, t.Translation FROM Translations t INNER JOIN PageLabels p ON p.PageLabelId = t.PageLabelId WHERE p.LabelName = @labelName AND t.LanguageId = @languageId",
                CommandType.DynamicSql,
                new DbParameter("languageId", languageId),
                new DbParameter("labelName", label));
        }

        public Translation GetSingle(int pageLabelId, int languageId)
        {
            return DbHelper.GetItem<Translation>("SELECT p.PageLabelId, p.LabelName, @languageId as LanguageId, t.Translation FROM Translations t INNER JOIN PageLabels p ON p.PageLabelId = t.PageLabelId WHERE p.PageLabelId = @pageLabelId AND t.LanguageId = @languageId",
                CommandType.DynamicSql,
                new DbParameter("languageId", languageId),
                new DbParameter("pageLabelId", pageLabelId));
        }

        public IEnumerable<Translation> GetAll(int languageId)
        {
            return DbHelper.GetList<Translation>("SELECT p.PageLabelId, p.LabelName, @languageId as LanguageId, t.Translation FROM PageLabels p INNER JOIN Translations t ON t.PageLabelId = p.PageLabelId WHERE t.LanguageId = @languageId ORDER BY p.LabelName",
                CommandType.DynamicSql,
                new DbParameter("languageId", languageId));
        }

        public void Update(Translation translation)
        {
            DbHelper.UpdateSingle("UPDATE Translations SET Translation = @translation WHERE PageLabelId = @pageLabelId AND LanguageId = @languageId",
                CommandType.DynamicSql,
                new DbParameter("pageLabelId", translation.PageLabelId),
                new DbParameter("languageId", translation.LanguageId),
                new DbParameter("translation", translation.Text));
        }
    }
}
