public static class NPCPool
{
    private List<NPC> _npcPool = new List<NPC>();

    public static void TilføjNPCTilPool(NPC npc)
    {
        if (npc != null && !_npcPool.Contains(npc))
            _npcPool.Add(npc);
    }

    public static void RydNPCPool()
    {
        _npcPool.Clear();
    }

    public static void InitialiserNPCPool()
    {
        RydNPCPool();

        TilføjNPCTilPool(new NPC(Person.Zehra, 0, 0));
        TilføjNPCTilPool(new NPC(Person.Muhsin, 0, 0));
        TilføjNPCTilPool(new NPC(Person.Lucius, 6, 9)); // park
        TilføjNPCTilPool(new NPC(Person.Riyan, 5, 7)); // hjem
        TilføjNPCTilPool(new NPC(Person.Ivana, 5, 7)); // hjem
        TilføjNPCTilPool(new NPC(Person.Adam, 0, 0));
    }

    // TO DO: evt. flere funktioner
}
