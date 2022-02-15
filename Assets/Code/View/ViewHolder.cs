using UnityEngine;

namespace TestAssignment
{
    public sealed class ViewHolder: MonoBehaviour
    {
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private PlantView _redPlantView;
        [SerializeField] private PlantView _greenPlantView;
        [SerializeField] private PlantView _yellowPlantView;

        public PlayerView PlayerView => _playerView;
        public PlantView RedPlantView => _redPlantView;
        public PlantView GreenPlantView => _greenPlantView;
        public PlantView YellowPlantView => _yellowPlantView;
    }
}