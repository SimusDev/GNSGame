using Friflo.Engine.ECS;
using System.Numerics;

namespace Common.Core.Component
{
    public struct Transform2D : IComponent
    {
        public Vector2 Position;
        public float Rotation;
        public Vector2 Scale;
    }
}
