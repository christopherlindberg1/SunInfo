using System;
using System.Collections.Generic;
using System.Text;

namespace SunInfoWpf
{
    public class ErrorMessageHandler : IErrorMessageHandler
    {
        private readonly List<string> _messages = new List<string>();
        private bool _hasSentMessage = false;


        private List<string> Messages
        {
            get => this._messages;
        }


        /// <summary>
        /// Internal method used to keep track of whether messages has been presented.
        /// </summary>
        private bool HasSentMessage
        {
            get => this._hasSentMessage;

            set => this._hasSentMessage = value;
        }

        /// <summary>
        /// Adds message to a List with messages.
        /// </summary>
        /// <param name="message"></param>
        public void AddMessage(string message)
        {
            if (String.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("Message", "Message cannot be null or white space");
            }

            if (this.HasSentMessage)
            {
                this.Messages.Clear();
                this.HasSentMessage = false;
            }

            this.Messages.Add(message);
        }

        /// <summary>
        /// Returns a string representation of all messages.
        /// </summary>
        /// <returns>String with message.</returns>
        public string GetMessages()
        {
            StringBuilder messageBuilder = new StringBuilder();

            foreach (string message in this.Messages)
            {
                messageBuilder.Append(message + "\n");
            }

            this.HasSentMessage = true;
            return messageBuilder.ToString();
        }
    }
}
