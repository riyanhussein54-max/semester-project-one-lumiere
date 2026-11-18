public static class NPCPool
{
    public static NPC Zehra = new NPC(
        NPCType.Zehra,
        1,
        1,
        DialogPool.OpretBegivenhedZehra()
    );

    public static NPC Muhsin = new NPC(
        NPCType.Muhsin,
        3,
        5,
        DialogPool.OpretBegivenhedMuhsin()
    );

    public static NPC Ivana = new NPC(
        NPCType.Ivana,
        3,
        5,
        DialogPool.OpretBegivenhedIvana()
    );

    public static NPC Riyan = new NPC(
        NPCType.Riyan,
        3,
        4,
        DialogPool.OpretBegivenhedRiyan()
    );

    public static NPC Lucius = new NPC(
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
