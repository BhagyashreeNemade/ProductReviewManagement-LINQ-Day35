using System;
using System.Collections.Generic;
using System.Linq;
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
                new ProductReview(){ProductId=4,UserId=2,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=5,UserId=3,Rating=2,Review="Good",IsLike=false},
                new ProductReview(){ProductId=6,UserId=4,Rating=1,Review="Good",IsLike=false},
                new ProductReview(){ProductId=7,UserId=3,Rating=1.5,Review="Good",IsLike=false},
                new ProductReview(){ProductId=8,UserId=10,Rating=9,Review="Good",IsLike=true},
                new ProductReview(){ProductId=9,UserId=10,Rating=10,Review="Good",IsLike=true},
                new ProductReview(){ProductId=10,UserId=10,Rating=8,Review="Good",IsLike=true},
                new ProductReview(){ProductId=11,UserId=10,Rating=3,Review="Good",IsLike=true},
                new ProductReview(){ProductId=12,UserId=10,Rating=7,Review="Good",IsLike=true},
                new ProductReview(){ProductId=13,UserId=10,Rating=2,Review="Good",IsLike=true},
                new ProductReview(){ProductId=14,UserId=10,Rating=1,Review="Good",IsLike=true},
                new ProductReview(){ProductId=15,UserId=10,Rating=6,Review="Good",IsLike=true},
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
            var data = (from list in productReviewList
                        orderby list.Rating descending
                        select list).Take(3);
            Console.WriteLine("\nTop 3 Records By Rating:");
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
    }
}
Footer