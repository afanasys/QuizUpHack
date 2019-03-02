using System;
using System.Threading;
using System.Threading.Tasks;

namespace QuizUpHack.Helpers
{
    public class WaitBoard
    {
        private readonly int _millisecond;
        private int _currentMillisecond;
        public WaitBoard(int millisecond)
        {
            _millisecond = millisecond;
            _currentMillisecond = 0;
        }

        public Task Wait(string message)
        {
            Console.WriteLine(message);
            var t = new Timer(TimerCallback, null, 0, 1000);
            Thread.Sleep(_millisecond);
            t.Dispose();

            Thread.Sleep(100);//Draw bug
            CommonHelpers.ClearCurrentConsoleLine();//Delete Progress Bar

            return Task.CompletedTask;
        }

        private void TimerCallback(Object o)
        {
            CommonHelpers.DrawTextProgressBar("seconds", _currentMillisecond / 1000, _millisecond / 1000);
            _currentMillisecond = _currentMillisecond + 1000;
            GC.Collect();
        }

    }
}
