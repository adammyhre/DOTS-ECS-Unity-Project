using Malevolent;
using Unity.Entities;

namespace GitAmend {
    public partial class PlayerSpawnerSystem : SystemBase {
        protected override void OnUpdate() {
            const int spawnAmount = 2;
            
            var query = EntityManager.CreateEntityQuery(typeof(PlayerTag));
            var playerSpawner = SystemAPI.GetSingleton<PlayerSpawnerComponent>();

            var buffer = SystemAPI.GetSingleton<BeginSimulationEntityCommandBufferSystem.Singleton>()
                .CreateCommandBuffer(World.Unmanaged);
            
            if (query.CalculateEntityCount() < spawnAmount) {
                var spawnedEntity = buffer.Instantiate(playerSpawner.playerPrefab);
                buffer.SetComponent(spawnedEntity, new Speed {
                    value = DotsHelpers.GetRandomFloat(1, 10)
                });
            }
        }
    }
}