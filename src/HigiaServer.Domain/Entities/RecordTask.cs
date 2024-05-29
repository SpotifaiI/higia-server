using System;

namespace HigiaServer.Domain.Entities;

public class RecordTask
{
    private TimeSpan _totalTimeSpend = TimeSpan.Zero;

    #region [Properties]

    public DateTime CreateDate { get; private set; } = DateTime.Now;
    public DateTime? StartDate { get; private set; }
    public DateTime? CloseDate { get; private set; }
    public DateTime? PausedTime { get; private set; }
    public TimeSpan TotalTimeSpend
    {
        get { return CalculateTotalTimeSpent(); }
        private set { _totalTimeSpend = value; }
    }

    public Task? Task { get; private set; }

    #endregion

    #region [Public Methods]

    public void RecordActiveTask()
    {
        if (PausedTime.HasValue)
        {
            _totalTimeSpend += DateTime.Now - PausedTime.Value;
            PausedTime = null;
        }
        else if (!StartDate.HasValue)
        {
            StartDate = DateTime.Now;
        }
    }

    public void RecordPausedTask()
    {
        if (StartDate.HasValue && !PausedTime.HasValue)
        {
            PausedTime = DateTime.Now;
        }
    }

    public void RecordCompleteTask()
    {
        if (StartDate.HasValue)
        {
            if (PausedTime.HasValue)
            {
                _totalTimeSpend += PausedTime.Value - StartDate.Value;
            }
            else
            {
                _totalTimeSpend += DateTime.Now - StartDate.Value;
            }

            CloseDate = DateTime.Now;
        }
    }

    private TimeSpan CalculateTotalTimeSpent()
    {
        if (StartDate.HasValue)
        {
            if (PausedTime.HasValue)
            {
                return _totalTimeSpend + (PausedTime.Value - StartDate.Value);
            }
            else if (CloseDate.HasValue)
            {
                return _totalTimeSpend;
            }
            else
            {
                return _totalTimeSpend + (DateTime.Now - StartDate.Value);
            }
        }

        return _totalTimeSpend;
    }

    #endregion
}

