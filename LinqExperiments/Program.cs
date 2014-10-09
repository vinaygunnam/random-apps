using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqExperiments.Models;

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
                                .GroupBy(o => new
                                {
                                    ProductID = o.ProductID,
                                    Name = o.Product.ProductName,
                                })
                                .Select(x => new
                                {
                                    ProductID = x.Key.ProductID,
                                    Name = x.Key.Name,
                                    Quantity = x.Sum(detail => detail.Quantity)
                                }).OrderBy(x => x.ProductID).ToList();

                totals.ForEach(t => Console.WriteLine("{0}: {1}\t\tCount = {1}", t.ProductID, t.Name, t.Quantity));
            }
            #endregion

            Console.ReadKey();
        }
    }
}
