using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController
{

    private int MiniMax(Board board, int depth, Team player, int alpha, int beta, bool isMaximazingPlayer)
    {
        int score;
        if (depth == 0 || board.IsWin(player) || board.IsWin(GetOpponent(player)) || board.IsTie())
        {
            score = isMaximazingPlayer ? Evaluate(board, player) : -Evaluate(board, player);
            return score;
        }
        score = isMaximazingPlayer ? -1000 : 1000;

        bool alphaBetaCut = false;
        foreach (MiniField field in board.GetActiveMiniFields())
        {
            if (alphaBetaCut) break;
            foreach (Cell cell in field.GetFreeCells())
            {
                //запоминаем доску
                bool[] active = new bool[9];
                for (int i = 0; i < 9; i++)
                {
                    active[i] = board[i].IsActive;
                }

                //делаем ход
                cell.MarkedBy = player;
                if (field.ShouldBeMarked())
                {
                    field.MarkedBy = player;
                    field.IsActive = false;
                }
                board.SwitchMiniFieldsToNextTurn(cell.ID);

                //минимакс
                if (isMaximazingPlayer)
                {
                    score = Mathf.Max(score, MiniMax(board, depth - 1, GetOpponent(player), alpha, beta, false));
                    alpha = Mathf.Max(alpha, score);
                }
                else
                {
                    score = Mathf.Min(score, MiniMax(board, depth - 1, GetOpponent(player), alpha, beta, true));
                    beta = Mathf.Min(beta, score);
                }

                if (beta <= alpha) alphaBetaCut = true;

                //возвращаем поле в изначальное состояние
                field.MarkedBy = Team.None;
                field.IsActive = true;
                cell.MarkedBy = Team.None;
                for (int i = 0; i < 9; i++)
                {
                    board[i].IsActive = active[i]  ;
                }
            }

        }

        return score;
    }

    private Move RootMinimax(Board board, int depth, Team player)
    {
        Move bestMove = new Move();
        bestMove.Score = -1000;

        foreach (MiniField field in board.GetActiveMiniFields())
        {
            
            foreach (Cell cell in field.GetFreeCells())
            {

                //запоминаем доску
                bool[] active = new bool[9];
                for (int i = 0; i < 9; i++)
                {
                    active[i] = board[i].IsActive;
                }

                //делаем ход
                cell.MarkedBy = player;
                if (field.ShouldBeMarked())
                {
                    field.MarkedBy = player;
                    field.IsActive = false;
                }
                board.SwitchMiniFieldsToNextTurn(cell.ID);

                //минимакс
                int value = MiniMax(board, depth, player, -1000, 1000, false);

                if (value > bestMove.Score)
                {
                    bestMove.Score = value;
                    bestMove.CellID = cell.ID;
                    bestMove.MiniFieldID = field.ID;
                }

                //возвращаем поле в изначальное состояние
                field.MarkedBy = Team.None;
                field.IsActive = true;
                cell.MarkedBy = Team.None;
                for (int i = 0; i < 9; i++)
                {
                    board[i].IsActive = active[i];
                }
            }

        }

        return bestMove;
    }

    private int Evaluate(Board board, Team team)
    {
        int score = 0;
        for (int i = 0; i < 9; i++)
        {
            score += EvaluateMiniField(board[i], team);
        }
        return score;
    }

    public Move GetMove(Board board, Team player)
    {
        Move move = RootMinimax(board, 6, player);
        Debug.Log(move.Score);
        return move;
    }

    

    private int EvaluateMiniField(MiniField board, Team team)
    {

        if (board.MarkedBy == team) return 100;
        else if (board.MarkedBy == GetOpponent(team)) return -100;
        else
        {
            int score = 0;
            Team teamOpponent = GetOpponent(team);

            //добавляем себе +5 если есть ситуация, когда 2 ячейки в ряд есть и одна свободна
            score += CheckLine(board.Cells, team, team, Team.None) * 5 ;
            score += CheckLine(board.Cells, team, Team.None, team) * 5;
            score += CheckLine(board.Cells, Team.None, team, team) * 5;

            //добавляем себе -5 если есть ситуация, когда 2 ячейки в ряд есть и одна свободна
            score -= CheckLine(board.Cells, teamOpponent, teamOpponent, Team.None) * 5;
            score -= CheckLine(board.Cells, teamOpponent, Team.None, teamOpponent) * 5;
            score -= CheckLine(board.Cells, Team.None, teamOpponent, teamOpponent) * 5;

            //добавляем себе +2 если есть ситуация, когда 1 ячейка и 2 свободны
            score += CheckLine(board.Cells, team, Team.None, Team.None) * 2;
            score += CheckLine(board.Cells, Team.None, Team.None, team) * 2;
            score += CheckLine(board.Cells, Team.None, team, Team.None) * 2;

            //добавляем себе -2 если есть ситуация, когда 1 ячейка и 2 свободны
            score -= CheckLine(board.Cells, teamOpponent, Team.None, Team.None) * 2;
            score -= CheckLine(board.Cells, Team.None, Team.None, teamOpponent) * 2;
            score -= CheckLine(board.Cells, Team.None, teamOpponent, Team.None) * 2;
            return score;
        }
    }


    private int CheckLine(Cell[] field, Team team1, Team team2, Team team3)
    {
        for (int i = 0; i < 9; i += 3)
            if (field[i].MarkedBy == team1 && field[i + 1].MarkedBy == team2 && field[i + 2].MarkedBy == team3) return 1;

        for (int i = 0; i < 3; i++)
            if (field[i].MarkedBy == team1 && field[i + 3].MarkedBy == team2 && field[i + 6].MarkedBy == team3) return 1;

        if (field[0].MarkedBy == team1 && field[4].MarkedBy == team2 && field[8].MarkedBy == team3)
            return 1;
        if (field[2].MarkedBy == team1 && field[4].MarkedBy == team2 && field[6].MarkedBy == team3)
            return 1;

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



