using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Malevolent {
    public static class DotsHelpers {
        const float TwoPi = 2f * math.PI;
        
        public static EntityManager EntityManager => World.DefaultGameObjectInjectionWorld.EntityManager;
        public static Vector3 GetEntityWorldPos(Entity entity) => EntityManager.GetComponentData<LocalToWorld>(entity).Position;

        public static class Direction {
            public static float3 Up => new float3(0, 1, 0);
            public static float3 Forward => new float3(0, 0, 1);
            public static float3 Right => new float3(1, 0, 0);
            public static float3 Zero => new float3(0, 0, 0);
        }
        
        static uint GetRandomSeed() => (uint) Random.Range(0, int.MaxValue);
        public static Unity.Mathematics.Random GetRandom() => new(GetRandomSeed());
        
        public static float GetRandomFloat(float min = 0f, float max = 1f) {
            return GetRandom().NextFloat(min, max);
        }
        
        public static float GetRandomAngle() {
            return GetRandomFloat(0, TwoPi);
        }
        
        public static float4 GetRandomColor() {
            return new float4(GetRandomFloat(), GetRandomFloat(), GetRandomFloat(), 1f);
        }
        
        public static float3 GetRandomDirection() {
            var angle = GetRandomAngle();
            return new float3(math.cos(angle), 0, math.sin(angle));
        }
        
        public static float3 GetRandomPosition(float radius = 10f, float3 center = default) {
            var angle = GetRandomAngle();
            var distance = GetRandomFloat(0, radius);
            var x = math.cos(angle) * distance;
            var z = math.sin(angle) * distance;
            return new float3(x, 0, z) + center;
        }

        public static bool IsCloseTo(float3 a, float3 b, float thresholdSquared = 0.01f) {
            return math.distancesq(a, b) < thresholdSquared;
        }
    }
}