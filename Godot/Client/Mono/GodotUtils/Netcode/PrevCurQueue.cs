﻿namespace GodotUtils.Netcode;

using System.Collections.Generic;

public class PrevCurQueue<T>
{
    public float Progress { get; set; }

    public T Previous { get; set; }
    public T Current { get; set; }

    /*
     * Should this keep updating even after a Progress of 1.0 has been reached?
     * If this is set to true then if say a position packet is not received in
     * time, then the player will continue moving in the last known direction.
     * If this is set to false then the player will just come to a direct halt
     * when a Progress value of 1.0 is reached.
     */
    public bool KeepUpdating { get; set; }

    readonly List<T> data = new();
    int interval;

    public PrevCurQueue(int interval)
    {
        this.interval = interval;
        Current = default(T);
    }

    public void Add(T data)
    {
        Progress = 0; // reset progress as this is new incoming data
        this.data.Add(data);

        if (this.data.Count > 2) // only keep track of previous and current
            this.data.RemoveAt(0);

        if (this.data.Count == 1)
        {
            Previous = this.data[0];
        }

        if (this.data.Count == 2)
        {
            Previous = this.data[0];
            Current = this.data[1];
        }
    }

    /*
     * There are 60 Frames in 1 Second (60 FPS)
     * 
     * If we set Interval to 1000 then UpdateProgress will have to be
     * called 60 times for Progress to reach a value of 1.0
     * That is it will happen in 1 second
     * 
     * If we set Interval to 2000 then UpdateProgress will have to be
     * called 120 times for Progress to reach a value of 1.0
     * That is it will happen in 2 seconds
     * 
     * Interval is the update interval. So if the server and client are
     * both sending say position updates every 50ms, then the Interval
     * should be set to 50ms
     */
    public void UpdateProgress(double delta)
    {
        if (Progress < 1.0)
            AddToProgress(delta);
        else
        {
            if (KeepUpdating)
                AddToProgress(delta);
        }
    }

    void AddToProgress(double delta) =>
        Progress += (float)delta * (1000f / interval);
}
