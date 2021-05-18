using System;
using System.Collections.Generic;
using System.Text;

namespace SunInfoWpf
{
    public interface IErrorMessageHandler
    {
        void AddMessage(string message);
        string GetMessages();
    }
}
