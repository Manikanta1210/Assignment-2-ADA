using System; // Imports basic system functionalities including input/output.
using System.Collections.Generic; // Imports generic collection types like List, HashSet, and Dictionary.

namespace Assignment_2 // Defines the namespace for organizing classes.
{
    class Program // Defines the main class for the program.
    {
        static void Main(string[] args) // Main entry point of the application.
        {
            Console.WriteLine("Question 1:"); // Prints the question label.
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 }; // Input array with duplicates and missing numbers.
            IList<int> missingNumbers = FindMissingNumbers(nums1); // Finds numbers missing from the range 1 to n.
            Console.WriteLine(string.Join(",", missingNumbers)); // Prints the missing numbers.
            // Edge Cases Handled: Duplicates, multiple missing numbers, empty input
            // Additional Edge Cases (from Copilot Docs): [4,3,2,7,8,2,3,1] → [5,6], [1,1] → [2]

            Console.WriteLine("Question 2:"); // Prints the question label.
            int[] nums2 = { 3, 1, 2, 4 }; // Input array with a mix of even and odd numbers.
            int[] sortedArray = SortArrayByParity(nums2); // Sorts the array placing even numbers before odd ones.
            Console.WriteLine(string.Join(",", sortedArray)); // Prints the sorted array.
            // Edge Cases Handled: Array with only odd/even, includes 0, and single-element arrays
            // Additional Edge Cases (from Copilot Docs): [3,1,2,4] → [2,4,3,1], [0,1,2] → [0,2,1]

            Console.WriteLine("Question 3:"); // Prints the question label.
            int[] nums3 = { 2, 7, 11, 15 }; // Input array for the two-sum problem.
            int target = 9; // Target value to find two numbers that add up to it.
            int[] indices = TwoSum(nums3, target); // Finds indices of the two numbers adding up to target.
            Console.WriteLine(string.Join(",", indices)); // Prints the indices.
            // Edge Cases Handled: Duplicates, no valid pair, exactly one valid pair
            // Additional Edge Cases (from Copilot Docs): [2,7,11,15], target=9 → [0,1]; [3,2,4], target=6 → [1,2]; O(n) time complexity

            Console.WriteLine("Question 4:"); // Prints the question label.
            int[] nums4 = { 1, 2, 3, 4 }; // Input array for product calculation.
            int maxProduct = MaximumProduct(nums4); // Calculates the maximum product of any three numbers.
            Console.WriteLine(maxProduct); // Prints the maximum product.
            // Edge Cases Handled: Negative numbers, product from two smallest and one largest, input size less than 3
            // Additional Edge Cases (from Copilot Docs): Handles [1,2,3,4] → 24, includes negative value handling

            Console.WriteLine("Question 5:"); // Prints the question label.
            int decimalNumber = 42; // Decimal number to convert to binary.
            string binary = DecimalToBinary(decimalNumber); // Converts the decimal number to binary.
            Console.WriteLine(binary); // Prints the binary representation.
            // Edge Cases Handled: Zero input, small and large positive integers
            // Additional Edge Cases (from Copilot Docs): 42 → 101010, 10 → 1010, 0 → 0

            Console.WriteLine("Question 6:"); // Prints the question label.
            int[] nums5 = { 3, 4, 5, 1, 2 }; // Input rotated sorted array.
            int minElement = FindMin(nums5); // Finds the minimum element in the rotated array.
            Console.WriteLine(minElement); // Prints the minimum element.
            // Edge Cases Handled: Fully rotated array, not rotated, null or empty input
            // Additional Edge Cases (from Copilot Docs): [3,4,5,1,2] → 1, [4,5,6,7,0,1,2] → 0, uses binary search

            Console.WriteLine("Question 7:"); // Prints the question label.
            int palindromeNumber = 121; // Number to check for palindrome property.
            bool isPalindrome = IsPalindrome(palindromeNumber); // Checks if the number is a palindrome.
            Console.WriteLine(isPalindrome); // Prints true if palindrome, false otherwise.
            // Edge Cases Handled: Negative number, numbers ending in 0, single-digit numbers
            // Additional Edge Cases (from Copilot Docs): 121 → true, 10 → false, -121 → false

