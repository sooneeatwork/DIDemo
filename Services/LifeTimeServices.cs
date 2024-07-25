using DIDemo.Logging;

namespace DIDemo.Services
{
    public interface ILifetimeDemoService
    {
        Guid Id { get; }
        void LogId();
    }

    public interface ITransientLifetimeDemoService : ILifetimeDemoService { }
    public interface IScopedLifetimeDemoService : ILifetimeDemoService { }
    public interface ISingletonLifetimeDemoService : ILifetimeDemoService { }

    public class TransientLifetimeDemoService : ITransientLifetimeDemoService
    {
        private readonly ILogger _logger;
        public Guid Id { get; } = Guid.NewGuid();

        public TransientLifetimeDemoService(ILogger logger)
        {
            _logger = logger;
        }

        public void LogId()
        {
            _logger.Log($"Transient Service Id: {Id}", LogLevel.Info);
        }
    }

    public class ScopedLifetimeDemoService : IScopedLifetimeDemoService
    {
        private readonly ILogger _logger;
        public Guid Id { get; } = Guid.NewGuid();

        public ScopedLifetimeDemoService(ILogger logger)
        {
            _logger = logger;
        }

        public void LogId()
        {
            _logger.Log($"Scoped Service Id: {Id}", LogLevel.Info);
        }
    }

    public class SingletonLifetimeDemoService : ISingletonLifetimeDemoService
    {
        private readonly ILogger _logger;
        public Guid Id { get; } = Guid.NewGuid();

        public SingletonLifetimeDemoService(ILogger logger)
        {
            _logger = logger;
        }

        public void LogId()
        {
            _logger.Log($"Singleton Service Id: {Id}", LogLevel.Info);
        }
    }
}