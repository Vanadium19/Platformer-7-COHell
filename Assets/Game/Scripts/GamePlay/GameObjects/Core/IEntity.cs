namespace Game.Core
{
    public interface IEntity
    {
        public T Get<T>();
        public bool TryGet<T>(out T value) where T : class;
    }
}