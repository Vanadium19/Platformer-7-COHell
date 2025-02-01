namespace Game.Core.Components
{
    public interface IJumper
    {
        public bool Jump();
        public void AddExtraForce(float multiplier);
    }
}