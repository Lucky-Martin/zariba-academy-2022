using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MoveHorizontalCommand : Command
{
    enum Direction
    {
        Right,
        Left,
        None
    }

    [SerializeField] public float speed = 1f;
    [SerializeField] public double directionChangeTimeout = 3;
    private Direction direction = Direction.None;
    private GameObject player;

    public override void Execute(GameObject player)
    {
        this.player = player;
        direction = Direction.Right;

        var task = Task.Run(async () => {
            for (; ; )
            {
                await Task.Delay((int)directionChangeTimeout * 1000);
                if (direction == Direction.Left)
                {
                    direction = Direction.Right;
                }
                else
                {
                    direction = Direction.Left;
                }
            }
        });
    }

    public void Update()
    {
        if (direction == Direction.Right)
        {
            player.transform.position = new Vector3(player.transform.position.x + speed * Time.deltaTime, player.transform.position.y);
        } 
        else if (direction == Direction.Left)
        {
            player.transform.position = new Vector3(player.transform.position.x - speed * Time.deltaTime, player.transform.position.y);
        }
    }
}
