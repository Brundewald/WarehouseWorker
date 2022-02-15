namespace TestAssignment
{
    public sealed class GameInitialization
    {
        public GameInitialization(ControllersProxy controllers, ViewHolder view)
        {
            var inputProxy = new InputProxy();
            var playerMovementHandler = new PlayerMovementHandler(inputProxy, view);
            var distanceCheckHandler = new ProximityCheckHandler(view);
            var productionHandler = new ProductionHandler(view, distanceCheckHandler);

            controllers.Add(inputProxy);
            controllers.Add(playerMovementHandler);
            controllers.Add(distanceCheckHandler);
            controllers.Add(productionHandler);
        }
    }
}