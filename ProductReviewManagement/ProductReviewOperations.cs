using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ProductReviewManagement
{
    class ProductReviewOperations
    {
        /// <summary>
        /// UC1
        /// Gets the product reviews.
        /// </summary>
        /// <returns></returns>
        public static List<ProductReview> GetProductReviews()
        {
            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductId=1,UserId=1,Rating=5,Review="Good",IsLike=true},
                new ProductReview(){ProductId=2,UserId=1,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=3,UserId=2,Rating=5,Review="Good",IsLike=true},
                new ProductReview(){ProductId=2,UserId=2,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=5,UserId=3,Rating=2,Review="Good",IsLike=false},
                new ProductReview(){ProductId=6,UserId=4,Rating=1,Review="Good",IsLike=false},
                new ProductReview(){ProductId=7,UserId=3,Rating=1.5,Review="Good",IsLike=false},
                new ProductReview(){ProductId=8,UserId=10,Rating=9,Review="Good",IsLike=true},
                new ProductReview(){ProductId=6,UserId=10,Rating=10,Review="Good",IsLike=true},
                new ProductReview(){ProductId=10,UserId=10,Rating=8,Review="Good",IsLike=true},
                new ProductReview(){ProductId=11,UserId=10,Rating=3,Review="Good",IsLike=true},
                new ProductReview(){ProductId=11,UserId=10,Rating=7,Review="Good",IsLike=true},
                new ProductReview(){ProductId=13,UserId=10,Rating=2,Review="Good",IsLike=true},
                new ProductReview(){ProductId=14,UserId=10,Rating=1,Review="Good",IsLike=true},
                new ProductReview(){ProductId=14,UserId=10,Rating=6,Review="Good",IsLike=true},
                new ProductReview(){ProductId=16,UserId=10,Rating=4,Review="Good",IsLike=true}
            };
            return productReviewList;
        }

        /// <summary>
        /// Displays the specified product review list.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public static void Display(List<ProductReview> productReviewList)
        {
            Console.Write("{0,-20}", "ProductId");
            Console.Write("{0,-20}", "UserId");
            Console.Write("{0,-20}", "Rating");
            Console.Write("{0,-20}", "Review");
            Console.Write("{0,-20}", "IsLike");
            Console.WriteLine();
            foreach (ProductReview pr in productReviewList)
            {
                Console.Write("{0,-20}", pr.ProductId);
                Console.Write("{0,-20}", pr.UserId);
                Console.Write("{0,-20}", pr.Rating);
                Console.Write("{0,-20}", pr.Review);
                Console.Write("{0,-20}", pr.IsLike);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// UC2
        /// Print top 3 record by rating
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public static void TopRecords(List<ProductReview> productReviewList)
        {
            var _data = productReviewList.OrderByDescending(a => a.Rating).Take(3);
            var data = (from list in productReviewList
                        orderby list.Rating descending
                        select list).Take(3);
            Console.WriteLine("\nTop 3 Records By Rating:");
            Console.Write("{0,-20}", "ProductId");
            Console.Write("{0,-20}", "UserId");
            Console.Write("{0,-20}", "Rating");
            Console.Write("{0,-20}", "Review");
            Console.Write("{0,-20}", "IsLike");
            Console.WriteLine();
            foreach (var pr in data)
            {
                Console.Write("{0,-20}", pr.ProductId);
                Console.Write("{0,-20}", pr.UserId);
                Console.Write("{0,-20}", pr.Rating);
                Console.Write("{0,-20}", pr.Review);
                Console.Write("{0,-20}", pr.IsLike);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// UC3
        /// Retrives the records with rating above3.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public static void RetriveRecordsWithRatingAbove3(List<ProductReview> productReviewList)
        {
            var _records = productReviewList.Where(a => (a.Rating > 3 && (a.ProductId == 1 || a.ProductId == 4 || a.ProductId == 9)));
            var records = from list in productReviewList
                          where list.Rating > 3 && (list.ProductId == 1 ||
                                list.ProductId == 4 || list.ProductId == 9)
                          select list;
            Console.WriteLine("\nRecords with rating greater than 3 and productId in (1,4,9):");
            Console.Write("{0,-20}", "ProductId");
            Console.Write("{0,-20}", "UserId");
            Console.Write("{0,-20}", "Rating");
            Console.Write("{0,-20}", "Review");
            Console.Write("{0,-20}", "IsLike");
            Console.WriteLine();
            foreach (var pr in records)
            {
                Console.Write("{0,-20}", pr.ProductId);
                Console.Write("{0,-20}", pr.UserId);
                Console.Write("{0,-20}", pr.Rating);
                Console.Write("{0,-20}", pr.Review);
                Console.Write("{0,-20}", pr.IsLike);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// UC4
        /// Counts the of review for each product identifier.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public static void CountOfReviewForEachProductID(List<ProductReview> productReviewList)
        {
            var _records = productReviewList.GroupBy(a => a.ProductId).Select(a => new { ProductId = a.Key, NumberOfReviews = a.Count() });
            var records = from list in productReviewList
                          group list by list.ProductId into grp
                          select new
                          {
                              ProductId = grp.Key,
                              NumberOfReviews = grp.Count()
                          };
            Console.WriteLine("\nNo of reviews per product id");
            Console.Write("{0,-20}", "ProductId");
            Console.Write("{0,-20}", "NumberOfReviews");
            Console.WriteLine();
            foreach (var pr in records)
            {
                Console.Write("{0,-20}", pr.ProductId);
                Console.Write("{0,-20}", pr.NumberOfReviews);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// UC5
        /// Gets the product identifier and review.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public static void GetProductIdAndReview(List<ProductReview> productReviewList)
        {
            var _records = productReviewList.Select(a => new { ProductId = a.ProductId, Review = a.Review });
            var records = from list in productReviewList
                          select new
                          {
                              ProductId = list.ProductId,
                              Review = list.Review
                          };
            Console.WriteLine("\nProductId and Review");
            Console.Write("{0,-20}", "ProductId");
            Console.Write("{0,-20}", "Review");
            Console.WriteLine();
            foreach (var pr in records)
            {
                Console.Write("{0,-20}", pr.ProductId);
                Console.Write("{0,-20}", pr.Review);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// UC6
        /// Skips the top 5 records.
        /// </summary>
        /// <param name="productReviewList">The product review list.</param>
        public static void SkipTop5Records(List<ProductReview> productReviewList)
        {
            var _records = productReviewList.Skip(5);
            var records = (from list in productReviewList
                           select list).Skip(5);
            Console.WriteLine("\nSkip First 5 Records:");
            Console.Write("{0,-20}", "ProductId");
            Console.Write("{0,-20}", "UserId");
            Console.Write("{0,-20}", "Rating");
            Console.Write("{0,-20}", "Review");
            Console.Write("{0,-20}", "IsLike");
            Console.WriteLine();
            foreach (var pr in records)
            {
                Console.Write("{0,-20}", pr.ProductId);
                Console.Write("{0,-20}", pr.UserId);
                Console.Write("{0,-20}", pr.Rating);
                Console.Write("{0,-20}", pr.Review);
                Console.Write("{0,-20}", pr.IsLike);
                Console.WriteLine();
            }
        }

        /// <summary>
        /// UC8
        /// Converts a list to datatable.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">The items.</param>
        /// <returns></returns>
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        /// <summary>
        /// Prints the data table.
        /// </summary>
        /// <param name="table">The table.</param>
        public static void PrintDataTable(DataTable table)
        {
            foreach (DataColumn column in table.Columns)
            {
                Console.Write("{0,-20}", column);
            }
            Console.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write("{0,-20}", item);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// UC9
        /// Retrieves the is like true records.
        /// </summary>
        /// <param name="table">The table.</param>
        public static void RetrieveIsLikeTrueRecords(DataTable table)
        {
            var _records = table.AsEnumerable().Where(a => a.Field<bool>("IsLike") == true);
            var records = from list in table.AsEnumerable()
                          where list.Field<bool>("IsLike") == true
                          select list;
            Console.WriteLine("\nSkip First 5 Records:");
            Console.Write("{0,-20}", "ProductId");
            Console.Write("{0,-20}", "UserId");
            Console.Write("{0,-20}", "Rating");
            Console.Write("{0,-20}", "Review");
            Console.Write("{0,-20}", "IsLike");
            Console.WriteLine();
            foreach (var pr in records)
            {
                Console.Write("{0,-20}", pr.Field<int>("ProductId"));
                Console.Write("{0,-20}", pr.Field<int>("UserId"));
                Console.Write("{0,-20}", pr.Field<double>("Rating"));
                Console.Write("{0,-20}", pr.Field<string>("Review"));
                Console.Write("{0,-20}", pr.Field<bool>("IsLike"));
                Console.WriteLine();
            }
        }

        /// <summary>
        /// UC10
        /// Finds the average rating for each product.
        /// </summary>
        /// <param name="table">The table.</param>
        public static void FindAverageRatingForEachProduct(DataTable table)
        {
            var _records = table.AsEnumerable().GroupBy(a => a.Field<int>("ProductId")).Select(a => new { ProductId = a.Key, AvgRating = a.Average(r => r.Field<double>("Rating")) });
            var records = from list in table.AsEnumerable()
                          group list by list.Field<int>("ProductId") into grp
                          select new
                          {
                              ProductId = grp.Key,
                              AvgRating = grp.Average(a => a.Field<double>("Rating"))
                          };
            Console.WriteLine("\nProductId and Average Rating:");
            Console.Write("{0,-20}", "ProductId");
            Console.Write("{0,-20}", "Average Rating");
            Console.WriteLine();
            foreach (var pr in _records)
            {
                Console.Write("{0,-20}", pr.ProductId);
                Console.Write("{0,-20}", pr.AvgRating);
                Console.WriteLine();
            }
        }
    }
}