using Microsoft.EntityFrameworkCore;
using StudentTest.Models;

namespace StudentTest.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public  DbSet<Question> Questions { get; set; }

        public DbSet<Log> Logs { get; set; }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<UserLogin>  UserLogins{ get; set; }

        public DbSet<TestSubmission> TestSubmissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);

            //Seed data for Questions
            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    QuestionText = "Which of the following is the correct syntax for declaring a character in C#?",
                    Explanation = "The 'char' keyword is used to declare a character in C#."
                },
                new Question
                {
                    QuestionId = 2,
                    QuestionText = "Which of the following is a value type in C#?",
                    Explanation = "int is a value type in C#, while string is a reference type."
                },
                new Question
                {
                    QuestionId = 3,
                    QuestionText = "Which operator is used for concatenation in C#?",
                    Explanation = "The '+' operator is used to concatenate strings in C#."
                },
                new Question
                {
                    QuestionId = 4,
                    QuestionText = "What is the default value of a Boolean in C#?",
                    Explanation = "The default value of a Boolean variable is 'false' in C#."
                },
                new Question
                {
                    QuestionId = 5,
                    QuestionText = "What does the keyword 'static' mean in C#?",
                    Explanation = "The 'static' keyword means that a member belongs to the type itself rather than to a specific object."
                },
                new Question
                {
                    QuestionId = 6,
                    QuestionText = "Which keyword is used to handle exceptions in C#?",
                    Explanation = "The 'try' keyword is used to start an exception handling block in C#."
                },
                new Question
                {
                    QuestionId = 7,
                    QuestionText = "Which method is used to output a line of text to the console in C#?",
                    Explanation = "The 'Console.WriteLine()' method outputs a line of text to the console."
                },
                new Question
                {
                    QuestionId = 8,
                    QuestionText = "What is the size of an int in C#?",
                    Explanation = "An 'int' in C# is 32-bits, which is 4 bytes."
                },
                new Question
                {
                    QuestionId = 9,
                    QuestionText = "What is boxing in C#?",
                    Explanation = "Boxing is the process of converting a value type to an object type in C#."
                },
                new Question
                {
                    QuestionId = 10,
                    QuestionText = "What is the base class of all classes in C#?",
                    Explanation = "'System.Object' is the base class of all classes in C#."
                },
                new Question
                {
                    QuestionId = 11,
                    QuestionText = "What is an interface in C#?",
                    Explanation = "An interface defines a contract that implementing classes must follow in C#."
                },
                new Question
                {
                    QuestionId = 12,
                    QuestionText = "Which of the following types in C# does not allow for inheritance?",
                    Explanation = "'sealed' types cannot be inherited in C#."
                },
                new Question
                {
                    QuestionId = 13,
                    QuestionText = "What is polymorphism in C#?",
                    Explanation = "Polymorphism allows methods to have different implementations depending on the object calling them."
                },
                new Question
                {
                    QuestionId = 14,
                    QuestionText = "What does the keyword 'void' indicate in a method declaration?",
                    Explanation = "The 'void' keyword indicates that the method does not return any value."
                },
                new Question
                {
                    QuestionId = 15,
                    QuestionText = "Which of the following is a reference type in C#?",
                    Explanation = "String is a reference type in C#."
                },
                new Question
                {
                    QuestionId = 16,
                    QuestionText = "What is the purpose of the 'readonly' keyword in C#?",
                    Explanation = "'readonly' variables can only be assigned values during declaration or in the constructor."
                },
                new Question
                {
                    QuestionId = 17,
                    QuestionText = "What is the maximum value of an int in C#?",
                    Explanation = "The maximum value of an 'int' in C# is 2,147,483,647."
                },
                new Question
                {
                    QuestionId = 18,
                    QuestionText = "What is the result of the expression '3 + 4 * 2' in C#?",
                    Explanation = "The result is 11 due to operator precedence (multiplication before addition)."
                },
                new Question
                {
                    QuestionId = 19,
                    QuestionText = "Which of the following loops in C# is guaranteed to execute at least once?",
                    Explanation = "'do...while' loops are guaranteed to execute at least once."
                },
                new Question
                {
                    QuestionId = 20,
                    QuestionText = "Which access modifier in C# allows a class member to be accessible only within its own class?",
                    Explanation = "The 'private' access modifier restricts access to the class in which the member is defined."
                }

            );

            // Seed data for answers
            modelBuilder.Entity<Answer>().HasData(
                new Answer { AnswerId = 1, AnswerText = "char", IsCorrect = true, QuestionId = 1 },
                new Answer { AnswerId = 2, AnswerText = "string", IsCorrect = false, QuestionId = 1 },
                new Answer { AnswerId = 3, AnswerText = "bool", IsCorrect = false, QuestionId = 1 },
                new Answer { AnswerId = 4, AnswerText = "int", IsCorrect = false, QuestionId = 1 },

                new Answer { AnswerId = 5, AnswerText = "int", IsCorrect = true, QuestionId = 2 },
                new Answer { AnswerId = 6, AnswerText = "string", IsCorrect = false, QuestionId = 2 },
                new Answer { AnswerId = 7, AnswerText = "bool", IsCorrect = false, QuestionId = 2 },
                new Answer { AnswerId = 8, AnswerText = "decimal", IsCorrect = false, QuestionId = 2 },

                new Answer { AnswerId = 9, AnswerText = "+", IsCorrect = true, QuestionId = 3 },
                new Answer { AnswerId = 10, AnswerText = "&", IsCorrect = false, QuestionId = 3 },
                new Answer { AnswerId = 11, AnswerText = "!", IsCorrect = false, QuestionId = 3 },
                new Answer { AnswerId = 12, AnswerText = "-", IsCorrect = false, QuestionId = 3 },

                new Answer { AnswerId = 13, AnswerText = "false", IsCorrect = true, QuestionId = 4 },
                new Answer { AnswerId = 14, AnswerText = "true", IsCorrect = false, QuestionId = 4 },
                new Answer { AnswerId = 15, AnswerText = "null", IsCorrect = false, QuestionId = 4 },
                new Answer { AnswerId = 16, AnswerText = "0", IsCorrect = false, QuestionId = 4 },

                new Answer { AnswerId = 17, AnswerText = "It belongs to the class, not the instance", IsCorrect = true, QuestionId = 5 },
                new Answer { AnswerId = 18, AnswerText = "It is inherited", IsCorrect = false, QuestionId = 5 },
                new Answer { AnswerId = 19, AnswerText = "It is abstract", IsCorrect = false, QuestionId = 5 },
                new Answer { AnswerId = 20, AnswerText = "It is readonly", IsCorrect = false, QuestionId = 5 },

                new Answer { AnswerId = 21, AnswerText = "The 'try' keyword is used to start an exception handling block in C#", IsCorrect = true, QuestionId = 6 },
                new Answer { AnswerId = 23, AnswerText = "It is inherited", IsCorrect = false, QuestionId = 6 },
                new Answer { AnswerId = 24, AnswerText = "It is abstract", IsCorrect = false, QuestionId = 6 },
                new Answer { AnswerId = 25, AnswerText = "It is readonly", IsCorrect = false, QuestionId = 6 },

                new Answer { AnswerId = 26, AnswerText = "Console.WriteLine()", IsCorrect = true, QuestionId = 7 },
                new Answer { AnswerId = 27, AnswerText = "Console.Output()", IsCorrect = false, QuestionId = 7 },
                new Answer { AnswerId = 28, AnswerText = "Console.PrintLine()", IsCorrect = false, QuestionId = 7 },
                new Answer { AnswerId = 29, AnswerText = "System.Console()", IsCorrect = false, QuestionId = 7 },

                new Answer { AnswerId = 30, AnswerText = "4 bytes", IsCorrect = true, QuestionId = 8 },
                new Answer { AnswerId = 31, AnswerText = "8 bytes", IsCorrect = false, QuestionId = 8 },
                new Answer { AnswerId = 32, AnswerText = "2 bytes", IsCorrect = false, QuestionId = 8 },
                new Answer { AnswerId = 33, AnswerText = "16 bytes", IsCorrect = false, QuestionId = 8 },

                new Answer { AnswerId = 34, AnswerText = "Converting a value type to an object type", IsCorrect = true, QuestionId = 9 },
                new Answer { AnswerId = 35, AnswerText = "Converting a reference type to a value type", IsCorrect = false, QuestionId = 9 },
                new Answer { AnswerId = 36, AnswerText = "Converting an int to a string", IsCorrect = false, QuestionId = 9 },
                new Answer { AnswerId = 37, AnswerText = "Converting an object type to a value type", IsCorrect = false, QuestionId = 9 },

                new Answer { AnswerId = 38, AnswerText = "System.Object", IsCorrect = true, QuestionId = 10 },
                new Answer { AnswerId = 39, AnswerText = "System.Base", IsCorrect = false, QuestionId = 10 },
                new Answer { AnswerId = 40, AnswerText = "System.Class", IsCorrect = false, QuestionId = 10 },
                new Answer { AnswerId = 41, AnswerText = "System.Root", IsCorrect = false, QuestionId = 10 },

                new Answer { AnswerId = 42, AnswerText = "A contract that classes must implement", IsCorrect = true, QuestionId = 11 },
                new Answer { AnswerId = 43, AnswerText = "A class with only static methods", IsCorrect = false, QuestionId = 11 },
                new Answer { AnswerId = 44, AnswerText = "A sealed class", IsCorrect = false, QuestionId = 11 },
                new Answer { AnswerId = 45, AnswerText = "A method that cannot return a value", IsCorrect = false, QuestionId = 11 },

                new Answer { AnswerId = 46, AnswerText = "Sealed", IsCorrect = true, QuestionId = 12 },
                new Answer { AnswerId = 47, AnswerText = "Abstract", IsCorrect = false, QuestionId = 12 },
                new Answer { AnswerId = 48, AnswerText = "Virtual", IsCorrect = false, QuestionId = 12 },
                new Answer { AnswerId = 49, AnswerText = "Static", IsCorrect = false, QuestionId = 12 },

                new Answer { AnswerId = 50, AnswerText = "The ability of a method to have different implementations", IsCorrect = true, QuestionId = 13 },
                new Answer { AnswerId = 51, AnswerText = "The ability to inherit from multiple classes", IsCorrect = false, QuestionId = 13 },
                new Answer { AnswerId = 52, AnswerText = "The ability of a class to have multiple constructors", IsCorrect = false, QuestionId = 13 },
                new Answer { AnswerId = 53, AnswerText = "The ability to overload operators", IsCorrect = false, QuestionId = 13 },

                new Answer { AnswerId = 54, AnswerText = "The method does not return a value", IsCorrect = true, QuestionId = 14 },
                new Answer { AnswerId = 55, AnswerText = "The method returns an integer", IsCorrect = false, QuestionId = 14 },
                new Answer { AnswerId = 56, AnswerText = "The method can return any type", IsCorrect = false, QuestionId = 14 },
                new Answer { AnswerId = 57, AnswerText = "The method is static", IsCorrect = false, QuestionId = 14 },

                new Answer { AnswerId = 58, AnswerText = "String", IsCorrect = true, QuestionId = 15 },
                new Answer { AnswerId = 59, AnswerText = "Int", IsCorrect = false, QuestionId = 15 },
                new Answer { AnswerId = 60, AnswerText = "Char", IsCorrect = false, QuestionId = 15 },
                new Answer { AnswerId = 61, AnswerText = "Float", IsCorrect = false, QuestionId = 15 },

                new Answer { AnswerId = 62, AnswerText = "It makes a variable assignable only in declaration or constructor", IsCorrect = true, QuestionId = 16 },
                new Answer { AnswerId = 63, AnswerText = "It prevents the variable from being assigned a value", IsCorrect = false, QuestionId = 16 },
                new Answer { AnswerId = 64, AnswerText = "It makes a variable accessible only within its class", IsCorrect = false, QuestionId = 16 },
                new Answer { AnswerId = 65, AnswerText = "It allows the variable to be modified from anywhere", IsCorrect = false, QuestionId = 16 },

                new Answer { AnswerId = 66, AnswerText = "2,147,483,647", IsCorrect = true, QuestionId = 17 },
                new Answer { AnswerId = 67, AnswerText = "9,223,372,036,854,775,807", IsCorrect = false, QuestionId = 17 },
                new Answer { AnswerId = 68, AnswerText = "32,767", IsCorrect = false, QuestionId = 17 },
                new Answer { AnswerId = 69, AnswerText = "65,535", IsCorrect = false, QuestionId = 17 },

                new Answer { AnswerId = 70, AnswerText = "11", IsCorrect = true, QuestionId = 18 },
                new Answer { AnswerId = 71, AnswerText = "14", IsCorrect = false, QuestionId = 18 },
                new Answer { AnswerId = 72, AnswerText = "7", IsCorrect = false, QuestionId = 18 },
                new Answer { AnswerId = 73, AnswerText = "10", IsCorrect = false, QuestionId = 18 },

                new Answer { AnswerId = 74, AnswerText = "do...while", IsCorrect = true, QuestionId = 19 },
                new Answer { AnswerId = 75, AnswerText = "while", IsCorrect = false, QuestionId = 19 },
                new Answer { AnswerId = 76, AnswerText = "for", IsCorrect = false, QuestionId = 19 },
                new Answer { AnswerId = 77, AnswerText = "foreach", IsCorrect = false, QuestionId = 19 },

                new Answer { AnswerId = 78, AnswerText = "private", IsCorrect = true, QuestionId = 20 },
                new Answer { AnswerId = 79, AnswerText = "public", IsCorrect = false, QuestionId = 20 },
                new Answer { AnswerId = 80, AnswerText = "protected", IsCorrect = false, QuestionId = 20 },
                new Answer { AnswerId = 81, AnswerText = "internal", IsCorrect = false, QuestionId = 20 }


            );
        }
    }
    

}
