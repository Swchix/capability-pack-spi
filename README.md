# Capability Pack SPI

A small C# service provider interface for **capability packs**: portable, versioned, content-hashed bundles of agent configuration that an agent harness reads.

This repository is interfaces and records only. It ships no implementation, data or defaults. If you fork it, you implement the services.

## The concept

A capability pack is configuration and learned priors, not model weights. A harness reads it to decide how an agent ranks, which rules it applies and what it expects. Because a pack is a plain manifest, it can be versioned, diffed, approved and rolled back separately from the agent.

A manifest holds an identity (`packId`, `agent`, `cohort`, `version`), a `contentHash`, a list of `sections`, and a `listing` that says what may be done with it. It carries no tenant or user data.

## Expectations of an implementation

- Declare the sections your packs contain. One you cannot fill stays present and empty, with a reason.
- Hash content deterministically, excluding timestamps and listing.
- Default to private and not resellable.
- Declare every event type as projected or informational, and fail on an undeclared one.
- Never let one malformed event stop a projection run. Informational events write no rows.

## Interfaces

| Interface | Role |
|---|---|
| `ISectionProvider` | Fills one section |
| `ICapabilityPackProvider` | Assembles and validates a manifest |
| `IPackHasher` | Content hash |
| `IPackWindow` | Selects entries within a context budget |
| `IEventDeclarations` | Projected or informational, per event type |
| `IEventProjector` | Runs events through a projection |

`samples/StubImplementation` has an empty class for each one.

## Build

Requires the .NET 8 SDK.

```bash
dotnet build samples/StubImplementation
```

## Status

Early and unstable. Names may change before 1.0.

## License

Apache License 2.0. See [LICENSE](LICENSE).
