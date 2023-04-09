using Unity.Mathematics;

namespace Malevolent {
    public static class Float4Extensions {
        /// <summary>
        /// Sets any values of the float4
        /// </summary>
        public static float4 With(this float4 vector, float? x = null, float? y = null, float? z = null, float? w = null) {
            return new float4(x ?? vector.x, y ?? vector.y, z ?? vector.z, w ?? vector.w);
        }

        /// <summary>
        /// Adds to any values of the float4
        /// </summary>
        public static float4 Add(this float4 vector, float? x = null, float? y = null, float? z = null, float? w = null) {
            return new float4(vector.x + (x ?? 0), vector.y + (y ?? 0), vector.z + (z ?? 0), vector.w + (w ?? 0));
        }
    }
}