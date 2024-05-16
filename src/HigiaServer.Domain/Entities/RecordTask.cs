namespace HigiaServer.Domain.Entities;

public class RecordTask
{
    #region [Properties]

    public DateTime CreateDate { get; private set; } = DateTime.Now; 
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set;}
    public DateTime TotalTimeSpend { get; private set;}
    public Task? Task { get; private set; }

    #endregion
}