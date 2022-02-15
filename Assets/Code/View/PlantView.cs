using UnityEngine;

namespace TestAssignment
{
    public sealed class PlantView: MonoBehaviour
    {
        [SerializeField] private PlantModel _plantModel;
        [SerializeField] private Transform _warehoseStockTransform;
        [SerializeField] private Transform _warehouseResourceTransform;
        public PlantModel PlantModel => _plantModel;
        public Transform WarehouseStockTransform => _warehoseStockTransform;
        public Transform WarehouseResourceTransform => _warehouseResourceTransform;
    }
}