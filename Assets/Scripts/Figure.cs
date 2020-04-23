using UnityEngine;
using System;
using UniRx;

public class Figure : MonoBehaviour
{
    private GameData _data;

    private IDisposable disposable;

    public GameData Data
    {
        set
        {
            _data = value;
        }
    }

    private void Start()
    {
        Timer();
    }

    public void ChangeColor(Color newColor)
    {
        GetComponent<MeshRenderer>().material.color = newColor;
    }

    private Color RandColorSelection()
    {
        var color = new Color(UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f), UnityEngine.Random.Range(0, 1f));
        return color;
    }

    private void Timer()
    {
        disposable = Observable.Timer(System.TimeSpan.FromSeconds(_data.ObservableTime)).Repeat().Subscribe(_ =>
        {
            ChangeColor(RandColorSelection());
        });
    }

    private void OnDestroy()
    {
        if (disposable != null)
            disposable.Dispose();
    }

}
