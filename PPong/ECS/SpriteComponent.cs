using SDL2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace Monster.ECS
{
	public  class SpriteComponent: Component
	{
        private TransformComponent transform;
        private IntPtr tex;
		private SDL.SDL_Rect srcRect, desRect;
		private IntPtr renderer;
        public Dictionary<string, Animation> animations = new Dictionary<string, Animation>();
        public SDL_RendererFlip flip = SDL_RendererFlip.SDL_FLIP_NONE;
        private bool animated = false;
        private int frames = 0;
        private int speed = 100;
        public int animIdex = 0;

        public SpriteComponent()
		{
			
		}
		public SpriteComponent(IntPtr src, IntPtr renderer)
		{
			this.renderer = renderer;
			setTex(src);
		}
        public SpriteComponent(IntPtr src, IntPtr renderer, bool isAnimated)
        {
            this.renderer = renderer;
            animated = true;
            Animation idle = new Animation(0, 3, 100);
            Animation walk = new Animation(1, 8, 100);
            animations.Add("Idle", idle);
            animations.Add("Walk", walk);
            Play("Idle");
            setTex(src);
        }
        public void setTex(IntPtr src)
		{
            tex = src;
        }
        public void Play(String animName)
        {
            frames = animations[animName].frame;
            animIdex = animations[animName].index;
            speed = animations[animName].speed;
        }
        public override void Init()
		{
            transform = Entity.GetComponent<TransformComponent>();
            srcRect.x= srcRect.y= 0;
            srcRect.w = transform.width;
            srcRect.h = transform.height;
        }
		public override void Update()
		{
            if (animated)
            {
                srcRect.x = srcRect.w * (int)((SDL.SDL_GetTicks() / speed) % frames);
            }
            srcRect.y = animIdex * transform.height;
            desRect.x = (int)(transform.position.x) - Game.camera.x;
            desRect.y = (int)(transform.position.y) - Game.camera.y;
            desRect.w = transform.width * transform.scale;
            desRect.h = transform.height * transform.scale;
        }
		public override void Draw()
		{
			TextureManager.Draw(tex, srcRect, desRect, renderer, flip);
		}
        public override void OnDestroy()
        {
            SDL.SDL_DestroyTexture(tex);
        }
    }
}
