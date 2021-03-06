namespace Akka.Actor.Internal
{
    /// <summary>INTERNAL
    /// A stash implementation that is unbounded
    /// <remarks>Note! Part of internal API. Breaking changes may occur without notice. Use at own risk.</remarks>
    /// </summary>
    public class UnboundedStashImpl : AbstractStash
    {
        /// <summary>INTERNAL
        /// A stash implementation that is bounded
        /// <remarks>Note! Part of internal API. Breaking changes may occur without notice. Use at own risk.</remarks>
        /// </summary>
        public UnboundedStashImpl(IActorContext context)
            : base(context, int.MaxValue)
        {
        }
    }
}