public static class NPCPool
{
    public static NPC Zehra = new NPC(NPCType.Zehra, 1, 1);
    public static NPC Muhsin = new NPC(NPCType.Muhsin, 3, 5); // Tek Kontor
    public static NPC Ivana = new NPC(NPCType.Ivana, 3, 5); // Hjem
    public static NPC Riyan = new NPC(NPCType.Riyan, 3, 4); // Hjem
    public static NPC Lucius = new NPC(NPCType.Lucius, 1, 1);
    public static NPC Adam = new NPC(NPCType.Adam, 1, 1);


    // TODO: evt. flere funktioner
    /*
    private static List<NPC> _npcPool = new List<NPC>();

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
     */
}
