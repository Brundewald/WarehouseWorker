using UnityEngine;

namespace TestAssignment
{
    public sealed class EnterPoint : MonoBehaviour
    {
        [SerializeField] private ViewHolder _viewHolder;
        private ControllersProxy _controllers;
        
        private void Awake()
        {
            _controllers = new ControllersProxy();
            var gameInitialization = new GameInitialization(_controllers, _viewHolder);
        }
        private void Start()
        {
            _controllers.Initialization();
        }

        private void Update()
        {
            _controllers.Execute(Time.deltaTime);
        }

        private void FixedUpdate()
        {
            _controllers.FixedExecute(Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            _controllers.Cleanup();
        }
    }   
}
