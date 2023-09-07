namespace BuberBreakfast.Contracts.Breakfast;

public record CreateBreakfastRequest(
    string Name,
    string Description,
    DateTime StartDatetime,
    DateTime EndDatetime,
    List<string> Savory,
    List<string> Sweet
);
