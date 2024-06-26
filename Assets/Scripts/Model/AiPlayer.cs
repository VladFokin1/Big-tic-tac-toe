using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiPlayer : Player
{
    public AiPlayer(Team team) : base(team)
    {
    }

    private int MiniMax(Board board, int depth, Player player, bool isMaximazingPlayer)
    {
        if (depth == 0 || board.IsWin(_team) || board.IsWin(GetOpponent(_team)) || board.IsTie())
            return isMaximazingPlayer ? Evaluate(board, player.Team) : Evaluate(board, GetOpponent(player.Team));

        foreach (MiniField field in board.GetActiveMiniFields())
        {
            foreach (Cell cell in field.GetFreeCells())
            {

            }

        }
    }

    private int Evaluate(Board board, Team team)
    {
        int score = 0;
        for (int i = 0; i < 9; i++)
        {
            score += EvaluateMiniField(board[i].Cells, team);
        }
        return score;
    }

    private int EvaluateMiniField(Cell[] board, Team team)
    {
        int score = 0;
        Team teamOpponent = GetOpponent(team);

        //добавл€ем себе +5 если есть ситуаци€, когда 2 €чейки в р€д есть и одна свободна
        score += CheckLine(board, team, team, Team.None);
        score += CheckLine(board, team, Team.None, team);
        score += CheckLine(board, Team.None, team, team);

        //добавл€ем себе -5 если есть ситуаци€, когда 2 €чейки в р€д есть и одна свободна
        score -= CheckLine(board, teamOpponent, teamOpponent, Team.None);
        score -= CheckLine(board, teamOpponent, Team.None, teamOpponent);
        score -= CheckLine(board, Team.None, teamOpponent, teamOpponent);


        //проверка по строкам
        for (int i = 0; i < 9; i += 3)
        {
            if (board[i].MarkedBy == board[i + 1].MarkedBy && board[i + 1].MarkedBy == board[i + 2].MarkedBy)
            {
                if (board[i].MarkedBy == _team) score += 10;
                else if ((board[i].MarkedBy == teamOpponent)) score += -10;
            }
        }

        //проверка по столбцам
        for (int i = 0; i < 3; i++)
        {
            if (board[i].MarkedBy == board[i + 3].MarkedBy && board[i + 3].MarkedBy == board[i + 6].MarkedBy)
            {
                if (board[i].MarkedBy == _team) score += 10;
                else if ((board[i].MarkedBy == teamOpponent)) score += -10;
            }

        }

        //диагонали
        if (board[0].MarkedBy == board[4].MarkedBy && board[4].MarkedBy == board[8].MarkedBy)
        {
            if (board[4].MarkedBy == _team) score += 10;
            else if ((board[4].MarkedBy == teamOpponent)) score += -10;
        }

        if (board[2].MarkedBy == board[4].MarkedBy && board[4].MarkedBy == board[6].MarkedBy)
        {
            if (board[4].MarkedBy == _team) score += 10;
            else if ((board[4].MarkedBy == teamOpponent)) score += -10;
        }

        return score;
    }


    private int CheckLine(Cell[] field, Team team1, Team team2, Team team3)
    {
        for (int i = 0; i < 9; i += 3)
            if (field[i].MarkedBy == team1 && field[i + 1].MarkedBy == team2 && field[i + 2].MarkedBy == team3) return 5;

        for (int i = 0; i < 3; i++)
            if (field[i].MarkedBy == team1 && field[i + 3].MarkedBy == team2 && field[i + 6].MarkedBy == team3) return 5;

        if (field[0].MarkedBy == team1 && field[4].MarkedBy == team2 && field[8].MarkedBy == team3)
            return 5;
        if (field[2].MarkedBy == team1 && field[4].MarkedBy == team2 && field[6].MarkedBy == team3)
            return 5;

        return 0;
    }


    private Team GetOpponent(Team team)
    {
        switch (team)
        {
            case Team.X:
                return Team.O;
            case Team.O:
                return Team.X;
            default:
                return Team.None;
        }
    }
}



