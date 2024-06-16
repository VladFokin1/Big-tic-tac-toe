using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRulesModel : Model
{
    /*
      0 - ничего нет,
     -1 - нолик,
      1 - крестик
      двумерный массив - каждое мини-поле имеет свой номер {id}, каждая клетка в мини-поле так же имеет свой номер
    
        номера распределяются таким образом:

            1 2 3
            4 5 6
            7 8 9
    */
    private int[][] _board;

    //аналогично с доской:
    // -1 - нолик,
    //  1 - крестик
    private int _player;



    public StandardRulesModel(View view) : base(view)
    {
        _board = new int[9][];
        for (int i = 0; i < 9; i++)
            _board[i] = new int[9];
        
    }

    public void SetCellState(int fieldID, int cellID, int player)
    {
        if (_board[fieldID][cellID] != 0) return;

        _board[fieldID][cellID] = player;
    }
}
