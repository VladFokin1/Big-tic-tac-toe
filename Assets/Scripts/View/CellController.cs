using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    [SerializeField] private Sprite _spriteX;
    [SerializeField] private Sprite _spriteO;
    [SerializeField] private int _id;


    private SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        Color old = _renderer.color;
        _renderer.color = new Color(old.r, old.g, old.b, 0);
    }

    private void OnMouseDown()
    {
        Color old = _renderer.color;
        _renderer.color = new Color(old.r, old.g, old.b, 255);
    }
}
