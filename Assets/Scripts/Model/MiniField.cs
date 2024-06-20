using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniField 
{
    private int _id;

    private Cell[] _cells;

    public Cell[] Cells { get { return _cells; } }

    public int ID { get { return _id; } }

    public MiniField(int id)
    {
        _id = id;
        _cells = new Cell[9];
        for (int i = 0; i < 9; i++)
            _cells[i] = new Cell(i + 1);
    }


}
