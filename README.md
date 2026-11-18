# Capability Pack SPI

A C# skeleton for **capability packs**: versioned, content-hashed bundles of agent configuration that an agent harness reads.

Overview: [swchix.com/knowledge/capability-pack-spi](https://swchix.com/knowledge/capability-pack-spi)

This repository holds interfaces and records only. It has no implementation, data or defaults. Fork it and write the services.

## Contents

| Type | Role |
|---|---|
| `PackManifest`, `Section`, `Entry` | The shape of a pack |
| `ISectionProvider` | Fills one section |
| `ICapabilityPackProvider` | Assembles a manifest |

## Build

Requires the .NET 8 SDK.

```bash
dotnet build src/CapabilityPack.Spi
```

## License

Apache License 2.0. See [LICENSE](LICENSE).
