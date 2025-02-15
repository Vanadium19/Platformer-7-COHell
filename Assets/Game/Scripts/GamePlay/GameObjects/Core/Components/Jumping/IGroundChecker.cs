using UniRx;

namespace Game.Core.Components
{
    public interface IGroundChecker
    {
        public IReadOnlyReactiveProperty<bool> IsGrounded { get; }
    }
}