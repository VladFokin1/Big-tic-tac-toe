using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVSComputerModel : Model
{
    AiController _aiController;
    public PlayerVSComputerModel(View view) : base(view)
    {
        _aiController = new AiController();
    }

    public override void NextTurn()
    {
        ChangeTurn();

        DoAiMove();
    }

    public override void SetCellState(int fieldID, int cellID)
    {
        if (_IsWin) return;
        if (!_board[fieldID - 1].IsActive) return;
        if (!_board[fieldID - 1].Cells[cellID - 1].IsEmpty()) return;

        DoMove(fieldID, cellID);

        if (!_IsWin)
        {
            NextTurn();
        }
    }

    protected override void DoAiMove()
    {
        Move aiMove = _aiController.GetMove(_board, _playerCurrent.Team);
       /* if (aiMove.Score == 0)
        {
            Debug.Log(aiMove.CellID);
            while (true)
            {
                int k = Random.Range(1, 9);
                if (_board[aiMove.MiniFieldID - 1].Cells[k].MarkedBy == Team.None)
                {
                    aiMove.CellID = k;
                    break;
                }
            }
            Debug.Log(aiMove.CellID);
        }*/

        DoMove(aiMove.MiniFieldID, aiMove.CellID);

        ChangeTurn();
    }



}
