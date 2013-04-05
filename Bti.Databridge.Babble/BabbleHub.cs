using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Bti.Databridge.Babble
{
    public class BabbleHub : Hub
    {
        private static int correctAnswers;

        public void AnswerTrivia(string message)
        {
            if (message.ToLower() == "klingon")
            {
                correctAnswers += 1;
                var msg = "";
                if (correctAnswers == 1)
                {
                    msg = "1 Correct Answer"; 
                }
                else
                {
                    msg = correctAnswers.ToString() + " Correct Answers";
                }
                Clients.All.answerTrivia(msg);
            }
        }

        public void AnswerQuote(string message)
        {
            Clients.All.answerQuote(message);
        }

        public void Take(string webid, string webline1, string webline2)
        {
            correctAnswers = 0;
            Clients.All.take(webid, webline1, webline2);
        }
    }
}