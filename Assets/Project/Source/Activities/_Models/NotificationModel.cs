using System;

public class NotificationModel
{
    public Guid Id { get;  set; }
    public string Message { get;  set; }
    public int RewardType { get;  set; }
    public int RewardCount { get;  set; }
    public Guid? RewardId { get;  set; }
    public Guid UserId { get;  set; }
    public string IconPath { get;  set; }
}
