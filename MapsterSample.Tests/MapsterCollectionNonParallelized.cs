namespace MapsterSample.Tests;

[CollectionDefinition(nameof(MapsterCollectionNonParallelized), DisableParallelization = true)]
public class MapsterCollectionNonParallelized
{
    // Disabling parallelization due to Mapster shared mappings on static GlobalSettings
}
