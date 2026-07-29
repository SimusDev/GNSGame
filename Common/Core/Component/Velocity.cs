using Friflo.Engine.ECS;
using System.Numerics;

namespace Common.Core.Component
{
    public struct Velocity : IComponent
    {
        public Vector2 Linear;
        public float Angular;
    }
}