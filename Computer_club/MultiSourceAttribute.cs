using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Computer_club;

public sealed class MultiSourceAttribute : Attribute, IBindingSourceMetadata
{
    public BindingSource BindingSource { get; } = CompositeBindingSource.Create(
        new[] { BindingSource.Path, BindingSource.Query },
        nameof(MultiSourceAttribute));
}