namespace GoodManager.Domain.Attributes;

/// <summary>
/// indicates that a data-property is a filter that need,s to be filled by user.
/// you can check if the user has filled any of the filter properties by calling HasFilters Method on the model itself
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
public class FilterInputAttribute : Attribute { }