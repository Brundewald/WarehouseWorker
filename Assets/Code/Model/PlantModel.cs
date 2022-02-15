using System;
using System.Collections.Generic;

namespace TestAssignment
{
    [Serializable]
    public sealed class PlantModel
    {
        public int ResourceQuantity;
        public int WarehouseCapacity;
        public int ProductionCapacity;
        public int ProductionTime;
        public ProductType ProduceProductType;
        public ProductType RequiredProductType;
    }
}