public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _bonusPoints;
    private int _currentCount;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override int RecordEvent()
    {
        _currentCount++;
        if (_currentCount == _targetCount)
            return GetPoints() + _bonusPoints;
        return GetPoints();
    }

    public override bool IsComplete() => _currentCount >= _targetCount;

    public override string GetStatus() =>
        (IsComplete() ? "[X] " : "[ ] ") + $"{GetName()} — Completed {_currentCount}/{_targetCount} times";

    public override string GetStringRepresentation() =>
        $"ChecklistGoal|{GetName()}|{GetDescription()}|{GetPoints()}|{_targetCount}|{_bonusPoints}|{_currentCount}";
}
