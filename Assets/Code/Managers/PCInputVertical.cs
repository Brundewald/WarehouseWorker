using System;
using UnityEngine;

namespace TestAssignment
{
    public sealed class PCInputVertical: IPlayerInput 
    {
        public event Action<float> OnAxisChange;
        public void GetAxis()
        {
            OnAxisChange?.Invoke(Input.GetAxis(AxisNames.Vertical));
        }
    }
}