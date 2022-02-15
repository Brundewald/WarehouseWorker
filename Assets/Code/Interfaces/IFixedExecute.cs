namespace TestAssignment
{
    public interface IFixedExecute: IController
    {
        void FixedExecute(float fixedDeltaTime);
    }
}