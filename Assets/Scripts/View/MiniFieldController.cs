using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniFieldController : MonoBehaviour
{
    [SerializeField] private int _id;
    public int ID { get { return _id; } set { _id = value; } }
}
