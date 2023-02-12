using System;

namespace boardgame {
    class BoardException : Exception {

        public BoardException(string message) : base(message) {
        }
    }
}
