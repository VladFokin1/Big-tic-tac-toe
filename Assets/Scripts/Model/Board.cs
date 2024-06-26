using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board
{
    private MiniField[] _board;

    public MiniField this[int index]
    {
        get { return _board[index]; }
        set { _board[index] = value; }
    }

    public Board()
    {
        _board = new MiniField[9];
        for (int i = 0; i < 9; i++)
            _board[i] = new MiniField(i + 1);
    }

    public bool IsTie()
    {
        for (int i = 0; i < 9; i++)
        {
            if (_board[i].MarkedBy == Team.None)
            {
                return false;
            }
        }
        return true;
    }

    public bool IsWin(Team team)
    {
        //проверка по строкам
        for (int i = 0; i < 9; i += 3)
        {
            if (_board[i].MarkedBy == team)
            {
                if (_board[i].MarkedBy == _board[i + 1].MarkedBy && _board[i + 1].MarkedBy == _board[i + 2].MarkedBy)
                    return true;
            }

        }

        //проверка по столбцам
        for (int i = 0; i < 3; i++)
        {
            if (_board[i].MarkedBy == team)
            {
                if (_board[i].MarkedBy == _board[i + 3].MarkedBy && _board[i + 3].MarkedBy == _board[i + 6].MarkedBy)
                    return true;
            }

        }

        //диагонали
        if (_board[4].MarkedBy == team)
        {
            if (_board[0].MarkedBy == _board[4].MarkedBy && _board[4].MarkedBy == _board[8].MarkedBy)
                return true;

            if (_board[2].MarkedBy == _board[4].MarkedBy && _board[4].MarkedBy == _board[6].MarkedBy)
                return true;
        }

        return false;
    }

    public List<Cell> GetFreeCells()
    {
        List<Cell> cells = new List<Cell>();
        foreach(MiniField field in _board)
        {
            if (field.MarkedBy != Team.None) continue;
            foreach(Cell cell in field.Cells)
            {
                if (cell.MarkedBy == Team.None)
                    cells.Add(cell);
            }
        }
        return cells;
    }

    public List<MiniField> GetActiveMiniFields()
    {
        List<MiniField> fields = new List<MiniField>();
        foreach (MiniField field in _board)
        {
            if (field.IsActive) fields.Add(field);
        }
        return fields;
    }
}
