using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gopher.ImportExport
{
    public enum BulkInsertStatus
    {
        Success = 0,
        Error = 1
    }

    public class BulkInsertResults
    {
        private BulkInsertStatus status;

        public BulkInsertStatus Status
        {
            get { return status; }
            set
            {
                status = value; 
                if (status == BulkInsertStatus.Success) 
                    ErrorMessage = null;
            }
        }

        public int RowsAffected { get; set; }
        public string ErrorMessage { get; set; }

        public BulkInsertResults()
        {
            Status = BulkInsertStatus.Error;
            RowsAffected = 0;
            ErrorMessage = "Not started (#14).";
        }
    }
}
