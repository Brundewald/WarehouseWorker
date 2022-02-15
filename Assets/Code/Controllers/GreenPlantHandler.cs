using System.Threading;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace TestAssignment
{
    public sealed class GreenPlantHandler: PlantHandler
    {
        private WarehouseHandler _warehouse;
        private int _productQuantity;
        private readonly int _delay;
        private readonly ProductType _produceProductType;
        private bool _productionIsStarted;

        public GreenPlantHandler(PlantModel plantModel, ProximityCheckHandler proximityCheckHandler)
        {
            _delay = plantModel.ProductionTime;
            _warehouse = new WarehouseHandler(plantModel, proximityCheckHandler);
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
                ProductionHandler(_warehouse.ResourceQuantity, _delay);
            }
        }

        private void ProductionHandler(int resourceOnWarehouse, int productionTime)
        {
            Debug.Log("Production began");
        }
    }

}