using Unity.Entities;
using UnityEngine;

namespace GitAmend {
    public class PlayerSpawnerAuthoring : MonoBehaviour {
        public GameObject playerPrefab;

        public class Baker : Baker<PlayerSpawnerAuthoring> {
            public override void Bake(PlayerSpawnerAuthoring authoring) {
                var entity = GetEntity(TransformUsageFlags.Renderable);
                var prefabEntity = GetEntity(authoring.playerPrefab, TransformUsageFlags.Renderable);
                
                var data = new PlayerSpawnerComponent {
                    playerPrefab = prefabEntity
                };
                AddComponent(entity, data);
            }
        }
    }
}