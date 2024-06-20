using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRulesModel : Model
{
   
    private MiniField[] _board;

    private Player _playerX;
    private Player _playerO;
    private Player _playerCurrent;



    public StandardRulesModel(View view) : base(view)
    {
        _board = new MiniField[9];
        for (int i = 0; i < 9; i++)
            _board[i] = new MiniField(i + 1);
        _playerX = new Player(Team.X);
        _playerO = new Player(Team.O);

        _playerCurrent = _playerX;
    }

    public override void SetCellState(int fieldID, int cellID)
    {
        if (!_board[fieldID - 1].Cells[cellID - 1].IsEmpty()) return;

        _board[fieldID - 1].Cells[cellID - 1].MarkedBy = _playerCurrent.Team;
        _view.MarkCell(fieldID, cellID, _playerCurrent);
        NextTurn();
    }

    private void NextTurn()
    {
        _playerCurrent = GetOpponent(_playerCurrent);
    }

    private Player GetOpponent(Player player)
    {
        if (player.Team == Team.X) return _playerO;
        else return _playerX;
    }
}
