using System;
using System.Collections.Generic;
using System.Data;

namespace ProductReviewManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to product review management using LINQ!\n");

            List<ProductReview> productReviewList = ProductReviewOperations.GetProductReviews();
            DataTable table = ProductReviewOperations.ToDataTable<ProductReview>(productReviewList);
            ProductReviewOperations.RetrieveRecordsWithUserId10AndOrderedByRating(table);
        }
    }
}