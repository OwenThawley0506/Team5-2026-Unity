using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class S_HideShadow : MonoBehaviour
{
    Light2D _light;
    string _name;

    float _darkVal = 0.4f;
    float _lightVal = 1.0f;

    private void Start()
    {
        _light = GetComponent<Light2D>();
        _name = gameObject.name;

        _light.enabled = true;
        _light.intensity = _darkVal;
    }

    // if player is in the room, hide the shadow
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //TODO: interpolate between dark value and light value
            //_light.intensity = Mathf.Lerp(_lightVal, _darkVal, 0);
            _light.enabled = false;
            Debug.Log($"Hiding shadow of {_name}");
        }
    }

    // when player leaves room, make shadow reappear
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //TODO: interpolate between dark value and light value
            //_light.intensity = Mathf.Lerp(_darkVal, _lightVal, 0);

            _light.enabled = true;
            Debug.Log($"showing shadow of {_name}");
        }
    }
}
