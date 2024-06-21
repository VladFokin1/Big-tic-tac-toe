using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CellController : MonoBehaviour
{
    [SerializeField] private Sprite _spriteX;
    [SerializeField] private Sprite _spriteO;
    [SerializeField] private int _id;

    public delegate void PressedCellHandler(int cellID);
    private event PressedCellHandler _pressedEvent;

    private SpriteRenderer _renderer;

    public PressedCellHandler Pressed { get { return _pressedEvent; } set { _pressedEvent = value; } }

    public void Mark(Team team)
    {
        /*if (team == Team.X)
            _renderer.sprite = _spriteX;
        else _renderer.sprite = _spriteO;*/
        switch (team)
        {
            case Team.X: 
                _renderer.sprite = _spriteX; 
                break;
            case Team.O:
                _renderer.sprite = _spriteO;
                break;
            default:
                return;
        }

        Color old = _renderer.color;
        _renderer.color = new Color(old.r, old.g, old.b, 255);
    }

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
        Color old = _renderer.color;
        _renderer.color = new Color(old.r, old.g, old.b, 0);
    }

    private void OnMouseDown()
    {
        _pressedEvent?.Invoke(_id);
    }

    
}
