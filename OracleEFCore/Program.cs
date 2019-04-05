using System;

namespace OracleEFCore
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new NhifEessiContext())
            {
                Ehic ehic = new Ehic()
                {
                    FullName = "John Smith",
                    IdcardIssueDate = new System.DateTime(2010, 03, 21),
                    IdcardNo = "1234567890",
                    Pin = "0987654321"
                };
                context.Ehic.Add(ehic);
                context.SaveChanges();
            }
        }
    }
}
