namespace Test.ObjectSettings
{
    public struct BalloonGameData
    {
        public BalloonColor Color { get; }
        public string Number { get; }
        public bool IsWantedNumber { get; }
        public bool IsAnswer { get; }

        public BalloonGameData(BalloonColor color, string number, bool isWantedNumber, bool isAnswer)
        {
            Color = color;
            Number = number;
            IsWantedNumber = isWantedNumber;
            IsAnswer = isAnswer;
        }

        public BalloonGameData(BalloonColor color, string number, bool isAnswer)
        {
            Color = color;
            Number = number;
            IsWantedNumber = false;
            IsAnswer = isAnswer;
        }
    }
}