using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController
{

    private Move MiniMax(Board board, int depth, Team player, int alpha, int beta, bool isMaximazingPlayer)
    {
        Move currentMove = new Move();
        if (depth == 0 || board.IsWin(player) || board.IsWin(GetOpponent(player)) || board.IsTie())
        {
            currentMove.Score = isMaximazingPlayer ? Evaluate(board, player) : -Evaluate(board, player);
            return currentMove;
        }
            

        Move bestMove = new Move();
        bestMove.Score = isMaximazingPlayer ? Int32.MinValue : Int32.MaxValue;

        bool alphaBetaCut = false;
        foreach (MiniField field in board.GetActiveMiniFields())
        {
            if (alphaBetaCut) break;
            foreach (Cell cell in field.GetFreeCells())
            {
                //запоминаем текущий ход
                currentMove.MiniFieldID = field.ID;
                currentMove.CellID = cell.ID;

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
                    currentMove.Score = Mathf.Max(currentMove.Score, MiniMax(board, depth - 1, GetOpponent(player), alpha, beta, false).Score);
                    alpha = Mathf.Max(alpha, currentMove.Score);
                }
                else
                {
                    currentMove.Score = Mathf.Min(currentMove.Score, MiniMax(board, depth - 1, GetOpponent(player), alpha, beta, true).Score);
                    beta = Mathf.Min(beta, currentMove.Score);
                }

                if (beta <= alpha) alphaBetaCut = true;

                //возвращаем поле в изначальное состо€ние
                field.MarkedBy = Team.None;
                field.IsActive = true;
                cell.MarkedBy = Team.None;

                if (isMaximazingPlayer)
                {
                    if (currentMove.Score > bestMove.Score)
                    {
                        bestMove.MiniFieldID = currentMove.MiniFieldID;
                        bestMove.CellID = currentMove.CellID;
                        bestMove.Score = currentMove.Score;
                    }
                }
                else
                {
                    if (currentMove.Score <= bestMove.Score)
                    {
                        bestMove.MiniFieldID = currentMove.MiniFieldID;
                        bestMove.CellID = currentMove.CellID;
                        bestMove.Score = currentMove.Score;
                    }
                }

            }

        }

        return bestMove;
    }

    public Move GetMove(Board  board, Team player)
    {
        Move move = MiniMax(board, 6, player, Int32.MinValue, Int32.MaxValue, true);
        return move;
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
                if (board[i].MarkedBy == team) score += 10;
                else if ((board[i].MarkedBy == teamOpponent)) score += -10;
            }
        }

        //проверка по столбцам
        for (int i = 0; i < 3; i++)
        {
            if (board[i].MarkedBy == board[i + 3].MarkedBy && board[i + 3].MarkedBy == board[i + 6].MarkedBy)
            {
                if (board[i].MarkedBy == team) score += 10;
                else if ((board[i].MarkedBy == teamOpponent)) score += -10;
            }

        }

        //диагонали
        if (board[0].MarkedBy == board[4].MarkedBy && board[4].MarkedBy == board[8].MarkedBy)
        {
            if (board[4].MarkedBy == team) score += 10;
            else if ((board[4].MarkedBy == teamOpponent)) score += -10;
        }

        if (board[2].MarkedBy == board[4].MarkedBy && board[4].MarkedBy == board[6].MarkedBy)
        {
            if (board[4].MarkedBy == team) score += 10;
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



