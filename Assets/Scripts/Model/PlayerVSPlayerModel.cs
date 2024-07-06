using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVSPlayerModel : Model
{

    public PlayerVSPlayerModel(View view) : base(view)
    {
       
    }

    public override void SetCellState(int fieldID, int cellID)
    {
        if (_IsWin) return;
        if (!_board[fieldID - 1].IsActive) return;
        if (!_board[fieldID - 1].Cells[cellID - 1].IsEmpty()) return;

        DoMove(fieldID, cellID);
        NextTurn();

    }


    public override void NextTurn()
    {
        ChangeTurn();
    }

    protected override void DoAiMove()
    {
        return;
    }
}
