using System;
using UnityEngine;

namespace TestAssignment
{
    public sealed class ProximityCheckHandler:IExecute
    {
        private const double MinimumDistance = 10;
        private readonly Transform _playerTransform;
        private readonly Transform _redPlantTransform;
        private readonly Transform _greenPlantTransform;
        private readonly Transform _yellowPlantTransform;
        private readonly PlayerView _playerView;
        public event Action OnPlantProximity;

        public PlayerView PlayerView => _playerView;
        
        public ProximityCheckHandler(ViewHolder view)
        {
            _playerView = view.PlayerView;
            _playerTransform = view.PlayerView.PlayerTransform;
            _redPlantTransform = view.RedPlantView.transform;
            _greenPlantTransform = view.GreenPlantView.transform;
            _yellowPlantTransform = view.YellowPlantView.transform;
        }


        public void Execute(float deltaTime)
        {
            CalculateDistance();
        }

        private void CalculateDistance()
        {
            var distanceToRedPlant = (_playerTransform.position - _redPlantTransform.position).magnitude;
            var distanceToGreenPlant = (_playerTransform.position - _greenPlantTransform.position).magnitude;
            var distanceToYellowPlant = (_playerTransform.position - _yellowPlantTransform.position).magnitude;
            CheckDistance(distanceToRedPlant, distanceToGreenPlant, distanceToYellowPlant);
        }

        private void CheckDistance(float distanceToRedPlant, float distanceToGreenPlant, float distanceToYellowPlant)
        {
            if (distanceToRedPlant < MinimumDistance) 
            {
                OnPlantProximity?.Invoke();
            }
            else if (distanceToGreenPlant < MinimumDistance)
            {
                OnPlantProximity?.Invoke();
            }
            else if (distanceToYellowPlant < MinimumDistance)
            {
                OnPlantProximity?.Invoke();
            }
        }
    }
}