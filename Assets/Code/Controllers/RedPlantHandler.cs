using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace TestAssignment
{
    public sealed class RedPlantHandler: PlantHandler
    {
        private const string ParentName = "Product";
        private readonly WarehouseHandler _warehouse;
        private readonly PlantModel _plantModel;
        private readonly ProductObjectBuilder _productBuilder;
        private readonly GameObject _parent;
        private readonly Transform _warehouseTransform;
        private int _productQuantity;
        private bool _productionIsStarted;

        public RedPlantHandler(PlantView plantView, ProximityCheckHandler proximityCheckHandler)
        {
            _plantModel = plantView.PlantModel;
            _warehouse = new WarehouseHandler(_plantModel, proximityCheckHandler);
            _productBuilder = new ProductObjectBuilder();
            _parent = new GameObject(ParentName);
            _warehouseTransform = plantView.WarehouseStockTransform;
        }


        public override void Initialization()
        {
            _warehouse.Initialization();
        }
        public override void Cleanup()
        {
            _warehouse.Cleanup();
        }
        
        public override void Produce()
        {
            if (!_productionIsStarted)
            {
                _productionIsStarted = true;
                AsyncProductProduction();
            }
        }

        private async void AsyncProductProduction()
        { 
            var capacity = _warehouse.WarehouseCapacity;
            
            for (var i = 0; capacity > i; i++)
            {
                await Task.Delay(_plantModel.ProductionTime);
                NewProductGeneration(capacity);
            }
        }

        private void NewProductGeneration(int capacity)
        {
            var newProduct = new ProductStruct();
            var product = _productBuilder.CreateProduct(_parent.transform);
            newProduct.Product = product;
            newProduct.ProductType = ProductType.Red;
            _warehouse.ProducedStock.Add(newProduct);
            PlaceOnWarehouse(product.transform);
            _productQuantity++;
            Debug.Log($"{capacity} {_productQuantity}");
        }

        private void PlaceOnWarehouse(Transform product)
        {
            var offset = new Vector3(0f, 1f, 0f);
            product.transform.position = _warehouseTransform.position + offset;
        }
    }
}