using System;

public delegate void LerpInformationEventHandler<T>(object sender, LerpInformationEventArgs<T> args);
public class LerpInformationEventArgs<T> : EventArgs
{
    public LerpInformation<T> LerpInformation { get; }
    public LerpInformationEventArgs(LerpInformation<T> lerpInformation)
    {
        LerpInformation = lerpInformation;
    }
}

public class LerpInformation<T>
{
    public T Source { get; }
    public T Destination { get; }

    public float Duration { get; }
    public float TimeLeft { get; private set; }
    public float LerpFactor => 1 - TimeLeft / Duration;

    public event LerpInformationEventHandler<T> Started; 
    public event LerpInformationEventHandler<T> Finished; 

    private readonly Func<T, T, float, T> lerpHandler;

    public LerpInformation(T source, T destination, float duration, Func<T, T, float, T> lerpHandler, 
        LerpInformationEventHandler<T> startedEventHandler = null, LerpInformationEventHandler<T> finishedEventHandler = null)
    {
        Source = source;    
        Destination = destination;
        Duration = duration;
        TimeLeft = duration;

        Started = startedEventHandler;
        Finished = finishedEventHandler;

        this.lerpHandler = lerpHandler;
    }

    /// <summary>
    /// Continue the lerp by one frame.
    /// </summary>
    /// <param name="deltaTime"></param>
    /// <returns>The value of the lerp after this frame step.</returns>
    public T Step(float deltaTime)
    {
        // First time we ever run Step
        if (TimeLeft == 0)
        {
            Started?.Invoke(this, new LerpInformationEventArgs<T>(this));
        }

        // If the lerp has finished
        if (TimeLeft <= 0)
        {
            Finished?.Invoke(this, new LerpInformationEventArgs<T>(this));
            return Destination;
        }

        T result = lerpHandler(Source, Destination, LerpFactor);
        TimeLeft -= deltaTime;

        return result;
    }
}