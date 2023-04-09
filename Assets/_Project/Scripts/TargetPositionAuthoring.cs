using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

namespace GitAmend {
    public class TargetPositionAuthoring : MonoBehaviour {
        public float3 value;

        public class Baker : Baker<TargetPositionAuthoring> {
            public override void Bake(TargetPositionAuthoring authoring) {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var data = new TargetPosition {
                    value = authoring.value
                };
                AddComponent(entity, data);
            }
        }
    }
}