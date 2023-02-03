using System;
namespace boardgame
{
    internal class BoardException : Exception
    {
        public BoardException(string message) : base(message) 
        { 
        }
    }
}
