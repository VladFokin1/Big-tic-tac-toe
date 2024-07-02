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

        Move aiMove = _aiController.GetMove(_board, _playerCurrent.Team);

        DoMove(aiMove.MiniFieldID, aiMove.CellID);

        ChangeTurn();
    }

    public override void SetCellState(int fieldID, int cellID)
    {
        if (_IsWin) return;

        DoMove(fieldID, cellID);

        if (!_IsWin)
        {
            NextTurn();
        }
        
    }
}
