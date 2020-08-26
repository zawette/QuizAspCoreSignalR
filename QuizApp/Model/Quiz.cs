using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Model
{
    public class Quiz
    {
        public int id;
        public string question;
        public string[] propositions;
        public string answer;
        public string anecdote;

        public Quiz()
        {
        }
        public Quiz(int id, string question, string[] propositions, string answer, string anecdote)
        {
            this.id = id;
            this.question = question;
            this.propositions = propositions;
            this.answer = answer;
            this.anecdote = anecdote;
        }

        public override string ToString()
        {
            return $"{id} {question} {propositions} {answer} {anecdote}";
        }
    }

}
