using System;

public class Score
{
    private int _points;

    public int Points => _points;

    public Score(int points)
    {
        _points = points;
    }

    public void AddPoints(int points)
    {
        if (points < 0)
            throw new ArgumentException();

        _points += points;
    }

    public void RemovePoints(int points)
    {
        if (points < 0)
            throw new ArgumentException();

        _points -= points;

        if (_points < 0)
            _points = 0;
    }
}
