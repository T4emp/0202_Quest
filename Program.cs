using System;
using System.IO;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main()
        {
            var lineList = File.ReadAllLines("History.txt");

            var totalQuestionCount = 0;
            var correctAnswerCount = 0;

            var question = string.Empty;
            var correctAnswer = string.Empty;
            var answerList = new List<string>();

            foreach (var line in lineList)
            {
                if (!string.IsNullOrEmpty(line))
                {
                    if (!line.StartsWith("-") && !line.StartsWith("+"))
                    {
                        totalQuestionCount++;
                        question = line;
                    }
                    else
                    {
                        answerList.Add(line);
                        if (line.StartsWith("+"))
                        {
                            correctAnswer = line;
                        }
                    }
                }
                else
                {
                    Console.WriteLine(question);
                    for (var i = 0; i < answerList.Count; i++)
                    {
                        Console.WriteLine(i + 1 + ". " + answerList[i].Substring(1, answerList[i].Length - 1));
                    }
                    var stringAnswer = Console.ReadLine();
                    if (int.TryParse(stringAnswer, out int answer) && answer > 0 && answer < answerList.Count + 1)
                    {
                        if (answerList[answer - 1] == correctAnswer)
                        {
                            correctAnswerCount++;
                        }
                    }
                    Console.WriteLine();
                    answerList.Clear();
                }
            }
            var result = (float)correctAnswerCount / totalQuestionCount;
            Console.WriteLine("Правильных ответов: " + correctAnswerCount + "/" + totalQuestionCount);
            Console.WriteLine("Результат: " + Math.Round(result, 2) * 100 + "%");
            Console.ReadKey();
        }
    }
}