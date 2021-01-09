using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    public float DissolveAmount = 0f;
    public float DissolveSpeed = 0.5f;
    [ColorUsage(true, true)]
    public Color DissolveInColor;
    [ColorUsage(true, true)]
    public Color DissolveOutColor;
    private bool _isDissolving = false;
    private Material _mat;
    void Start()
    {
        _mat = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            _isDissolving = false;

        if (Input.GetMouseButtonUp(1))
            _isDissolving = true;

        DissolveIn();
        DissolveOut();

        _mat.SetFloat("_DissolveAmount", DissolveAmount);
    }

    private void DissolveIn()
    {
        if (!_isDissolving && DissolveAmount < 1)
        {
            _mat.SetColor("_DissolveColor", DissolveInColor);
            DissolveAmount += DissolveSpeed * Time.deltaTime;
        }
        
    }

    private void DissolveOut()
    {
        if (_isDissolving && DissolveAmount > -0.1)
        {
            _mat.SetColor("_DissolveColor", DissolveOutColor);
            DissolveAmount -= DissolveSpeed * Time.deltaTime;
        }
    }
}
