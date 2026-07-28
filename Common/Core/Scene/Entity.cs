using Common.Network;

namespace Common.Core.Scene
{
    public class Entity
    {
        public Entity()
        {
            _instanceId = 0;
            _nextInstanceId++;
        }

        protected MultiplayerAPI _multiplayer;

        public MultiplayerAPI Multiplayer => _multiplayer;

        static ulong _nextInstanceId = 0;
        private ulong _instanceId = 0;
        public ulong InstanceId => _instanceId;

        private Entity _parent;

        public Entity Parent => _parent;

        private List<Entity> _children = new();
        public List<Entity> Children => _children;
        public int ChildCount => _children.Count;

        private string _name = "Entity";

        private bool _isReady = false;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public void AddChild(Entity child)
        {
            if (child.Parent != null)
                return;

            child._parent = this;
            _children.Add(child);
            child.RequestReady();
        }

        public void RemoveChild(Entity child)
        {
            if (child.Parent == this)
            {
                _children.Remove(child);
            }
        }

        private void RequestReady()
        {
            if (_isReady)
                return;

            ReadyInternal();
            _isReady = true;
        }

        private void ReadyInternal()
        {
            _Ready();
        }

        public virtual void _Ready()
        {

        }

        public void TickInternal(double delta)
        {
            for (int i = 0; i < _children.Count; i++)
                _children[i].TickInternal(delta);
        }

        protected virtual void Tick(double delta)
        {

        }

        private void DestroyInternal()
        {
            _Destroy();
        }

        protected virtual void _Destroy()
        {

        }

        public void Free()
        {
            foreach (var child in _children)
                child.Free();
        }

        public void QueueFree()
        {
            foreach (var child in _children)
                child.QueueFree();

            Free(); 
        }
    }
}
