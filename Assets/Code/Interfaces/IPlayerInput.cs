using System;

namespace TestAssignment
{
    public interface IPlayerInput
    {
        event Action<float> OnAxisChange;

        void GetAxis();
    }
}