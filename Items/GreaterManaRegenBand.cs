using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace AccessoriesImproved.Items
{
	public class GreaterManaRegenBand : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("Greater Mana Regeneration Band");
			Tooltip.SetDefault("Magic Regeneration Increased \n40 Extra Mana");
		}

		public override void SetDefaults()
		{
			item.value = Item.buyPrice(0, 5, 0, 0);
			item.rare = 5;
			item.maxStack = 1;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.manaRegenBonus += 30;
			player.statManaMax2 += 40;
		}

		public override bool CanEquipAccessory(Player player, int slot)
		{
			if (slot < 10)
			{
				int maxAccessoryIndex = 5 + player.extraAccessorySlots;
				for (int i = 3; i < 3 + maxAccessoryIndex; i++)
				{
					if (slot != i && (player.armor[i].type == ItemID.ManaRegenerationBand || player.armor[i].type == ModContent.ItemType<SuperiorManaRegenBand>() || player.armor[i].type == ModContent.ItemType<EmblemOfMana>()))
					{
						return false;
					}
				}
			}
			return true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ManaRegenerationBand);
			recipe.AddIngredient(ItemID.ManaCrystal, 4);
			recipe.AddIngredient(ItemID.ManaRegenerationPotion, 10);
			recipe.AddIngredient(ItemID.MagicPowerPotion, 6);
			recipe.AddIngredient(ItemID.CrystalBall, 2);
			recipe.AddTile(TileID.CrystalBall);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}