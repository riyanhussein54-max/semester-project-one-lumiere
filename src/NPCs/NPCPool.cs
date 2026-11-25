public static class NPCPool
{
    public static NPC Zehra = new(
        person: NPCType.Zehra,
        række: 3,
        søjle: 5,
        begivenhed: DialogPool.OpretBegivenhedZehra()
    );

    public static NPC Muhsin = new(
        person: NPCType.Muhsin,
        række: 1,
        søjle: 3,
        begivenhed: DialogPool.OpretBegivenhedMuhsin()
    );

    public static NPC Ivana = new(
        person: NPCType.Ivana,
        række: 3,
        søjle: 5,
        begivenhed: DialogPool.OpretBegivenhedIvana()
    );

    public static NPC Riyan = new(
        person: NPCType.Riyan,
        række: 3,
        søjle: 4,
        begivenhed: DialogPool.OpretBegivenhedRiyan()
    );

    public static NPC Lucius = new(
        person: NPCType.Lucius,
        række: 1,
        søjle: 1,
        begivenhed: DialogPool.OpretBegivenhedLucius()
    );

    public static NPC Adam = new NPC(
        person: NPCType.Adam,
        række: 1,
        søjle: 1,
        begivenhed: DialogPool.OpretBegivenhedAdam()
    );
}
