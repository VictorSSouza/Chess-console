using System;

namespace boardgame {
    class BoardException : Exception {

        public BoardException(string msg) : base(msg) {
        }
    }
}
