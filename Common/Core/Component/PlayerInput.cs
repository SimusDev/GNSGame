using Friflo.Engine.ECS;
using System.Numerics;

namespace Common.Core.Component
{
    public struct PlayerInput : IComponent
    {
        public Vector2 Direction;
    }
}