using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRulesModel : Model
{

    public StandardRulesModel(View view) : base(view)
    {

    }

    public override void SetCellState(int fieldID, int cellID)
    {
        if (_IsWin) return;
        if (!_board[fieldID - 1].IsActive) return;
        if (!_board[fieldID - 1].Cells[cellID - 1].IsEmpty()) return;
       

        _board[fieldID - 1].Cells[cellID - 1].MarkedBy = _playerCurrent.Team;
        _view.MarkCell(fieldID, cellID, _playerCurrent);

        if (_board[fieldID - 1].ShouldBeMarked())
        {
            _board[fieldID - 1].MarkedBy = _playerCurrent.Team;
            _board[fieldID - 1].IsActive = false;
            _view.DeactivateMiniField(fieldID);
            _view.MarkMiniField(fieldID, _playerCurrent);
        }

        if (_board.IsWin(_playerCurrent.Team))
        {
            _IsWin = true;
            _view.ShowWinScreen(_playerCurrent.Team);
        }

        SwitchMiniFieldsToNextTurn(cellID);

        NextTurn();



    }


    public override void NextTurn()
    {
        _playerCurrent = GetOpponent(_playerCurrent);
        _view.ChangeTurnText(_playerCurrent.Team);
    }


    protected override Player GetOpponent(Player player)
    {
        switch (player.Team)
        {
            case Team.X:
                return _playerO;
            case Team.O:
                return _playerX;
            default:
                return null;
        }
    }


    protected override void ActivateAllPossible()
    {
        for (int i = 0; i < 9; i++)
        {
            if (_board[i].MarkedBy == Team.None && !_board[i].IsTie())
            {
                _board[i].IsActive = true;
                _view.ActivateMiniField(i + 1);
            }
        }
    }


    protected override void SwitchMiniFieldsToNextTurn(int cellID)
    {
        for (int i = 0; i < 9; i++)
        {
            if (_board[i].ID == cellID)
            {
                if (_board[i].MarkedBy == Team.None && !_board[i].IsTie())
                {
                    _board[i].IsActive = true;
                    _view.ActivateMiniField(i + 1);
                }
                else
                {
                    ActivateAllPossible();
                    break;
                }

            }
            else
            {
                _board[i].IsActive = false;
                _view.DeactivateMiniField(i + 1);
            }

        }
    }
}
