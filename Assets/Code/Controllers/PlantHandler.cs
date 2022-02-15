namespace TestAssignment
{
    public abstract class PlantHandler: IInitialization, ICleanup
    {
        public abstract void Produce();
        public abstract void Initialization();
        public abstract void Cleanup();
    }
}