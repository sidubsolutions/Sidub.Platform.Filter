# Sidub Platform - Filter
This repository contains the filter module for the Sidub Platform. Filter 
concept abstractions allow definition of filters while language-specific 
parser implementations allow for the parsing of filter definitions.

## Main Components

### Filter Concepts
A filter is represented as an `IFilter` with `FilterPredicate`, 
`FilterPipeline` and `FilterLogicalOperator` as the main concrete concepts. 
The `FilterPredicate` is the basic building block of a filter and represents a
single condition. The `FilterPipeline` is a collection of `IFilter` instances 
and the `FilterLogicalOperator` is used to combine `IFilter` instances within 
the a pipeline.

Filters may be built using the `FilterBuilder` class which provides a fluent 
API for building filters.

### Filter Parsing
A filter representation can be parsed to its string representation using the 
appropriate parser. Various language-specific parsers exist to parse filters 
to appropriate string representations. 

## Usage
While filters can be manually composed using the respective `IFilter` 
implementations, the `FilterBuilder` class provides a fluent API for building 
filters. Once prepared, the filter can be parsed to its string representation 
using the appropriate parser service.

### Building a Filter
To build a simple filter, you can use the `FilterBuilder` as follows:

```csharp
var builder = new FilterBuilder();
var filter = builder
	.Add("FieldA", ComparisonOperator.Equals, "FieldATestValue")
	.Build();
```

For filters with multiple conditions, you can use the `FilterPipeline` and 
`FilterLogicalOperator` as follows:

```csharp
var builder = new FilterBuilder();

var filter = builder
	.Add("FieldA", ComparisonOperator.Equals, "FieldATestValue")
	.Add(LogicalOperator.And)
	.Add("FieldB", ComparisonOperator.NotEquals, "FieldBTestValue");
```

Pipelines can be nested to create more advanced filters:

```csharp
var builder = new FilterBuilder();

var filter = builder
	.Add("FieldA", ComparisonOperator.Equals, "FieldATestValue")
	.Add(LogicalOperator.And)
	.Add(inner1 => inner1
		.Add("FieldB", ComparisonOperator.Equals, "FieldBTestValue01")
		.Add(LogicalOperator.Or)
		.Add("FieldB", ComparisonOperator.Equals, "FieldBTestValue02"));
```

### Parsing a Filter
To parse a filter to its string representation, you can use the appropriate 
parser service. Concrete implementations of the 
`IFilterService<TConfiguration>` interface are provided for various languages.

```csharp
private readonly ODataFilterService _filterService;

public ProductService(ODataFilterService filterService)
{
	_filterService = filterService;
}

public string BuildProductQuery(ProductFilter productFilter)
{
	return _filterService.Parse(filterFilter);
}
```

## Considerations
The library currently only supports implementations in which the filter is 
parsed to a string representation. Future implemenations will evolve this 
concept to support more advanced use-cases, such as applying the filter 
against an in-memory collection or against other query constructs.

## License
This project is dual-licensed under the AGPL v3 or a proprietary license. For
details, see [https://sidub.ca/licensing](https://sidub.ca/licensing) or the 
LICENSE.txt file.