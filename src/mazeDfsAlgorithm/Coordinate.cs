namespace mazeDfsAlgorithm
{
    public struct Coordinate
    {
        public int X { get; set; }
        public int Y { get; set; }
        //public bool Visited { get; set; }
        //public bool Wall { get; set; }

        public Coordinate UpperAdjacent() => new Coordinate { X = X + 1, Y = Y };
        public Coordinate LowerAdjacent() => new Coordinate { X = X - 1, Y = Y };
        public Coordinate LeftAdjacent() => new Coordinate { X = X , Y = Y - 1 };
        public Coordinate RightAdjacent() => new Coordinate { X = X , Y = Y + 1 };

        public override string ToString()
            => $"X: {X}, Y: {Y}";
    }
}
