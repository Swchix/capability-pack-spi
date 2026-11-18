namespace CapabilityPack.Spi;

/// <summary>How a section was filled.</summary>
public enum SectionStatus { Live, Starting, NotYet }

/// <summary>A named group of entries. A section that is not produced is present and empty, with a reason in <c>Note</c>.</summary>
public sealed record Section(string Key, SectionStatus Status, string Note, IReadOnlyList<Entry> Entries);

/// <summary>One fact in a section. <c>Weight</c> is in [0,1].</summary>
public sealed record Entry(string Id, string Text, double Weight);

/// <summary>What may be done with a pack. Implementations should default to private.</summary>
public sealed record Listing(string Status, bool Resellable);

/// <summary>A versioned, content-hashed pack. It carries no tenant or user identity.</summary>
public sealed record PackManifest(
    string Schema, string PackId, string Agent, string Cohort, int Version,
    string ContentHash, DateTimeOffset CreatedAt, IReadOnlyList<Section> Sections, Listing Listing);
