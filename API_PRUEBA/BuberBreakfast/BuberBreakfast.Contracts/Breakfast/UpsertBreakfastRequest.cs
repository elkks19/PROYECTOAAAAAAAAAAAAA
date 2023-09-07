namespace BuberBreakfast.Contracts.Breakfast;

public record UpsertBreakfastRequest(
    string Name,
    string Description,
    DateTime StartDatetime,
    DateTime EndDatetime,
    List<string> Savory,
    List<string> Sweet
);
