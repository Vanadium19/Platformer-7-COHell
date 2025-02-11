using Game.Core;

namespace Game.Content.Player
{
    public class CharacterProvider
    {
        private readonly IEntity _entity;

        public CharacterProvider(IEntity entity)
        {
            _entity = entity;
        }

        public T Get<T>()
        {
            return _entity.Get<T>();
        }

        public bool TryGet<T>(out T value) where T : class
        {
            return _entity.TryGet(out value);
        }
    }
}