using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExperiments
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Learning GROUPBY
            using (var db = new DataEntities())
            {
                var totals = db.Order_Details
                                .GroupBy(o => o.ProductID)
                                .Select(x => new
                                {
                                    ProductID = x.Key,
                                    Quantity = x.Sum(detail => detail.Quantity)
                                }).OrderBy(x => x.ProductID).ToList();

                totals.ForEach(t => Console.WriteLine("{0}\t\t\tCount = {1}", t.ProductID, t.Quantity));
            }
            #endregion

            Console.ReadKey();
        }
    }
}