            Console.WriteLine("Question 8:"); // Prints the question label.
            int n = 4; // Index for Fibonacci calculation.
            int fibonacciNumber = Fibonacci(n); // Calculates the nth Fibonacci number.
            Console.WriteLine(fibonacciNumber); // Prints the Fibonacci number.
            // Edge Cases Handled: n = 0, n = 1, negative input
            // Additional Edge Cases (from Copilot Docs): 2 → 1, 3 → 2, 4 → 3

        }

        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                int n = nums.Length;
                HashSet<int> numSet = new HashSet<int>(nums); // Handles duplicates by storing only unique elements.
                List<int> missingNumbers = new List<int>();

                for (int i = 1; i <= n; i++)
                {
                    if (!numSet.Contains(i)) // Detects which numbers from 1 to n are missing.
                    {
                        missingNumbers.Add(i);
                    }
                }

                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                int[] result = new int[nums.Length];
                int evenIndex = 0;
                int oddIndex = nums.Length - 1;

                foreach (int num in nums)
                {
                    if (num % 2 == 0)
                    {
                        result[evenIndex++] = num; // Ensures even numbers (including 0) are placed first.
                    }
                    else
                    {
                        result[oddIndex--] = num; // Places odd numbers at the end.
                    }
                }

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                Dictionary<int, int> numDict = new Dictionary<int, int>();

                for (int i = 0; i < nums.Length; i++)
                {
                    int complement = target - nums[i];
                    if (numDict.ContainsKey(complement)) // Catches valid pairs early, even if duplicates exist.
                    {
                        return new int[] { numDict[complement], i };
                    }
                    numDict[nums[i]] = i; // Adds current number and index to the dictionary for lookup.
                }

                throw new ArgumentException("No two sum solution"); // Handles edge case where no solution exists.
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int MaximumProduct(int[] nums)
        {
            try
            {
                if (nums.Length < 3)
                {
                    throw new ArgumentException("Array must contain at least three elements."); // Handles arrays too short for valid product.
                }

                Array.Sort(nums); // Sorting handles negative and positive number order automatically.
                int n = nums.Length;

                int maxProduct = Math.Max(nums[n - 1] * nums[n - 2] * nums[n - 3],
                                          nums[0] * nums[1] * nums[n - 1]); // Evaluates both possible max products: top 3 vs 2 smallest * largest.

                return maxProduct;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                if (decimalNumber == 0)
                {
                    return "0"; // Explicitly handles 0 as input.
                }

                string binary = string.Empty;
                while (decimalNumber > 0)
                {
                    binary = (decimalNumber % 2) + binary;
                    decimalNumber /= 2;
                }

                return binary;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int FindMin(int[] nums)
        {
            try
            {
                if (nums == null || nums.Length == 0)
                {
                    throw new ArgumentException("Array must not be null or empty."); // Validates empty or null input.
                }

                int left = 0;
                int right = nums.Length - 1;

                while (left < right)
                {
                    int mid = left + (right - left) / 2;

                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1; // Handles rotated cases where min is in the right half.
                    }
                    else
                    {
                        right = mid; // Handles cases where min could be at mid or to the left.
                    }
                }

                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static bool IsPalindrome(int x)
        {
            try
            {
                if (x < 0)
                {
                    return false; // Immediately returns false for negative numbers.
                }

                int original = x;
                int reversed = 0;

                while (x > 0)
                {
                    int digit = x % 10;
                    reversed = reversed * 10 + digit; // Builds reversed number digit by digit.
                    x /= 10;
                }

                return original == reversed; // Compares original and reversed for palindrome check.
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Fibonacci(int n)
        {
            try
            {
                if (n < 0)
                {
                    throw new ArgumentException("Input must be a non-negative integer."); // Handles invalid negative inputs.
                }

                if (n == 0) return 0; // Edge case for 0.
                if (n == 1) return 1; // Edge case for 1.

                int a = 0, b = 1;

                for (int i = 2; i <= n; i++)
                {
                    int temp = a + b;
                    a = b;
                    b = temp;
                }

                return b;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}


