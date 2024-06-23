using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell 
{
    private int _id;
    private Team _markedBy = Team.None;
    public Team MarkedBy { get { return _markedBy; } set { _markedBy = value; } }
    public int ID { get { return _id; } }



    public Cell(int id)
    {
        _id = id;
    }

    public bool IsEmpty()
    {
        return _markedBy == Team.None;
    }

}
