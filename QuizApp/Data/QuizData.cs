using Newtonsoft.Json.Linq;
using QuizApp.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Data
{

    public class QuizData
    {
        public IList<Quiz> QuizList { get; set; }

        public QuizData()
        {
            JObject JsonQuiz = JObject.Parse(File.ReadAllText(@"QuizJson/culturegenerale.json"));
            JArray QuizArray = (JArray)JsonQuiz["quizz"]["fr"]["débutant"];
            this.QuizList = QuizArray.Select(q =>
             {
                 int id = (int)q["id"];
                 string question = (string)q["question"];
                 string[] propositions = q["propositions"].ToObject<string[]>();
                 string answer= (string)q["réponse"];
                 string anecdote= (string)q["anecdote"];
                 return new Quiz(id,question,propositions,answer,anecdote);
             }).ToList();
        }

        public QuizData(string lang, string fileName, string difficulty)
        {
            JObject JsonQuiz = JObject.Parse(File.ReadAllText(@$"QuizJson/{fileName}.json"));
            JArray QuizArray = (JArray)JsonQuiz["quizz"][lang][difficulty];
            this.QuizList= QuizArray.Select(q =>
            {
                int id = (int)q["id"];
                string question = (string)q["question"];
                string[] propositions = q["propositions"].ToObject<string[]>();
                string answer = (string)q["réponse"];
                string anecdote = (string)q["anecdote"];
                return new Quiz(id, question, propositions, answer, anecdote);
            }).ToList();

        }
    }
}
