using Malevolent;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Physics;
using Unity.Rendering;

namespace GitAmend {
    [BurstCompile]
    public partial struct PlayerCollisionSystem : ISystem {
        ComponentLookup<PlayerTag> playerGroup;
        ComponentLookup<URPMaterialPropertyBaseColor> colorGroup;

        [BurstCompile]
        public void OnCreate(ref SystemState state) {
            playerGroup = state.GetComponentLookup<PlayerTag>(true);
            colorGroup = state.GetComponentLookup<URPMaterialPropertyBaseColor>();
        }

        [BurstCompile]
        public void OnUpdate(ref SystemState state) {
            playerGroup.Update(ref state);
            colorGroup.Update(ref state);
            
            var simulationSingleton = SystemAPI.GetSingletonRW<SimulationSingleton>().ValueRW;
            var color = DotsHelpers.GetRandomColor();

            var job = new PlayerTriggerJob {
                PlayerGroup = playerGroup,
                ColorGroup = colorGroup,
                color = color
            };
            state.Dependency = job.Schedule(simulationSingleton, state.Dependency);
        }

        [BurstCompile]
        public void OnDestroy(ref SystemState state) { }
    }

    [BurstCompile]
    struct PlayerTriggerJob : ITriggerEventsJob {
        [ReadOnly] public ComponentLookup<PlayerTag> PlayerGroup;
        public ComponentLookup<URPMaterialPropertyBaseColor> ColorGroup;
        public float4 color;

        [BurstCompile]
        public void Execute(TriggerEvent triggerEvent) {
            bool isEntityAPerson = PlayerGroup.HasComponent(triggerEvent.EntityA);
            bool isEntityBPerson = PlayerGroup.HasComponent(triggerEvent.EntityB);
            
            if (isEntityAPerson && isEntityBPerson) {
                ChangeMaterialColor(triggerEvent.EntityB);
            }
        }
        
        void ChangeMaterialColor(Entity entity) {
            ColorGroup[entity] = new URPMaterialPropertyBaseColor {
                Value = color
            };
        }
    }
}