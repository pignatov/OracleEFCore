using System;
using System.Collections.Generic;

namespace OracleEFCore
{
    public partial class Ehic
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Pin { get; set; }
        public string IdcardNo { get; set; }
        public DateTime IdcardIssueDate { get; set; }
    }
}
