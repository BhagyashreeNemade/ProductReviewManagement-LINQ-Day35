using System;
using System.Collections.Generic;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product review management using LINQ!\n");

            List<ProductReview> productReviewList = new List<ProductReview>()
            {
                new ProductReview(){ProductId=1,UserId=1,Rating=5,Review="Good",IsLike=true},
                new ProductReview(){ProductId=2,UserId=1,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=3,UserId=2,Rating=5,Review="Good",IsLike=true},
                new ProductReview(){ProductId=4,UserId=2,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=5,UserId=3,Rating=2,Review="Good",IsLike=false},
                new ProductReview(){ProductId=6,UserId=4,Rating=1,Review="Good",IsLike=false},
                new ProductReview(){ProductId=7,UserId=3,Rating=1.5,Review="Good",IsLike=false},
                new ProductReview(){ProductId=8,UserId=10,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=9,UserId=10,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=10,UserId=10,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=11,UserId=10,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=12,UserId=10,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=13,UserId=10,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=14,UserId=10,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=15,UserId=10,Rating=4,Review="Good",IsLike=true},
                new ProductReview(){ProductId=16,UserId=10,Rating=4,Review="Good",IsLike=true}
            };

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
    }
}