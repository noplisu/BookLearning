using UnityEngine;
using System.Collections;

public class BookController : MonoBehaviour {

    public Animator cover;
    public GameObject pages;
    BookFinished theEnd;

    bool finished = false;
    bool closed = true;
    int page = 0;
    private Animator[] pagesAnimators;
	// Use this for initialization
	void Start () {
        theEnd = GetComponent<BookFinished>();
        pagesAnimators = pages.GetComponentsInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0)){
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10f))
            {
                string interactor = hit.collider.name;
                if (closed && interactor == "CoverTop")
                    OpenCover();
                else if (!closed && interactor == "CoverTop")
                {
                    if (page == 0)
                        CloseCover();
                    else
                        FlipRight();
                }
                else if (!closed && interactor == "CoverBottom")
                {
                    if (page < pagesAnimators.Length)
                        FlipLeft();
                    else if (!finished)
                    {
                        FinishBook();
                    }
                }
            }
        }
	}

    void OpenCover() 
    {
        cover.SetBool("Open", true);
        closed= false;
    }

    void CloseCover()
    {
        cover.SetBool("Open", false);
        closed = true;
    }

    void FlipLeft()
    {
        pagesAnimators[page].SetBool("Open", true);
        page++;
    }

    void FlipRight()
    {
        page--;
        pagesAnimators[page].SetBool("Open", false);
    }

    void FinishBook()
    {
        finished = true;
        theEnd.Finished();
    }
}
