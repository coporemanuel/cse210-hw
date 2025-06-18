class Swimming : Activity
{
    private int laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        this.laps = laps;
    }

    public override double GetDistance() => laps * 50.0 / 1000;

    public override double GetSpeed() => (GetDistance() / Minutes) * 60;

    public override double GetPace() => Minutes / GetDistance();
}
