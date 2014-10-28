using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Gopher.ImportExport;

namespace Gopher.Upload
{
    public enum UploadStatus
    {
        Success = 0,
        Error = 1
    }

    public class UploadResults
    {
        public ParseResults ParseResults { get; set; }
        public BulkInsertResults BulkInsertResults { get; set; }
        public string FileName { get; set; }

        public UploadStatus Status
        {
            get
            {
                if (ParseResults.Status == ParseStatus.Success
                    && BulkInsertResults.Status == BulkInsertStatus.Success)
                {
                    return UploadStatus.Success;
                }

                return UploadStatus.Error;
            }
        }

        public string ErrorMessage
        {
            get
            {
                if (!string.IsNullOrEmpty(customErrorMessage))
                    return customErrorMessage;
                if (!string.IsNullOrEmpty(ParseResults.ErrorMessage))
                    return ParseResults.ErrorMessage;
                if (!string.IsNullOrEmpty(BulkInsertResults.ErrorMessage))
                    return BulkInsertResults.ErrorMessage;
                return null;
            }
        }

        private string customErrorMessage = null;
        public void SetCustomErrorMessage(string message)
        {
            customErrorMessage = message;
        }

        public UploadResults(ParseResults parseResults, BulkInsertResults bulkInsertResults)
        {
            ParseResults = parseResults;
            BulkInsertResults = bulkInsertResults;
        }
    }
}