

#region Enuns
public enum Resource
{
    water,
    energy
}

public enum CellElementCategory
{
    air,
    mainGround,
    secondaryGround,
    underground
}

public enum ConditionToPlaceElement
{
    none,
    hasRootOnTile,
    hasOnlyNeighborRoot,
    mainGroundFree,
    secondaryGroundFree,
    airFree,
    undergroundFree,
    hasHumanBuilding
}
#endregion

#region Structs

#endregion