using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour
{

    public BallMovement ballMovement;

    public ScoreController scoreController;

    void BoundFromRacket(Collision2D c)
    {
        Vector3 ballPosition = this.transform.position;

        Vector3 racketPosition =c.gameObject.transform.position;

        float racketHeight = c.collider.bounds.size.y;

        float x;
        if(c.gameObject.name == "RacketPlayer1")
        {
            x = 1;
        }
        else
        {
            x = -1;
        }

        float y =(ballPosition.y - racketPosition.y) / racketHeight;

        this.ballMovement.IncreaseHitCounter();
        this.ballMovement.MoveBall(new Vector2(x,y));
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2")
        {
            this.BoundFromRacket(collision);
        }
        else if (collision.gameObject.name == "WallLeft")
        {
            this.scoreController.GoalPlayer2();
            StartCoroutine(this.ballMovement.StartBall(true));

            Debug.Log("CollisionWith Wall left");
        }
        else if (collision.gameObject.name == "WallRight")
        {
            Debug.Log("CollisionWith Wall Right");
            this.scoreController.GoalPlayer1();
            StartCoroutine(this.ballMovement.StartBall(false));
        }

    }

}
