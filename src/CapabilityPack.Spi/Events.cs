namespace CapabilityPack.Spi;

/// <summary>Every event type is declared one of these. There is no default.</summary>
public enum EventKind { Projected, Informational }

public sealed record AgentEvent(string Id, string Type, string? Payload);

public enum ProjectionOutcome { Projected, Skipped, Rejected }

public sealed record ProjectionResult(string EventId, ProjectionOutcome Outcome, string? Reason);

/// <summary>Declares each event type. Implementations should throw for an undeclared type.</summary>
public interface IEventDeclarations
{
    EventKind KindOf(string eventType);
}

/// <summary>
/// Implementations should not let a malformed event stop the run, and should write no projection rows for informational events.
/// </summary>
public interface IEventProjector
{
    IReadOnlyList<ProjectionResult> Run(IEnumerable<AgentEvent> events);
}
