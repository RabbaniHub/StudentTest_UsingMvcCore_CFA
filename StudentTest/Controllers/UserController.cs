using Microsoft.AspNetCore.Mvc;
using StudentTest.Models;
using System.Linq;
using System;
using StudentTest.Data;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

public class UserController : Controller
{
     public ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }
    // GET: User/Register
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    // POST: User/Register
    [HttpPost]
    public IActionResult Register(User model)
    {
          // Check if the username or email already exists
            if (_context.Users.Any(u => u.UserName == model.UserName || u.Email == model.Email))
            {
                ModelState.AddModelError("", "Username or Email already exists.");
                return View(model);
            }

            _context.Users.Add(model);
            _context.SaveChanges();
            return RedirectToAction("Login");
      
    }

    // GET: User/Login
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // POST: User/Login
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);
        if (user != null)
        {
            // Create a login record
            var loginRecord = new UserLogin
            {
                UserId = user.UserId,
                LoginTime = DateTime.Now,
                IsLoggedIn = true
            };
            _context.UserLogins.Add(loginRecord);
            _context.SaveChangesAsync();

            return RedirectToAction("StartTest"); // Redirect to test
        }
        else
        {
            ModelState.AddModelError("", "Invalid username or password.");
            return View(new User());
        }
    }
    public IActionResult StartTest()
    {
        // Fetch 20 random questions from the database along with their answers
        var questions = _context.Questions
            .Select(q => new Question
            {
                QuestionId = q.QuestionId,
                QuestionText = q.QuestionText,
                Explanation = q.Explanation,
                Answers = q.Answers.Select(a => new Answer
                {
                    AnswerId = a.AnswerId,
                    AnswerText = a.AnswerText
                }).ToList()
            })
            .OrderBy(q => Guid.NewGuid()) // Shuffle to get random questions
            .Take(5)
            .ToList();

        // Log action (Start Test)
        _context.Logs.Add(new Log
        {
            Action = "Start Test",
            TimeStamp = DateTime.Now,
            Details = "User started the test."
        });
        _context.SaveChanges();

        return View(questions);
    }

    // POST: Test/Submit
    [HttpPost]
    public IActionResult Submit(List<SubmitTest> Answers)
    {
        if (Answers == null || !Answers.Any())
        {
            return Content("No answers selected.");
        }

        int correctAnswers = 0;

        foreach (var submission in Answers)
        {
            // Find the correct answer for the question
            var correctAnswer = _context.Answers
                .FirstOrDefault(a => a.QuestionId == submission.QuestionId && a.IsCorrect);

            // Check if the user's selected answer is correct
            if (correctAnswer != null && correctAnswer.AnswerId == submission.SelectedAnswerId)
            {
                correctAnswers++;
            }

            // Log each submission (optional)
            _context.Logs.Add(new Log
            {
                Action = "Question Attempted",
                TimeStamp = DateTime.Now,
                Details = $"User attempted question {submission.QuestionId} with answer {submission.SelectedAnswerId}."
            });
        }

        // Save all logs (optional)
        _context.SaveChanges();

        // Calculate the score (e.g., out of 20)
        int score = correctAnswers;

        // Log the final submission
        _context.Logs.Add(new Log
        {
            Action = "Submit Test",
            TimeStamp = DateTime.Now,
            Details = $"User submitted the test and scored {score}."
        });
        _context.SaveChanges();

        // Redirect to the result page with the score
        return RedirectToAction("Result", new { score = score });
    }
   
    public IActionResult Result(int score)
    {
        // Optional: Retrieve total questions for additional context (if needed)
        int totalQuestions = _context.Answers.Where(a => a.IsCorrect).Count(); // Assuming 1 correct answer per question

        // Optional: Calculate the percentage score
        double percentageScore = ((double)score / totalQuestions) * 100;


        // Pass data to the view using ViewBag or a strongly-typed view model
     
        ViewBag.Score = score;
        ViewBag.TotalQuestions = totalQuestions;
        ViewBag.PercentageScore = percentageScore;

        // Log action (View Results)
        _context.Logs.Add(new Log
        {
            Action = "View Results",
            TimeStamp = DateTime.Now,
            Details = $"User viewed the test results with a score of {score} out of {totalQuestions}." // You can include additional user-related information here, e.g., "UserId: 123"
        });

        // Save the log entry
        _context.SaveChanges();

        return View(); // Or return View() if not using a view model
    }

}
