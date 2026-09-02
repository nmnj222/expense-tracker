using System.Threading.Channels;

namespace ExpenseTracker.Services;

public class ReminderChannelService
{

    private readonly Channel<string> _channel = Channel.CreateUnbounded<string>();

    public ChannelReader<string> Reader => _channel.Reader;

    public async ValueTask PublishReminderAsync(string message)
    {
        await _channel.Writer.WriteAsync(message);
    }
}
