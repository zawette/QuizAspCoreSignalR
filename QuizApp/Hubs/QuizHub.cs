using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json.Linq;
using QuizApp.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace QuizApp.Hubs
{
    public class QuizHub : Hub
    {
        static QuizData quizData;

        public async Task ConfigGame(string lang, string fileName, string difficulty, int MaxPlayers)
        {
            quizData = new QuizData(lang, fileName, difficulty);
            await Clients.All.SendAsync("gameConfigured", new { maxPlayers = MaxPlayers, maxQuestions = quizData.QuizList.Count });
        }

        public async Task Join(string name)
        {
            await Clients.All.SendAsync("PlayerJoined", new { name });
        }

        public async Task GetQuestion(int QuestionIndex)
        {
            Console.WriteLine(quizData.QuizList);

            if (QuestionIndex < quizData.QuizList.Count)
            {
                Console.WriteLine(quizData.QuizList[QuestionIndex]);
                await Clients.All.SendAsync("NewQuestion", new { 
                    question = quizData.QuizList[QuestionIndex].question,
                    propositions = quizData.QuizList[QuestionIndex].propositions,
                    answer = quizData.QuizList[QuestionIndex].answer,
                    anecdote = quizData.QuizList[QuestionIndex].anecdote });
            }
            else
            {
                await Clients.All.SendAsync("NewQuestion", new object());
            }

        }

        public async Task sendFakeAnswer(string fakeAnswer)
        {
            await Clients.All.SendAsync("receiveFakeAnswer", new { fakeAnswer });
        }

        public async Task AddScoreTo(string playerName)
        {
            await Clients.All.SendAsync("winnerName", new { playerName });
        }



    }
}
