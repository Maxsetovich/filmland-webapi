using FilmLand.Service.Dtos.Notifications;

namespace FilmLand.Service.Interfaces.Notifications;

public interface ISmsSender
{
    public Task<bool> SendAsync(SmsMessage smsMessage);
}
