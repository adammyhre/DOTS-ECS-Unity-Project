using Unity.Entities;
using UnityEngine;

namespace GitAmend {
    public class SpeedAuthoring : MonoBehaviour {
        public float value;

        public class Baker : Baker<SpeedAuthoring> {
            public override void Bake(SpeedAuthoring authoring) {
                var entity = GetEntity(TransformUsageFlags.Dynamic);
                var data = new Speed {
                    value = authoring.value
                };
                AddComponent(entity, data);
            }
        }
    }
}