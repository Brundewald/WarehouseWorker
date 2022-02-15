using UnityEngine;

namespace TestAssignment
{
    public sealed class PlayerMovementHandler:IInitialization, IExecute, ICleanup
    {
        private readonly Transform _playerTransform;
        private readonly IPlayerInput _inputHorizontal;
        private readonly IPlayerInput _inputVertical;
        private float _horizontal;
        private float _vertical;
        private Vector3 _moveVector = new Vector3(0, 0, 1);

        public PlayerMovementHandler(InputProxy inputProxy, ViewHolder view)
        {
            _playerTransform = view.PlayerView.PlayerTransform;
            _inputHorizontal = inputProxy.GetInput().inputHorizontal;
            _inputVertical = inputProxy.GetInput().inputVertical;
        }


        public void Initialization()
        {
            _inputHorizontal.OnAxisChange += GetHorizontal;
            _inputVertical.OnAxisChange += GetVertical;
        }

        public void Execute(float deltaTime)
        {
            _playerTransform.position += _playerTransform.forward * _vertical * deltaTime * 5;
            _playerTransform.Rotate(0f, (_horizontal*0.1f), 0f);
        }

        public void Cleanup()
        { 
            _inputHorizontal.OnAxisChange -= GetHorizontal;
            _inputVertical.OnAxisChange -= GetVertical;
        }

        private void GetHorizontal(float value)
        {
            _horizontal = value;
        }

        private void GetVertical(float value)
        {
            _vertical = value;
        }
    }
}