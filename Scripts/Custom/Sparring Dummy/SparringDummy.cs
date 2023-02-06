using System;
using Server;
using Server.Mobiles;

namespace Server.Items
{
	[Flipable(0x1070, 0x1074)]
	public class SparringDummyEast : DamageableItem
	{
		[Constructable]
		public SparringDummyEast()
			: base(4212, 4212, 7604)
		{
			Name = "Sparring Dummy";
			// Level = ItemLevel.Hard;
			Hits = HitsMax = (int)0x7FFFFFFF;
		}

		public override int Damage(int amount, Mobile from)
		{
			if (!CanDamage && from.Combatant == this)
			{
				from.Combatant = null;
				return 0;
			}

			if (amount > 0)
				RegisterDamage(from, amount);

			if (HitEffect > 0)
				Effects.SendLocationEffect(Location, Map, HitEffect, 10, 5);

			SendDamagePacket(from, amount);

			OnDamage(amount, from, Hits < 0);

			return amount;
		}

		public override bool CheckHit(Mobile m)
		{
			BaseWeapon atkWeapon = m.Weapon as BaseWeapon;
			Skill atkSkill = m.Skills[atkWeapon.Skill];

			if (atkWeapon.WeaponAttributes.MageWeapon > 0 && m.Skills[SkillName.Magery].Value > atkSkill.Value)
				m.CheckSkill(SkillName.Magery, 50);

			m.CheckSkill(atkSkill.SkillName, 50);

			return true;
		}

		public SparringDummyEast(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); //version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}

	[Flipable(0x1070, 0x1074)]
	public class SparringDummySouth : DamageableItem
	{
		[Constructable]
		public SparringDummySouth()
			: base(4208, 4208, 7604)
		{
			Name = "Sparring Dummy";
			// Level = ItemLevel.Hard;
			Hits = HitsMax = (int)0x7FFFFFFF;
		}

		public override int Damage(int amount, Mobile from)
		{
			if (!CanDamage && from.Combatant == this)
			{
				from.Combatant = null;
				return 0;
			}

			if (amount > 0)
				RegisterDamage(from, amount);

			if (HitEffect > 0)
				Effects.SendLocationEffect(Location, Map, HitEffect, 10, 5);

			SendDamagePacket(from, amount);

			OnDamage(amount, from, Hits < 0);

			return amount;
		}

		public override bool CheckHit(Mobile m)
		{
			BaseWeapon atkWeapon = m.Weapon as BaseWeapon;
			Skill atkSkill = m.Skills[atkWeapon.Skill];

			if (atkWeapon.WeaponAttributes.MageWeapon > 0 && m.Skills[SkillName.Magery].Value > atkSkill.Value)
				m.CheckSkill(SkillName.Magery, 50);

			m.CheckSkill(atkSkill.SkillName, 50);

			return true;
		}
		
		public SparringDummySouth(Serial serial)
			: base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int)0); //version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}