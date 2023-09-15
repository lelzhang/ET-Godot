using System;
using Godot;

namespace ET
{
	[ObjectSystem]
	public class AnimatorComponentAwakeSystem : AwakeSystem<AnimatorComponent>
	{
		public override void Awake(AnimatorComponent self)
		{
			self.Awake();
		}
	}

	[ObjectSystem]
	public class AnimatorComponentUpdateSystem : UpdateSystem<AnimatorComponent>
	{
		public override void Update(AnimatorComponent self)
		{
			self.Update();
		}
	}
	
	[ObjectSystem]
	public class AnimatorComponentDestroySystem : DestroySystem<AnimatorComponent>
	{
		public override void Destroy(AnimatorComponent self)
		{
			//self.animationClips = null;
			//self.Parameter = null;
			//self.Animator = null;
		}
	}

	[FriendClass(typeof(AnimatorComponent))]
	public static class AnimatorComponentSystem
	{
		public static void Awake(this AnimatorComponent self)
		{
			//Animator animator = self.Parent.GetComponent<GameObjectComponent>().GameObject.GetComponent<Animator>();

			//if (animator == null)
			//{
			//	return;
			//}

			//if (animator.runtimeAnimatorController == null)
			//{
			//	return;
			//}

			//if (animator.runtimeAnimatorController.animationClips == null)
			//{
			//	return;
			//}
			//self.Animator = animator;
			//foreach (AnimationClip animationClip in animator.runtimeAnimatorController.animationClips)
			//{
			//	self.animationClips[animationClip.name] = animationClip;
			//}
			//foreach (AnimatorControllerParameter animatorControllerParameter in animator.parameters)
			//{
			//	self.Parameter.Add(animatorControllerParameter.name);
			//}
		}

		public static void Update(this AnimatorComponent self)
		{
			if (self.isStop)
			{
				return;
			}

			if (self.MotionType == MotionType.None)
			{
				return;
			}

			try
			{
				//self.Animator.SetFloat("MotionSpeed", self.MontionSpeed);

				//self.Animator.SetTrigger(self.MotionType.ToString());

				self.MontionSpeed = 1;
				self.MotionType = MotionType.None;
			}
			catch (Exception ex)
			{
				throw new Exception($"动作播放失败: {self.MotionType}", ex);
			}
		}

		
	}
}