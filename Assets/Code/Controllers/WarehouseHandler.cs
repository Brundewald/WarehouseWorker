using System.Collections.Generic;
using UnityEngine;

namespace TestAssignment
{
    public sealed class WarehouseHandler: IInitialization, ICleanup
    {
        private PlayerView _playerView;
        private readonly ProximityCheckHandler _proximityCheckHandler;
        private readonly ProductType _requiredType;
        public readonly int WarehouseCapacity;
        public readonly int ResourceQuantity;
        public List<ProductStruct> ProducedStock;



        public WarehouseHandler(PlantModel plantModel, ProximityCheckHandler proximityCheckHandler)
        {
            _playerView = proximityCheckHandler.PlayerView;
            _proximityCheckHandler = proximityCheckHandler;
            _requiredType = plantModel.RequiredProductType;
            WarehouseCapacity = plantModel.WarehouseCapacity;
            ResourceQuantity = plantModel.ResourceQuantity;
            ProducedStock = new List<ProductStruct>();
        }

        public void Initialization()
        {
            _proximityCheckHandler.OnPlantProximity += ResourceExchange;
        }

        public void Cleanup()
        {
            _proximityCheckHandler.OnPlantProximity -= ResourceExchange;
        }

        private void ResourceExchange()
        {
            var offset = new Vector3(1f, 0, 0);
            var playerStock = _playerView.PlayerStock;
            var resourceHandleCapacity = _playerView.PlayerModel.ResourceHandleCapacity;
            if (playerStock is null)
            {
                playerStock = new List<ProductStruct>();
            }
            
            var playerReadyToExchange = playerStock.Count < resourceHandleCapacity;
            var warehouseReadyToExchange = ProducedStock.Count == WarehouseCapacity;
            
            Debug.Log($"{playerReadyToExchange}, {warehouseReadyToExchange}");
            if(playerReadyToExchange && warehouseReadyToExchange)
            {
                foreach (var product in ProducedStock)
                {
                    playerStock.Add(product);
                    product.Product.transform.position = _playerView.transform.position + offset;
                }
                ProducedStock.Clear();
            }
            else
            {
                Debug.Log("Not ready for exchange");
            }
        }
    }
}