namespace CapabilityPack.Spi;

/// <summary>A named group of entries inside a pack.</summary>
public sealed record Section(string Key, string Status, string Note, IReadOnlyList<Entry> Entries);

/// <summary>One fact in a section.</summary>
public sealed record Entry(string Id, string Text, double Weight);

/// <summary>A versioned, content-hashed pack. It carries no tenant or user identity.</summary>
public sealed record PackManifest(string PackId, string Agent, string Cohort, int Version, string ContentHash, IReadOnlyList<Section> Sections);

/// <summary>Fills one section for a cohort.</summary>
public interface ISectionProvider
{
    string Key { get; }
    Task<Section> BuildAsync(string cohort, CancellationToken ct = default);
}

/// <summary>Assembles a manifest from section providers.</summary>
public interface ICapabilityPackProvider
{
    Task<PackManifest> GetManifestAsync(string agent, string cohort, int version, CancellationToken ct = default);
}
