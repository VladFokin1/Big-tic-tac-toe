using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Model 
{
    protected View _view;
    protected Board _board;
    protected bool _IsWin;

    protected Player _playerX;
    protected Player _playerO;
    protected Player _playerCurrent;

    public Model(View view)
    {
        _IsWin = false;
        _view = view;
        _board = new Board();
        _playerX = new Player(Team.X);
        _playerO = new Player(Team.O);

        _playerCurrent = _playerX;
    }

    public abstract void SetCellState(int fieldID, int cellID);

    public abstract void NextTurn();

    protected abstract Player GetOpponent(Player player);

    protected abstract void ChangeActivationOnView();
}
