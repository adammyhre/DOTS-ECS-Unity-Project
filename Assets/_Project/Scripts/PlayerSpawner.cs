using Unity.Entities;

namespace GitAmend {
    public struct PlayerSpawnerComponent : IComponentData {
        public Entity playerPrefab;
    }
}