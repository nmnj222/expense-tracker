using System.Diagnostics.Tracing;

namespace ExpenseTracker.Common.Results;

public sealed record Error(string Code, string Description, ErrorType Type);
