using AccessoriesImproved.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AccessoriesImproved.Items
{
	public class AccessPlayer : ModPlayer
	{
		// Weather Toggle
		public bool ToggleRain = false;
		public bool ToggleSandstorm = false;
		public bool ToggleSnowstorm = false;

		// Other
		public bool EyeOfTheStorm = false;
		public bool EternalFlame = false;
		public bool BetsyEgg = false;
		public bool ToggleDjinnsCurse = false;

		public bool DestroyerGauntlet = false;
		public bool VortexBracers = false;


		public override void ResetEffects()
		{
			// Weather Toggle
			ToggleRain = false;
			ToggleSandstorm = false;
			ToggleSnowstorm = false;

			//Other
			EyeOfTheStorm = false;
			EternalFlame = false;
			BetsyEgg = false;
			ToggleDjinnsCurse = false;

			DestroyerGauntlet = false;
		}

		// Code Borrowed From : https://github.com/Werebearguy/AssortedCrazyThings/blob/master/AssPlayer.cs
		private void ApplyHitDebuffs(Entity victim)
		{
			if (victim is NPC)
			{
				if (EternalFlame)
				{
					((NPC)victim).AddBuff(BuffID.OnFire, 60);
					((NPC)victim).AddBuff(BuffID.CursedInferno, 60);
				}
				if (BetsyEgg)
				{
					((NPC)victim).AddBuff(BuffID.OnFire, 60);
					((NPC)victim).AddBuff(BuffID.CursedInferno, 60);
					((NPC)victim).AddBuff(BuffID.BetsysCurse, 60);
				}
				if (EyeOfTheStorm)
				{
					((NPC)victim).AddBuff(ModContent.BuffType<Electrifed>(), 60);
				}
			}
		}

		public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
		{
			ApplyHitDebuffs(target);
		}

		public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
		{
			ApplyHitDebuffs(target);
		}

		// End Code Borrowed
		public float GetWeaponKnockback(Item sItem, float KnockBack)
		{
			if (sItem.melee && DestroyerGauntlet)
			{
				KnockBack *= 2.5f;
			}
			return KnockBack;
		}
	}
}