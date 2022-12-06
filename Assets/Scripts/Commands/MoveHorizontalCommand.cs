// using System;
// using System.Threading;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System.Threading.Tasks;

// public class MoveHorizontalCommand : Command
// {
//     enum Direction
//     {
//         Right,
//         Left,
//         None
//     }

//     [SerializeField] public float speed = 1f;
//     [SerializeField] public double directionChangeTimeout = 3;
//     private Direction direction = Direction.None;
//     private BaseUnit unit;

//     public MoveHorizontalCommand(string name): base(name)
//     {

//     }

    
//     public override bool IsFinished(BaseUnit unit)
//     {
//         return true;
//     }


//     public override void Execute(BaseUnit unit)
//     {
//         this.unit = unit;
//         direction = Direction.Right;

//         var task = Task.Run(async () => {
//             for (; ; )
//             {
//                 await Task.Delay((int)directionChangeTimeout * 1000);
//                 if (direction == Direction.Left)
//                 {
//                     direction = Direction.Right;
//                 }
//                 else
//                 {
//                     direction = Direction.Left;
//                 }
//             }
//         });
//     }

//     public void Update()
//     {
//         if (direction == Direction.Right)
//         {
//             unit.transform.position = new Vector3(unit.transform.position.x + speed * Time.deltaTime, unit.transform.position.y);
//         } 
//         else if (direction == Direction.Left)
//         {
//             unit.transform.position = new Vector3(unit.transform.position.x - speed * Time.deltaTime, unit.transform.position.y);
//         }
//     }
// }
