using System;
namespace Server.Items
{
    public class ViewEffectItem : Item
    {
	private int m_ItemID = 0;
	private int m_Duration = 30;
	private int m_Speed = 10;
	private int m_Hue = 0;
	private int m_RenderMode = 0;
	private int m_Height = 0;
	private Point3D p;

	[CommandProperty(AccessLevel.GameMaster)]
	public int itemID
	{
	    get { return m_ItemID; }
	    set { m_ItemID = value; }
	}
	[CommandProperty(AccessLevel.GameMaster)]
	public int Duration
	{
	    get { return m_Duration; }
	    set { m_Duration = value; }
	}
	[CommandProperty(AccessLevel.GameMaster)]
	public int Speed
	{
	    get { return m_Speed; }
	    set { m_Speed = value; }
	}
	[CommandProperty(AccessLevel.GameMaster)]
	public int effectHue
	{
	    get { return m_Hue; }
	    set { m_Hue = value; }
	}
	[CommandProperty(AccessLevel.GameMaster)]
	public int RenderMode
	{
	    get { return m_RenderMode; }
	    set { m_RenderMode = value; }
	}
	[CommandProperty(AccessLevel.GameMaster)]
	public int Height
	{
	    get { return m_Height; }
	    set { m_Height = value; }
	}


        [Constructable]
        public ViewEffectItem()
            : base(0x1BC3)
        {
	    Movable = false;
            Weight = 1.0;
	    Visible = false;
	}

        public ViewEffectItem (Serial serial)
            : base(serial)
        {
        }
	

	public override void OnDoubleClick(Mobile from)
	{	
	    p = Location;
	    p.Z += m_Height;
            Effects.SendLocationEffect(EffectItem.Create(p, Map, EffectItem.DefaultDuration), Map, m_ItemID, m_Duration, m_Speed, m_Hue, m_RenderMode);
	}

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();

        }
	
    }
}