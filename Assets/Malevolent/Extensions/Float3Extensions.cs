using Unity.Mathematics;

namespace Malevolent {
    public static class Float3Extensions {
        /// <summary>
        /// Sets any values of the float3
        /// </summary>
        public static float3 With(this float3 vector, float? x = null, float? y = null, float? z = null) {
            return new float3(x ?? vector.x, y ?? vector.y, z ?? vector.z);
        }

        /// <summary>
        /// Adds to any values of the float3
        /// </summary>
        public static float3 Add(this float3 vector, float? x = null, float? y = null, float? z = null) {
            return new float3(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0));
        }
    }
}