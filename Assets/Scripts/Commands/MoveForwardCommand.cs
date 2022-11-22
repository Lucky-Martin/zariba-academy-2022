using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MoveForwardCommand : Command
{
    enum Direction
    {
        Forward,
        Backward,
        None
    }

    [SerializeField] public float speed = 1f;
    [SerializeField] public double directionChangeTimeout = 3;
    private Direction direction = Direction.None;
    private GameObject player;

    public override void Execute(GameObject player)
    {
        this.player = player;
        direction = Direction.Forward;

        var task = Task.Run(async () => {
            for (; ; )
            {
                await Task.Delay((int)directionChangeTimeout * 1000);
                if (direction == Direction.Forward)
                {
                    direction = Direction.Backward;
                }
                else
                {
                    direction = Direction.Forward;
                }
            }
        });
    }

    public void Update()
    {
        if (direction == Direction.Forward)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y + speed * Time.deltaTime);
        } 
        else if (direction == Direction.Backward)
        {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y - speed * Time.deltaTime);
        }
    }
}
