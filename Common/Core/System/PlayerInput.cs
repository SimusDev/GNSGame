// Test xD
using Friflo.Engine.ECS.Systems;

namespace Common.Core.System
{
    public class PlayerInput : QuerySystem<Component.PlayerInput>
    {
        protected override void OnUpdate() {
            Query.ForEachEntity((ref playerInput, entity) => {
                playerInput.Direction.X = 1.0f;
            });
        }
    }
}