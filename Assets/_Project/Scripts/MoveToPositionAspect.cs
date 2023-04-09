using Malevolent;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

namespace GitAmend {
    public readonly partial struct MoveToPositionAspect : IAspect {
        // readonly Entity entity; // autopopulated??

        readonly RefRW<LocalTransform> localTransform;
        readonly RefRO<Speed> speed;
        readonly RefRW<TargetPosition> targetPosition;

        public MoveToPositionAspect(RefRW<LocalTransform> localTransform, RefRO<Speed> speed, RefRW<TargetPosition> targetPosition) {
            this.localTransform = localTransform;
            this.speed = speed;
            this.targetPosition = targetPosition;
        }

        public void Move(float deltaTime, float3 newTargetPosition) {
            var direction = math.normalize(targetPosition.ValueRW.value - localTransform.ValueRW.Position);
            localTransform.ValueRW.Position += direction * deltaTime * speed.ValueRO.value;
            
            if (DotsHelpers.IsCloseTo(localTransform.ValueRW.Position, targetPosition.ValueRW.value, 0.5f)) {
                targetPosition.ValueRW.value = newTargetPosition;
            }
        }
    }
}