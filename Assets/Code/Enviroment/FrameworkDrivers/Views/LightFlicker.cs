using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour, ILightFlicker
{
    [SerializeField]
    private float maximumDim;
    [SerializeField]
    private float maximumBoost;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float strength;
    [SerializeField]
    private bool isflickerEnabled;

    private Light _lightSource;
    private float _initialIntensity;

    // Give default vaules on Editor
    public void Reset()
    {
        maximumDim = 0.2f;
        maximumBoost = 0.2f;
        speed = 0.1f;
        strength = 250;
        isflickerEnabled = true;
    }

    private void Start()
    {
        _lightSource = GetComponent<Light>();
        _initialIntensity = _lightSource.intensity;
        if (isflickerEnabled) startFlicker();
    }

    public void startFlicker()
    {
        isflickerEnabled = true;
        StartCoroutine(FlickerCoroutine());
    }

    public void stopFlicker()
    {
        isflickerEnabled = false;
    }

    private IEnumerator FlickerCoroutine()
    {
        while (isflickerEnabled)
        {
            _lightSource.intensity = Mathf.Lerp(
                _lightSource.intensity,
                Random.Range(_initialIntensity - maximumDim, _initialIntensity + maximumBoost),
                strength * Time.deltaTime
            );
            yield return new WaitForSeconds(speed);
        }
    }

}



