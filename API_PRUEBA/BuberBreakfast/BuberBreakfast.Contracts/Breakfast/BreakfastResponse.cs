namespace BuberBreakfast.Contracts.Breakfast;

public record BreakfastResponse(
    Guid Id,
    string Name,
    string Description,
    DateTime StartDatetime,
    DateTime EndDatetime,
    DateTime LastModifiedDatetime,
    List<string> Savory,
    List<string> Sweet
);
