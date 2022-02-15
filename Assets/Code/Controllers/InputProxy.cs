namespace TestAssignment
{
    public sealed class InputProxy: IExecute
    {
        private IPlayerInput _vertical;
        private IPlayerInput _horizontal;
        
        public InputProxy()
        {
            _vertical = new PCInputVertical();
            _horizontal = new PCInputHorizontal();
        }

        public void Execute(float deltaTime)
        {
            _vertical.GetAxis();
            _horizontal.GetAxis();
        }

        public (IPlayerInput inputHorizontal, IPlayerInput inputVertical) GetInput()
        {
            (IPlayerInput inputHorizontal, IPlayerInput inputVertical)
                result = (_horizontal, _vertical);
            return result;
        }
    }
}