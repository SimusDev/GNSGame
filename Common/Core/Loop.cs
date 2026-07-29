
using System.Diagnostics;

namespace Common.Core
{
    public class Loop
    {
        private bool _isRunning;
        public bool IsRunning => _isRunning;

        private Stopwatch _stopwatch = new();

        private float _deltaTime = 0;

        private Action<float> _tickFunc;

        public Loop(Action<float> tickFunc)
        {
            _tickFunc = tickFunc;
        }

        public void Start()
        {
            if (_isRunning) return;

            _isRunning = true;

            double lastTime = _stopwatch.Elapsed.TotalSeconds;
            
            while (_isRunning)
            {
                double currentTime = _stopwatch.Elapsed.TotalSeconds;
                _deltaTime = (float)(currentTime - lastTime);
                lastTime = currentTime;

                _tickFunc.Invoke(_deltaTime);
            }

            Shutdown();
        }

        private void Shutdown()
        {
            _stopwatch.Stop();
        }

        public void Stop()
        {
            if (_isRunning)
                _isRunning = false;
        }
    }
}
