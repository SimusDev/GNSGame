using Common.Core.Component;
using Friflo.Engine.ECS;

namespace Common.Core.System
{
    class MoveSystem : QuerySystem<Position, Velocity>
    {
        protected override void OnUpdate() {
            Query.ForEachEntity((ref Position position, ref Velocity velocity, Entity entity) => {
                position.value += velocity.value;
            });
        }
    }
}