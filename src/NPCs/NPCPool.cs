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
}
