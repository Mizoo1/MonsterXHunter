using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Monster.ECS
{
    public class EnemyComponent : Component
    {
        public TransformComponent transform;
        public Entity player;
        SpriteComponent sprite;

        Entity Shoot;
        float shootDistance = 50;
        bool moving;
        public EnemyComponent()
        {

        }
        public EnemyComponent(TransformComponent transform, Entity player)
        {

            this.transform = transform;
            this.player = player;
            transform.speed = 1;
        }
        public override void Init()
        {
            sprite = Entity.GetComponent<SpriteComponent>();

        }
        public override void Update()
        {
            float distance = (float)Math.Sqrt(Math.Pow(player.GetComponent<TransformComponent>().position.x - transform.position.x, 2) + Math.Pow(player.GetComponent<TransformComponent>().position.y - transform.position.y, 2));
            if (distance < shootDistance)
            {
                sprite.Play("Shoot");
                // Enemy is close enough to shoot
            }
            else
            {
                if (distance < shootDistance + 100)
                {
                    Move();
                }
                else
                {
                    sprite.Play("Idle");
                }


            }

        }
        public void Move()
        {

            sprite.Play("Walk");
            float distance = (float)Math.Sqrt(Math.Pow(player.GetComponent<TransformComponent>().position.x - 20 - transform.position.x, 2) + Math.Pow(player.GetComponent<TransformComponent>().position.y - 20 - transform.position.y, 2));
            float directionX = (player.GetComponent<TransformComponent>().position.x - 20 - transform.position.x) / distance;
            float directionY = (player.GetComponent<TransformComponent>().position.y - transform.position.y) / distance;
            float angle = (float)(Math.Atan2(directionY, directionX) * 180 / Math.PI);
            if (angle > 45.0f)
            {
                // Enemy is facing to the right
                sprite.flip = SDL.SDL_RendererFlip.SDL_FLIP_HORIZONTAL;
            }
            else if (angle < 45.0f)
            {
                // Enemy is facing to the left
                sprite.flip = SDL.SDL_RendererFlip.SDL_FLIP_NONE;
            }
            transform.position.x += directionX * transform.speed;
            transform.position.y += directionY * transform.speed;

        }

    }
}
