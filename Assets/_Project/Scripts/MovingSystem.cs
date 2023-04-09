using Malevolent;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

namespace GitAmend {
    [BurstCompile]
    public partial struct MovingSystem : ISystem {
        [BurstCompile]
        public void OnCreate(ref SystemState state) { }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            var deltaTime = SystemAPI.Time.DeltaTime;
            var targetPosition = DotsHelpers.GetRandomPosition();

            new MoveJob {
                deltaTime = deltaTime,
                targetPosition = targetPosition
            }.ScheduleParallel();
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state) { }
    }

    [BurstCompile]
    public partial struct MoveJob : IJobEntity {
        public float deltaTime;
        public float3 targetPosition;

        [BurstCompile]
        public void Execute(MoveToPositionAspect aspect) {
            aspect.Move(deltaTime, targetPosition);
        }
    }
}