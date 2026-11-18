namespace CapabilityPack.Spi;

/// <summary>Fills one section for a cohort.</summary>
public interface ISectionProvider
{
    string Key { get; }
    Task<Section> BuildAsync(string cohort, CancellationToken ct = default);
}

/// <summary>Deterministic hash of pack content. Must ignore timestamps and listing.</summary>
public interface IPackHasher
{
    string Hash(string agent, string cohort, int version, IReadOnlyList<Section> sections);
}

/// <summary>Assembles and validates a manifest.</summary>
public interface ICapabilityPackProvider
{
    Task<PackManifest> GetManifestAsync(string agent, string cohort, int version, CancellationToken ct = default);
}

/// <summary>Reads a manifest within a context budget.</summary>
public interface IPackWindow
{
    IReadOnlyList<Entry> Select(PackManifest manifest, string question, int maxTokens);
}
