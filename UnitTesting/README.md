# UnitTesting - NUnit basics

A small, self-contained project for learning [NUnit](https://docs.nunit.org/),
the most common unit testing framework for .NET. It's a separate project
(`UnitTesting.csproj`) from the rest of this repo, since it needs its own
NuGet packages (NUnit, the NUnit test adapter, and the .NET test SDK).

## Structure

```
UnitTesting/
├── Exercise1_Calculator/
│   ├── Calculator.cs         <- the class being tested
│   └── CalculatorTests.cs    <- its tests
└── Exercise2_StringHelper/
    ├── StringHelper.cs       <- the class being tested
    └── StringHelperTests.cs  <- its tests
```

Each exercise pairs a plain "production" class with a `*Tests.cs` file.
The production classes have nothing NUnit-specific about them - only the
test files use NUnit attributes and assertions.

## Running the tests

From this folder (or anywhere in the repo, by pointing `dotnet test` at the
project file):

```bash
cd UnitTesting
dotnet test
```

You should see the worked-example tests pass, and four tests reported as
skipped - those are the exercises left for you to complete (see below).

## The NUnit basics used here

- `[TestFixture]` - marks a class as containing tests.
- `[Test]` - marks a single test method.
- `[SetUp]` - runs before every `[Test]` in the class; used here to get a
  fresh instance of the class under test for each test, so tests can't
  accidentally affect each other.
- `[TestCase(...)]` - runs the same test method once per set of arguments,
  useful for checking several inputs without duplicating code.
- `Assert.That(actual, Is.EqualTo(expected))` - NUnit's "constraint model"
  assertion syntax. Other constraints you'll run into often: `Is.True`,
  `Is.False`, `Is.Null`, `Is.GreaterThan(x)`, `Contains.Item(x)`.
- `Assert.Throws<TException>(() => ...)` - checks that the code inside the
  lambda throws a specific exception type.

A typical test follows the **Arrange / Act / Assert** pattern: set up
whatever the test needs, call the method being tested, then assert on the
result.

## Your turn

Four tests are stubbed out with `Assert.Ignore("TODO: ...")` - two in each
exercise. Open the test files, read the comment above each stub, and
replace `Assert.Ignore(...)` with a real test body (Arrange/Act/Assert,
same as the worked examples above them). Run `dotnet test` again afterwards
to confirm they pass.
