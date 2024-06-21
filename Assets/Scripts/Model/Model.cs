using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Model 
{
    protected View _view;
    protected MiniField[] _board;

    protected Player _playerX;
    protected Player _playerO;
    protected Player _playerCurrent;

    public Model(View view)
    {
        _view = view;
        _board = new MiniField[9];
        for (int i = 0; i < 9; i++)
            _board[i] = new MiniField(i + 1);
        _playerX = new Player(Team.X);
        _playerO = new Player(Team.O);

        _playerCurrent = _playerX;
    }

    public abstract void SetCellState(int fieldID, int cellID);

    public abstract void NextTurn();

    protected abstract Player GetOpponent(Player player);

    protected abstract void ActivateAllPossible();

    protected abstract void SwitchMiniFieldsToNextTurn(int cellID);
}
