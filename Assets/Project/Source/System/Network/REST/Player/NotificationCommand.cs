
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class NotificationCommand : ICommand
{
    public NotificationCommand(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; private set; }
}

public class GetNotificationsCommandHandler : ApiCommandHandler, ICommandHandler<NotificationCommand, List<NotificationModel>>
{
    public GetNotificationsCommandHandler() : base(WebSettings.GameServerBaseUrl)
    {
    }

    public Task<List<NotificationModel>> Handle(NotificationCommand command)
    {
        return GetAsync<List<NotificationModel>>($"Reward?userId={command.UserId}");
    }
}
