public static class NPCPool
{
    public static NPC Zehra = new(
        NPCType.Zehra,
        3,
        5,
        DialogPool.OpretBegivenhedZehra()
    );

    public static NPC Muhsin = new(
        NPCType.Muhsin,
        1,
        3,
        DialogPool.OpretBegivenhedMuhsin()
    );

    public static NPC Ivana = new(
        NPCType.Ivana,
        3,
        5,
        DialogPool.OpretBegivenhedIvana()
    );

    public static NPC Riyan = new(
        NPCType.Riyan,
        3,
        4,
        DialogPool.OpretBegivenhedRiyan()
    );

    public static NPC Lucius = new(
        NPCType.Lucius,
        1,
        1,
        DialogPool.OpretBegivenhedLucius()
    );

    public static NPC Adam = new NPC(
        NPCType.Adam,
        1,
        1,
        DialogPool.OpretBegivenhedAdam()
    );
}
