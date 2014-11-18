using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using Gopher.ImportExport;
using Gopher.ImportExport.Tools;
using Gopher.Tools;
using Newtonsoft.Json;

namespace Gopher.Upload
{
    /// <summary>
    /// Summary description for UploadHandler
    /// </summary>
    public class UploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "POST":
                    HandleUploadingFile(context);
                    break;
                default:
                    throw new NotImplementedException();
            }
        }

        private void HandleUploadingFile(HttpContext context)
        {
            var parseResult = new ParseResults();
            var bulkInsertResult = new BulkInsertResults();
            UploadResults result = null;

            try
            {
                var tempFileName = Helper.GenerateTempFileName();
                using (var output = new FileStream(tempFileName, FileMode.CreateNew))
                {
                    parseResult = Import.GenerateBulkInsertFile(context.Request.Files[0].InputStream, output);
                }

                if (parseResult.Status == ParseStatus.Success)
                    bulkInsertResult = Import.BulkInsert(tempFileName, parseResult.FileType);

                result = new UploadResults(parseResult, bulkInsertResult);
                result.FileName = context.Request.Files[0].FileName;

                File.Delete(tempFileName);
            }
            catch (Exception ex)
            {
                if (result == null)
                    result = new UploadResults(parseResult, bulkInsertResult);
                result.SetCustomErrorMessage(ErrorMessage.FromException(ex));
            }

            var response = JsonConvert.SerializeObject(new
            {
                status = (int)result.Status,
                message = result.ErrorMessage,
                fileName = result.FileName,
                parse = new
                {
                    type = (int)result.ParseResults.FileType,
                    size = result.ParseResults.FileSize,
                    rows = result.ParseResults.RowsInFile,
                    message = result.ParseResults.ErrorMessage,
                    status = (int)result.ParseResults.Status
                },
                bulkInsert = new
                {
                    affected = result.BulkInsertResults.RowsAffected,
                    message = result.BulkInsertResults.ErrorMessage,
                    status = (int)result.BulkInsertResults.Status
                }
            });

            context.Response.Write(response);
            context.Response.ContentType = "application/json";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}