using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFieldController : MonoBehaviour
{
    [SerializeField] private int _id;
    [SerializeField] private CellController[] _cells;

    public delegate void MiniFieldCellPressedHanlder(int minifieldID, int cellID);

    private event MiniFieldCellPressedHanlder _pressedEvent;
    public MiniFieldCellPressedHanlder Pressed { get { return _pressedEvent; } set { _pressedEvent = value; } }

    public int ID { get { return _id; } set { _id = value; } }
    public CellController[] Cells => _cells;





    private void Awake()
    {
        for (int i = 0; i < _cells.Length; i++)
        {
            _cells[i].Pressed += OnCellPressed;
        }
    }

    public void OnCellPressed(int cellID)
    {

        _pressedEvent?.Invoke(_id, cellID);
    }



}
