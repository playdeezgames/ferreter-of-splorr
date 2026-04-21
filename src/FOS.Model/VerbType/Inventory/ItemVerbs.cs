namespace FOS.Model
{
    internal static class ItemVerbs
    {
        private static string GetName(string name) => $"{nameof(ItemVerbs)}.{name}";
        internal readonly static string BLUR_ITEM = GetName(nameof(BLUR_ITEM));
        internal readonly static string DROP_ITEM = GetName(nameof(DROP_ITEM));
        internal readonly static string TAKE_ITEM = GetName(nameof(TAKE_ITEM));
        internal static readonly IReadOnlyList<IVerbType> All =
            [
                new VerbType(
                    BLUR_ITEM,
                    (x,_)=>!x.IsDead() && x.HasFocusItem,
                    x=>"Inventory...",
                    (x,_)=>x.FocusItem = null),
                new VerbType(
                    DROP_ITEM,
                    (x,_)=> !x.IsDead() &&
                        x.HasMode() &&
                        x.GetMode() == Modes.INVENTORY &&
                        x.HasFocusItem,
                    x=> "Drop",
                    (x,_)=>
                    {
                        var item = x.FocusItem!;
                        x.FocusItem = null;
                        x.Inventory.RemoveItem(item);
                        x.Location.Inventory.AddItem(item);
                        x.AddMessage(Moods.NORMAL, $"You drop {item.Name}.");
                    }),
                new VerbType(
                    TAKE_ITEM,
                    (x,_)=>!x.IsDead() &&
                        x.HasMode() &&
                        x.GetMode() == Modes.GROUND_INVENTORY &&
                        x.HasFocusItem,
                    x=>"Take...",
                    (x,_)=>
                    {
                        var item = x.FocusItem!;
                        x.FocusItem = null;
                        x.Location.Inventory.RemoveItem(item);
                        x.Inventory.AddItem(item);
                        x.AddMessage(Moods.NORMAL, $"You take {item.Name}.");
                    })
            ];
    }
}
