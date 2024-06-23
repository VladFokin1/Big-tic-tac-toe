using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player 
{

    private readonly Team _team;
    public Team Team { get { return _team; } }

    public Player(Team team)
    {
        this._team = team;
    }

    public bool IsWin(MiniField[] board)
    {
        //проверка по строкам
        for (int i = 0; i < 9; i += 3)
        {
            if (board[i].MarkedBy == _team)
            {
                if (board[i].MarkedBy == board[i + 1].MarkedBy && board[i + 1].MarkedBy == board[i + 2].MarkedBy)
                    return true;
            }

        }

        //проверка по столбцам
        for (int i = 0; i < 3; i++)
        {
            if (board[i].MarkedBy == _team)
            {
                if (board[i].MarkedBy == board[i + 3].MarkedBy && board[i + 3].MarkedBy == board[i + 6].MarkedBy)
                    return true;
            }

        }

        //диагонали
        if (board[4].MarkedBy == _team)
        {
            if (board[0].MarkedBy == board[4].MarkedBy && board[4].MarkedBy == board[8].MarkedBy)
                return true;

            if (board[2].MarkedBy == board[4].MarkedBy && board[4].MarkedBy == board[6].MarkedBy)
                return true;
        }

        return false;
    }
}

