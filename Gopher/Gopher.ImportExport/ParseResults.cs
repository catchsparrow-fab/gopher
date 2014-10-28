using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport
{
    public enum ParseStatus
    {
        Success = 0,
        Error = 1
    }

    public class ParseResults
    {
        private ParseStatus status;
        public InputFileType FileType { get; set; }
        public int RowsInFile { get; set; }
        /// <summary>
        /// The size of the input file, in bytes.
        /// </summary>
        public long FileSize { get; set; }

        public ParseStatus Status
        {
            get { return status; }
            set
            {
                status = value;
                if (status == ParseStatus.Success)
                    ErrorMessage = null;
            }
        }

        /// <summary>
        /// If Status == ParseStatus.Error, contains the error text.
        /// </summary>
        public string ErrorMessage { get; set; }

        public ParseResults()
        {
            Status = ParseStatus.Error;
            RowsInFile = 0;
            FileSize = 0;
            FileType = InputFileType.Unrecognized;
            ErrorMessage = "Not started (#17).";
        }
    }
}
