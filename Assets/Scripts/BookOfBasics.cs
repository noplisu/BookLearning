using UnityEngine;
using System.Collections;

public class BookOfBasics : BookFinished {

    public Animator Door;

    public override void Finished()
    {
        Door.SetBool("Open", true);
    }
}
