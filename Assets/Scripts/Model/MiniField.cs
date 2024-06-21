using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniField 
{
    private int _id;

    private Cell[] _cells;
    private Team _markedBy;
    private bool _isActive;

    public Cell[] Cells { get { return _cells; } }

    public int ID { get { return _id; } }
    public Team MarkedBy { 
        get { return _markedBy; } 
        set { _markedBy = value; } 
    }
    public bool IsActive { 
        get { return _isActive; } 
        set { _isActive = value; } 
    }

    public MiniField(int id)
    {
        _id = id;
        _markedBy = Team.None;
        _cells = new Cell[9];
        _isActive = true;
        for (int i = 0; i < 9; i++)
            _cells[i] = new Cell(i + 1);
    }

    public bool ShouldBeMarked()
    {
        //проверка по строкам
        for (int i = 0; i < 9; i += 3)
        {
            if (_cells[i].MarkedBy != Team.None)
            {
                if (_cells[i].MarkedBy == _cells[i + 1].MarkedBy && _cells[i + 1].MarkedBy == _cells[i + 2].MarkedBy)
                    return true;
            }
            
        }

        //проверка по столбцам
        for (int i = 0; i < 3; i++)
        {
            if (_cells[i].MarkedBy != Team.None)
            {
                if (_cells[i].MarkedBy == _cells[i + 3].MarkedBy && _cells[i + 3].MarkedBy == _cells[i + 6].MarkedBy)
                    return true;
            }
                
        }

        //диагонали
        if (_cells[4].MarkedBy != Team.None)
        {
            if (_cells[0].MarkedBy == _cells[4].MarkedBy && _cells[4].MarkedBy == _cells[8].MarkedBy)
                return true;

            if (_cells[2].MarkedBy == _cells[4].MarkedBy && _cells[4].MarkedBy == _cells[6].MarkedBy)
                return true;
        }

        return false;

    }


}
