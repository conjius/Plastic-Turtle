using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private double _elapsed;
    private double _lastLap;

    public void Start()
    {
        Reset();
    }

    // Update is called once per frame
    private void Update()
    {
        _elapsed += Time.deltaTime;
    }

    public void Reset()
    {
        _elapsed = _lastLap = 0d;
    }

    public void Lap()
    {
        _lastLap = _elapsed;
    }

    public double GetLastLap()
    {
        return _lastLap;
    }

    public bool HasElapsed(double interval)
    {
        if (_elapsed - _lastLap < interval) return false;
        Lap();
        return true;
    }
}