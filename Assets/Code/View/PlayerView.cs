using System.Collections.Generic;
using UnityEngine;

namespace TestAssignment
{
    public sealed class PlayerView: MonoBehaviour
    {
        [SerializeField] private Transform _playerTransform;
        [SerializeField] private PlayerModel _playerModel;
        private List<ProductStruct> _playerStock;
        public Transform PlayerTransform => _playerTransform;
        public PlayerModel PlayerModel => _playerModel;
        public List<ProductStruct> PlayerStock
        {
            get => _playerStock;
            set => _playerStock = value;
        }
    }
}