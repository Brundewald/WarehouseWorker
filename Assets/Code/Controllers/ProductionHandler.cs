using System.Collections.Generic;

namespace TestAssignment
{
    public sealed class ProductionHandler: IInitialization, ICleanup, IExecute
    {
        private readonly List<PlantHandler> _plants;
        
        public ProductionHandler(ViewHolder view, ProximityCheckHandler proximityCheckHandler)
        {
            _plants = new List<PlantHandler>
            {
                new RedPlantHandler(view.RedPlantView, proximityCheckHandler),
                new GreenPlantHandler(view.GreenPlantView.PlantModel, proximityCheckHandler)
            };
        }

        public void Initialization()
        {
            foreach (var plant in _plants)
            {
                plant.Initialization();
            }
        }

        public void Cleanup()
        {
            foreach (var plant in _plants)
            {
                plant.Cleanup();
            }
        }

        public void Execute(float deltaTime)
        {
            foreach (var plant in _plants)
            {
                plant.Produce();
            }
        }
    }
}