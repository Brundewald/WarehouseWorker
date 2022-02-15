using System.Collections.Generic;

namespace TestAssignment
{
    public sealed class ControllersProxy
    {
        private List<IInitialization> _initializationControllers;
        private List<IExecute> _executeControllers;
        private List<IFixedExecute> _fixedExecuteControllers;
        private List<ICleanup> _cleanupControllers;

        public ControllersProxy()
        {
            _initializationControllers = new List<IInitialization>();
            _executeControllers = new List<IExecute>();
            _fixedExecuteControllers = new List<IFixedExecute>();
            _cleanupControllers = new List<ICleanup>();
        }

        public void Add(IController controller)
        {
            if (controller is IInitialization initializationController)
            {
                _initializationControllers.Add(initializationController);
            }

            if (controller is IExecute executeController)
            {
                _executeControllers.Add(executeController);
            }
                    
            if(controller is IFixedExecute fixedExecuteController)
            {
                _fixedExecuteControllers.Add(fixedExecuteController);
                
            }
            
            if (controller is ICleanup cleanupController)
            {
                _cleanupControllers.Add(cleanupController);
            }
        }

        public void Initialization()
        {
            foreach (var controller in _initializationControllers)
            {
                controller.Initialization();
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var controller in _executeControllers)
            {
                controller.Execute(deltaTime);
            }
        }

        public void FixedExecute(float fixedDeltaTime)
        {
            foreach (var controller in _fixedExecuteControllers)
            {
                controller.FixedExecute(fixedDeltaTime);
            }
        }

        public void Cleanup()
        {
            foreach (var controller in _cleanupControllers)
            {
                controller.Cleanup();
            }
        }
    }
}