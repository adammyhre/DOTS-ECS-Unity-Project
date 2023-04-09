using Unity.Entities;
using UnityEngine;

namespace GitAmend {
    public class PlayerTagAuthoring : MonoBehaviour {
        public class Baker : Baker<PlayerTagAuthoring> {
            public override void Bake(PlayerTagAuthoring authoring) {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var data = new PlayerTag();
                AddComponent(entity, data);
            }
        }
    }
}