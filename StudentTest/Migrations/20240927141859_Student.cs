using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentTest.Migrations
{
    /// <inheritdoc />
    public partial class Student : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.QuestionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    AnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.AnswerId);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TestSubmissions",
                columns: table => new
                {
                    SelectedAnswerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestSubmissions", x => x.SelectedAnswerId);
                    table.ForeignKey(
                        name: "FK_TestSubmissions_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "QuestionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    UserLoginId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => x.UserLoginId);
                    table.ForeignKey(
                        name: "FK_UserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "Explanation", "QuestionText" },
                values: new object[,]
                {
                    { 1, "The 'char' keyword is used to declare a character in C#.", "Which of the following is the correct syntax for declaring a character in C#?" },
                    { 2, "int is a value type in C#, while string is a reference type.", "Which of the following is a value type in C#?" },
                    { 3, "The '+' operator is used to concatenate strings in C#.", "Which operator is used for concatenation in C#?" },
                    { 4, "The default value of a Boolean variable is 'false' in C#.", "What is the default value of a Boolean in C#?" },
                    { 5, "The 'static' keyword means that a member belongs to the type itself rather than to a specific object.", "What does the keyword 'static' mean in C#?" },
                    { 6, "The 'try' keyword is used to start an exception handling block in C#.", "Which keyword is used to handle exceptions in C#?" },
                    { 7, "The 'Console.WriteLine()' method outputs a line of text to the console.", "Which method is used to output a line of text to the console in C#?" },
                    { 8, "An 'int' in C# is 32-bits, which is 4 bytes.", "What is the size of an int in C#?" },
                    { 9, "Boxing is the process of converting a value type to an object type in C#.", "What is boxing in C#?" },
                    { 10, "'System.Object' is the base class of all classes in C#.", "What is the base class of all classes in C#?" },
                    { 11, "An interface defines a contract that implementing classes must follow in C#.", "What is an interface in C#?" },
                    { 12, "'sealed' types cannot be inherited in C#.", "Which of the following types in C# does not allow for inheritance?" },
                    { 13, "Polymorphism allows methods to have different implementations depending on the object calling them.", "What is polymorphism in C#?" },
                    { 14, "The 'void' keyword indicates that the method does not return any value.", "What does the keyword 'void' indicate in a method declaration?" },
                    { 15, "String is a reference type in C#.", "Which of the following is a reference type in C#?" },
                    { 16, "'readonly' variables can only be assigned values during declaration or in the constructor.", "What is the purpose of the 'readonly' keyword in C#?" },
                    { 17, "The maximum value of an 'int' in C# is 2,147,483,647.", "What is the maximum value of an int in C#?" },
                    { 18, "The result is 11 due to operator precedence (multiplication before addition).", "What is the result of the expression '3 + 4 * 2' in C#?" },
                    { 19, "'do...while' loops are guaranteed to execute at least once.", "Which of the following loops in C# is guaranteed to execute at least once?" },
                    { 20, "The 'private' access modifier restricts access to the class in which the member is defined.", "Which access modifier in C# allows a class member to be accessible only within its own class?" }
                });

            migrationBuilder.InsertData(
                table: "Answers",
                columns: new[] { "AnswerId", "AnswerText", "IsCorrect", "QuestionId" },
                values: new object[,]
                {
                    { 1, "char", true, 1 },
                    { 2, "string", false, 1 },
                    { 3, "bool", false, 1 },
                    { 4, "int", false, 1 },
                    { 5, "int", true, 2 },
                    { 6, "string", false, 2 },
                    { 7, "bool", false, 2 },
                    { 8, "decimal", false, 2 },
                    { 9, "+", true, 3 },
                    { 10, "&", false, 3 },
                    { 11, "!", false, 3 },
                    { 12, "-", false, 3 },
                    { 13, "false", true, 4 },
                    { 14, "true", false, 4 },
                    { 15, "null", false, 4 },
                    { 16, "0", false, 4 },
                    { 17, "It belongs to the class, not the instance", true, 5 },
                    { 18, "It is inherited", false, 5 },
                    { 19, "It is abstract", false, 5 },
                    { 20, "It is readonly", false, 5 },
                    { 21, "The 'try' keyword is used to start an exception handling block in C#", true, 6 },
                    { 23, "It is inherited", false, 6 },
                    { 24, "It is abstract", false, 6 },
                    { 25, "It is readonly", false, 6 },
                    { 26, "Console.WriteLine()", true, 7 },
                    { 27, "Console.Output()", false, 7 },
                    { 28, "Console.PrintLine()", false, 7 },
                    { 29, "System.Console()", false, 7 },
                    { 30, "4 bytes", true, 8 },
                    { 31, "8 bytes", false, 8 },
                    { 32, "2 bytes", false, 8 },
                    { 33, "16 bytes", false, 8 },
                    { 34, "Converting a value type to an object type", true, 9 },
                    { 35, "Converting a reference type to a value type", false, 9 },
                    { 36, "Converting an int to a string", false, 9 },
                    { 37, "Converting an object type to a value type", false, 9 },
                    { 38, "System.Object", true, 10 },
                    { 39, "System.Base", false, 10 },
                    { 40, "System.Class", false, 10 },
                    { 41, "System.Root", false, 10 },
                    { 42, "A contract that classes must implement", true, 11 },
                    { 43, "A class with only static methods", false, 11 },
                    { 44, "A sealed class", false, 11 },
                    { 45, "A method that cannot return a value", false, 11 },
                    { 46, "Sealed", true, 12 },
                    { 47, "Abstract", false, 12 },
                    { 48, "Virtual", false, 12 },
                    { 49, "Static", false, 12 },
                    { 50, "The ability of a method to have different implementations", true, 13 },
                    { 51, "The ability to inherit from multiple classes", false, 13 },
                    { 52, "The ability of a class to have multiple constructors", false, 13 },
                    { 53, "The ability to overload operators", false, 13 },
                    { 54, "The method does not return a value", true, 14 },
                    { 55, "The method returns an integer", false, 14 },
                    { 56, "The method can return any type", false, 14 },
                    { 57, "The method is static", false, 14 },
                    { 58, "String", true, 15 },
                    { 59, "Int", false, 15 },
                    { 60, "Char", false, 15 },
                    { 61, "Float", false, 15 },
                    { 62, "It makes a variable assignable only in declaration or constructor", true, 16 },
                    { 63, "It prevents the variable from being assigned a value", false, 16 },
                    { 64, "It makes a variable accessible only within its class", false, 16 },
                    { 65, "It allows the variable to be modified from anywhere", false, 16 },
                    { 66, "2,147,483,647", true, 17 },
                    { 67, "9,223,372,036,854,775,807", false, 17 },
                    { 68, "32,767", false, 17 },
                    { 69, "65,535", false, 17 },
                    { 70, "11", true, 18 },
                    { 71, "14", false, 18 },
                    { 72, "7", false, 18 },
                    { 73, "10", false, 18 },
                    { 74, "do...while", true, 19 },
                    { 75, "while", false, 19 },
                    { 76, "for", false, 19 },
                    { 77, "foreach", false, 19 },
                    { 78, "private", true, 20 },
                    { 79, "public", false, 20 },
                    { 80, "protected", false, 20 },
                    { 81, "internal", false, 20 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_TestSubmissions_QuestionId",
                table: "TestSubmissions",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogins_UserId",
                table: "UserLogins",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "TestSubmissions");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
