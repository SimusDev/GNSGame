using Friflo.Engine.ECS.Systems;

namespace Common.Core.System
{
    public class Movement : QuerySystem<Component.Transform2D, Component.Velocity>
    {
        protected override void OnUpdate() {
            Query.ForEachEntity((ref transform, ref velocity, entity) => {
                transform.Position.X += velocity.Linear.X;
                transform.Position.Y += velocity.Linear.Y;

                transform.Rotation += velocity.Angular;
            });
        }
    }
}