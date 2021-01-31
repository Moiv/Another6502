namespace Another6502
{
    interface IClock
    {
        void Reset();
        void Start();
        void Stop();
        void Tick();
    }
}
