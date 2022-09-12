using System;
using System.Collections.Generic;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product review management using LINQ!\n");

            List<ProductReview> productReviewList = ProductReviewOperations.GetProductReviews();
            //ProductReviewOperations.Display(productReviewList);
            ProductReviewOperations.SkipTop5Records(productReviewList);
        }
    }
}