using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardRulesModel : Model
{
    /*
      0 - ������ ���,
     -1 - �����,
      1 - �������
      ��������� ������ - ������ ����-���� ����� ���� ����� {id}, ������ ������ � ����-���� ��� �� ����� ���� �����
    
        ������ �������������� ����� �������:

            1 2 3
            4 5 6
            7 8 9
    */
    private int[][] _board;

    //���������� � ������:
    // -1 - �����,
    //  1 - �������
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
