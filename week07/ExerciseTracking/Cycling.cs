class Cycling : Activity
{
    private double speedKph;

    public Cycling(DateTime date, int minutes, double speedKph)
        : base(date, minutes)
    {
        this.speedKph = speedKph;
    }

    public override double GetSpeed() => speedKph;

    public override double GetDistance() => (speedKph * Minutes) / 60;

    public override double GetPace() => 60 / speedKph;
}