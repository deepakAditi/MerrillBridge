

namespace Merrill.Infrastructure.Messaging
{
    /// <summary>
    /// The CommandHandler interface.
    /// </summary>
    /// <typeparam name="TCommand">
    /// </typeparam>
    public interface ICommandHandler<TCommand> where TCommand : Command
    {
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="command">
        /// The command.
        /// </param>
        void Execute(TCommand command);
    }
}
