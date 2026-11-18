using CapabilityPack.Spi;

namespace StubImplementation;

// Starting points only. Each member is yours to implement.
public sealed class MySectionProvider : ISectionProvider
{
    public string Key => throw new NotImplementedException();
    public Task<Section> BuildAsync(string cohort, CancellationToken ct = default) => throw new NotImplementedException();
}

public sealed class MyPackProvider : ICapabilityPackProvider
{
    public Task<PackManifest> GetManifestAsync(string agent, string cohort, int version, CancellationToken ct = default) =>
        throw new NotImplementedException();
}

public sealed class MyHasher : IPackHasher
{
    public string Hash(string agent, string cohort, int version, IReadOnlyList<Section> sections) => throw new NotImplementedException();
}

public sealed class MyWindow : IPackWindow
{
    public IReadOnlyList<Entry> Select(PackManifest manifest, string question, int maxTokens) => throw new NotImplementedException();
}

public sealed class MyDeclarations : IEventDeclarations
{
    public EventKind KindOf(string eventType) => throw new NotImplementedException();
}

public sealed class MyProjector : IEventProjector
{
    public IReadOnlyList<ProjectionResult> Run(IEnumerable<AgentEvent> events) => throw new NotImplementedException();
}
